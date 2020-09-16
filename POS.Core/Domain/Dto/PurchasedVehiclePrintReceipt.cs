using System;
using Newtonsoft.Json;

namespace POS.Core.Domain
{
    [Serializable]
    [JsonObject]
    public class PurchasedVehiclePrintReceipt
    {
        public long UserPurchasedVehicleID { get; set; }

        public long VehicleID { get; set; }

        public long VehicleAuctionID { get; set; }

        public int UserID { get; set; }

        public string PurchaseType { get; set; }

        public decimal PurchasedAmount { get; set; }

        public string ImageTitle { get; set; }

        public string ImageMediaLink { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Year { get; set; }

        public string PaymentRefNo { get; set; }

        public DateTime AuctionEndOn { get; set; }
        public string AuctionReferenceNo { get; set; }

        public string Color { get; set; }
        public string VehiclePlateNo { get; set; }

        public string BillerCode { get; set; }
        public string BillNumber { get; set; }
        public string CustomerName { get; set; }

        public string MerchantName { get; set; }
        public string MerchantTIN { get; set; }
        public string MerchantAddress { get; set; }
        public DateTime? PaymentDate { get; set; }

        public decimal AuctionAmount { get; set; }
        public decimal FeesAmount { get; set; }
        public decimal ExportDeliveryFeesAmt { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal SubTotal { get; set; }
        public string VatPercentage { get; set; }

        public string AuctionEndDateForPrintReceipt { get; set; }
        public string PaymentDateForPrintReceipt { get; set; }

        public short? BuldingNumber { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        public string CityName { get; set; }
        public string Country { get; set; }
        public string ForeignAddress { get; set; }
        public string Additionalnumber { get; set; }
        public string ReceiptRefNo { get; set; }
        public short PaymentTypeID { get; set; }
        public string PaymentType { get; set; }
        public string TransactionNumber { get; set; }
        public string AccountName { get; set; }
        public DateTime? TransactionCompletedOn { get; set; }
        public string TransactionCompletedOnForPrintReceipt { get; set; }
        public bool IsForeignAccount { get; set; }
        public decimal EquivalentAmount { get; set; }
    }
}
