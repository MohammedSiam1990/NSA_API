using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Linq.Mapping;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic;



namespace NSR.Common
{
    public static class Utils
    {
        public static string ToSafeString(this object objString)
        {
            return (objString == null || objString == DBNull.Value) ? string.Empty : objString.ToString().Trim();
        }

        public static object NullCheck(this string self)
        {
            return (string.IsNullOrEmpty(self)) ? (object)DBNull.Value : self;
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

        public static double ToSafeDouble(this object objString)
        {
            return (objString == null || objString == DBNull.Value) ? 0.0D : Utils.ToDouble(objString.ToString());
        }

        public static decimal ToSafeDecimal(this object objString)
        {
            return (objString == null || objString == DBNull.Value) ? 0 : Utils.ToDecimal(objString.ToString());
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

        public static double ToDouble(string str)
        {
            double result = 0;
            if (str != null && Information.IsNumeric(str))
            {
                try
                {
                    result = Convert.ToDouble(str);
                }
                catch
                {
                    return result;
                }
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

        public static string ConfigKey(string key)
        {
            return ConfigurationManager.AppSettings[key].ToSafeString();
        }

        public static long ToSafeLong(this object objString)
        {
            return (objString == null || objString == DBNull.Value) ? 0 : Utils.ToLong(objString.ToString());
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

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            try
            {
                // Unix timestamp is seconds past epoch
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
                return dtDateTime;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static long DateTimeToUnixTimeStamp(DateTime dateTimeValue)
        {
            try
            {
                // Unix timestamp is seconds past epoch
                return (Int64)(dateTimeValue.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalMilliseconds;
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime ConvertMMDDYYToDate(this string dateString)
        {
            DateTime dt;
            if (DateTime.TryParseExact(dateString,
                                        "MM/dd/yyyy h:mm tt",
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
        /// <summary>
        /// Grt Culture Date by Culture
        /// </summary>
        /// <param name="culture"> Selected culture  </param>
        /// <param name="datetime"> Specific Date object </param>
        /// <history>
        /// [Created] : 14-Act-2019 By  Hafez Bassem
        /// </history>
        /// <returns> Object </returns>
        public static string GetCultureSpecificDateString(int culture, DateTime? datetime)
        {
            if (datetime != null)
            {
                // we Use AR-AE Becouse this git Gregorian date in Arabic
                // Note : AR-SA get Hijri Date in Arabic
                return Convert.ToDateTime(datetime).ToString("dd MMM yyyy", new CultureInfo(culture == 1 ? "en" : "ar" + "-AE"));
            }
            return "";
        }
        /// <summary>
        /// Grt Culture DateTime by Culture
        /// </summary>
        /// <param name="culture"> Selected culture  </param>
        /// <param name="datetime"> Specific DateTime object </param>
        /// <history>
        /// [Created] : 14-Act-2019 By  Hafez Bassem
        /// </history>
        /// <returns> Object </returns>
        public static string GetCultureSpecificDateTimeString(int culture, DateTime? datetime)
        {
            if (datetime!=null)
            {
                // we Use AR-AE Becouse this git Gregorian date in Arabic
                // Note : AR-SA get Hijri Date in Arabic
                return Convert.ToDateTime(datetime).ToString("dd MMM yyyy -hh:mm ", new CultureInfo(culture == 1 ? "en" : "ar" + "-AE"));
            }
            return "";
        }
        public static string Get8Digits()
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return String.Format("{0:D8}", random);
        }

        /// <summary>
        /// Check Null value for the object
        /// </summary>
        /// <typeparam name="T"> Type of Object </typeparam>
        /// <param name="obj"> Object Value </param>
        /// <history>
        /// [Created] : 29-Aug-2017 By Krishna Palan
        /// </history>
        /// <returns> Object </returns>
        public static object CheckNull<T>(object obj)
        {
            object resultValue = DBNull.Value;
            try
            {
                if (obj != null)
                {
                    if (typeof(T) == typeof(DateTime) && Convert.ToDateTime(obj) == DateTime.MinValue)
                    {
                        resultValue = DBNull.Value;
                    }
                    else
                    {
                        resultValue = (T)Convert.ChangeType(obj, typeof(T));
                    }
                }
            }
            catch (Exception)
            {
                return DBNull.Value;
            }
            return resultValue;
        }

        public static string Get8Digits(string prefix)
        {
            var bytes = new byte[4];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);
            uint random = BitConverter.ToUInt32(bytes, 0) % 100000000;
            return prefix + String.Format("{0:D8}", random);
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

        public static bool IsAllLettersOrDigits(string s)
        {
            foreach (char c in s)
            {
                if (!Char.IsLetterOrDigit(c))
                    return false;
            }
            return true;
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                Regex regex = new Regex(@"^[a-z0-9][-a-z0-9.!#$%&'*+-=?^_`{|}~\/]+@([-a-z0-9]+\.)+[a-z]{2,5}$");
                return regex.IsMatch(email);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidZipCode(string zipCode)
        {
            try
            {
                Regex regex = new Regex(@"^[1-8]{1}[2-9]{1}[2-9]{1}[1-9]{1}[1-9]{1}$");
                return regex.IsMatch(zipCode);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidBuildingOrAdditionalNumber(string value)
        {
            try
            {
                Regex regex = new Regex(@"^[0-9]{4}$");
                return regex.IsMatch(value);
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidMobile(string mobile)
        {
            try
            {
                Regex regex = new Regex(@"^05[0-9]{8}$");
                return regex.IsMatch(mobile);
            }
            catch
            {
                return false;
            }
        }

        public static bool ToSafeBool(this object objString, bool defValue)
        {
            return (objString == null || objString == DBNull.Value) ? defValue : Utils.ToBool(objString.ToString());
        }

        public static bool ToSafeBool(this bool? objString, bool defValue)
        {
            return (objString == null || !objString.HasValue) ? defValue : Utils.ToBool(objString.ToString());
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

        /// <summary>
        /// Extension method to split a list into smaller list of given size (chunk size)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((smallValue, smallIndex) => new { Index = smallIndex, Value = smallValue })
                .GroupBy(smallValue => smallValue.Index / chunkSize)
                .Select(smallValue => smallValue.Select(record => record.Value).ToList())
                .ToList();
        }

        /// <summary>
        /// Extension method to check datatable has value or not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable"></param>
        /// <returns></returns>
        public static bool HasValue(this DataTable dataTable)
        {
            return (dataTable != null && dataTable.Rows.Count > 0);
        }

        /// <summary>
        /// Extension method to check DataSet has table or not
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public static bool HasValue(this DataSet dataSet)
        {
            return (dataSet != null && dataSet.Tables.Count > 0);
        }

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

        #region GLOBAL CONSTANTS
        public const string ConstGumProductCode = "AWALMAZAD";
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
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            {
                result = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
                result = HttpContext.Current.Request.UserHostAddress;
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

        public static string GetApplicationPath()
        {
            return ((Page)HttpContext.Current.CurrentHandler).ResolveUrl("~");
        }

        public static void DeleteFile(string strPath)
        {
            if (!string.IsNullOrWhiteSpace(strPath))
            {
                FileInfo fi = new FileInfo(strPath);
                try
                {
                    if (fi.Exists)
                        fi.Delete();
                }
                catch { }
            }
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
        /// To the data table.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static DataTable ToDataTableWithNull<T>(this IList<T> data)
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
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
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

        public static string Base64Encode(this object objString)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(objString.ToSafeString());
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Base64Decode(this object objString)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(objString.ToSafeString());
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
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

        public static decimal ToSafeDecimal(this decimal? objValue)
        {
            return (objValue == null || !objValue.HasValue) ? 0.0M : objValue.Value;
        }

        public static double ToSafeDouble(this double? objValue, int decimalPlaces = 2)
        {
            return (objValue == null || !objValue.HasValue) ? Math.Round(0.00, decimalPlaces) : Math.Round(objValue.Value, decimalPlaces);
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

        /// <summary>
        /// To generate random password
        /// </summary>
        /// <param name="length">lenght of password</param>
        /// <param name="noofSpecialChar">how many special chars needed</param>
        /// <returns></returns>
        public static string GetRandomPassword(int length, int noofSpecialChar)
        {
            return System.Web.Security.Membership.GeneratePassword(length, noofSpecialChar);
        }

        public static List<TSource> ToEntityList<TSource>(this DataTable dataTable) where TSource : new()
        {
            var dataList = new List<TSource>();

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
            var objFieldNames = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
                                 select new
                                 {
                                     Name = aProp.Name,
                                     Type = Nullable.GetUnderlyingType(aProp.PropertyType) ??
                             aProp.PropertyType
                                 }).ToList();
            var dataTblFieldNames = (from DataColumn aHeader in dataTable.Columns
                                     select new
                                     {
                                         Name = aHeader.ColumnName,
                                         Type = aHeader.DataType
                                     }).ToList();
            var commonFields = objFieldNames.Intersect(dataTblFieldNames).ToList();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                var aTSource = new TSource();
                foreach (var aField in commonFields)
                {
                    PropertyInfo propertyInfos = aTSource.GetType().GetProperty(aField.Name);
                    var value = (dataRow[aField.Name] == DBNull.Value) ?
                    null : dataRow[aField.Name]; //if database field is nullable
                    propertyInfos.SetValue(aTSource, value, null);
                }
                dataList.Add(aTSource);
            }
            return dataList;
        }

        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public static byte[] ImageToByte2(System.Drawing.Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }

        #endregion
    }
}