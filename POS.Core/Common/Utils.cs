// ---------------------------------------------------------
// <copyright file="Utils.cs" company="">
// All right reserved.
// </copyright>
// <author>AhmedMustafa</author>
// ------------------------------------------------------------ 

namespace POS.Core
{
    using Microsoft.VisualBasic;
    using POS.Core.Domain;

    #region Namespaces
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Configuration;
    using System.Data;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Routing;
    using System.Web.UI;
    using System.Web.UI.WebControls;


    #endregion
    /// <summary>
    /// Utils class which contains common methods.
    /// </summary>
    public static class Utils
    {
        #region Global Messages
        // TODO : Code commenting and formatting. 

        // global messages
        public const string NORIGHTSMESSAGE_ACTION = "You do not have sufficient rights to do that action.";
        public const string NORIGHTSMESSAGE_ACTION2 = "You do not have access to perform that action. Please contact Administrator.";
        public const string NORIGHTSMESSAGE_PAGE = "You do not have sufficient rights to access that page.";
        public const string HTML_TAG_PATTERN = "<.*?>";
        public const string UNICODE_PATTERN = @"[^\u0000-\u007F]";
        public static IEnumerable<string> ValidDocumentImagesList = new List<string> { ".jpg", ".png", ".jpeg", ".bmp", ".doc", ".docx", ".pdf", ".xls", ".xlsx", "" };

        #endregion

        #region Global Methods

        public static Dictionary<string, string> GetConfiguration()
        {
            Dictionary<string, string> configurationMap = new Dictionary<string, string>();
            configurationMap.Add("mode", ConfigKey("PayPalExpMode"));
            return configurationMap;
        }

        public static string StripHTML(string inputString)
        {
            string safeString = Regex.Replace(inputString, UNICODE_PATTERN, string.Empty);
            return Regex.Replace(safeString, HTML_TAG_PATTERN, string.Empty);
        }

        public static string StripHTMLHTAGS(string inputString)
        {
            string cleanString = Regex.Replace(inputString, @"(\</?H1(.*?)/?\>)", string.Empty, RegexOptions.IgnoreCase);
            return Regex.Replace(cleanString, "<P>", "<div style=\"height: 5px;\">&nbsp;</div><P>", RegexOptions.IgnoreCase);
        }

        public static bool ContainsAny(this string stringToCheck, params string[] parameters)
        {
            return parameters.Any(parameter => stringToCheck.Contains(parameter));
        }

        public static int GetDescriptionLengthLimit(int defaultLen = 2000)
        {
            int maxLen = ConfigKey("maxlengthdesc").ToSafeInt();
            if (maxLen <= 0)
                maxLen = defaultLen;

            return maxLen;
        }

        public static string GetCurrentPageName()
        {
            string sPath = HttpContext.Current.Request.Url.AbsolutePath;
            System.IO.FileInfo oInfo = new System.IO.FileInfo(sPath);
            string sRet = oInfo.Name;
            return sRet;
        }

        public static void PopulateModel(object sourceObj, object targetObj)
        {
            var sourceProperties = TypeDescriptor.GetProperties(sourceObj).Cast<PropertyDescriptor>()
                .Where(p => p.Attributes.OfType<ColumnAttribute>().Count() > 0);

            var targetProperties = TypeDescriptor.GetProperties(targetObj).Cast<PropertyDescriptor>()
                .Where(p => p.Attributes.OfType<ColumnAttribute>().Count() > 0);


            for (int i = 0; i < sourceProperties.Count(); i++)
            {
                targetProperties.ElementAt(i).SetValue(targetObj,
                    sourceProperties.ElementAt(i).GetValue(sourceObj));
            }
        }

        public static void PopulateModelWithNoNull(object sourceObj, object targetObj)
        {
            var sourceProperties = TypeDescriptor.GetProperties(sourceObj).Cast<PropertyDescriptor>()
                .Where(p => p.Attributes.OfType<ColumnAttribute>().Count() > 0);

            var targetProperties = TypeDescriptor.GetProperties(targetObj).Cast<PropertyDescriptor>()
                .Where(p => p.Attributes.OfType<ColumnAttribute>().Count() > 0);


            for (int i = 0; i < sourceProperties.Count(); i++)
            {
                if (sourceProperties.ElementAt(i).GetValue(sourceObj) != null)
                {
                    targetProperties.ElementAt(i).SetValue(targetObj,
                        sourceProperties.ElementAt(i).GetValue(sourceObj));
                }
            }
        }

        public static string GetHijriFromGregorian(DateTime greDate)
        {
            CultureInfo arSA = CultureInfo.CreateSpecificCulture("ar-SA");
            return greDate.ToString("dd/MM/yyyy", arSA);
        }

        public static string GetHijriFromGregorian(string greDate)
        {
            //CultureInfo arSA = CultureInfo.CreateSpecificCulture("ar-SA");
            //return greDate.ToString("dd/MM/yyyy", arSA);

            CultureInfo arCul = new CultureInfo("ar-SA");
            CultureInfo enCul = new CultureInfo("en-US");
            DateTime tempDate = DateTime.ParseExact(greDate, allFormats, enCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
            return tempDate.ToString("dd/MM/yyyy", arCul.DateTimeFormat);
        }

        public static string GetGregorianFromHijri(DateTime hijriDate)
        {
            CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");
            return hijriDate.ToString("dd/MM/yyyy", enUS);
        }

        private static string[] allFormats = { "yyyy/MM/dd", "yyyy/M/d", "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy", "yyyy-MM-dd", "yyyy-M-d", "dd-MM-yyyy", "d-M-yyyy", "dd-M-yyyy", "d-MM-yyyy", "yyyy MM dd", "yyyy M d", "dd MM yyyy", "d M yyyy", "dd M yyyy", "d MM yyyy" };
        public static string GetGregorianFromHijri(string hijri)
        {
            CultureInfo arCul = new CultureInfo("ar-SA");
            CultureInfo enCul = new CultureInfo("en-US");
            DateTime tempDate = DateTime.ParseExact(hijri, allFormats, arCul.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces);
            return tempDate.ToString("dd/MM/yyyy", enCul.DateTimeFormat);
        }

        public static DateTime ConvertDDMMYYToDate(this string dateString)
        {
            DateTime dt;
            if (DateTime.TryParseExact(dateString,
                                        "d/M/yyyy",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                out dt))
            {
                //valid date
            }
            else
            {
                //invalid date
            }

            return dt;
        }

        public static DateTime ConvertDDMMYYHHMMToDate(this string dateString, string timeString)
        {
            DateTime dt;
            if (DateTime.TryParseExact(string.Format("{0} {1}", dateString, timeString),
                                        "d/M/yyyy H:mm",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None,
                out dt))
            {
                //valid date
            }
            else
            {
                //invalid date
            }

            return dt;
        }

        public static void ClearCache(System.Web.HttpContext currentContext, string cacheKey)
        {
            try
            {
                if (!string.IsNullOrEmpty(cacheKey))
                {
                    List<string> itemsToRemove = new List<string>();

                    foreach (DictionaryEntry entry in currentContext.Cache)
                    {
                        if (entry.Key.ToSafeString().StartsWith(cacheKey))
                        {
                            currentContext.Cache.Remove(entry.Key.ToSafeString());
                        }
                    }
                }
                else
                {
                    foreach (DictionaryEntry entry in currentContext.Cache)
                    {
                        currentContext.Cache.Remove(entry.Key.ToSafeString());
                    }
                }

            }
            catch { }
        }

        public static string ToSafePageName(this string str)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                str = str.Replace(c.ToString(), string.Empty);
            }

            // Remove Some more extra characters.
            str = str.ToLower().Trim().Replace("&", " ").Replace("/", " ").Replace("\\", " ").Replace("-", " ");

            // Replace multiple spaces to single space in string key.
            str = Regex.Replace(str, @"\s+", " ");

            // Returns string after replacing space with -
            return str.Replace(" ", "-").Replace(".", "").Replace("'", "").Replace("+", "");
        }

        public static string ToSafePageNameWithURL(this string str)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
            {
                str = str.Replace(c.ToString(), string.Empty);
            }

            // Remove Some more extra characters.
            str = str.ToLower().Trim().Replace("&", " ").Replace("/", " ").Replace("\\", " ").Replace("-", " ");

            // Replace multiple spaces to single space in string key.
            str = Regex.Replace(str, @"\s+", " ");

            // Returns string after replacing space with -
            return Regex.Replace(str, "[^0-9a-zA-Z~_ -]+", string.Empty).Replace(" ", "-");
        }

        public static string Truncate(object pstrData, int intCount)
        {
            string result = string.Empty;

            try
            {
                if (!(pstrData == null))
                {
                    if (pstrData.ToString().Length > intCount)
                    {
                        //Truncate String
                        result = pstrData.ToString().Substring(0, intCount) + "...";
                    }
                    else
                    {
                        result = pstrData.ToString(); //Data already smaller.
                    }
                }
            }
            catch
            {
                result = pstrData.ToString();
            }


            return result;
        }

        public static string GetVisitorIPAddress()
        {
            string result = string.Empty;
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToSafeString()))
            {
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (!string.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToSafeString()))
            {
                result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            return result;
        }

        public static void AlertMessage(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(typeof(string), "msgs", "alert('" + msg + "');", true);
        }

        public static void AlertMessageAndRedirect(Page page, string msg, string url)
        {
            page.ClientScript.RegisterStartupScript(typeof(string), "msgs", "alert('" + msg + "'); location.href='" + url + "';", true);
        }

        public static string ConfigKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToSafeString();
        }

        public static string GetApplicationPath()
        {
            return ((Page)HttpContext.Current.CurrentHandler).ResolveUrl("~");
        }

        public static void DeleteFile(string strPath)
        {
            FileInfo fi = new FileInfo(strPath);
            try
            {
                if (fi.Exists)
                    fi.Delete();
            }
            catch { }
        }

        public static string GetIconNameFromExtension_64(this string extension)
        {
            string result = "file.png";

            switch (extension.ToLower())
            {
                case ".jpg":
                case ".png":
                case ".bmp":
                case ".jpeg":
                case ".gif":
                    result = "image.png";
                    break;
                case ".doc":
                case ".docx":
                    result = "word.png";
                    break;
                case ".xls":
                case ".xlsx":
                    result = "excel.png";
                    break;
                case ".ppt":
                case ".pptx":
                case ".pps":
                case ".ppsx":
                    result = "powerpoint.png";
                    break;
                case ".pdf":
                    result = "pdf.png";
                    break;
                case ".tiff":
                case ".tif":
                    result = "tiff.png";
                    break;
            }

            return result;
        }

        /// <summary>
        /// Generate Excel reports
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lstData">Data list</param>
        /// <param name="Response"></param>
        /// <param name="listResources">Resources for Column header</param>
        /// <param name="fileName">Name of files</param>
        /// <updated by>Arjun</updated>
        /// <updated on>22 MAr 2017</updated>
        /// <discription>Add file name parameter</discription>
        public static void GenerateExcelReport<T>(IEnumerable<T> lstData, System.Web.HttpResponseBase Response, List<string> listResources, string fileName, bool isFormatted = false)
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "UTF-8";
            Response.ContentEncoding = System.Text.Encoding.UTF8;

            Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");
            Response.ContentType = "application/ms-excel";

            GridView objgrid = new GridView();
            objgrid.DataSource = lstData;
            objgrid.DataBind();

            for (int grIndex = 0; grIndex < objgrid.Rows.Count; grIndex++)
            {
                for (int gcIndex = 0; gcIndex < objgrid.Rows[grIndex].Cells.Count; gcIndex++)
                {
                    objgrid.Rows[grIndex].Cells[gcIndex].Attributes.Add("class", "text");
                    objgrid.HeaderRow.Cells[gcIndex].Text = listResources[gcIndex];
                }
            }

            if (isFormatted)
            {
                for (int i = 0; i < objgrid.Rows.Count; i++)
                {
                    System.Web.UI.WebControls.GridViewRow gvr = objgrid.Rows[i];
                    for (int j = 0; j < gvr.Cells.Count; j++)
                    {
                        //gvr.Cells[j].Style.Add("background-color", "#DBE5F1");
                        if (gvr.Cells[j].Text == "RequiredELMField")
                        {
                            gvr.Cells[j].Style.Add("background-color", "#F7E7E4");
                            gvr.Cells[j].Style.Add("color", "#B55351");
                            gvr.Cells[j].Text = "null";
                        }
                    }

                }
            }

            objgrid.RenderControl(htw);
            string style = @"<style> .text { mso-number-format:\@; } </style> ";
            Response.Write("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />");
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        /// <summary>
        /// To the data table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(
                                    prop.PropertyType) ?? prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(values);
            }
            return table;
        }

        /// <summary>
        /// Convert Datatable to Entity List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        /// <version>1.0    15th June 18     AhmedMustafa</version>
        public static List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            if (dt?.Rows != null)
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }

            return data;
        }

        /// <summary>
        /// Convert Datatable rows to Entity list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dr"></param>
        /// <returns></returns>
        /// <version>1.0    15th June 18     AhmedMustafa</version>
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public static Control FindControlRecursive(Control Root, string Id)
        {
            if (Root.ID == Id)
                return Root;
            foreach (Control Ctl in Root.Controls)
            {
                Control FoundCtl = FindControlRecursive(Ctl, Id);
                if (FoundCtl != null)
                    return FoundCtl;
            }
            return null;
        }

        public static string strQueryString(string str)
        {
            string result = "";
            if (HttpContext.Current.Request.QueryString[str] != null)
            {
                try
                {
                    result = HttpContext.Current.Request.QueryString[str].ToString();
                }
                catch { }
            }

            return result;
        }

        public static double ToDouble(string str)
        {
            double result = 0;
            if (str != null && Information.IsNumeric(str))
            {
                try
                {
                    result = Convert.ToDouble(str);
                }
                catch { }
            }
            return result;
        }

        public static long ToLong(string str)
        {
            long result = 0;
            if (str != null && Information.IsNumeric(str))
            {
                try
                {
                    result = Convert.ToInt64(str);
                }
                catch { }
            }
            return result;
        }

        public static object GetEmptyOptions()
        {
            string result = "ERROR", message = string.Empty;
            dynamic recordList = null;
            try
            {
                recordList = new List<ListOptions>().Select(c => new { DisplayText = c.Text, Value = c.Value }).ToList();
                result = "OK";
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            if (result == "OK")
                return new { Result = "OK", Options = recordList };
            else
                return new { Result = "ERROR", Message = message };
        }

        public static int intQueryString(string str)
        {
            int result = 0;
            if (HttpContext.Current.Request.QueryString[str] != null)
            {
                try
                {
                    int.TryParse(HttpContext.Current.Request.QueryString[str].ToString(), out result);
                }
                catch { }
            }

            return result;
        }

        public static int ToInt(string str)
        {
            int result = 0;
            if (str != null && str.Length > 0)
            {
                try
                {
                    int.TryParse(str, out result);
                }
                catch { }
            }

            return result;
        }

        public static short ToInt16(object str)
        {
            short result = 0;
            if (str != null)
            {
                try
                {
                    short.TryParse(str.ToString(), out result);
                }
                catch { }
            }

            return result;
        }

        public static DateTime ToDate(object data)
        {
            if (data == null)
                return new DateTime(1900, 1, 1);
            else
                return ToDate(data.ToString());
        }

        public static DateTime ToDate(this string data)
        {
            DateTime result = new DateTime(1900, 1, 1);
            if (data.ToSafeString() != string.Empty && Information.IsDate(data))
            {
                try
                {
                    result = Convert.ToDateTime(data);
                }
                catch { }
            }
            return result;
        }

        public static int ToInt(object str)
        {
            int result = 0;
            if (str != null)
            {
                try
                {
                    int.TryParse(str.ToString(), out result);
                }
                catch { }
            }

            return result;
        }

        public static bool ToBool(object data)
        {
            if (data == null)
                return false;
            else
                return ToBool(data.ToString());
        }

        public static bool ToBool(string data)
        {
            bool result = false;
            if (data != null)
            {
                string tdata = data.Trim().ToLower();
                if (tdata == "true" || tdata == "yes" || tdata == "1")
                    result = true;
                else
                    result = false;
            }
            return result;
        }

        public static decimal ToDecimal(string str)
        {
            decimal result = 0;
            if (str != null && Information.IsNumeric(str))
            {
                try
                {
                    result = Convert.ToDecimal(str);
                }
                catch { }
            }
            return result;
        }

        public static string ReadFile(string filePath)
        {
            StreamReader fp;
            string fileContent = string.Empty;
            try
            {
                fp = File.OpenText(filePath);
                fileContent = fp.ReadToEnd();
                fp.Close();
            }
            catch { }
            finally { }

            return fileContent;
        }

        public static string Get8Digits()
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D8}", random);
        }

        public static void SaveFile(HttpPostedFile postedFile, string filePath, string fileName)
        {
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            if (postedFile.ContentLength > 0)
                postedFile.SaveAs(filePath + fileName);
        }

        public static void MoveImages(string sessPath, string dirPath, int fileLimitToMove = 25, bool isUniqueName = false)
        {
            try
            {
                string fileName = string.Empty;
                string newFilePath = string.Empty;
                string uniqueFileName = string.Empty;

                DirectoryInfo sessionDirInfo = new DirectoryInfo(sessPath);
                if (sessionDirInfo.Exists)
                {
                    DirectoryInfo desDirInfo = new DirectoryInfo(dirPath);
                    if (!desDirInfo.Exists)
                        desDirInfo.Create();

                    int fileLimitIndex = 0;
                    foreach (var file in sessionDirInfo.GetFiles())
                    {
                        if (fileLimitIndex >= fileLimitToMove)
                        {
                            break;
                        }
                        fileName = Path.GetFileName(file.Name);
                        if (File.Exists(Path.Combine(dirPath + "\\", fileName)))
                        {
                            File.Delete(Path.Combine(dirPath + "\\", fileName));
                        }

                        if (isUniqueName)
                            uniqueFileName = System.Guid.NewGuid().ToString() + Path.GetExtension(fileName);

                        newFilePath = Path.Combine(dirPath + "\\", (isUniqueName ? uniqueFileName : fileName));
                        System.IO.File.Move(sessPath + "\\" + fileName, newFilePath);

                        fileLimitIndex = fileLimitIndex + 1;
                    }
                    Directory.Delete(sessPath, true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string CreateTempTableSQLString(DataTable dTbl)
        {
            StringBuilder stb = new StringBuilder();
            stb.Append(" CREATE TABLE #" + dTbl.TableName + " (");
            foreach (DataColumn dcol in dTbl.Columns)
            {
                switch (dcol.DataType.Name.ToLower())
                {
                    case "string":
                        stb.Append(dcol.ColumnName + " varchar(500), ");
                        break;
                    case "decimal":
                    case "double":
                    case "float":
                        stb.Append(dcol.ColumnName + " money, ");
                        break;
                    case "int32":
                        stb.Append(dcol.ColumnName + " int, ");
                        break;
                    case "bool":
                    case "boolean":
                        stb.Append(dcol.ColumnName + " bit, ");
                        break;
                }
            }

            stb.Remove(stb.ToString().Length - 2, 2);
            stb.Append(");");

            return stb.ToString();
        }

        public static string MakeRelativeCustomUrlSafeForApp(string customUrl, string appPath)
        {
            string result = customUrl;
            string testAppPath = appPath.TrimEnd('/');

            if (appPath != "/")
            {
                if (testAppPath.Length > 0)
                {
                    result = testAppPath + customUrl;
                }
            }

            return result;
        }

        public static string BuildURL(object idOrKey, object pagePart, string appPath)
        {
            return MakeRelativeCustomUrlSafeForApp("/" + pagePart + "/" + idOrKey + ".aspx", appPath);
        }

        public static string BuildURL(object idOrKey, object subIdOrKey, object pagePart, string appPath)
        {
            return MakeRelativeCustomUrlSafeForApp("/" + pagePart + "/" + subIdOrKey + "/" + idOrKey + ".aspx", appPath);
        }

        public static string BuildURL(object idOrKey, object subIdOrKey, object subSection, object pagePart, string appPath)
        {
            return MakeRelativeCustomUrlSafeForApp("/" + pagePart + "/" + subIdOrKey + "/" + subSection + "/" + idOrKey + ".aspx", appPath);
        }

        public static string BuildURL(object idOrKey, object subIdOrKey, object subSection, object pagePart, string appPath, object searchPart = null)
        {
            return MakeRelativeCustomUrlSafeForApp("/" + pagePart + "/" + subIdOrKey + "/" + subSection + "/" + idOrKey + ".aspx" + (searchPart != null ? "?" + searchPart.ToString() : ""), appPath);
        }

        public static string ToSafeString(this object objString)
        {
            return (objString == null || objString == DBNull.Value) ? string.Empty : objString.ToString().Trim();
        }

        public static string ToLimitString(this string objString, int limit)
        {
            string resultString = objString;
            if (!string.IsNullOrEmpty(objString))
            {
                string safeString = Regex.Replace(objString, UNICODE_PATTERN, string.Empty);
                if (safeString.Length > limit)
                {
                    resultString = safeString.Substring(0, limit) + "...";
                }
            }
            return resultString;
        }

        public static decimal ToSafeDecimal(this object objString)
        {
            return (objString == null || objString == DBNull.Value) ? 0 : Utils.ToDecimal(objString.ToString());
        }

        public static double ToSafeDouble(this object objString)
        {
            return (objString == null || objString == DBNull.Value) ? 0.0D : Utils.ToDouble(objString.ToString());
        }

        public static long ToSafeLong(this object objString)
        {
            return (objString == null || objString == DBNull.Value) ? 0 : Utils.ToLong(objString.ToString());
        }

        public static decimal ToSafeDecimal(this decimal? objValue)
        {
            return (objValue == null || !objValue.HasValue) ? 0.0M : objValue.Value;
        }

        public static double ToSafeDouble(this double? objValue, int decimalPlaces = 2)
        {
            return (objValue == null || !objValue.HasValue) ? Math.Round(0.00, decimalPlaces) : Math.Round(objValue.Value, decimalPlaces);
        }

        public static int ToSafeInt(this object objString)
        {
            return (objString == null || objString == DBNull.Value) ? 0 : Utils.ToInt(objString.ToString());
        }

        public static int ToSafeInt(this int? objValue)
        {
            return (objValue == null || !objValue.HasValue) ? 0 : objValue.Value;
        }

        public static int ToSafeInt(this object objString, int defValue)
        {
            return (objString == null || objString == DBNull.Value) ? defValue : Utils.ToInt(objString.ToString());
        }

        public static short ToSafeInt16(this object objValue)
        {
            short result = 0;
            return (objValue == null || objValue == DBNull.Value) ? result : ToInt16(objValue.ToString());
        }

        public static short ToSafeInt16(this object objString, short defValue)
        {
            return (objString == null || objString == DBNull.Value) ? defValue : ToInt16(objString.ToString());
        }

        public static bool ToSafeBool(this object objString, bool defValue)
        {
            return (objString == null || objString == DBNull.Value) ? defValue : Utils.ToBool(objString.ToString());
        }

        public static bool ToSafeBool(this bool? objString, bool defValue)
        {
            return (objString == null || !objString.HasValue) ? defValue : Utils.ToBool(objString.ToString());
        }

        public static string GetArrayPart(this string[] objArray, int arrayIndex)
        {
            return (objArray != null && objArray.Length > arrayIndex) ? objArray[arrayIndex] : string.Empty;
        }

        public static string GetPropertyValue(this object o, string propName)
        {
            try
            {
                Type t = o.GetType();
                PropertyInfo p = t.GetProperty(propName);
                object v = p.GetValue(o, null);

                return v.ToSafeString();
            }
            catch
            {
                return string.Empty;
            }
        }

        public static object GetPropertyValueAsObject(this object o, string propName)
        {
            try
            {
                Type t = o.GetType();
                PropertyInfo p = t.GetProperty(propName);
                object v = p.GetValue(o, null);

                return v;
            }
            catch
            {
                return null;
            }
        }

        public static string GetDataFromFile(string FileName)
        {
            StringBuilder stbHTML = new StringBuilder();
            if (File.Exists(FileName))
            {
                StreamReader objStreamReader = new StreamReader(FileName);
                stbHTML.Append(objStreamReader.ReadToEnd());
                objStreamReader.Dispose();
            }

            return stbHTML.ToString();
        }

        public static string EncodeString(string s)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(s);
            return Convert.ToBase64String(b, 0, b.Length);
        }

        public static string DecodeString(string s)
        {
            byte[] b = Convert.FromBase64String(s);
            return System.Text.Encoding.Default.GetString(b);
        }

        public static void SetCookie(string cookieName, string value)
        {
            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookieName);
                string currentValue = cookie.Value;
                if (currentValue != value)
                {
                    HttpContext.Current.Response.Cookies.Remove(cookieName);
                    cookie.Value = value;
                    cookie.Expires = DateTime.Now.AddDays(365);
                    HttpContext.Current.Response.SetCookie(cookie);
                }
            }
            else
            {
                HttpCookie cookie = new HttpCookie(cookieName);
                HttpContext.Current.Response.Cookies.Remove(cookieName);
                cookie.Value = value;
                cookie.Expires = DateTime.Now.AddDays(365);
                HttpContext.Current.Response.SetCookie(cookie);
            }

        }

        public static string GetCookie(string cookieName, string defaultValue = "")
        {
            string result = defaultValue;

            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookieName);
                result = cookie.Value;
            }

            return result;
        }

        #endregion

        #region Encrypt Decrypt

        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("se89geji144t89f2");
        private static string passPhrase = "s4a2l9v7a5g1e7t1a2m9";
        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;

        private static string securityKey = "f9c63e36-5362-9fb4-hh15-559981seerw7";

        public static string EncryptStrong(string plainText)
        {
            try
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                                {
                                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                    cryptoStream.FlushFinalBlock();
                                    byte[] cipherTextBytes = memoryStream.ToArray();
                                    //return Convert.ToBase64String(cipherTextBytes);
                                    return System.Web.HttpServerUtility.UrlTokenEncode(cipherTextBytes);
                                }
                            }
                        }
                    }
                }
            }
            catch { return string.Empty; }
        }

        public static string DecryptStrong(string cipherText)
        {
            try
            {
                //byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                byte[] cipherTextBytes = System.Web.HttpServerUtility.UrlTokenDecode(cipherText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }
            catch { return string.Empty; }
        }

        public static string EncryptNormal(string plainText)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();

            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Utils.securityKey));

            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            byte[] DataToEncrypt = UTF8.GetBytes(plainText);

            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            return Convert.ToBase64String(Results);
        }

        public static string DecryptNormal(string encryptedText)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();

            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Utils.securityKey));

            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            encryptedText = encryptedText.Replace(" ", "+");

            byte[] DataToDecrypt = Convert.FromBase64String(encryptedText);

            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            return UTF8.GetString(Results);
        }

        // File constants:
        static byte[] fileKey = Encoding.UTF8.GetBytes("asdf!@#$1234ASDF");

        public static object CoreCommon { get; private set; }

        public static byte[] DecryptFile(string filePath)
        {
            List<byte> fileBytes = new List<byte>();

            FileStream fs = new FileStream(filePath, FileMode.Open);
            RijndaelManaged rmcrypt = new RijndaelManaged();
            CryptoStream cs = new CryptoStream(fs, rmcrypt.CreateDecryptor(fileKey, fileKey), CryptoStreamMode.Read);

            int data;
            while ((data = cs.ReadByte()) != -1)
            {
                fileBytes.Add((byte)data);
            }

            cs.Close();
            fs.Close();

            return fileBytes.ToArray();
        }

        public static bool EncryptFile(string filePath)
        {
            bool result = false;
            try
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    using (RijndaelManaged rmCryp = new RijndaelManaged())
                    {
                        using (CryptoStream cs = new CryptoStream(fs, rmCryp.CreateEncryptor(fileKey, fileKey), CryptoStreamMode.Write))
                        {
                            foreach (var data in fileBytes)
                            {
                                cs.WriteByte((byte)data);
                            }

                            result = true;
                        }
                    }
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public static string EncryptAlphanumeric(string input)
        {
            byte[] ba = Encoding.Default.GetBytes(input);
            return System.Web.HttpServerUtility.UrlTokenEncode(ba);
        }

        public static string DecryptAlphanumeric(string input)
        {
            byte[] ba = System.Web.HttpServerUtility.UrlTokenDecode(input);
            return Encoding.UTF8.GetString(ba);
        }

        #endregion

        #region"Encoded Action Link"

        /// <summary>
        /// Encodeds the action link.
        /// </summary>
        /// <param name="linkText">The link text.</param>
        /// <param name="Action">The action.</param>
        /// <param name="ControllerName">Name of the controller.</param>
        /// <param name="Area">The area.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns></returns>
        public static string EncodedActionLink(string linkText, string Action, string ControllerName, string Area, object routeValues, object htmlAttributes)
        {
            string queryString = string.Empty;
            string htmlAttributesString = string.Empty;
            ////My Changes
            bool IsRoute = true;
            if (routeValues != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(routeValues);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    ////My Changes
                    if (!d.Keys.Contains("IsRoute"))
                    {
                        if (i > 0)
                        {
                            queryString += "&";
                        }

                        queryString += d.Keys.ElementAt(i) + "=" + d.Values.ElementAt(i);
                    }
                    else
                    {
                        ////My Changes
                        if (!d.Keys.ElementAt(i).Contains("IsRoute"))
                        {
                            queryString += d.Values.ElementAt(i);
                            IsRoute = true;
                        }
                    }
                }
            }

            if (htmlAttributes != null)
            {
                RouteValueDictionary d = new RouteValueDictionary(htmlAttributes);
                for (int i = 0; i < d.Keys.Count; i++)
                {
                    htmlAttributesString += " " + d.Keys.ElementAt(i) + "=" + d.Values.ElementAt(i);
                }
            }

            StringBuilder ancor = new StringBuilder();            
            if (htmlAttributesString != string.Empty)
            {
                ancor.Append(htmlAttributesString);
            }
            if (Area != string.Empty)
            {
                ////ancor.Append("/" + Area);
            }

            if (ControllerName != string.Empty)
            {
                ancor.Append("/" + ControllerName);
            }

            if (Action != "")
            {
                ancor.Append("/" + Action);
            }
            ////My Changes
            if (queryString != string.Empty)
            {
                if (IsRoute == false)
                {
                    ancor.Append("?" + EncryptStrong(queryString));
                }
                else
                {
                    ancor.Append("/" + EncryptStrong(queryString));
                }
            }
            return ancor.ToString();
        }

        #endregion

        #region EncryptDecrypt 
        public class EncryptDecryptUtility
        {
            /// <summary>
            /// The initialize vector bytes
            /// </summary>
            private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

            /// <summary>
            /// The key size.
            /// This constant is used to determine the key size of the encryption algorithm.
            /// </summary>
            private const int keysize = 256;

            /// <summary>
            /// The pass phrase
            /// </summary>
            public static string passPhrase = "asdasd";

            /// <summary>
            /// Encrypts the specified plain text.
            /// </summary>
            /// <param name="plainText">The plain text.</param>
            /// <param name="test">if set to <c>true</c> [test].</param>
            /// <returns>Encrypted string.</returns>
            /// <updatedby>Rujuta Xavier</updatedby>
            /// <updatedon>11/03/2016</updatedon>
            /// <updates>Commented code removed.</updates>
            public static string Encrypt(string plainText, bool test)
            {
                try
                {
                    byte[] keyArray;
                    byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(plainText);

                    System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();

                    // Get the key from config file
                    string key = "";

                    // If hashing use get hashcode regards to your key
                    if (true)
                    {
                        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                        // Always release the resources and flush data
                        // of the Cryptographic service provide. Best Practice
                        hashmd5.Clear();
                    }

                    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                    // set the secret key for the tripleDES algorithm
                    tdes.Key = keyArray;

                    // mode of operation. there are other 4 modes. We choose ECB(Electronic code Book)
                    tdes.Mode = CipherMode.ECB;

                    // padding mode(if any extra byte added)
                    tdes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = tdes.CreateEncryptor();

                    // transform the specified region of bytes array to resultArray
                    byte[] resultArray = cTransform.TransformFinalBlock
                            (toEncryptArray, 0, toEncryptArray.Length);

                    // Release resources held by TripleDes Encryptor
                    tdes.Clear();

                    // Return the encrypted data into unreadable string format
                    return Convert.ToBase64String(resultArray, 0, resultArray.Length).Replace('+', '_').Replace('/', '-').Replace('=', '$');
                }
                catch
                {
                    return plainText;
                }
            }

            /// <summary>
            /// Encrypts the specified plain text.
            /// </summary>
            /// <param name="plainText">The plain text.</param>
            /// <returns>Encrypted string.</returns>
            /// <updatedby>Rujuta Xavier</updatedby>
            /// <updatedon>11/03/2016</updatedon>
            /// <updates>Commented code removed.</updates>
            public static string Encrypt(string plainText)
            {
                try
                {
                    byte[] keyArray;
                    byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(plainText);

                    System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();

                    // Get the key from config file
                    string key = "";

                    // System.Windows.Forms.MessageBox.Show(key);
                    // If hashing use get hashcode regards to your key
                    if (true)
                    {
                        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                        // Always release the resources and flush data
                        // of the Cryptographic service provide. Best Practice
                        hashmd5.Clear();
                    }

                    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                    // set the secret key for the tripleDES algorithm
                    tdes.Key = keyArray;

                    //mode of operation. there are other 4 modes. We choose ECB(Electronic code Book)
                    tdes.Mode = CipherMode.ECB;

                    //p adding mode(if any extra byte added)
                    tdes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = tdes.CreateEncryptor();

                    // transform the specified region of bytes array to resultArray
                    byte[] resultArray = cTransform.TransformFinalBlock
                            (toEncryptArray, 0, toEncryptArray.Length);

                    // Release resources held by TripleDes Encryptor
                    tdes.Clear();

                    // Return the encrypted data into unreadable string format
                    return Convert.ToBase64String(resultArray, 0, resultArray.Length).Replace('+', '_').Replace('/', '-').Replace('=', '$');
                }
                catch
                {
                    return plainText;
                }
            }

            /// <summary>
            /// Decrypts the specified cipher text.
            /// </summary>
            /// <param name="cipherText">The cipher text.</param>
            /// <param name="test">if set to <c>true</c> [test].</param>
            /// <returns>Decrypted string.</returns>
            /// <updatedby>Rujuta Xavier</updatedby>
            /// <updatedon>11/03/2016</updatedon>
            /// <updates>Commented code removed.</updates>
            public static string Decrypt(string cipherText, bool test)
            {
                try
                {
                    byte[] keyArray;

                    // get the byte code of the string
                    cipherText = cipherText.Replace('_', '+').Replace('-', '/').Replace('$', '=');
                    byte[] toEncryptArray = Convert.FromBase64String(cipherText);
                    System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();

                    // Get your key from config file to open the lock!
                    string key = "";

                    if (true)
                    {
                        // if hashing was used get the hash code with regards to your key
                        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                        // release any resource held by the MD5CryptoServiceProvider
                        hashmd5.Clear();
                    }

                    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                    // set the secret key for the tripleDES algorithm
                    tdes.Key = keyArray;

                    // mode of operation. there are other 4 modes.
                    // We choose ECB(Electronic code Book)
                    tdes.Mode = CipherMode.ECB;

                    // padding mode(if any extra byte added)
                    tdes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = tdes.CreateDecryptor();
                    byte[] resultArray = cTransform.TransformFinalBlock
                            (toEncryptArray, 0, toEncryptArray.Length);

                    // Release resources held by TripleDes Encryptor
                    tdes.Clear();

                    // return the Clear decrypted TEXT
                    return UTF8Encoding.UTF8.GetString(resultArray);
                }
                catch
                {
                    return cipherText;
                }
            }

            /// <summary>
            /// Decrypts the specified cipher text.
            /// </summary>
            /// <param name="cipherText">The cipher text.</param>
            /// <returns>Decrypted string.</returns>
            /// <updatedby>Rujuta Xavier</updatedby>
            /// <updatedon>11/03/2016</updatedon>
            /// <updates>Commented code removed.</updates>
            public static string Decrypt(string cipherText)
            {
                try
                {
                    byte[] keyArray;

                    // get the byte code of the string
                    cipherText = cipherText.Replace('_', '+').Replace('-', '/').Replace('$', '=');
                    byte[] toEncryptArray = Convert.FromBase64String(cipherText);
                    System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();

                    // Get your key from config file to open the lock!
                    string key = string.Empty;

                    if (true)
                    {
                        // if hashing was used get the hash code with regards to your key
                        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));

                        // release any resource held by the MD5CryptoServiceProvider
                        hashmd5.Clear();
                    }

                    TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

                    // set the secret key for the tripleDES algorithm
                    tdes.Key = keyArray;

                    // mode of operation. there are other 4 modes.
                    // We choose ECB(Electronic code Book)
                    tdes.Mode = CipherMode.ECB;

                    // padding mode(if any extra byte added)
                    tdes.Padding = PaddingMode.PKCS7;

                    ICryptoTransform cTransform = tdes.CreateDecryptor();
                    byte[] resultArray = cTransform.TransformFinalBlock
                            (toEncryptArray, 0, toEncryptArray.Length);

                    // Release resources held by TripleDes Encryptor
                    tdes.Clear();

                    // return the Clear decrypted TEXT
                    return UTF8Encoding.UTF8.GetString(resultArray);
                }
                catch
                {
                    return cipherText;
                }
            }

            /// <summary>
            /// Redirects the action parameter.
            /// </summary>
            /// <param name="inputQuerystring">The input query string.</param>
            /// <returns>Redirects to given action.</returns>
            /// <updatedby>Rujuta Xavier</updatedby>
            /// <updatedon>11/03/2016</updatedon>
            /// <updates>Commented code removed.</updates>
            public static string RedirecttoActionParameter(string inputQuerystring)
            {
                return Encrypt(inputQuerystring);
            }
        }

        #endregion
    }
}