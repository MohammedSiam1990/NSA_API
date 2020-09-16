namespace POS.Core.Domain
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Pending payment intermediate reminder
    /// </summary>
    /// <Updatedby>AhmedMustafa</Updatedby>
    /// <UpdatedDate>06 Jun 2019 </UpdatedDate>
    [JsonObject]
    [Serializable]
    public class PendingPaymentIntermediateReminder
    {
        public long VehiclePaymentID { get; set; }
        public string PaymentRefNo { get; set; }
        public decimal PaymentAmount { get; set; }
        public DateTime BillExpiryDate { get; set; }
        public long VehicleAuctionID { get; set; }
        public string AuctionReferenceNo { get; set; }
        public DateTime AuctionEndDateTime { get; set; }
        public long VehicleID { get; set; }
        public string BillerCode { get; set; }
        public string BillNumber { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ManufactureYear { get; set; }
        public string UserFullName { get; set; }
        public string UserEmail { get; set; }
        public string UserAlias { get; set; }
        public long UserMobileNumber { get; set; }
        public int DefaultNotificationLanguage { get; set; }
        public int UserID { get; set; }
        public byte PaymentTypeID { get; set; }
        public DateTime BankTransferBillExpiryDate { get; set; }
        public string BankName { get; set; }
        public string IBAN { get; set; }
        public string SwiftCode { get; set; }
        public string AccountName { get; set; }
        public decimal EquivalentAmount { get; set; }
        public short CountryID { get; set; }
        public string SARValue { get; set; }
        public bool IsCombinedinOneBill { get; set; }
    }
}
