using System;
using System.Collections.Generic;
using System.Globalization;

namespace NSR.Core
{
    public static class Utility
    {
        public const int RowsNumber = 10;

        public const int MaxRowsNumber = 1000;

        public static List<int> RowsList = new List<int> { 10, 20, 30, 40, 50 };
        public static int maxRowList = 999;

        #region TotalPages
        public static int TotalPages(float totalRecordsCount, float recordsCount)
        {
            try
            {
                return (int)Math.Ceiling(totalRecordsCount / recordsCount);
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region Static variable

        public static string CurrentCulture = "CurrentCulture";
        public static string CurrentCultureCode = "CurrentCultureCode";
        public static string AspNetUsersession = "AspNetUsersession";
        public static string SelectedTab = "SelectedTab";
        public static string PolicyType = "PolicyType";
        public static string FTLSearch = "FTLSearch";
        public static string CallerSearchCondition = "CallerSearchCondition";
        public static string CaseSearchCondition = "CaseSearchCondition";
        public static string NajmNetInquirySearch = "NajmNetInquirySearch";
        public static string EmployeeSearchCondition = "EmployeeSearchCondition";
        public static string InsuranceInquirySession = "InsuranceInquirySession";
        public static string InsuranceInquiryList = "InsuranceInquiryList";
        public static string LDDetails = "LDDetails";
        public static string LDDetailsCaseImage = "LDDetailsCaseImage";
        public static string EditICRefNoSearchCondition = "EditICRefNoSearchCondition";
        public static string BrowseCasePhotos = "BrowseCasePhotos";
        public static string SearchClaim = "SearchClaim";
        public const string DirClaimDocuments = "Claim Documents";
        public const string DirPOD = "POD";
        public const string Year = "20";
        public const string ActionDepartment = "Insurance Company";
        public const string ClaimSearch = "ClaimSearch";
        public const string Comprehensive = "Comprehensive";
        public const string ThirdParty = "ThirdParty";
        public const string Claims = "Claims";
        public const string CRICLogID = "CRICLogID";
        public const string ClaimInEachStageReport = "ClaimInEachStageReport";
        public const string ClaimClosingReport = "ClaimClosingReport";
        public const string SuccessMessageType = "SuccessMessageType";
        public const string UrlReferrer = "UrlReferrer";
        public static string UserID = "UserID";
        public static string GeoLocatorSearchCV = "GeoLocatorSearchCV";
        public static string SearchCondition = "SearchCondition";
        public static string ClaimSearchCondition = "ClaimSearchCondition";
        public static string DefaultDateFormate = "dd/MM/yyy";

   

        #region Cache keys
        public static string ResourceCacheKey = "ResourceCacheKey";
        public static string CityCacheKey = "CityCacheKey";
        public static string DepartmentCacheKey = "DepartmentCacheKey";
        public static string ZoneCacheKey = "ZoneCacheKey";
        public static string SubZoneCacheKey = "SubZoneCacheKey";
        public static string POSPlateTypeMaster = "POSPlateTypeMaster";
        public static string PlateCharacterMaster = "PlateCharacterMaster";
        public static string CRStageMaster = "CRStageMaster";
        public static string CRStatusMaster = "CRStatusMaster";
        public static string InsuranceMaster = "InsuranceMaster";
        public static string FinanceStatusMaster = "FinanceStatusMaster";
        public static string CRRejectionMaster = "CRRejectionMaster";
        public static string CRCategoryMaster = "CRCategoryMaster";
        public static string CRBankMaster = "CRBankMaster";
        public static string CourierMaster = "CourierMaster";
        public static string CaseType = "CaseType";
        public static string CaseTypeReason = "CaseTypeReason";
        public static string SaudiPlateTypeMaster = "SaudiPlateTypeMaster";
        public static string ICOtherUserType = "ICOtherUserType";
        public static string CRNegotiationAmountReason = "CRNegotiationAmountReason";

        public static string FISPOSPlateTypeMaster = "FISPOSPlateTypeMaster";
        public static string FISPlateCharacterMaster = "FISPlateCharacterMaster";
        public static string FISReferenceTypeMaster = "ReferenceTypeMaster";
        public static string FISUnNajmCRTypeMaster = "FISUnNajmCRTypeMaster";
        public static string FISClaimTypeMaster = "FISClaimTypeMaster";
        public static string FISSaudiPlateTypeMaster = "FISSaudiPlateTypeMaster";
        public static string FISReasonMaster = "FISReasonMaster";

        #endregion



        #endregion

        #region Culture.
        public const string EnglishCultureCode = "en";
        public const string ArabicCultureCode = "ar";
        public const string EnglishCulture = "English";
        public const string ArabicCulture = "Arabic";

        #endregion

        #region Date Format

        //public static string GetFormatedDatewithTime(string obj)
        //{
        //    string datetime = string.Empty;
        //    if (obj != null)
        //    {
        //        datetime = DateTime.ParseExact(obj, Utilty.DateFormat, CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture);
        //    }
        //    return datetime;
        //}

        #endregion

        #region "Handle null sql parameters"

        public static object ToSQLDataType(this object value)
        {
            object result;

            if (value != null)
            {
                result = value;
            }
            else
            {
                result = DBNull.Value;
            }
            return result;
        }

        public static object ToSQLDataType(this object value, string dateFormate)
        {
            object result;
            if (value != null)
            {
                DateTime eDate = new DateTime();
                DateTime.TryParseExact(value.ToSafeString(), dateFormate, CultureInfo.InvariantCulture, DateTimeStyles.None, out eDate);
                result = eDate;
            }
            else
            {
                result = DBNull.Value;
            }
            return result;
        }

        #endregion

        #region
        /// <summary>
        /// Get status text from value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <history>
        /// [Created By] : Dipali Bhavsar on 3-Aug-2015
        /// </history>
        public static string ConvertStatus(object value)
        {
            if (value == null)
                return string.Empty;
            else if ((bool)value == true)
                return "Open";
            else if ((bool)value == false)
                return "Close";
            else
                return string.Empty;
        }
        #endregion

        /// <summary>
        /// Gets the hijri date from GRE date.
        /// </summary>
        /// <param name="greDate">The gre date.</param>
        /// <returns></returns>
        /// [Created] : 14-Jul-2015 by Dhruti Desai.
        public static string GetHijriDateFromGREDate(DateTime greDate)
        {
            CultureInfo arSA = new CultureInfo("ar-SA");
            return greDate.ToString("dd/MM/yyyy", arSA);
        }

        /// <summary>
        /// Gets the GRE date from hijri date 
        /// </summary>
        /// <param name="hijriDate">The Hijri date</param>
        /// <returns>GRE date</returns>
        /// <history>
        /// [Created By]: Mitesh Thakkar on 29-Sept-2015
        /// </history>
        public static DateTime GetGREDateFromHijriDate(string hijriDate)
        {
            CultureInfo arCI = new CultureInfo("ar-SA");
            DateTime tempDate = DateTime.ParseExact(hijriDate, "dd/MM/yyyy", arCI.DateTimeFormat, DateTimeStyles.AllowInnerWhite);
            return tempDate;
        }
        public static string CheckLanguage(string lang)
        {
            try
            {
                if (lang.ToLower() == "en")
                    return "en";
                if (lang.ToLower() == "ar")
                    return "ar";
                return "en";
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }
            return "en";
        }
    }
}

