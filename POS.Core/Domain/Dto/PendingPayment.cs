using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using static POS.Core.Utils;

namespace POS.Core.Domain
{
    /// <summary>
    /// Pending payments
    /// </summary>
    /// <Updatedby>AhmedMustafa</Updatedby>
    /// <UpdatedDate>06 Jun 2019 </UpdatedDate>
    [Serializable()]
    [JsonObject]
    public class PendingPayment
    {
        public long VehiclePaymentID { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal LastBidAmount { get; set; }
        public int DepositAmount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime BillExpiryDate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string PaymentRefNo { get; set; }
        public long VehicleAuctionID { get; set; }
        public long VehicleID { get; set; }
        public string ParentBillerCode { get; set; }
        public string BillNumber { get; set; }
        public string AuctionReferenceNo { get; set; }
        public string BillerName { get; set; }
        public decimal CustCommFeesAmt { get; set; }
        public decimal VATAmount { get; set; }
        public byte VehiclePaymentStatusID { get; set; }
        public byte NoOfPages { get; set; }
        public byte PaymentTypeID { get; set; }
        public string SalvageRegistrationNo { get; set; }
        public byte PaymentStatusID { get; set; }
        public string TransactionNumber { get; set; }
        public string BankName { get; set; }
        public string IBAN { get; set; }
        public string SwiftCode { get; set; }
        public decimal ExportDeliveryFeesAmt { get; set; }
        public decimal EquivalentAmount { get; set; }
        public string AccountName { get; set; }
        public long VehiclePaymentDetailCombinedBillID { get; set; }
        public byte IndividualBillCount { get; set; }
    }

    [Serializable()]
    [JsonObject]
    public class PendingPaymentDetails
    {
        public long VehiclePaymentID { get; set; }
        public decimal PaymentAmount { get; set; }
        public decimal LastBidAmount { get; set; }
        public int DepositAmount { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime BillExpiryDate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string PaymentRefNo { get; set; }
        public long VehicleAuctionID { get; set; }
        public long VehicleID { get; set; }
        public string ParentBillerCode { get; set; }
        public string BillNumber { get; set; }
        public string AuctionReferenceNo { get; set; }
        public string BillerName { get; set; }
        public decimal CustCommFeesAmt { get; set; }
        public decimal ExportDeliveryFeesAmt { get; set; }
        public decimal VATAmount { get; set; }
        public byte VehiclePaymentStatusID { get; set; }
        public bool IsForeignAccount { get; set; }
        public bool IsCombinedinOneBill { get; set; }
        public string PaymentRefNoCombinedBill { get; set; }
        public long VehiclePaymentDetailCombinedBillID { get; set; }
        public byte IndividualBillCount { get; set; }
        public DateTime? OneBillExpiryDate { get; set; }
    }

    /// <summary>
    /// Pending Payment Details Extended Model For Sadad and Bank Transfer Data
    /// </summary>
    /// <version>1.0    01st November 18     AhmedMustafa</version>
    [Serializable()]
    [JsonObject]
    public class PendingPaymentDetailsExtendedModel : PendingPaymentDetails
    {
        public short PaymentTypeID { get; set; }
        public long? TransferScanDocumentID { get; set; }
        public string TransactionNumber { get; set; }
        public string AccountName { get; set; }
        public DateTime? TransactionCompletedOn { get; set; }
        public string EncryptedTransferScanDocumentID
        {
            get
            {
                return (TransferScanDocumentID == 0) ? "" : EncryptDecryptUtility.Encrypt(TransferScanDocumentID.ToSafeString());
            }
        }
        public string BankName { get; set; }
        public string IBAN { get; set; }
        public string SwiftCode { get; set; }
    }

    [Serializable()]
    [JsonObject]
    public class PendingPaymentDetailStatistics
    {
        public int TotalRecords { get; set; }
        public int NoOfPages { get; set; }
        public int PendingCount { get; set; }
        public int ExpiredCount { get; set; }
        public int OneBillCount { get; set; }
    }

    [Serializable()]
    [JsonObject]
    public class PendingPaymentViewModel
    {
        public List<PendingPaymentDetailsExtendedModel> pendingPaymentDetails { get; set; }
        public PendingPaymentDetailStatistics pendingPaymentDetailStatistics { get; set; }
    }
}
