using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.IO;

namespace NSR.Common
{
    public class WatermarkHelper : IDisposable
    {
        #region Private Fields
        private Image _image;
        private string _originalImageFullName;
        private Image _watermark;
        private float _opacity = 1.0f;
        private WatermarkPosition _position = WatermarkPosition.Absolute;
        private int _positionX = 0;
        private int _positionY = 0;
        private Color _transparentColor = Color.Empty;
        private RotateFlipType _rotateFlip = RotateFlipType.RotateNoneFlipNone;
        private int _marginLeft = 0;
        private int _marginTop = 0;
        private int _marginRight = 0;
        private int _marginBottom = 0;
        private Font _font = new Font(FontFamily.GenericSansSerif, 10);
        private Color _fontColor = Color.Black;
        private float _scaleRatio = 1.0f;
        private int _watermarkBaseWidth = 0;
        private int _watermarkBaseHeight = 0;
        private float _watermarkBaseScaleRatio = 0f;
        private int _watermarkBaseMargin = 0;

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the image with drawn watermarks
        /// </summary>        
        public Image Image { get { return _image; } }

        public string OriginalImageFullName { get { return _originalImageFullName; } set { _originalImageFullName = value; } }

        /// <summary>
        /// Watermark position relative to the image sizes. 
        /// If Absolute is chosen, watermark positioning is being done via PositionX and PositionY 
        /// properties (0 by default)\n
        /// </summary>        
        public WatermarkPosition Position { get { return _position; } set { _position = value; } }

        /// <summary>
        /// Watermark X coordinate (works if Position property is set to WatermarkPosition.Absolute)
        /// </summary>
        public int PositionX { get { return _positionX; } set { _positionX = value; } }

        /// <summary>
        /// Watermark Y coordinate (works if Position property is set to WatermarkPosition.Absolute)
        /// </summary>
        public int PositionY { get { return _positionY; } set { _positionY = value; } }

        /// <summary>
        /// Watermark opacity. Can have values from 0.0 to 1.0
        /// </summary>
        public float Opacity { get { return _opacity; } set { _opacity = value; } }

        /// <summary>
        /// Transparent color
        /// </summary>
        public Color TransparentColor { get { return _transparentColor; } set { _transparentColor = value; } }

        /// <summary>
        /// Watermark rotation and flipping
        /// </summary>
        public RotateFlipType RotateFlip { get { return _rotateFlip; } set { _rotateFlip = value; } }

        /// <summary>
        /// Spacing between watermark and image edges
        /// </summary>
        public int MarginLeft { get { return _marginLeft; } set { _marginLeft = value; } }
        public int MarginTop { get { return _marginTop; } set { _marginTop = value; } }
        public int MarginRight { get { return _marginRight; } set { _marginRight = value; } }
        public int MarginBottom { get { return _marginBottom; } set { _marginBottom = value; } }

        /// <summary>
        /// Watermark scaling ratio. Must be greater than 0. Only for image watermarks. Will be calculated automatically if WatermarkBaseScale and base width/height are provided.
        /// </summary>
        public float ScaleRatio { get { return _scaleRatio; } set { _scaleRatio = value; } }

        /// <summary>
        /// Font of the text to add
        /// </summary>
        public Font Font { get { return _font; } set { _font = value; } }

        /// <summary>
        /// Color of the text to add
        /// </summary>
        public Color FontColor { get { return _fontColor; } set { _fontColor = value; } }

        public int WatermarkBaseWidth { get { return _watermarkBaseWidth; } set { _watermarkBaseWidth = value; } }
        public int WatermarkBaseHeight { get { return _watermarkBaseHeight; } set { _watermarkBaseHeight = value; } }
        public int WatermarkBaseMargin { get { return _watermarkBaseMargin; } set { _watermarkBaseMargin = value; } }
        public float WatermarkBaseScaleRatio { get { return _watermarkBaseScaleRatio; } set { _watermarkBaseScaleRatio = value; } }

        #endregion

        #region Public Methods      

        /// <summary>
        /// Create separate image with watermark or replace the existing file with watermark image.
        /// </summary>
        /// <param name="watermarkImageFullName">watermark image with full path</param>
        /// <param name="errorMsg">errorMsg: will contain error in case of failure</param>
        /// <param name="replaceSourceFile">send true to replace the original file</param>
        /// <param name="targetImageFullName">send target image with full path if want to create separate image.</param>
        /// <returns>True for success else false.</returns>
        public bool DrawImage(string watermarkImageFullName, out string errorMsg, bool replaceSourceFile = false, string targetImageFullName = "")
        {
            errorMsg = string.Empty;

            try
            {
                //check if Original Image Full name is provided or not.
                if (string.IsNullOrEmpty(_originalImageFullName))
                    errorMsg = "ERROR: OriginalImageFullName property is empty.";

                //check if Watermark Image Full name is provided or not.
                if (string.IsNullOrEmpty(watermarkImageFullName))
                    errorMsg = "ERROR: watermarkImageFullName is empty.";

                //check if Opacity value is valid
                if (_opacity < 0 || _opacity > 1)
                    errorMsg = "ERROR: Please mention Opacity between 0.1 to 1.0";

                //check scaleration value is valid.
                if (_scaleRatio <= 0 && _watermarkBaseScaleRatio <= 0)
                    errorMsg = "ERROR: Please mention ScaleRatio greater than 0.";

                //check if target image full name is provided or not
                if (!replaceSourceFile && string.IsNullOrEmpty(targetImageFullName))
                    errorMsg = "ERROR: targetImageFullName is empty.";

                if (!File.Exists(_originalImageFullName))
                    errorMsg = "ERROR: Original Image does not exists.";

                if (!File.Exists(watermarkImageFullName))
                    errorMsg = "ERROR: Watermark Image does not exists.";

                if (!string.IsNullOrEmpty(errorMsg))
                    return false;

                string orgFileExtension = Path.GetExtension(_originalImageFullName).ToLower();
                string watermarkFileExtension = Path.GetExtension(watermarkImageFullName).ToLower();

                if ((
                    orgFileExtension != ".gif" &&
                    orgFileExtension != ".jpg" &&
                    orgFileExtension != ".jpeg" &&
                    orgFileExtension != ".png") || (
                    watermarkFileExtension != ".gif" &&
                    watermarkFileExtension != ".jpg" &&
                    watermarkFileExtension != ".jpeg" &&
                    watermarkFileExtension != ".png")
                    )
                {
                    errorMsg = "ERROR: file type of original image or watermark image is not supported.";
                    return false;
                }

                string tempTargetFile = string.Empty;

                using (Image mainImage = Image.FromFile(_originalImageFullName))
                {
                    using (Image watermark = Image.FromFile(watermarkImageFullName))
                    {
                        _image = mainImage;

                        // Creates a new watermark with margins (if margins are not specified returns the original watermark)
                        _watermark = GetWatermarkImage(watermark, _image.Height, _image.Width);

                        // Rotates and/or flips the watermark
                        _watermark.RotateFlip(_rotateFlip);

                        // Calculate watermark position
                        Point waterPos = GetWatermarkPosition();

                        // Watermark destination rectangle
                        Rectangle destRect = new Rectangle(waterPos.X, waterPos.Y, _watermark.Width, _watermark.Height);

                        // This colorMatrix is generated to set the opacity of the watermark image. 
                        //3rd row 3rd column has the "m_opacity" variable which has the opacity value.
                        ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                        {
                            new float[] { 1, 0f, 0f, 0f, 0f},
                            new float[] { 0f, 1, 0f, 0f, 0f},
                            new float[] { 0f, 0f, 1, 0f, 0f},
                            new float[] { 0f, 0f, 0f, _opacity, 0f},
                            new float[] { 0f, 0f, 0f, 0f, 1}
                        });

                        ImageAttributes attributes = new ImageAttributes();

                        // Set the opacity of the watermark
                        attributes.SetColorMatrix(colorMatrix);

                        // Set the transparent color 
                        if (_transparentColor != Color.Empty)
                        {
                            attributes.SetColorKey(_transparentColor, _transparentColor);
                        }

                        if (IsIndexedPixelFormat(_image.PixelFormat))
                        {
                            //Create tempBitmap
                            Bitmap tempBitmap = new Bitmap(_image.Width, _image.Height);

                            // Draw the watermark
                            using (Graphics gr = Graphics.FromImage(tempBitmap))
                            {
                                gr.DrawImage(_image, 0, 0);
                                gr.DrawImage(_watermark, destRect, 0, 0, _watermark.Width, _watermark.Height, GraphicsUnit.Pixel, attributes);
                            }

                            using (Image imgPhotoTemp = tempBitmap)
                            {
                                // Save the file to the server folder            
                                if (replaceSourceFile)
                                {
                                    ImageFormat sourceImageFormat;
                                    switch (orgFileExtension)
                                    {
                                        case ".gif":
                                            sourceImageFormat = ImageFormat.Gif;
                                            break;
                                        case ".jpg":
                                        case ".jpeg":
                                            sourceImageFormat = ImageFormat.Jpeg;
                                            break;
                                        case ".png":
                                            sourceImageFormat = ImageFormat.Png;
                                            break;
                                        default:
                                            sourceImageFormat = ImageFormat.Jpeg;
                                            break;
                                    }

                                    tempTargetFile = _originalImageFullName.Replace(Path.GetExtension(_originalImageFullName), "") + "_Temp" + orgFileExtension;
                                    imgPhotoTemp.Save(tempTargetFile, sourceImageFormat);
                                }
                                else
                                {
                                    imgPhotoTemp.Save(targetImageFullName, ImageFormat.Jpeg);
                                }
                            }
                        }
                        else
                        {
                            // Draw the watermark
                            using (Graphics gr = Graphics.FromImage(_image))
                            {
                                gr.DrawImage(_watermark, destRect, 0, 0, _watermark.Width, _watermark.Height, GraphicsUnit.Pixel, attributes);
                            }

                            using (Image imgPhotoTemp = _image)
                            {
                                // Save the file to the server folder            
                                if (replaceSourceFile)
                                {
                                    ImageFormat sourceImageFormat;
                                    switch (orgFileExtension)
                                    {
                                        case ".gif":
                                            sourceImageFormat = ImageFormat.Gif;
                                            break;
                                        case ".jpg":
                                        case ".jpeg":
                                            sourceImageFormat = ImageFormat.Jpeg;
                                            break;
                                        case ".png":
                                            sourceImageFormat = ImageFormat.Png;
                                            break;
                                        default:
                                            sourceImageFormat = ImageFormat.Jpeg;
                                            break;
                                    }

                                    tempTargetFile = _originalImageFullName.Replace(Path.GetExtension(_originalImageFullName), "") + "_Temp" + orgFileExtension;
                                    imgPhotoTemp.Save(tempTargetFile, sourceImageFormat);
                                }
                                else
                                {
                                    imgPhotoTemp.Save(targetImageFullName, ImageFormat.Jpeg);
                                }
                            }
                        }
                    }
                }

                if (replaceSourceFile)
                {
                    File.Delete(_originalImageFullName);

                    while (File.Exists(_originalImageFullName))
                    {
                        Thread.Sleep(300);
                    }

                    File.Move(tempTargetFile, _originalImageFullName);

                }
                return true;
            }
            catch (Exception ex)
            {
                errorMsg = "ERROR: Error While generating watermark image: Exception: " + ex.Message + " inner exception: " + ex.InnerException?.Message + " stacktrace: " + ex.StackTrace;
                return false;
            }
        }

        /// <summary>
        /// Create separate image with watermark or replace the existing file with watermark image.
        /// </summary>
        /// <param name="watermark">watermark image</param>                
        /// <param name="errorMsg">errorMsg: will contain error in case of failure</param>
        /// <param name="replaceSourceFile">send true to replace the original file</param>
        /// <param name="targetImageFullName">send target image with full path if want to create separate image.</param>
        /// <returns>True for success else false.</returns>
        public bool DrawImage(Image watermark, out string errorMsg, bool replaceSourceFile = false, string targetImageFullName = "")
        {
            errorMsg = string.Empty;

            try
            {
                //check if Original Image Full name is provided or not.
                if (string.IsNullOrEmpty(_originalImageFullName))
                    errorMsg = "ERROR: OriginalImageFullName property is empty.";

                //check if Watermark Image is provided or not.
                if (watermark == null)
                    errorMsg = "ERROR: watermark image is not available.";

                //check if Opacity value is valid
                if (_opacity < 0 || _opacity > 1)
                    errorMsg = "ERROR: Please mention Opacity between 0.1 to 1.0";

                //check scaleration value is valid.
                if (_scaleRatio <= 0)
                    errorMsg = "ERROR: Please mention ScaleRatio greater than 0.";

                //check if target image full name is provided or not
                if (!replaceSourceFile && string.IsNullOrEmpty(targetImageFullName))
                    errorMsg = "ERROR: targetImageFullName is empty.";

                if (!File.Exists(_originalImageFullName))
                    errorMsg = "ERROR: Original Image does not exists.";

                if (!string.IsNullOrEmpty(errorMsg))
                    return false;

                string orgFileExtension = Path.GetExtension(_originalImageFullName).ToLower();

                if (orgFileExtension != ".gif" &&
                    orgFileExtension != ".jpg" &&
                    orgFileExtension != ".jpeg" &&
                    orgFileExtension != ".png")
                {
                    errorMsg = "ERROR: file type of original image or watermark image is not supported.";
                    return false;
                }

                string tempTargetFile = string.Empty;

                using (Image mainImage = Image.FromFile(_originalImageFullName))
                {
                    using (watermark)
                    {
                        _image = mainImage;

                        // Creates a new watermark with margins (if margins are not specified returns the original watermark)
                        _watermark = GetWatermarkImage(watermark, _image.Height, _image.Width);

                        // Rotates and/or flips the watermark
                        _watermark.RotateFlip(_rotateFlip);

                        // Calculate watermark position
                        Point waterPos = GetWatermarkPosition();

                        // Watermark destination rectangle
                        Rectangle destRect = new Rectangle(waterPos.X, waterPos.Y, _watermark.Width, _watermark.Height);

                        // This colorMatrix is generated to set the opacity of the watermark image. 
                        //3rd row 3rd column has the "m_opacity" variable which has the opacity value.
                        ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                        {
                            new float[] { 1, 0f, 0f, 0f, 0f},
                            new float[] { 0f, 1, 0f, 0f, 0f},
                            new float[] { 0f, 0f, 1, 0f, 0f},
                            new float[] { 0f, 0f, 0f, _opacity, 0f},
                            new float[] { 0f, 0f, 0f, 0f, 1}
                        });

                        ImageAttributes attributes = new ImageAttributes();

                        // Set the opacity of the watermark
                        attributes.SetColorMatrix(colorMatrix);

                        // Set the transparent color 
                        if (_transparentColor != Color.Empty)
                        {
                            attributes.SetColorKey(_transparentColor, _transparentColor);
                        }

                        if (IsIndexedPixelFormat(_image.PixelFormat))
                        {
                            //Create tempBitmap
                            Bitmap tempBitmap = new Bitmap(_image.Width, _image.Height);

                            // Draw the watermark
                            using (Graphics gr = Graphics.FromImage(tempBitmap))
                            {
                                gr.DrawImage(_image, 0, 0);
                                gr.DrawImage(_watermark, destRect, 0, 0, _watermark.Width, _watermark.Height, GraphicsUnit.Pixel, attributes);
                            }

                            using (Image imgPhotoTemp = tempBitmap)
                            {
                                // Save the file to the server folder            
                                if (replaceSourceFile)
                                {
                                    ImageFormat sourceImageFormat;
                                    switch (orgFileExtension)
                                    {
                                        case ".gif":
                                            sourceImageFormat = ImageFormat.Gif;
                                            break;
                                        case ".jpg":
                                        case ".jpeg":
                                            sourceImageFormat = ImageFormat.Jpeg;
                                            break;
                                        case ".png":
                                            sourceImageFormat = ImageFormat.Png;
                                            break;
                                        default:
                                            sourceImageFormat = ImageFormat.Jpeg;
                                            break;
                                    }

                                    tempTargetFile = _originalImageFullName.Replace(Path.GetExtension(_originalImageFullName), "") + "_Temp" + orgFileExtension;
                                    imgPhotoTemp.Save(tempTargetFile, sourceImageFormat);
                                }
                                else
                                {
                                    imgPhotoTemp.Save(targetImageFullName, ImageFormat.Jpeg);
                                }
                            }
                        }
                        else
                        {
                            // Draw the watermark
                            using (Graphics gr = Graphics.FromImage(_image))
                            {
                                gr.DrawImage(_watermark, destRect, 0, 0, _watermark.Width, _watermark.Height, GraphicsUnit.Pixel, attributes);
                            }

                            using (Image imgPhotoTemp = _image)
                            {
                                // Save the file to the server folder            
                                if (replaceSourceFile)
                                {
                                    ImageFormat sourceImageFormat;
                                    switch (orgFileExtension)
                                    {
                                        case ".gif":
                                            sourceImageFormat = ImageFormat.Gif;
                                            break;
                                        case ".jpg":
                                        case ".jpeg":
                                            sourceImageFormat = ImageFormat.Jpeg;
                                            break;
                                        case ".png":
                                            sourceImageFormat = ImageFormat.Png;
                                            break;
                                        default:
                                            sourceImageFormat = ImageFormat.Jpeg;
                                            break;
                                    }

                                    tempTargetFile = _originalImageFullName.Replace(Path.GetExtension(_originalImageFullName), "") + "_Temp" + orgFileExtension;
                                    imgPhotoTemp.Save(tempTargetFile, sourceImageFormat);
                                }
                                else
                                {
                                    imgPhotoTemp.Save(targetImageFullName, ImageFormat.Jpeg);
                                }
                            }
                        }
                    }
                }

                if (replaceSourceFile)
                {
                    File.Delete(_originalImageFullName);

                    while (File.Exists(_originalImageFullName))
                    {
                        Thread.Sleep(300);
                    }

                    File.Move(tempTargetFile, _originalImageFullName);

                }
                return true;
            }
            catch (Exception ex)
            {
                errorMsg = "ERROR: Error While generating watermark image: Exception: " + ex.Message + " inner exception: " + ex.InnerException?.Message + " stacktrace: " + ex.StackTrace;
                return false;
            }
        }

        /// <summary>
        /// Create separate image with watermark text or replace the existing file with watermark text.
        /// </summary>
        /// <param name="text">Watermark Text</param>
        /// <param name="errorMsg">errorMsg: will contain error in case of failure</param>
        /// <param name="replaceSourceFile">send true to replace the original file</param>
        /// <param name="targetImageFullName">send target image with full path if want to create separate image.</param>
        /// <returns>True for success else false.</returns>
        public void DrawText(string text, out string errorMessage, bool replaceSourceFile = false, string targetImageFullName = "")
        {
            // Convert text to image, so we can use opacity etc.
            Image textWatermark = GetTextWatermark(text);

            DrawImage(textWatermark, out errorMessage, replaceSourceFile, targetImageFullName);
        }

        public void Dispose()
        {
            if (_image != null)
                _image.Dispose();

            if (_watermark != null)
                _watermark.Dispose();

            if (_font != null)
                _font.Dispose();
        }

        #endregion

        #region Private Methods      
        private Image GetTextWatermark(string text)
        {

            Brush brush = new SolidBrush(_fontColor);
            SizeF size;

            if (IsIndexedPixelFormat(_image.PixelFormat))
            {
                //Create tempBitmap
                Bitmap tempBitmap = new Bitmap(_image.Width, _image.Height);

                // Figure out the size of the box to hold the watermarked text
                using (Graphics g = Graphics.FromImage(tempBitmap))
                {
                    g.DrawImage(_image, 0, 0);
                    size = g.MeasureString(text, _font);
                }
            }
            else
            {
                // Figure out the size of the box to hold the watermarked text
                using (Graphics g = Graphics.FromImage(_image))
                {
                    size = g.MeasureString(text, _font);
                }
            }            

            // Create a new bitmap for the text, and, actually, draw the text
            Bitmap bitmap = new Bitmap((int)size.Width, (int)size.Height);
            bitmap.SetResolution(_image.HorizontalResolution, _image.VerticalResolution);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawString(text, _font, brush, 0, 0);
            }

            return bitmap;
        }

        private Image GetWatermarkImage(Image watermark, int orgImageHeight = 0, int orgImageWidth = 0)
        {
            //Check if Base properties are provided (Base Width, Base Height, Base Margin, Base Scale) and calculate Scaleration and Margins.
            if (_watermarkBaseWidth > 0 && _watermarkBaseHeight > 0 && _watermarkBaseMargin > 0 && _watermarkBaseScaleRatio > 0 && orgImageHeight > 0 && orgImageWidth > 0)
            {
                decimal heightRatio = Math.Round((decimal)_watermarkBaseHeight / orgImageHeight, 2);
                decimal widthRatio = Math.Round((decimal)_watermarkBaseWidth / orgImageWidth, 2);
                decimal scaleHeight = Math.Round((decimal)_watermarkBaseScaleRatio / (heightRatio > 0 ? heightRatio : 1), 2);
                decimal scaleWidth = Math.Round((decimal)_watermarkBaseScaleRatio / (widthRatio > 0 ? widthRatio : 1), 2);
                _scaleRatio = (float)Math.Min(scaleHeight, scaleWidth);
                _marginLeft = _marginTop = _marginRight = _marginBottom = (int)Math.Ceiling(_watermarkBaseMargin * _scaleRatio);
            }

            // If there are no margins specified and scale ration is 1, no need to create a new bitmap
            if (_marginLeft == 0 && _marginTop == 0 && _marginRight == 0 && _marginBottom == 0 && _scaleRatio == 1.0f)
                return watermark;

            // Create a new bitmap with new sizes (size + margins) and draw the watermark
            int newWidth = Convert.ToInt32(watermark.Width * _scaleRatio);
            int newHeight = Convert.ToInt32(watermark.Height * _scaleRatio);

            Rectangle sourceRect = new Rectangle(_marginLeft, _marginTop, newWidth, newHeight);
            Rectangle destRect = new Rectangle(0, 0, watermark.Width, watermark.Height);

            Bitmap bitmap = new Bitmap(newWidth + _marginLeft + _marginRight, newHeight + _marginTop + _marginBottom);
            bitmap.SetResolution(watermark.HorizontalResolution, watermark.VerticalResolution);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawImage(watermark, sourceRect, destRect, GraphicsUnit.Pixel);
            }

            return bitmap;
        }

        private Point GetWatermarkPosition()
        {
            int x = 0;
            int y = 0;

            switch (_position)
            {
                case WatermarkPosition.Absolute:
                    x = _positionX; y = _positionY;
                    break;
                case WatermarkPosition.TopLeft:
                    x = 0; y = 0;
                    break;
                case WatermarkPosition.TopRight:
                    x = _image.Width - _watermark.Width; y = 0;
                    break;
                case WatermarkPosition.TopMiddle:
                    x = (_image.Width - _watermark.Width) / 2; y = 0;
                    break;
                case WatermarkPosition.BottomLeft:
                    x = 0; y = _image.Height - _watermark.Height;
                    break;
                case WatermarkPosition.BottomRight:
                    x = _image.Width - _watermark.Width; y = _image.Height - _watermark.Height;
                    break;
                case WatermarkPosition.BottomMiddle:
                    x = (_image.Width - _watermark.Width) / 2; y = _image.Height - _watermark.Height;
                    break;
                case WatermarkPosition.MiddleLeft:
                    x = 0; y = (_image.Height - _watermark.Height) / 2;
                    break;
                case WatermarkPosition.MiddleRight:
                    x = _image.Width - _watermark.Width; y = (_image.Height - _watermark.Height) / 2;
                    break;
                case WatermarkPosition.Center:
                    x = (_image.Width - _watermark.Width) / 2; y = (_image.Height - _watermark.Height) / 2;
                    break;
                default:
                    break;
            }

            return new Point(x, y);
        }

        /// <summary>
        /// Check if Image Pixel Format is Indexed or not
        /// </summary>
        /// <param name="imagePixelFormat">PixelFormat of Image object</param>
        /// <returns>True if indexed pixel format else false</returns>
        private bool IsIndexedPixelFormat(PixelFormat imagePixelFormat)
        {
            if (imagePixelFormat == PixelFormat.Format1bppIndexed || imagePixelFormat == PixelFormat.Format4bppIndexed ||
                imagePixelFormat == PixelFormat.Format8bppIndexed || imagePixelFormat == PixelFormat.Format16bppArgb1555 ||
                imagePixelFormat == PixelFormat.Format16bppGrayScale || imagePixelFormat == PixelFormat.DontCare ||
                imagePixelFormat == PixelFormat.Undefined)
                return true;
            else
                return false;
        }
        #endregion


    }
}
