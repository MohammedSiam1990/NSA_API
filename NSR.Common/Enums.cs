using NSR.Common;

namespace NSR.Common
{
    public class Enums
    {
        public enum Language
        {
            [StringValue("en")]
            EN = 1,

            [StringValue("ar")]
            AR = 2
        }
        public enum ConfirmeStatus : byte
        {
            [StringValue("Pinding")]
            Pinding = 0,
            [StringValue("View")]
            View = 1,
            [StringValue("Confirmed")]
            Confirmed = 2,
            [StringValue("Reject")]
            Reject = 3
        }
        public enum AuctionCommonStatus
        {
            /// <summary>
            /// The pending
            /// </summary>
            [StringValue("Pending")]
            Pending = 18,

            [StringValue("Approved")]
            Approved = 19,

            [StringValue("Active")]
            Active = 20,

            [StringValue("Blacklisted")]
            Blacklisted = 16,

            [StringValue("Pending Verification")]
            PendingVerification = 23
        }

        public enum AuctionAspNetUserstatus
        {
            [StringValue("Rejected")]
            Rejected = 11,

            [StringValue("Hold")]
            Hold = 12,

            [StringValue("Inactive")]
            Inactive = 13,

            [StringValue("Verified")]
            Verified = 14,

            [StringValue("Blocked")]
            Blocked = 15,

            [StringValue("Blacklisted")]
            Blacklisted = 16,

            [StringValue("PendingUnblockApproval")]
            PendingUnblockApproval = 17,

            [StringValue("Pending")]
            Pending = 18,

            [StringValue("Approved")]
            Approved = 19,

            [StringValue("Active")]
            Active = 20,

            [StringValue("Locked")]
            Locked = 22,

            [StringValue("PendingVerification")]
            PendingVerification = 23
        }

        /// <summary>
        /// Enumeration for SMS source.
        /// </summary>
        public enum SMSSenderType
        {
            [StringValue("AwalMazad")]
            AwalMazad = 4
        }

        public enum Event
        {
            /// <summary>
            /// The admin verification
            /// </summary>
            [StringValue("AdminVerification")]
            AdminVerification,

            /// <summary>
            /// The registration
            /// </summary>
            [StringValue("Registration")]
            Registration,

            /// <summary>
            /// The login
            /// </summary>
            [StringValue("Login")]
            Login,

            /// <summary>
            /// The change mobile
            /// </summary>
            [StringValue("ChangeMobile")]
            ChangeMobile,

            /// <summary>
            /// The change mobile
            /// </summary>
            [StringValue("SettingChangeMobile")]
            SettingChangeMobile,

            /// <summary>
            /// The mobile verify
            /// </summary>
            [StringValue("MobileVerify")]
            MobileVerify,

            /// <summary>
            /// The resend OTP
            /// </summary>
            [StringValue("ResendOTP")]
            ResendOTP,

            /// <summary>
            /// The Pos recharge
            /// </summary>
            [StringValue("PosRecharge")]
            PosRecharge,

            /// <summary>
            /// Salvage Deposit Refund
            /// </summary>
            [StringValue("SalvageDepositRefund")]
            SalvageDepositRefund,

            /// <summary>
            /// Buy Now Mobile Verification
            /// </summary>
            [StringValue("BuyNowMobileVerification")]
            BuyNowMobileVerification,

            /// <summary>
            /// Buy Now Mobile Verification
            /// </summary>
            [StringValue("UnlockUserAccount")]
            UnlockUserAccount,

            /// <summary>
            /// Mobile Verification To Get Purchased POS Of Customer
            /// </summary>
            [StringValue("PurchasedCustomersPOS")]
            PurchasedCustomersPOS
        }

        public enum EmailSourceStatusMaster
        {
            [StringValue("SalvageCustomerRegistered")]
            SalvageCustomerRegistered = 5301,
            [StringValue("SalvagePaymentCompleted")]
            SalvagePaymentCompleted = 5302,
            [StringValue("SalvageSADADBillAuctionWon")]
            SalvageSADADBillAuctionWon = 5303,
            [StringValue("SalvageSADADBillDepositDetails")]
            SalvageSADADBillDepositDetails = 5304,
            [StringValue("SalvageSADADBillTimedOut")]
            SalvageSADADBillTimedOut = 5305,
            [StringValue("SalvageSADADBillBuyNow")]
            SalvageSADADBillBuyNow = 5306,
            [StringValue("SalvageSADADDepositDetails")]
            SalvageSADADDepositDetails = 5307,
            [StringValue("SalvagePendingPaymentDetails")]
            SalvagePendingPaymentDetails = 5308,
            [StringValue("SalvageAuctionDetailURL")]
            SalvageAuctionDetailURL = 5309,
            [StringValue("SalvageShareYardLocation")]
            SalvageShareYardLocation = 5310,
            [StringValue("SalvagePendingICConfimrationNotification")]
            SalvagePendingICConfimrationNotification = 5311,
            [StringValue("SalvagePendingICConfimrationEscalation")]
            SalvagePendingICConfimrationEscalation = 5312,
            [StringValue("SalvageStatisticsReportForIC")]
            SalvageStatisticsReportForIC = 5313,
            [StringValue("SalvageShareNetworkLocation")]
            SalvageShareNetworkLocation = 5314,
            [StringValue("SalvageShareYardLocationForIC")]
            SalvageShareYardLocationForIC = 5315,
            [StringValue("SalvageShareNetworkLocationForIC")]
            SalvageShareNetworkLocationForIC = 5316,
            [StringValue("SalvageProviderInspectorRegistration")]
            SalvageProviderInspectorRegistration = 5317,
            [StringValue("SalvageProviderDriverRegistration")]
            SalvageProviderDriverRegistration = 5318,
            [StringValue("SalvageRejectedPendingActionNotification")]
            SalvageRejectedPendingActionNotification = 5319,
            [StringValue("SalvageRejectedPendingActionEscalation")]
            SalvageRejectedPendingActionEscalation = 5320,
            [StringValue("SalvageForgotPassword")]
            SalvageForgotPassword = 5321,
            [StringValue("SalvageLimitedAuctionBid")]
            SalvageLimitedAuctionBid = 5322,
            [StringValue("SalvageUserPasswordChanged")]
            SalvageUserPasswordChanged = 5323,
            [StringValue("SalvageUserAliasNameChanged")]
            SalvageUserAliasNameChanged = 5324,
            [StringValue("SalvageUserEmailChanged")]
            SalvageUserEmailChanged = 5325,
            [StringValue("SalvageExitAuction")]
            SalvageExitAuction = 5326,
            [StringValue("SalvageSADADBillReGeneratedForIC")]
            SalvageSADADBillReGeneratedForIC = 5327,
            [StringValue("SalvageDepositRefundRequest")]
            SalvageDepositRefundRequest = 5328,
            [StringValue("SalBwaDepositRefunded")]
            SalBwaDepositRefunded = 5329,
            [StringValue("SalvageBwabatiUserRegister")]
            SalvageBwabatiUserRegister = 5330,
            [StringValue("SalvageBwabatiUserRoleAssigned")]
            SalvageBwabatiUserRoleAssigned = 5331,
            [StringValue("SalvageProviderInspectorResetPassword")]
            SalvageProviderInspectorResetPassword = 5332,
            [StringValue("SalvageProviderDriverResetPassword")]
            SalvageProviderDriverResetPassword = 5333,
            [StringValue("SalvageBlacklisted")]
            SalvageBlacklisted = 5334,
            [StringValue("SalvageDepositPaymentCompleted")]
            SalvageDepositPaymentCompleted = 5335,
            [StringValue("SalvageDepositDedectued")]
            SalvageDepositDedectued = 5336,
            [StringValue("SalvageWatchListBidds")]
            SalvageWatchListBidds = 5337,
            [StringValue("SalvageAuctionEnded")]
            SalvageAuctionEnded = 5338,
            [StringValue("SalvageAuctionPendingPaymentReminder")]
            SalvageAuctionPendingPaymentReminder = 5339,
            [StringValue("SalvageLockedUser")]
            SalvageLockedUser = 5340,
            [StringValue("SalvageRepairEstimationRequestCompleted")]
            SalvageRepairEstimationRequestCompleted = 5341,
            [StringValue("SalvageRefundAdditionalRequestBuyNow")]
            SalvageRefundAdditionalRequestBuyNow = 5342,
            [StringValue("SalvageCompleteAdditionalRequest")]
            SalvageCompleteAdditionalRequest = 5343,
            [StringValue("SalvageAuctionAdditionalServiceRequestPayment")]
            SalvageAuctionAdditionalServiceRequestPayment = 5344,
            [StringValue("SalvageAdditionalServiceRequestRefunded")]
            SalvageAdditionalServiceRequestRefunded = 5345,
            [StringValue("SalvagePayfortPolicyRefundFailedEmail")]
            SalvagePayfortPolicyRefundFailedEmail = 5346,
            [StringValue("SalvagePayfortPolicyTechnicalFailedEmail")]
            SalvagePayfortPolicyTechnicalFailedEmail = 5347,
            [StringValue("SalvagePayfortPolicyVoidEmail")]
            SalvagePayfortPolicyVoidEmail = 5348,
            [StringValue("SalvagePayfortPolicyVoidFailedEmail")]
            SalvagePayfortPolicyVoidFailedEmail = 5349,
            [StringValue("SalvagePurchasedPolicyRefund")]
            SalvagePurchasedPolicyRefund = 5350,
            [StringValue("BankTransferPaymentAction")]
            BankTransferPaymentAction = 5351,
            [StringValue("SalvageTransactionVerified")]
            SalvageTransactionVerified = 5352,
            [StringValue("SalvageBankTransferBillBuyNow")]
            SalvageBankTransferBillBuyNow = 5353,
            [StringValue("SalvageBankTransferTransactionSubmit")]
            SalvageBankTransferTransactionSubmit = 5354,
            [StringValue("SalvageBankTransferPendingPaymentReminder")]
            SalvageBankTransferPendingPaymentReminder = 5355,
            [StringValue("SalvageTransactionRejected")]
            SalvageTransactionRejected = 5356,
            [StringValue("SalvageBankDepositDetails")]
            SalvageBankDepositDetails = 5357,
            [StringValue("SalvageBankDepositShareDetails")]
            SalvageBankDepositShareDetails = 5358,
            [StringValue("ForeignAccountAwaitingApproval")]
            ForeignAccountAwaitingApproval = 5359,
            [StringValue("SalvageBankTransferBillAuctionWon")]
            SalvageBankTransferBillAuctionWon = 5360,
            [StringValue("SalvageDepositTransactionVerified")]
            SalvageDepositTransactionVerified = 5361,
            [StringValue("SalvageDepositTransactionRejected")]
            SalvageDepositTransactionRejected = 5362,
            [StringValue("SalvageDepositBankTransferTransactionSubmit")]
            SalvageDepositBankTransferTransactionSubmit = 5363,
            [StringValue("ForeignAccountAdminVerification")]
            ForeignAccountAdminVerification = 5364,
            [StringValue("SalvageRegisteredCarTowedNotification")]
            SalvageRegisteredCarTowedNotification = 5365,
            [StringValue("SalvageBankTransferBillBuyNowForeignAccount")]
            SalvageBankTransferBillBuyNowForeignAccount = 5366,
            [StringValue("BankTransferPaymentActionForeignAccount")]
            BankTransferPaymentActionForeignAccount = 5367,
            [StringValue("SalvageBankTransferPendingPaymentReminderFrgnAcc")]
            SalvageBankTransferPendingPaymentReminderFrgnAcc = 5368,
            [StringValue("RefundRequestReceivedNotificationKSA")]
            RefundRequestReceivedNotificationKSA = 5369,
            [StringValue("RefundRequestReceivedNotificationUAE")]
            RefundRequestReceivedNotificationUAE = 5370,
            [StringValue("SalvagePOSAddedNotification")]
            SalvagePOSAddedNotification = 5371,
            [StringValue("POSStageNotChangedLongTimeNotification")]
            POSStageNotChangedLongTimeNotification = 5372,
            [StringValue("PaymentNotCompletedAuctionNotificationKSA")]
            PaymentNotCompletedAuctionNotificationKSA = 5373,
            [StringValue("PaymentNotCompletedAuctionNotificationUAE")]
            PaymentNotCompletedAuctionNotificationUAE = 5374,
            [StringValue("PaymentNotCompletedDepositNotificationKSA")]
            PaymentNotCompletedDepositNotificationKSA = 5375,
            [StringValue("PaymentNotCompletedDepositNotificationUAE")]
            PaymentNotCompletedDepositNotificationUAE = 5376,
            [StringValue("VechilePaymentCombinedBillGeneratedNotification")]
            VechilePaymentCombinedBillGeneratedNotification = 5377,
            [StringValue("SalvageSadadOneBillPaymentReminder")]
            SalvageSadadOneBillPaymentReminder = 5378,
            [StringValue("SalvageSadadOneBillPaymentCompleted")]
            SalvageSadadOneBillPaymentCompleted = 5379,
            [StringValue("SalvageSadadOneBillPaymentTimeout")]
            SalvageSadadOneBillPaymentTimeout = 5380,
            [StringValue("SalvagePendingPaymentDetailsOneBill")]
            SalvagePendingPaymentDetailsOneBill = 5381,
            [StringValue("OwnershipTransferProofSubmitted")]
            OwnershipTransferProofSubmitted = 5382,
            [StringValue("OwnershipTransferProofApproved")]
            OwnershipTransferProofApproved = 5383,
            [StringValue("OwnershipTransferProofReject")]
            OwnershipTransferProofReject = 5384,
            [StringValue("SalvageIcCreditNoteNotification")]
            SalvageIcCreditNoteNotification = 5385,
            [StringValue("SalvageIcDebitNoteNotification")]
            SalvageIcDebitNoteNotification = 5386,
            [StringValue("SalvageCustomerWaiverInfoFirstTime")]
            SalvageCustomerWaiverInfoFirstTime = 5387,
            [StringValue("AttestedWaiverDocumentChanged")]
            AttestedWaiverDocumentChanged = 5388,     
            [StringValue("AttestedWaiverDocumentUploaded")]
            AttestedWaiverDocumentUploaded = 5389,
            [StringValue("SalvageIcWaiverLetterNotification")]
            SalvageIcWaiverLetterNotification = 5390
        }

        /// <summary>
        /// POS Stages Master
        /// </summary>
        /// <returns></returns>
        /// <createdBy> Krishna Palan</createdBy>
        /// <createdDate>21/8/17 </createdDate>
        public enum POSStagesMaster
        {
            /// <summary>
            /// Entered Yard
            /// </summary>
            InspectionCompleted = 1,

            /// <summary>
            /// Towing Requested
            /// </summary>
            TowingRequested = 2,

            /// <summary>
            /// Car Towed
            /// </summary>
            CarTowed = 3,

            /// <summary>
            /// Waiting Payment
            /// </summary>
            WaitingPayment = 4,

            /// <summary>
            /// Payment Completed
            /// </summary>
            PaymentCompleted = 5,

            /// <summary>
            /// Pending Action
            /// </summary>
            PendingAction = 6,

            /// <summary>
            /// Delivered
            /// </summary>
            Delivered = 7,

            /// <summary>
            /// Waiting Yard Delivery
            /// </summary>
            WaitingYardDelivery = 8,

            /// <summary>
            /// Under Bidding
            /// </summary>
            UnderBidding = 9,

            /// <summary>
            /// No Action
            /// </summary>
            NoAction = 10,

            /// <summary>
            /// Photo Upload
            /// </summary>
            PhotoUpload = 11,

            /// <summary>
            /// Pending IC Confirmation
            /// </summary>
            PendingICConfirmation = 12,

            /// <summary>
            /// Pending Ownership Transfer
            /// </summary>
            PendingOwnershipTransfer = 13,

            /// <summary>
            /// Pending Customer Pickup
            /// </summary>
            PendingCustomerPickup = 14,

            /// <summary>
            /// Waiting for Bidding
            /// </summary>
            WaitingforBidding = 15,

            /// <summary>
            /// Settled
            /// </summary>
            Settled = 16,

            /// <summary>
            /// Pending Action By Provider
            /// </summary>
            PendingActionByProvider = 17,
        }

        /// <summary>
        /// Towing Request Stage Master
        /// </summary>
        /// <returns></returns>
        /// <createdBy> Krishna Palan</createdBy>
        /// <createdDate>04/10/17 </createdDate>
        public enum TowingStageMaster
        {
            /// <summary>
            /// Submitted
            /// </summary>
            Submitted = 1,

            /// <summary>
            /// Command Center
            /// </summary>
            CommandCenter = 2,

            /// <summary>
            /// Driver Assigned
            /// </summary>
            DriverAssigned = 3,

            /// <summary>
            /// Driver Arrived
            /// </summary>
            DriverArrived = 4,

            /// <summary>
            /// Car Towed
            /// </summary>
            CarTowed = 5,

            /// <summary>
            /// Photo Upload
            /// </summary>
            PhotoUpload = 6,

            /// <summary>
            /// Rejected
            /// </summary>
            Rejected = 7,

            /// <summary>
            /// Reverted
            /// </summary>
            Reverted = 8,

            /// <summary>
            /// Delivered
            /// </summary>
            Delivered = 9,

            /// <summary>
            /// Cancelled
            /// </summary>
            Cancelled = 10
        }

        /// <summary>
        /// Towing Request Status Master
        /// </summary>
        /// <returns></returns>
        /// <createdBy> Krishna Palan</createdBy>
        /// <createdDate>04/10/17 </createdDate>
        public enum TowingStatusMaster
        {
            /// <summary>
            /// OnProcess
            /// </summary>
            OnProcess = 1,

            /// <summary>
            /// Closed
            /// </summary>
            Closed = 2
        }

        #region SearchPOSEnums

        public enum ConditionalOperator
        {
            And = 0,
            OR = 1
        }

        /// <summary>
        /// Operation type of serach criteria for POS.
        /// </summary>
        /// <createdby>AhmedMustafa</createdby>
        /// <createdon>12/02/2018</createdon>
        public enum POSSearchOperatorPurchasedPOS
        {
            /// <summary>
            /// Equal
            /// </summary>
            [StringValue("Equal")]
            Equal = 1,

            /// <summary>
            ///Not Equal
            /// </summary>
            [StringValue("NotEqual")]
            NotEqual = 2,

            /// <summary>
            /// Contains
            /// </summary>
            [StringValue("Contains")]
            Contains = 3,

            /// <summary>
            ///Between
            /// </summary>
            [StringValue("Between")]
            Between = 4,

            /// <summary>
            /// GreaterThan
            /// </summary>
            [StringValue("Greater Than")]
            GreaterThan = 5,

            /// <summary>
            /// LessThan
            /// </summary>
            [StringValue("Less Than")]
            LessThan = 6
        }

        public enum ScreenFrom
        {
            InpectPOS = 1,
            PublishPOS = 2,
            CheckoutPOS = 3,
            CheckinPOS = 4,
            PickupPOS = 5,
            InprogressPOS = 6,
            InYardPOS = 7,
        }

        /// <summary>
        /// Serach Criteria For Purchased POS.
        /// </summary>
        /// <createdby>AhmedMustafa</createdby>
        /// <createdon>12/02/2018</createdon>
        public enum POSSearchByPurchasedPOS
        {
            /// <summary>
            /// Make
            /// </summary>
            [StringValue("Make")]
            Make = 1,

            /// <summary>
            ///Model
            /// </summary>
            [StringValue("Model")]
            Model = 2,

            /// <summary>
            /// ManufactureYear
            /// </summary>
            [StringValue("ManufactureYear")]
            ManufactureYear = 3,

            /// <summary>
            /// Payment Ref Number
            /// </summary>
            [StringValue("PaymentRefNo")]
            PaymentRefNo = 4,

            /// <summary>
            /// AuctionID
            /// </summary>
            [StringValue("AuctionID")]
            AuctionID = 5,

            /// <summary>
            ///Yard
            /// </summary>
            [StringValue("Yard")]
            Yard = 6
        }

        #endregion

        /// <summary>
        /// Filter type for My Auction page
        /// </summary>
        public enum MyAuctionsFilterType
        {
            [StringValue("UnderBidding")]
            UnderBidding = 1,

            [StringValue("Ended")]
            Ended = 2,
        }

        /// <summary>
        /// Customer auction filter type
        /// </summary>
        public enum CustomerAuctionFilterType
        {
            [StringValue("UnderBidding")]
            UnderBidding = 0,

            [StringValue("Ended")]
            Ended = 1,
        }

        /// <summary>
        /// Filter By Month
        /// </summary>
        public enum FilterBy
        {
            [StringValue("ThisMonth")]
            ThisMonth = 1,

            [StringValue("LastThreeMonth")]
            LastThreeMonth = 2,

            [StringValue("LastYear")]
            LastYear = 3,

            [StringValue("All")]
            All = 99,

        }

        /// <summary>
        /// Response Message for Palce Auction Bid
        /// </summary>
        public enum AuctionPlaceBidMessage
        {
            [StringValue("Success")]
            Success = 1,

            [StringValue("ErrorNoDepositAvailable")]
            ErrorNoDepositAvailable = 2,

            [StringValue("ErrorLastBidAmount")]
            ErrorLastBidAmount = 3,

            [StringValue("ErrorMinimumIncrementalBidAmount")]
            ErrorMinimumIncrementalBidAmount = 4,

            [StringValue("ErrorStartingBidAmount")]
            ErrorStartingBidAmount = 5
        }

        public enum CustomizeErrors
        {
            /// <summary>
            /// The code error
            /// </summary>
            [StringValue("Code Error")]
            CodeError = 1001
        }

        public enum POSDeliveryMethod
        {
            /// <summary>
            /// Insurance Company will Deliver POS to Yard
            /// </summary>
            [StringValue("Insurance Company will Deliver POS to Yard")]
            InsuranceCompanyDeliverPOS = 1,

            /// <summary>
            /// I Need a Towing Truck
            /// </summary>
            [StringValue("I Need a Towing Truck")]
            NeedTowingTruck = 2,


            /// <summary>
            /// Pickup POS By Customer
            /// </summary>
            [StringValue("Customer will pickup POS from yard")]
            CustomerPickUp = 3
        }

        public enum POSAuctionEndedState
        {
            /// <summary>
            /// Ended With Highest Bid
            /// </summary>
            EndedWithHighestBid = 1,

            /// <summary>
            /// Ended With Highest Bid
            /// </summary>
            EndedWithMinimumBid = 2,

            /// <summary>
            /// Ended With No Bid
            /// </summary>
            EndedWithNoBid = 3
        }

        public enum POSPaymentStatus
        {
            [StringValue("Pending")]
            Pending = 1,
            [StringValue("Completed")]
            Completed = 2,
            [StringValue("Expired")]
            Expired = 3,
            [StringValue("First Trial")]
            FirstTrial = 4,
            [StringValue("Second Trial")]
            SecondTrial = 5,
            [StringValue("Third Trial")]
            ThirdTrial = 6,
            [StringValue("Upload Pending")]
            UploadPending = 7,
            [StringValue("Upload Failed")]
            UploadFailed = 8,
            [StringValue("Pending Transaction")]
            PendingTransaction = 9,
            [StringValue("Under Review")]
            UnderReview = 10,
            [StringValue("Verified")]
            Verified = 11,
            [StringValue("Rejected")]
            Rejected = 12
        }

        public enum DepositPaymentStatus
        {
            [StringValue("Pending")]
            Pending = 1,
            [StringValue("Completed")]
            Completed = 2,
            [StringValue("Expired")]
            Expired = 3,
            [StringValue("First Trial")]
            FirstTrial = 4,
            [StringValue("Second Trial")]
            SecondTrial = 5,
            [StringValue("Third Trial")]
            ThirdTrial = 6,
            [StringValue("Pending Transaction")]
            PendingTransaction = 7,
            [StringValue("Under Review")]
            UnderReview = 8,
            [StringValue("Verified")]
            Verified = 9,
            [StringValue("Rejected")]
            Rejected = 10
        }

        public enum POSStatusReasonMaster
        {

            [StringValue("Bidding Closed with No bids")]
            BiddingClosedwithNobids = 1,
            [StringValue("Bidding Closed with bids below 'Minimum Price'")]
            BiddingClosedWithBidsBelowMinimumPrice = 2,
            [StringValue("SADAD Payment Not Completed")]
            SADADPaymentNotCompleted = 3,
            [StringValue("Buy Now Payment Not Completed")]
            BuyNowPaymentNotCompleted = 4,
            [StringValue("Auction Closed by Provider")]
            AuctionClosedbyProvider = 5,
            [StringValue("Auction Closed by Admin")]
            AuctionClosedbyAdmin = 6,
            [StringValue("Other")]
            NotSoldOther = 7,
            [StringValue("Missing Parts in POS")]
            MissingPartsInPOS = 8,
            [StringValue("Different POS Details")]
            DifferentPOSDetails = 9,
            [StringValue("Towing Rejected By Driver/Provider")]
            TowingRejectedByDriverProvider = 10,
            [StringValue("POS/Customer does not exist")]
            POSCustomerDoesNotExist = 11,
            [StringValue("Missing Documents")]
            MissingDocuments = 12,
            [StringValue("Wrong POS Location")]
            WrongPOSLocation = 13,
            [StringValue("Other")]
            RejectOther = 14,
            [StringValue("Duplicated")]
            Duplicated = 15,
            [StringValue("Not interested")]
            Notinterested = 16,
            [StringValue("Car already sold")]
            CarAlreadySold = 17,
            [StringValue("Other")]
            CancelOther = 18,
            [StringValue("IC request to stop the Auction")]
            ICRequestToStopTheAuction = 19,
            [StringValue("Dispute")]
            Dispute = 20,
            [StringValue("Rejected & Returned")]
            RejectedAndReturned = 21,
            [StringValue("Towing Driver Returned POS")]
            TowingDriverReturnedPOS = 22,
            [StringValue("Other")]
            TowingOther = 23,
            [StringValue("BankTransferPaymentNotCompleted")]
            BankTransferPaymentNotCompleted = 24,
            [StringValue("BankTransferPaymentRejected")]
            BankTransferPaymentRejected = 25
        }

        public enum PurchasedPOSListType
        {
            /// <summary>
            /// The OnGoing
            /// </summary>
            [StringValue("OnGoing")]
            OnGoing = 1,

            /// <summary>
            /// The Completed
            /// </summary>
            [StringValue("Completed")]
            Completed = 2
        }

        /// <summary>
        /// Choose AccountType for User Registration
        /// </summary>
        public enum AccountType
        {
            /// <summary>
            /// The Golden
            /// </summary>
            [StringValue("Golden")]
            Golden = 1,

            /// <summary>
            /// The Silver
            /// </summary>
            [StringValue("Silver")]
            Silver = 2
        }

        /// <summary>
        /// Choose ScreenAlias to log the number of views
        /// </summary>
        public enum ScreenAliasForVisitLog
        {
            /// <summary>
            /// The POS Detail
            /// </summary>
            [StringValue("POSDetail")]
            POSDetail = 1
        }

        public enum LatestActivityDuration
        {
            Last7Days = 1,
            Last2Weeks = 2,
            LastMonth = 3,
            Last3Months = 4,
        }

        public enum FeesTypeCode
        {
            [StringValue("CUSTCOMMISSION")]
            CUSTCOMMISSION,
            [StringValue("RELIST")]
            RELIST,
            [StringValue("EXPORTDELIVERYFEES")]
            EXPORTDELIVERYFEES
        }

        public enum TaxTypeCode
        {
            [StringValue("VAT")]
            VAT,
            [StringValue("VATUAE")]
            VATUAE
        }

        /// <summary>
        /// Enumeration for Freshdesk ticket type
        /// </summary>
        public enum TicketType
        {
            /// <summary>
            /// The general inquiry
            /// </summary>
            [StringValue("General Inquiry")]
            GeneralInquiry = 1,

            /// <summary>
            /// The problem
            /// </summary>
            [StringValue("Problem")]
            Problem,

            /// <summary>
            /// The suggestion
            /// </summary>
            [StringValue("Suggestion")]
            Suggestion,

            /// <summary>
            /// The other
            /// </summary>
            [StringValue("Other")]
            Other,

            /// <summary>
            /// The lead
            /// </summary>
            [StringValue("Lead")]
            Lead
        }

        /// <summary>
        /// IC Notification Type Code
        /// </summary>
        public enum IcNotificationTypeCode
        {
            [StringValue("PENDINGICCONFIRMESCALATION")]
            PENDINGICCONFIRMESCALATION,
            [StringValue("REJECTPENDINGACTIONESCALATION")]
            REJECTPENDINGACTIONESCALATION,
            [StringValue("STATISTICALREPORT")]
            STATISTICALREPORT,
            [StringValue("CARTOWEDNOTIFICATION")]
            CARTOWEDNOTIFICATION,
            [StringValue("PENDINGICCONFIRMATIONNOTIFICATION")]
            PENDINGICCONFIRMATIONNOTIFICATION,
            [StringValue("SOLDSETTLEMENTNOTIFICATION")]
            SOLDSETTLEMENTNOTIFICATION,
            [StringValue("UNSOLDSETTLEMENTNOTIFICATION")]
            UNSOLDSETTLEMENTNOTIFICATION,
            [StringValue("WAIVERLETTERREQUESTSNOTIFICATION")]
            WAIVERLETTERREQUESTSNOTIFICATION
        }

        public enum POSActionResult
        {
            [StringValue("Success")]
            Success = 600,

            [StringValue("ActionAlreadyPerformed")]
            ActionAlreadyPerformed = 601,

            [StringValue("POSNotExists")]
            POSNotExists = 602,

            [StringValue("POSStatusStageMismatch")]
            POSStatusStageMismatch = 603,

            [StringValue("POSImageAlreadyUploadedByAdmin")]
            POSImageAlreadyUploadedByAdmin = 604,

            [StringValue("ForcePasswordChange")]
            ForcePasswordChange = 801,
        }

        public enum DepositRefundRequestSearchBy
        {
            RefundRequestRefNo = 1,
            MobileNumber = 2,
            NationalIqamaID = 3,
            UserName = 4,
            RefundRequestDate = 5
        }

        public enum AuctionAspNetUsersSearchBy
        {
            Email = 1,
            FullName = 2,
            AliasName = 3,
            NationalIqamaID = 4,
            Mobile = 5,
            UserType = 6,
            Status = 7
        }

        public enum CustomerAuctionSearchBy
        {
            AuctionID = 1,
            POSMake = 2,
            POSModel = 3,
            POSManufactureYear = 4,
            AuctionEndDate = 5,
            Yard = 6
        }

        public enum DepositRefundSearchOperator
        {
            [StringValue("Equal")]
            Equal = 1,

            [StringValue("Between")]
            Between = 2,

            [StringValue("GreaterThan")]
            GreaterThan = 3,

            [StringValue("LessThan")]
            LessThan = 4
        }

        public enum ICContactType
        {
            [StringValue("Technical")]
            Technical = 1,

            [StringValue("Business")]
            Business = 2
        }


        public enum AuctionAspNetUsersSearchOperator
        {
            [StringValue("Equal")]
            Equal = 1,

            [StringValue("Contains")]
            Contains = 2,
        }

        public enum CustomerAuctionSearchOperator
        {
            [StringValue("Equal")]
            Equal = 1,

            [StringValue("Between")]
            Between = 2,

            [StringValue("GreaterThan")]
            GreaterThan = 3,

            [StringValue("LessThan")]
            LessThan = 4
        }


        /// <summary>
        /// Role search operation
        /// </summary>
        /// <Createdby>Mustafa </Createdby>
        public enum RoleSearchOperation
        {
            /// <summary>
            /// Equal
            /// </summary>
            [StringValue("Equal")]
            Equal = 1,

            /// <summary>
            /// Contains
            /// </summary>
            [StringValue("Contains")]
            Contains = 2,
        }
        /// <summary>
        /// role search by
        /// </summary>
        public enum RoleSearchBy
        {
            /// <summary>
            /// SequenceNumber
            /// </summary>
            [StringValue("RoleName")]
            RoleName = 1,

            /// <summary>
            ///CustomID
            /// </summary>
            [StringValue("UserType")]
            UserType = 2,

            /// <summary>
            /// SalvageRegNo
            /// </summary>
            [StringValue("Status")]
            Status = 3,
        }
        public enum RoleSearchOperator
        {
            /// <summary>
            /// Equal
            /// </summary>
            [StringValue("Equal")]
            Equal = 1,

            /// <summary>
            /// Contains
            /// </summary>
            [StringValue("Contains")]
            Contains = 2,
        }

        public enum Rights
        {
            [StringValue("View")]
            View = 1,

            [StringValue("Operation")]
            Operation = 2,

            [StringValue("Modify Customer Details")]
            ModifyCustomerDetails = 3,

            [StringValue("Blacklist Customer")]
            BlacklistCustomer = 4,

            [StringValue("Unblacklist Customer")]
            UnblacklistCustomer = 5,

            [StringValue("Publish Without Review")]
            PublishWithoutReview = 6,

            [StringValue("Review Publish")]
            ReviewPublish = 7,

            [StringValue("Update Waiver Details")]
            UpdateWaiverDetails = 8,

            [StringValue("Upload Missing Documents")]
            UploadMissingDocuments = 9
        }


        /// <summary>
        /// Enumeration for operation type.
        /// </summary>
        public enum OperationType
        {
            /// <summary>
            /// The edit
            /// </summary>
            Edit = 1,

            /// <summary>
            /// The delete
            /// </summary>
            Delete
        }


        /// <summary>
        /// Dealer Registration Status.
        /// </summary>
        public enum DealerRegistrationStatus
        {
            /// <summary>
            /// The pending
            /// </summary>
            Pending = 1,

            /// <summary>
            /// The approved
            /// </summary>
            Approved = 2
        }

        /// <summary>
        /// User Type.
        /// </summary>
        /// <createdby>Rujuta Xavier</createdby>
        /// <createdon>07/08/2015</createdon>
        /// <updatedby>Pranav Patel</editdby>
        /// <updatedon>26/09/2017</editedon>
        public enum UserType
        {
            /// <summary>
            /// The individual
            /// </summary>
            [StringValue("Internal")]
            Internal = 1,

            /// <summary>
            /// The dealer
            /// </summary>
            [StringValue("Dealer")]
            Dealer = 2,

            /// <summary>
            /// The insurance company
            /// </summary>
            [StringValue("Insurance Company")]
            InsuranceCompany = 3,

            /// <summary>
            /// The Pos
            /// </summary>
            [StringValue("Pos")]
            Pos = 4,

            [StringValue("Salvage Customer")]
            SalvageCustomer = 5,

            /// <summary>
            /// The Pos
            /// </summary>
            [StringValue("Salvage Inspector")]
            SalvageInspector = 6,


            /// <summary>
            /// The provider(Bawabati)
            /// </summary>
            [StringValue("Salvage Provider")]
            Bawabati = 7,

            /// <summary>
            /// The Salvage Driver
            /// </summary>
            [StringValue("Salvage Driver")]
            SalvageDriver = 8,

            /// <summary>
            /// The Salvage Driver
            /// </summary>
            [StringValue("AwalMazad System")]
            AwalMazadSystem = 9
        }

        /// <summary>
        /// Service Type.
        /// </summary>
        /// <createdby>Prakash Patel</createdby>
        /// <createdon>09-10-2015</createdon>
        public enum ServiceType
        {
            /// <summary>
            /// The technical
            /// </summary>
            [StringValue("Technical")]
            Technical,

            /// <summary>
            /// The business
            /// </summary>
            [StringValue("Business")]
            Business
        }

        /// <summary>
        /// Product Type for payment integration (Payfort)
        /// </summary>
        /// <version>1.0    13th June 18     AhmedMustafa</version>
        public enum ProductType
        {
            /// <summary>
            /// AMZ
            /// </summary>
            [StringValue("AMZ")]
            AwalMazad
        }

        /// <summary>
        /// PayFort Redirect Type
        /// </summary>
        public enum PayFortRedirectType
        {
            /// <summary>
            /// Optional
            /// </summary>
            [StringValue("Optional")]
            Optional,

            /// <summary>
            ///DirectFeedBack
            /// </summary>
            [StringValue("DirectFeedBack")]
            DirectFeedBack
        }

        /// <summary>
        /// Common Status.
        /// </summary>
        /// <createdby>Rujuta Xavier</createdby>
        /// <createdon>11/08/2015</createdon>
        public enum CommonStatus
        {
            /// <summary>
            /// The active
            /// </summary>
            [StringValue("Active")]
            Active = 5,

            /// <summary>
            /// The inactive
            /// </summary>
            [StringValue("Inactive")]
            Inactive = 6,

            /// <summary>
            /// The hold
            /// </summary>
            [StringValue("Hold")]
            Hold = 12,

            /// <summary>
            /// The reject
            /// </summary>
            [StringValue("Rejected")]
            Reject = 13,

            /// <summary>
            /// The approved
            /// </summary>
            [StringValue("Active")]
            Approved = 10,

            /// <summary>
            /// The pending
            /// </summary>
            [StringValue("Pending")]
            Pending = 11,

            /// <summary>
            /// The blocked
            /// </summary>
            [StringValue("Blocked")]
            Blocked = 15,

            /// <summary>
            /// The Blacklisted
            /// </summary>
            [StringValue("Blacklisted")]
            Blacklisted = 16,

            /// <summary>
            /// The Pending Unblock Approval
            /// </summary>
            [StringValue("Pending Unblock Approval")]
            PendingUnblockApproval = 17,
        }

        /// <summary>
        /// Role Type.
        /// </summary>
        /// <createdby>Rujuta Xavier</createdby>
        /// <createdon>1/09/2015</createdon>
        public enum RoleType
        {
            /// <summary>
            /// The admin
            /// </summary>
            [StringValue("Admin")]
            Admin,

            /// <summary>
            /// The user
            /// </summary>
            [StringValue("User")]
            User
        }

        /// <summary>
        /// Notification Value Type.
        /// </summary>
        /// <createdby>Dwarkesh</createdby>
        /// <createdon>10/09/2015</createdon>
        public enum NotificationType
        {
            /// <summary>
            /// The day
            /// </summary>
            [StringValue("DAY")]
            DAY,

            /// <summary>
            /// The SAR
            /// </summary>
            [StringValue("SAR")]
            SAR
        }

        /// <summary>
        /// Notification Value Type.
        /// </summary>
        /// <createdby>Dwarkesh</createdby>
        /// <createdon>10/09/2015</createdon>
        /// <updatedby>Rujuta Xavier</updatedby>
        /// <updatedon>23/05/2016</updatedon>
        /// <updates>Setting start value.</updates>
        public enum CarUniqueIDType
        {
            /// <summary>
            /// The sequence no
            /// </summary>
            [StringValue("SequenceNo")]
            SequenceNo = 1,

            /// <summary>
            /// The custom identifier
            /// </summary>
            [StringValue("CustomID")]
            CustomID = 2,
        }

        /// <summary>
        /// POS Identifier Type enumeration
        /// </summary>
        /// <createdby>Rujuta Xavier</createdby>
        /// <createdon>21/05/2016</createdon>
        public enum POSIdentifierType
        {
            /// <summary>
            /// The custom card
            /// </summary>
            [StringValue("Custom Card")]
            CustomCard,

            /// <summary>
            /// The registration card
            /// </summary>
            [StringValue("Registration Card")]
            RegistrationCard,
        }

        /// <summary>
        /// Payment Type.
        /// </summary>
        /// <createdby>Rujuta Xavier</createdby>
        /// <createdon>23/09/2015</createdon>
        /// <version>2.0    13th June 18     AhmedMustafa</version>
        public enum PaymentType
        {
            /// <summary>
            /// The SADAD
            /// </summary>
            [StringValue("SADAD")]
            SADAD = 1,

            /// <summary>
            /// The master card
            /// </summary>
            [StringValue("MasterCard")]
            MasterCard = 2,

            /// <summary>
            /// The visa
            /// </summary>
            [StringValue("VISA")]
            VISA = 3,

            /// <summary>
            /// Payment type BankTransfer
            /// </summary>
            [StringValue("BankTransfer")]
            BankTransfer = 4,
        }

        /// <summary>
        /// Allow access enumeration.
        /// </summary>
        /// <createdby>Rujuta Xavier</createdby>
        /// <createdon>29/09/2015</createdon>
        public enum AllowAccess
        {
            UserIsNotExists = -1,

            InActiveUser = -2,

            NotEnrolledWithSalvage = -3,

            AccessDenied = -4,

            AccessAllowed = 1,

            EnrolledWithSalvage = 2,
        }

        /// <summary>
        /// PaymentStatus enumeration.
        /// </summary>
        public enum PaymentStatus
        {
            /// <summary>
            /// The invalid request
            /// </summary>
            InvalidRequest = 0,

            /// <summary>
            /// The order stored
            /// </summary>
            OrderStored = 1,

            /// <summary>
            /// The authorization success
            /// </summary>
            AuthorizationSuccess = 2,

            /// <summary>
            /// The authorization failed
            /// </summary>
            AuthorizationFailed = 3,

            /// <summary>
            /// The capture success
            /// </summary>
            CaptureSuccess = 4,

            /// <summary>
            /// The capture failed
            /// </summary>
            Capturefailed = 5,

            /// <summary>
            /// The refund success
            /// </summary>
            RefundSuccess = 6,

            /// <summary>
            /// The refund failed
            /// </summary>
            RefundFailed = 7,

            /// <summary>
            /// The authorization voided successfully
            /// </summary>
            AuthorizationVoidedSuccessfully = 8,

            /// <summary>
            /// The authorization void failed
            /// </summary>
            AuthorizationVoidFailed = 9,

            /// <summary>
            /// The incomplete
            /// </summary>
            Incomplete = 10,

            /// <summary>
            /// The check status failed
            /// </summary>
            CheckstatusFailed = 11,

            /// <summary>
            /// The check status success
            /// </summary>
            Checkstatussuccess = 12,

            /// <summary>
            /// The purchase failure
            /// </summary>
            PurchaseFailure = 13,

            /// <summary>
            /// The purchase success
            /// </summary>
            PurchaseSuccess = 14,

            /// <summary>
            /// The uncertain transaction
            /// </summary>
            UncertainTransaction = 15,

            /// <summary>
            /// The tokenization failed
            /// </summary>
            Tokenizationfailed = 17,

            /// <summary>
            /// The tokenization success
            /// </summary>
            Tokenizationsuccess = 18,

            /// <summary>
            /// The transaction pending
            /// </summary>
            Transactionpending = 19,

            /// <summary>
            /// The on hold
            /// </summary>
            Onhold = 20,

            /// <summary>
            /// The SDK token creation failure
            /// </summary>
            SDKtokencreationfailure = 21,

            /// <summary>
            /// The SKD token creation success
            /// </summary>
            SDKtokencreationsuccess = 22
        }

        /// <summary>
        /// Enumeration for track ticket status.
        /// </summary>
        public enum TrackTicketStatus
        {
            /// <summary>
            /// The open
            /// </summary>
            Open = 2,

            /// <summary>
            /// The pending
            /// </summary>
            Pending = 3,

            /// <summary>
            /// The resolved
            /// </summary>
            Resolved = 4,

            /// <summary>
            /// The closed
            /// </summary>
            Closed = 5,
        }

        /// <summary>
        /// Enumeration time period.
        /// </summary>
        public enum TimePeriod
        {
            /// <summary>
            /// The days
            /// </summary>
            [StringValue("Day")]
            Days,

            /// <summary>
            /// The months
            /// </summary>
            [StringValue("Month")]
            Months,

            /// <summary>
            /// The years
            /// </summary>
            [StringValue("Year")]
            Years
        }

        /// <summary>
        /// Enumeration for screen alias
        /// </summary>
        /// <createdby>Rujuta Xavier</createdby>
        /// <createdon>08/02/2016</createdon>
        /// <updatedby>Rujuta Xavier</updatedby>
        /// <updatedon>09/02/2016</updatedon>
        /// <updates>Pos Admin Screen Alias added.</updates>
        /// <updatedby>Rujuta Xavier</updatedby>
        /// <updatedon>10/02/2016</updatedon>
        /// <updates>Insurance Company Screen Alias added.</updates>
        /// <updatedby>Rujuta Xavier</updatedby>
        /// <updatedon>12/09/2016</updatedon>
        /// <updates>Flags attribute added for testing and commented for the time being.</updates>
        /// <updatedBy>Pranav Patel</updatedBy>
        /// <updatedOn>28/08/2017</updatedOn>
        /// <updates>ScreenAlias added for bawabati</updates>
        //[Flags]
        public enum ScreenAlias
        {
            /// <summary>
            /// Manage salavge POS
            /// </summary>
            /// <addBy> Mustafa_24/08/17</addBy>
            [StringValue("managePOS")]
            SalvageManagePOS,

            /// <summary>
            /// The provider company dashboard
            /// </summary>
            [StringValue("providerdashboard")]
            ProviderDashboard,

            /// <summary>
            /// Provider Manage POS(s)
            /// </summary>
            [StringValue("providermanagePOS")]
            ProviderManagePOS,

            /// <summary>
            /// Provider Pending Action POSs
            /// </summary>
            [StringValue("providerpendingactionsPOSs")]
            PendingActionPOSs,

            /// <summary>
            /// Provider Pending Action POSs
            /// </summary>
            [StringValue("pendingactionsPOSsic")]
            PendingActionPOSsIC,

            /// <summary>
            /// Provider View Yard
            /// </summary>
            [StringValue("viewyard")]
            ViewYard,

            /// <summary>
            /// Broker View Payment
            /// </summary>
            [StringValue("viewpayment")]
            ViewPayment,

            /// <summary>
            /// salvage add POS
            /// </summary>
            /// <CreatedBy> Mustafa </CreatedBy>
            [StringValue("addsalvagePOS")]
            AddSalvagePOS,


            /// <summary>
            /// salvage dashboard
            /// </summary>
            /// <CreatedBy> Mustafa </CreatedBy>
            [StringValue("salvagedashboard")]
            SalvageDashboard,

            /// <summary>
            /// provider Settings for notification
            /// </summary>
            [StringValue("providersettings")]
            ProviderSettings,

            /// <summary>
            /// provider manage notification settings
            /// </summary>
            [StringValue("managenotification")]
            ManageNotification,

            /// <summary>
            /// provider manage user notification settings
            /// </summary>
            [StringValue("manageusernotification")]
            ManageUserNotification,

            /// <summary>
            /// Dynamic Report
            /// </summary>
            [StringValue("dynamicreport")]
            DynamicReport,

            /// <summary>
            /// Towing Command Center
            /// </summary>
            [StringValue("towingcommandcenter")]
            TowingCommandCenter,

            /// <summary>
            /// provider active shift
            /// </summary>
            [StringValue("activeshift")]
            ActiveShift,

            [StringValue("ManageInspectorDriverTruck")]
            ManageDriverInspectorTruck,

            /// <summary>
            /// Towing Command Center
            /// </summary>
            [StringValue("towingrequestsreport")]
            TowingRequestReport,

            /// <summary>
            /// Towing Command Center
            /// </summary>
            [StringValue("paymentsnotcompleted")]
            PaymentsNotCompleted,

            [StringValue("ManageUser")]
            ManageUser,

            [StringValue("providerpendingactionsPOSs")]
            providerpendingactionsPOSs,

            [StringValue("AuctionAspNetUsers")]
            AuctionAspNetUsers,

            [StringValue("DepositRefundRequests")]
            DepositRefundRequests,

            [StringValue("paymentsnotcompleted")]
            paymentsnotcompleted,

            [StringValue("RoleMaster")]
            RoleMaster,

            [StringValue("salvageinsurancecompanies")]
            SalvageInsuranceCompanies,

            [StringValue("AdminDashboard")]
            AdminDashboard,

            [StringValue("SalvageManagerDashboard")]
            SalvageManagerDashboard,

            [StringValue("SalvageICDashboard")]
            SalvageICDashboard,

            [StringValue("InspectorDriverShiftReport")]
            InspectorDriverShiftReport,

            [StringValue("pendingactionsPOSsic")]
            pendingactionsPOSsic,

            [StringValue("addmultiplePOSs")]
            MultiplePOS,

            [StringValue("UndoPOSTowRequest")]
            RevertProviderRequest,

            [StringValue("SalvageProviderDashboard")]
            SalvageProviderDashboard,

            [StringValue("NewAdditionalRequest")]
            NewAdditionalRequest,

            [StringValue("UnderProcessAdditionalRequest")]
            UnderProcessAdditionalRequest,

            [StringValue("CompletedAdditionalRequest")]
            CompletedAdditionalRequest,

            [StringValue("RefundedAdditionalRequest")]
            RefundedAdditionalRequest,

            [StringValue("ManageAdditionalRequest")]
            ManageAdditionalRequest,

            [StringValue("ViewAdditionalRequestDetail")]
            ViewAdditionalRequestDetail,

            [StringValue("AdditionalRequestDetail")]
            AdditionalRequestDetail,

            [StringValue("AdditionalRequestHistory")]
            AdditionalRequestHistory,

            [StringValue("AdditionalProcessrequest")]
            AdditionalProcessrequest,

            [StringValue("ViewAdditionalRequest")]
            ViewAdditionalRequest,

            [StringValue("TowRequestreport")]
            TowRequestreport,

            [StringValue("VatReport")]
            VatReport,

            [StringValue("POSsReconciliationReport")]
            POSsReconciliationReport,

            [StringValue("providercompany")]
            providercompany,

            [StringValue("AdditionalServiceReport")]
            AdditionalServiceReport,

            [StringValue("POSsAgeingReport")]
            POSsAgeingReport,

            [StringValue("Banktransactionreport")]
            Banktransactionreport,

            [StringValue("VerifyTransactions")]
            VerifyTransactions,

            [StringValue("ChangePaymentMethod")]
            ChangePaymentMethod,

            [StringValue("AuctionUserAccountConfiguration")]
            AuctionUserAccountConfiguration,

            [StringValue("SoldPOSs")]
            SoldPOSs,

            [StringValue("AccountVerification")]
            AccountVerification,

            [StringValue("BankTransactionReportUAE")]
            BankTransactionReportUAE,

            [StringValue("DepositBankTransactionReportUAE")]
            DepositBankTransactionReportUAE,

            [StringValue("DepositRefundRequestsUAE")]
            DepositRefundRequestsUAE,

            [StringValue("VerifyTransactionsUAE")]
            VerifyTransactionsUAE,

            [StringValue("VerifyDepositTransactionsUAE")]
            VerifyDepositTransactionsUAE,

            [StringValue("SMSEmailHistory")]
            SMSEmailHistory,

            [StringValue("POSTypesAndPhotos")]
            POSTypesAndPhotos,

            [StringValue("CurrencyExchangeRate")]
            CurrencyExchangeRate,

            [StringValue("PendingICConfirmation")]
            PendingICConfirmation,

            [StringValue("confirmedPOSslist")]
            confirmedPOSslist,

            [StringValue("GeneralPermissions")]
            GeneralPermissions,

            [StringValue("ReviewPOSsToBePublished")]
            ReviewPOSsToBePublished,

            [StringValue("POSsTowingStorageFees")]
            POSsTowingStorageFees,

            [StringValue("UnsoldReturnedPOSsDebitNotes")]
            UnsoldReturnedPOSsDebitNotes,

            [StringValue("SoldPOSsCreditNotes")]
            SoldPOSsCreditNotes,

            [StringValue("Settlement")]
            Settlement,

            [StringValue("ProofOwnershipRequest")]
            ProofOwnershipRequest,

            [StringValue("PurchasedCustomersPOSs")]
            PurchasedCustomersPOSs,

            [StringValue("ViewWaiverRequest")]
            ViewWaiverRequest,

            [StringValue("PendingAttestationWaiverRequest")]
            PendingAttestationWaiverRequest,

            [StringValue("PendingWaiverInformationRequest")]
            PendingWaiverInformationRequest,

            [StringValue("CompletedWaiverRequest")]
            CompletedWaiverRequest,
            [StringValue("NetworkMaster")]
            NetworkMaster,

            [StringValue("RejectedAdditionalRequest")]
            RejectedAdditionalRequest,
        }

        /// <summary>
        /// Payment command enumeration.
        /// </summary>
        /// <createdby>Rujuta Xavier</createdby>
        /// <createdon>08/04/2016</createdon>
        public enum PaymentCommand
        {
            /// <summary>
            /// The authorization
            /// </summary>
            [StringValue("AUTHORIZATION")]
            AUTHORIZATION,

            /// <summary>
            /// The purchase
            /// </summary>
            [StringValue("PURCHASE")]
            PURCHASE
        }

        /// <summary>
        /// Payment Capture or Refund Command
        /// </summary>
        /// <createdby>Rujuta Xavier</createdby>
        /// <createdon>08/04/2016</createdon>
        public enum PaymentCaptureRefundCommand
        {
            /// <summary>
            /// The capture
            /// </summary>
            [StringValue("CAPTURE")]
            Capture,

            /// <summary>
            /// The refund
            /// </summary>
            [StringValue("REFUND")]
            Refund
        }

        /// <summary>
        /// SMSSentStatusMaster
        /// <createdby>Prakash Patel</createdby>
        /// <createdon>09-11-2016</createdon>
        /// </summary>
        public enum SMSSentStatusMaster
        {
            /// <summary>
            /// Pending
            /// </summary>
            [StringValue("Pending")]
            Pending = 1,

            /// <summary>
            /// Success
            /// </summary>
            [StringValue("Success")]
            Success = 2,

            /// <summary>
            /// Failure
            /// </summary>
            [StringValue("Failure")]
            Failure = 3,
        }

        /// <summary>
        /// SMS Source Status Master
        /// <createdby>Prakash Patel</createdby>
        /// <createdon>09-11-2016</createdon>
        /// </summary>
        public enum SMSSourceStatusMaster
        {
            [StringValue("ICInvalidLoginAttempt")]
            ICInvalidLoginAttempt = 5301,
            [StringValue("ChangeMobileSendOTP")]
            ChangeMobileSendOTP = 5302,
            [StringValue("SalvageOTP")]
            SalvageOTP = 5303,
            [StringValue("SalvagePaymentCompleted")]
            SalvagePaymentCompleted = 5304,
            [StringValue("SalvageSADADBillAuctionWon")]
            SalvageSADADBillAuctionWon = 5305,
            [StringValue("SalvageSADADBillDepositDetails")]
            SalvageSADADBillDepositDetails = 5306,
            [StringValue("SalvageSADADBillTimedOut")]
            SalvageSADADBillTimedOut = 5307,
            [StringValue("SalvageSADADBillBuyNow")]
            SalvageSADADBillBuyNow = 5308,
            [StringValue("SalvageSADADDepositDetails")]
            SalvageSADADDepositDetails = 5309,
            [StringValue("SalvagePendingPaymentDetails")]
            SalvagePendingPaymentDetails = 5310,
            [StringValue("SalvageAuctionURL")]
            SalvageAuctionURL = 5311,
            [StringValue("SalvageShareYardLocation")]
            SalvageShareYardLocation = 5312,
            [StringValue("SalvageShareNetworkLocationForIC")]
            SalvageShareNetworkLocationForIC = 5313,
            [StringValue("SalvageShareYardLocationForIC")]
            SalvageShareYardLocationForIC = 5314,
            [StringValue("SalvageDriverAssignForIC")]
            SalvageDriverAssignForIC = 5315,
            [StringValue("SalvageLimitedAuctionBid")]
            SalvageLimitedAuctionBid = 5316,
            [StringValue("SalvageUserPasswordChanged")]
            SalvageUserPasswordChanged = 5317,
            [StringValue("SalvageUserAliasNameChanged")]
            SalvageUserAliasNameChanged = 5318,
            [StringValue("SalvageUserEmailChanged")]
            SalvageUserEmailChanged = 5319,
            [StringValue("SalvageExitAuction")]
            SalvageExitAuction = 5320,
            [StringValue("SalvageSADADBillReGeneratedForIC")]
            SalvageSADADBillReGeneratedForIC = 5321,
            [StringValue("SalvageDepositRefundRequest")]
            SalvageDepositRefundRequest = 5322,
            [StringValue("SalBwaDepositRefunded")]
            SalBwaDepositRefunded = 5323,
            [StringValue("SalvageProviderInspectorResetPassword")]
            SalvageProviderInspectorResetPassword = 5324,
            [StringValue("SalvageProviderDriverResetPassword")]
            SalvageProviderDriverResetPassword = 5325,
            [StringValue("SalvageCustomerFullNameChanged")]
            SalvageCustomerFullNameChanged = 5326,
            [StringValue("SalvageShareSadadBillDetailsForProvider")]
            SalvageShareSadadBillDetailsForProvider = 5327,
            [StringValue("SalvageCustomerAliasChanged")]
            SalvageCustomerAliasChanged = 5328,
            [StringValue("SalvageCustomerEmailChanged")]
            SalvageCustomerEmailChanged = 5329,
            [StringValue("SalvageCustomerMobileNumberChanged")]
            SalvageCustomerMobileNumberChanged = 5330,
            [StringValue("SalvageCustomerNationalAddressChanged")]
            SalvageCustomerNationalAddressChanged = 5331,
            [StringValue("SalvageAuctionBuyNowForbiddenTime")]
            SalvageAuctionBuyNowForbiddenTime = 5332,
            [StringValue("SalvageAuctionAddDepositForbiddenTime")]
            SalvageAuctionAddDepositForbiddenTime = 5333,
            [StringValue("SalvageProviderRegenerateForbiddenTime")]
            SalvageProviderRegenerateForbiddenTime = 5334,
            [StringValue("SADADExpiredDeposit")]
            SADADExpiredDeposit = 5335,
            [StringValue("BawabatiShareAppLink")]
            BawabatiShareAppLink = 5336,
            [StringValue("SalvageLimitedAuctionBidders")]
            SalvageLimitedAuctionBidders = 5337,
            [StringValue("SalvageSADADBill")]
            SalvageSADADBill = 5338,
            [StringValue("SalvageDepositDedectued")]
            SalvageDepositDedectued = 5339,
            [StringValue("SalvageBlacklisted")]
            SalvageBlacklisted = 5340,
            [StringValue("SalvageDepositPaymentCompleted")]
            SalvageDepositPaymentCompleted = 5341,
            [StringValue("SalvageAuctionPendingPaymentReminder")]
            SalvageAuctionPendingPaymentReminder = 5342,
            [StringValue("SalvageRepairEstimationRequestCompleted")]
            SalvageRepairEstimationRequestCompleted = 5343,
            [StringValue("SalvageRefundAdditionalRequestBuyNow")]
            SalvageRefundAdditionalRequestBuyNow = 5344,
            [StringValue("SalvageCompleteAdditionalRequest")]
            SalvageCompleteAdditionalRequest = 5345,
            [StringValue("SalvageAuctionAdditionalServiceRequestPayment")]
            SalvageAuctionAdditionalServiceRequestPayment = 5346,
            [StringValue("SalvageAdditionalServiceRequestRefunded")]
            SalvageAdditionalServiceRequestRefunded = 5347,
            [StringValue("BankTransferPaymentAction")]
            BankTransferPaymentAction = 5348,
            [StringValue("SalvageTransactionVerified")]
            SalvageTransactionVerified = 5349,
            [StringValue("SalvageBankTransferBillBuyNow")]
            SalvageBankTransferBillBuyNow = 5350,
            [StringValue("SalvageBankTransferBillBankDetailSMS")]
            SalvageBankTransferBillBankDetailSMS = 5351,
            [StringValue("SalvageBankTransferTransactionSubmit")]
            SalvageBankTransferTransactionSubmit = 5352,
            [StringValue("SalvageBankTransferPendingPaymentReminder")]
            SalvageBankTransferPendingPaymentReminder = 5353,
            [StringValue("SalvageTransactionRejected")]
            SalvageTransactionRejected = 5354,
            [StringValue("SalvageBankDepositDetails")]
            SalvageBankDepositDetails = 5355,
            [StringValue("SalvageBankDepositBill")]
            SalvageBankDepositBill = 5356,
            [StringValue("SalvageBankDepositShareDetails")]
            SalvageBankDepositShareDetails = 5357,
            [StringValue("SalvageBankTransferBillAuctionWon")]
            SalvageBankTransferBillAuctionWon = 5358,
            [StringValue("SalvageDepositTransactionVerified")]
            SalvageDepositTransactionVerified = 5359,
            [StringValue("SalvageDepositTransactionRejected")]
            SalvageDepositTransactionRejected = 5360,
            [StringValue("SalvageDepositBankTransferTransactionSubmit")]
            SalvageDepositBankTransferTransactionSubmit = 5361,
            [StringValue("ForeignAccountAdminVerification")]
            ForeignAccountAdminVerification = 5362,
            [StringValue("SalvageProviderDriverRegistration")]
            SalvageProviderDriverRegistration = 5363,
            [StringValue("SalvageProviderInspectorRegistration")]
            SalvageProviderInspectorRegistration = 5364,
            [StringValue("SalvageBankTransferBillBankDetailSMSFrgnAcc")]
            SalvageBankTransferBillBankDetailSMSFrgnAcc = 5365,
            [StringValue("BankTransferPaymentActionForeignAccount")]
            BankTransferPaymentActionForeignAccount = 5366,
            [StringValue("AuctionInWatchList24HoursRemainingNotification")]
            AuctionInWatchList24HoursRemainingNotification = 5367,
            [StringValue("AuctionInWatchList4HoursRemainingNotification")]
            AuctionInWatchList4HoursRemainingNotification = 5368,
            [StringValue("AuctionInWatchList1HourRemainingNotification")]
            AuctionInWatchList1HourRemainingNotification = 5369,
            [StringValue("VechilePaymentCombinedBillGeneratedNotification")]
            VechilePaymentCombinedBillGeneratedNotification = 5370,
            [StringValue("SalvageSadadOneBillPaymentReminder")]
            SalvageSadadOneBillPaymentReminder = 5371,
            [StringValue("SalvageSadadOneBillPaymentCompleted")]
            SalvageSadadOneBillPaymentCompleted = 5372,
            [StringValue("SalvageSadadOneBillPaymentTimeout")]
            SalvageSadadOneBillPaymentTimeout = 5373,
            [StringValue("OwnershipTransferProofSubmitted")]
            OwnershipTransferProofSubmitted = 5374,
            [StringValue("OwnershipTransferProofApproved")]
            OwnershipTransferProofApproved = 5375,
            [StringValue("OwnershipTransferProofReject")]
            OwnershipTransferProofReject = 5376,
            [StringValue("SalvageCustomerWaiverInfoFirstTime")]
            SalvageCustomerWaiverInfoFirstTime = 5377,
            [StringValue("AttestedWaiverDocumentChanged")]
            AttestedWaiverDocumentChanged = 5378,
            [StringValue("AttestedWaiverDocumentUploaded")]
            AttestedWaiverDocumentUploaded = 5379
        }

        /// <summary>
        /// Attachemnt File Name
        /// </summary>
        public enum AttachmentFileName
        {
            [StringValue("PolicyDetails")]
            PolicyDetails,

            [StringValue("PolicyPaper")]
            PolicyPaper,

            [StringValue("InsuranceCard")]
            InsuranceCard,
        }

        // SendGrid Response
        public enum SendGridResponse
        {
            [StringValue("Accepted")]
            Accepted,

            [StringValue("Rejected")]
            Rejected,

            [StringValue("Unauthorized")]
            Unauthorized
        }

        public enum SadadLastPaymentNotificationType
        {
            [StringValue("Refund")]
            Refund = 1,

            [StringValue("ReIssue")]
            ReIssue = 2
        }

        public enum POSRepairPlace
        {
            [StringValue("Agency")]
            Agency = 1,

            [StringValue("Workshop")]
            Workshop = 2,
        }

        public enum EmailVerification
        {
            EmailVerified = 1,
            EmailNotVerified = -1,
            LinkExpired = -2,
            LinkUsed = -3
        }

        /// <summary>
        /// POS Status Master
        /// </summary>
        /// <returns></returns>
        /// <createdBy> Mustafa U </createdBy>
        /// <createdDate>7/09/17 </createdDate>
        public enum POSStatusMaster
        {
            /// <summary>
            /// Registered
            /// </summary>
            Registered = 1,

            /// <summary>
            /// Sold
            /// </summary>
            Sold = 2,

            /// <summary>
            /// Not Sold
            /// </summary>
            NotSold = 3,

            /// <summary>
            /// Rejected
            /// </summary>
            Rejected = 4,

            /// <summary>
            /// Cancelled
            /// </summary>
            Cancelled = 5,

            /// <summary>
            /// Disputed
            /// </summary>
            Disputed = 6
        }
        /// <summary>
        /// created by mustafa 7/9/17
        /// </summary>
        public enum POSDeliveryDetail
        {
            ICDeliverdToYard = 1,
            TowingTruck = 2
        }
        /// <summary>
        /// salvage dashboard chart enum based on stage and status
        /// </summary>
        /// <CreatedBy> Mustafa </CreatedBy>
        /// <CreatedDate> 12/09/17 </CreatedDate>
        public enum SalvageDashBoardChartDetail
        {
            SoldandDeliverd = 1,

            RejectandDeliverd = 2,

            RejectedandDeliverdReason = 3,

            SoldandDeliverdMonthwise = 4,

            RejectandDeliverdMonthWise = 5,

            RejectandDeliverdReasonMonthWise = 6
        }

        /// <summary>
        /// Serach Criteria For POS.
        /// </summary>
        /// <createdby>AhmedMustafa</createdby>
        /// <createdon>28/09/2017</createdon>
        /// <updated>Added column IsTotalLossDocumentReady, ConfirmationStatus and ConfirmationStatusComment</updated>
        public enum POSSearchBy
        {
            /// <summary>
            /// SequenceNumber
            /// </summary>
            [StringValue("SequenceNumber")]
            SequenceNumber = 1,

            /// <summary>
            ///CustomID
            /// </summary>
            [StringValue("CustomID")]
            CustomID = 2,

            /// <summary>
            /// SalvageRegNo
            /// </summary>
            [StringValue("SalvageReferenceNumber")]
            SalvageRefNo = 3,

            /// <summary>
            /// Make
            /// </summary>
            [StringValue("Make")]
            Make = 4,

            /// <summary>
            /// Model
            /// </summary>
            [StringValue("Model")]
            Model = 5,

            /// <summary>
            ///Status
            /// </summary>
            [StringValue("Status")]
            Status = 6,

            /// <summary>
            /// Stage
            /// </summary>
            [StringValue("Stage")]
            Stage = 7,

            /// <summary>
            /// DateOfRegistration
            /// </summary>
            [StringValue("DateOfRegistration")]
            DateOfRegistration = 8,


            /// <summary>
            /// AuctionID
            /// </summary>
            [StringValue("AuctionID")]
            AuctionID = 9,

            /// <summary>
            /// AuctionID
            /// </summary>
            [StringValue("Insurance Company")]
            InsuranceCompany = 10,

            [StringValue("PlateNumber")]
            PlateNumber = 11,
            ChasisID = 12,
            ManufactureYear = 13,
            Color = 14,
            Yard = 15,
            [StringValue("ProviderCompany")]
            ProviderCompany = 16,

            /// <summary>
            /// Claim Reference Number
            /// </summary>
            /// AhmedMustafa | 18 April 2019
            [StringValue("Claim Reference Number")]
            ClaimReferenceNumber = 17,

            /// <summary>
            /// Is Total-Loss Document Ready
            /// </summary>
            /// AhmedMustafa | 18 June 2019
            [StringValue("IsTotalLossDocumentReady")]
            IsTotalLossDocumentReady = 18,

            /// <summary>
            /// Confirmation Status
            /// </summary>
            /// AhmedMustafa | 18 June 2019
            [StringValue("ConfirmationStatus")]
            ConfirmationStatus = 19,

            /// <summary>
            /// Confirmation Status Comment
            /// </summary>
            /// AhmedMustafa | 18 June 2019
            [StringValue("ConfirmationStatusComment")]
            ConfirmationStatusComment = 20,

            [StringValue("PendingConfirmationDate")]
            PendingConfirmationDate = 21,

            [StringValue("OwnerFullName")]
            OwnerFullName = 22,

            [StringValue("InYardSince")]
            InYardSince = 23,

            [StringValue("IsSettled")]
            IsSettled = 24,

            [StringValue("TowingFees")]
            TowingFees = 25,

            [StringValue("AgencyClearanceFees")]
            AgencyClearanceFees = 26,

            [StringValue("SheikhExhibitionsEvaluationService")]
            SheikhExhibitionsEvaluationService = 27,

            [StringValue("TotalFees")]
            TotalFees = 28,

            [StringValue("DebitNoteNumber")]
            DebitNoteNumber = 29,

            [StringValue("ReturnRequestDate")]
            ReturnRequestDate = 30,

            [StringValue("ReturnedDate")]
            ReturnedDate = 31,

            [StringValue("SoldDate")]
            SoldDate = 32,

            [StringValue("SoldPrice")]
            SoldPrice = 33,

            [StringValue("CreditNoteNumber")]
            CreditNoteNumber = 34,

            [StringValue("IsSheikhOfExhibitionsEvaluationNeeded")]
            IsSheikhOfExhibitionsEvaluationNeeded = 35,

            /// <summary>
            /// Total-Loss Document Ready date
            /// </summary>
            [StringValue("TotalLossDocumentReadyDate")]
            TotalLossDocumentReadyDate = 36,
        }

        /// <summary>
        /// Confirmed POS search by
        /// </summary>
        public enum ConfirmedPOSSearchBy
        {
            /// <summary>
            /// SequenceNumber
            /// </summary>
            [StringValue("SequenceNumber")]
            SequenceNumber = 1,

            /// <summary>
            ///CustomID
            /// </summary>
            [StringValue("CustomID")]
            CustomID = 2,

            /// <summary>
            /// SalvageRegNo
            /// </summary>
            [StringValue("SalvageReferenceNumber")]
            SalvageRefNo = 3,

            /// <summary>
            /// Make
            /// </summary>
            [StringValue("Make")]
            Make = 4,

            /// <summary>
            /// Model
            /// </summary>
            [StringValue("Model")]
            Model = 5,

            /// <summary>
            ///Status
            /// </summary>
            [StringValue("Status")]
            Status = 6,

            /// <summary>
            /// Stage
            /// </summary>
            [StringValue("Stage")]
            Stage = 7,

            /// <summary>
            /// DateOfRegistration
            /// </summary>
            [StringValue("DateOfRegistration")]
            DateOfRegistration = 8,


            /// <summary>
            /// AuctionID
            /// </summary>
            [StringValue("AuctionID")]
            AuctionID = 9,

            /// <summary>
            /// AuctionID
            /// </summary>
            [StringValue("Insurance Company")]
            InsuranceCompany = 10,

            [StringValue("PlateNumber")]
            PlateNumber = 11,
            ChasisID = 12,
            ManufactureYear = 13,
            Color = 14,
            Yard = 15,
            [StringValue("ProviderCompany")]
            ProviderCompany = 16,

            /// <summary>
            /// Claim Reference Number
            /// </summary>
            /// AhmedMustafa | 18 April 2019
            [StringValue("Claim Reference Number")]
            ClaimReferenceNumber = 17,

            [StringValue("ElapsedDays")]
            ElapsedDays = 18,

            [StringValue("ICConfirmationDate")]
            ICConfirmationDate = 19,

            [StringValue("IsICConfirmationRequired")]
            IsICConfirmationRequired = 20
        }

        /// <summary>
        /// Additional service search criteria type
        /// </summary>
        /// <version>1.0    03rd August 18     AhmedMustafa</version>
        public enum AdditionalServicesSearchBy
        {
            [StringValue("RequestRef")]
            RequestRef = 1,

            [StringValue("AuctionId")]
            AuctionId = 2,

            [StringValue("RequestDate")]
            RequestDate = 3,

            [StringValue("RequestType")]
            RequestType = 4
        }

        /// <summary>
        /// Verify Transaction search criteria type
        /// </summary>
        /// <version>1.0    31st October 18     AhmedMustafa</version>
        public enum VerifyTransactionSearchBy
        {
            [StringValue("TransactionDate")]
            TransactionDate = 1,

            [StringValue("TransactionNumber")]
            TransactionNumber = 2,

            [StringValue("AuctionID")]
            AuctionID = 3,

            [StringValue("POSRefNumber")]
            POSRefNumber = 4,

            [StringValue("MobileNumber")]
            MobileNumber = 5
        }

        /// <summary>
        /// Verify deposit transaction search by
        /// </summary>
        /// <version>1.0    29th April 19     AhmedMustafa</version>
        public enum VerifyDepositTransactionSearchBy
        {
            [StringValue("TransactionDate")]
            TransactionDate = 1,

            [StringValue("TransactionNumber")]
            TransactionNumber = 2,

            [StringValue("DepositRefNo")]
            DepositRefNo = 3,

            [StringValue("MobileNumber")]
            MobileNumber = 4
        }

        public enum ServicePOSSearchBy
        {
            PlateNumber = 1,
            SequenceNumber = 2,
            CustomID = 3,
            SalvageRegNo = 4,
            InsuranceComany = 5,
            Status = 6,
            Stage = 7,
            Date = 8,
            TowingStage = 9,
            TowingStatus = 10,
            POSVin = 11
        }

        public enum ServicePOSSearchOperator
        {
            Equals = 1,
            NotEquals = 2,
            Contains = 3,
            Between = 4,
            Greater_than = 5,
            Less_than = 6
        }

        /// <summary>
        /// Operation type of serach criteria for POS.
        /// </summary>
        /// <createdby>AhmedMustafa</createdby>
        /// <createdon>28/09/2017</createdon>
        public enum POSSearchOperator
        {
            /// <summary>
            /// Equal
            /// </summary>
            [StringValue("Equal")]
            Equal = 1,

            /// <summary>
            ///Not Equal
            /// </summary>
            [StringValue("NotEqual")]
            NotEqual = 2,

            /// <summary>
            /// Contains
            /// </summary>
            [StringValue("Contains")]
            Contains = 3,

            /// <summary>
            ///Between
            /// </summary>
            [StringValue("Between")]
            Between = 4,

            /// <summary>
            /// GreaterThan
            /// </summary>
            [StringValue("Greater Than")]
            GreaterThan = 5,

            /// <summary>
            /// LessThan
            /// </summary>
            [StringValue("Less Than")]
            LessThan = 6
        }

        /// <summary>
        /// Confirmed POS search operator
        /// </summary>
        public enum ConfirmedPOSSearchOperator
        {
            /// <summary>
            /// Equal
            /// </summary>
            [StringValue("Equal")]
            Equal = 1,

            /// <summary>
            ///Not Equal
            /// </summary>
            [StringValue("NotEqual")]
            NotEqual = 2,

            /// <summary>
            /// Contains
            /// </summary>
            [StringValue("Contains")]
            Contains = 3,

            /// <summary>
            ///Between
            /// </summary>
            [StringValue("Between")]
            Between = 4,

            /// <summary>
            /// GreaterThan
            /// </summary>
            [StringValue("Greater Than")]
            GreaterThan = 5,

            /// <summary>
            /// LessThan
            /// </summary>
            [StringValue("Less Than")]
            LessThan = 6,

            [StringValue("Greater Than or Equal")]
            GreaterThanOrEqual = 7,

            [StringValue("Less Than or Equal")]
            LessThanOrEqual = 8,
        }

        /// <summary>
        /// POS types and photos search operator
        /// </summary>
        /// <version>1.0    20th May 19     AhmedMustafa</version>
        public enum POSTypesAndPhotosSearchOperator
        {
            [StringValue("Equal")]
            Equal = 1,

            [StringValue("NotEqual")]
            NotEqual = 2,

            [StringValue("Contains")]
            Contains = 3,

            [StringValue("Less Than")]
            LessThan = 4,

            [StringValue("Less Than or Equal")]
            LessThanOrEqual = 5,

            [StringValue("Greater Than")]
            GreaterThan = 6,

            [StringValue("Greater Than or Equal")]
            GreaterThanOrEqual = 7,

            [StringValue("Between")]
            Between = 8
        }

        /// <summary>
        /// Additional service search operator type
        /// </summary>
        /// <version>1.0    03rd August 18     AhmedMustafa</version>
        public enum AdditionalServicesSearchOperator
        {
            /// <summary>
            /// Equal
            /// </summary>
            [StringValue("Equal")]
            Equal = 1,

            /// <summary>
            ///Not Equal
            /// </summary>
            [StringValue("NotEqual")]
            NotEqual = 2,

            /// <summary>
            /// Contains
            /// </summary>
            [StringValue("Contains")]
            Contains = 3,

            /// <summary>
            ///Between
            /// </summary>
            [StringValue("Between")]
            Between = 4,

            /// <summary>
            /// GreaterThan
            /// </summary>
            [StringValue("Greater Than")]
            GreaterThan = 5,

            /// <summary>
            /// LessThan
            /// </summary>
            [StringValue("Less Than")]
            LessThan = 6
        }

        /// <summary>
        /// Verify Transaction search operator type
        /// </summary>
        /// <version>1.0    31st October 18     AhmedMustafa</version>
        public enum VerifyTransactionSearchOperator
        {
            /// <summary>
            /// Equal
            /// </summary>
            [StringValue("Equal")]
            Equal = 1
        }

        /// <summary>
        /// Verify deposit transaction search operator
        /// </summary>
        /// <version>1.0    29th April 19     AhmedMustafa</version>
        public enum VerifyDepositTransactionSearchOperator
        {
            /// <summary>
            /// Equal
            /// </summary>
            [StringValue("Equal")]
            Equal = 1
        }

        public enum StatementTypes
        {
            None = 0,
            Procedure = 0,
            Alter = 1,
            Create = 2,
            Delete = 4,
            Drop = 8,
            Execute = 16,
            Insert = 32,
            Select = 64,
            Update = 128,
            Union = 256,
            Batch = 512,
            Merge = 1024 | Delete | Insert | Select | Update
        }

        /// <summary>
        /// Actions which are performed on POSs
        /// </summary>
        /// <createdby>AhmedMustafa</createdby>
        /// <createdon>05/10/2017</createdon>
        public enum SalvageActionMaster
        {
            /// <summary>
            /// Register
            /// </summary>
            [StringValue("Register")]
            Register = 1,

            /// <summary>
            ///Publish
            /// </summary>
            [StringValue("Publish")]
            Publish = 2,

            /// <summary>
            /// Rejected and Return
            /// </summary>
            [StringValue("Rejected and Return")]
            RejectedAndReturn = 3,

            /// <summary>
            ///Check-In
            /// </summary>
            [StringValue("Check-In")]
            CheckIn = 4,

            /// <summary>
            /// Check-Out
            /// </summary>
            [StringValue("Check-Out")]
            CheckOut = 5,

            /// <summary>
            /// Reject and Return to Yard
            /// </summary>
            [StringValue("Reject and Return to Yard")]
            RejectAndReturnToYard = 6,

            /// <summary>
            /// Pick-Up
            /// </summary>
            [StringValue("Pick-Up")]
            PickUp = 100,

            /// <summary>
            ///Pick-Up Reject
            /// </summary>
            [StringValue("Pick-Up Reject")]
            PickUpReject = 101,

            /// <summary>
            /// Pick-Up In Progress
            /// </summary>
            [StringValue("Pick-Up In Progress")]
            PickUpInProgress = 102,

            /// <summary>
            ///Pick-Up Revert
            /// </summary>
            [StringValue("Pick-Up Revert")]
            PickUpRevert = 103,

            [StringValue("Update POS Details")]
            UpdatePOSDetails = 202,

            [StringValue("Process Additional Photo Request")]
            ProcessAdditionalPhotoRequest = 224
        }

        /// <summary>
        /// Predifined Actions
        /// </summary>
        /// <createdBy>Pranav Patel</createdBy>
        /// <createdOn>05-10-2017</createdOn>
        public enum POSAction
        {
            Register = 1,
            Publish = 2,
            RejectedAndReturn = 3,
            CheckIn = 4,
            CheckOut = 5,
            RejectedAndAdmitted = 6,
            Inspection = 10,
            WaiverLetterUploaded = 13,
            WaiverLetterChanged = 14,
            PickUp = 100,
            PickUpReject = 101,
            PickUpInProgress = 102,
            PickUpRevert = 103,
            PickupDelivered = 104,
            PickupCancelled = 105,
            UpdatePOSDetails = 202,
            OwnershipTransferProofSubmitted = 233
        }

        /// <summary>
        /// salvage registerd POS document category master
        /// </summary>
        /// <CreatedBy> Mustafa </CreatedBy>
        /// <CreatedDate> 05/10/2017 </CreatedDate>
        public enum SalvagePOSDocumentCategoryMaster
        {
            [StringValue("OwnershipTransferDocument")]
            OwnershipTransferDocument = 1,

            [StringValue("ContractofAssignment")]
            ContractofAssignment = 2,

            [StringValue("Others")]
            Others = 3,

            [StringValue("BuyerID")]
            BuyerID = 4,

            [StringValue("Towing Permission")]
            TowingPermission = 5,

            [StringValue("POS Disclaimer Release Paper")]
            POSDisclaimerReleasePaper = 6,

            [StringValue("Clearance Invoice")]
            ClearanceInvoice = 7,

            [StringValue("Letter to Sheikh of exhibitions")]
            LetterToSheikhOfExhibitions = 8,

            [StringValue("Sheikh of exhibitions Evaluation Result")]
            SheikhOfExhibitionsEvaluationResult = 9,

            [StringValue("Sheikh of exhibitions Transportation Invoice")]
            SheikhOfExhibitionsTransportationInvoice = 10,

            [StringValue("Sheikh of Exhibitions Evaluation Invoice")]
            SheikhOfExhibitionsEvaluationInvoice = 11,

            [StringValue("Waiver Letter for Customer")]
            WaiverLetterForCustomer = 12,

            [StringValue("Add Ser Repair Estimation")]
            AddSerRepairEstimation = 101
        }

        /// <summary>
        /// Fees Type Enums
        /// </summary>
        /// <createdby>AhmedMustafa</createdby>
        /// <createdon>24/10/2017</createdon>
        public enum FeesType
        {
            /// <summary>
            /// Customer Commission
            /// </summary>
            [StringValue("Customer Commission")]
            CustomerCommission = 1,

            /// <summary>
            ///Relisting Fees
            /// </summary>
            [StringValue("Relisting Fees")]
            RelistingFees = 2
        }

        /// <summary>
        /// Fees Status Master
        /// </summary>
        /// <createdby>AhmedMustafa</createdby>
        /// <createdon>24/10/2017</createdon>
        public enum FeesStatusMaster
        {
            /// <summary>
            /// Pending
            /// </summary>
            [StringValue("Pending")]
            Pending = 1,

            /// <summary>
            ///Completed
            /// </summary>
            [StringValue("Completed")]
            Completed = 2,

            /// <summary>
            ///Expired
            /// </summary>
            [StringValue("Expired")]
            Expired = 3
        }

        public enum SalvageAuctionDetailMethod
        {
            [StringValue("No,Not Now")]
            NoNotNow = 0,
            [StringValue("Yes,Show Me")]
            YesShowMe = 1
        }

        /// <summary>
        /// SalvagePOSStatusReasonMaster Enums
        /// </summary>
        /// <createdby>AhmedMustafa</createdby>
        /// <createdon>02/11/2017</createdon>
        public enum SalvagePOSStatusReason
        {
            /// <summary>
            /// Duplicated
            /// </summary>
            [StringValue("Duplicated")]
            Duplicated = 15,

            /// <summary>
            ///Not interested
            /// </summary>
            [StringValue("Not Interested")]
            NotInterested = 16,

            /// <summary>
            /// Car Already Sold
            /// </summary>
            [StringValue("Car Already Sold")]
            CarAlreadySold = 17,

            /// <summary>
            /// Other
            /// </summary>
            [StringValue("Other")]
            Other = 18,

            [StringValue("Dispute")]
            Dispute = 20,

            [StringValue("Car can not be sold")]
            CarCanNotBeSold = 27
        }

        /// <summary>
        /// salvage dashboard make model id 1
        /// </summary>
        /// <CreatedBy> Mustafa </CreatedBy>
        /// <CreatedDate> 2/11/17 </CreatedDate>
        public enum MakeModelSalvageDashboard
        {
            MakeTable = 1,
            MakeModelTable = 2
        }

        /// <summary>
        /// Master Table show Status.
        /// </summary>
        /// <createdby>Nirav Shah</createdby>
        /// <createdon>08/11/2017</createdon>
        public enum MasterDataShowStatus
        {
            /// <summary>
            /// The Hide
            /// </summary>
            [StringValue("Hide")]
            Hide = 0,

            /// <summary>
            /// The Show
            /// </summary>
            [StringValue("Show")]
            Show = 1,
        }

        /// <summary>
        /// Provider Notification Value Type.
        /// </summary>
        /// <createdby>Pranav Patel</createdby>
        /// <createdon>02-11-2017</createdon>
        public enum UserNotificationType
        {
            [StringValue("Pending IC Confirmation")]
            PendingICConfirmation = 1,
            [StringValue("Rejected And Pending Actions")]
            RejectedAndPendingActions = 2,
            [StringValue("Statistical Report")]
            StatisticalReport = 3,
            [StringValue("Registered and Car Towed")]
            RegisteredCarTowed = 4,
            [StringValue("Pending IC Confirmation Notification")]
            PendingICConfirmationNotification = 5,
            [StringValue("Sold Settlement Invoice Notification")]
            SoldSettlementNotification = 6,
            [StringValue("Unsold Settlement Invoice Notification")]
            UnsoldSettlementNotification = 7,
            [StringValue("Waiver Letter Requests Notification")]
            WaiverLetterRequest = 8
        }

        public enum TowingRequestType
        {
            [StringValue("IsFromNetwork")]
            IsFromNetwork,

            [StringValue("IsFromCustomer")]
            IsFromCustomer,

            [StringValue("IsFromSpecifyLocation")]
            IsFromSpecifyLocation,
        }

        /// <summary>
        /// Salvage Provider Dashboard Data Request Type
        /// </summary>
        /// <createdBy> Alpesh Paramar </createdBy>
        /// <CreatedDate> 04/12/17 </CreatedDate>
        public enum SalvageProviderDashboardDataRequestType
        {
            NewTowingRequested = 1,
            OnlineDrivers = 2,
            PendingICConfirmation = 3,
            PendingActionByProvider = 4,
            PendingOwnershipTransfer = 5,
            WaitingForBidding = 6
        }

        /// <summary>
        /// Reason Code
        /// </summary>
        /// <createdBy>AhmedMustafa</createdBy>
        /// <createdOn>13-12-2017</createdOn>
        public enum ReasonCode
        {
            /// <summary>
            /// RoR1
            /// </summary>
            [StringValue("RoR1")]
            RoR1,
            /// <summary>
            /// RoR2
            /// </summary>
            [StringValue("RoR2")]
            RoR2,
            /// <summary>
            /// RoR3
            /// </summary>
            [StringValue("RoR3")]
            RoR3,
            /// <summary>
            /// RoR4
            /// </summary>
            [StringValue("RoR4")]
            RoR4,
            /// <summary>
            /// RoR5
            /// </summary>
            [StringValue("RoR5")]
            RoR5,
            /// <summary>
            /// RoR6
            /// </summary>
            [StringValue("RoR6")]
            RoR6,
            /// <summary>
            /// RoR7
            /// </summary>
            [StringValue("RoR7")]
            RoR7,
            /// <summary>
            /// RoR8
            /// </summary>
            [StringValue("RoR8")]
            RoR8
        }

        /// <summary>
        /// Serach Criteria For Towing.
        /// </summary>
        /// <createdby>AhmedMustafa</createdby>
        /// <createdon>20/12/2017</createdon>
        public enum TowingCommandSearchBy
        {
            /// <summary>
            /// TowingReqID
            /// </summary>
            [StringValue("Towing Req ID")]
            TowingReqID = 1,

            /// <summary>
            ///SalvageRegNo
            /// </summary>
            [StringValue("Salvage Reg No")]
            SalvageRegNo = 2,

            /// <summary>
            /// Make
            /// </summary>
            [StringValue("Make")]
            Make = 3,

            /// <summary>
            /// Model
            /// </summary>
            [StringValue("Model")]
            Model = 4,

            /// <summary>
            ///TowingStatus
            /// </summary>
            [StringValue("Towing Status")]
            TowingStatus = 5,

            /// <summary>
            /// TowingStage
            /// </summary>
            [StringValue("Towing Stage")]
            TowingStage = 6,

            /// <summary>
            /// TowingSubmitDate
            /// </summary>
            [StringValue("Towing Submit Date")]
            TowingSubmitDate = 7,

            /// <summary>
            /// TowingDriver
            /// </summary>
            [StringValue("Towing Driver")]
            TowingDriver = 8,

            /// <summary>
            /// PlateNumber
            /// </summary>
            [StringValue("Plate Number")]
            PlateNumber = 9
        }

        /// <summary>
        /// POS types and photots search by
        /// </summary>
        /// <version>1.0    20th May 19     AhmedMustafa</version>
        public enum POSTypesAndPhotosSearchBy
        {
            [StringValue("SalvageReferenceNumber")]
            SalvageReferenceNumber = 1,

            [StringValue("POSType")]
            POSType = 2,

            [StringValue("POSPlateType")]
            POSPlateType = 3,

            [StringValue("PlateNumber")]
            PlateNumber = 4,

            [StringValue("PhotosByDrivers")]
            PhotosByDrivers = 5,

            [StringValue("PhotosByIC")]
            PhotosByIC = 6,

            [StringValue("PhotosByInspector")]
            PhotosByInspector = 7
        }


        /// <summary>
        /// Serach Criteria For Payment not completed.
        /// </summary>
        /// <createdby>Pranav</createdby>
        /// <createdon>03/01/2018</createdon>
        public enum PaymentNotCompletedSearchBy
        {
            /// <summary>
            /// AuctionID
            /// </summary>
            [StringValue("AuctionID")]
            AuctionID = 1,

            /// <summary>
            ///SalvageRegNo
            /// </summary>
            [StringValue("Salvage Reg No")]
            SalvageRegNo = 2,

            /// <summary>
            /// User Name
            /// </summary>
            [StringValue("User Name")]
            UserName = 3,

            /// <summary>
            /// Mobile Number
            /// </summary>
            [StringValue("Mobile Number")]
            MobileNumber = 4,

            /// <summary>
            ///SADAD Expired Date
            /// </summary>
            [StringValue("SADAD Expired Date")]
            SADADExpiredDate = 5,

            /// <summary>
            /// Deposit Amount
            /// </summary>
            [StringValue("Deposit Amount")]
            DepositAmount = 6,

            /// <summary>
            /// Reason
            /// </summary>
            [StringValue("Reason")]
            Reason = 7,
            /// <summary>
            /// payment type - Sadad or bank transfer payments
            /// </summary>
            [StringValue("PaymentType")]
            PaymentType = 8,

            /// <summary>
            /// Country
            /// </summary>
            [StringValue("Country")]
            Country = 9,

            [StringValue("POSID")]
            POSID = 10

        }

        /// <summary>
        /// Deposite Status Master.
        /// </summary>
        /// <createdby>Pranav</createdby>
        /// <createdon>06/01/2018</createdon>
        public enum DepositStatus
        {
            /// <summary>
            ///Available
            /// </summary>
            [StringValue("Available")]
            Available = 1,

            /// <summary>
            ///Locked
            /// </summary>
            [StringValue("Locked")]
            Locked = 2,

            /// <summary>
            ///Refunded
            /// </summary>
            [StringValue("Refunded")]
            Refunded = 3,

            /// <summary>
            ///Under Refund
            /// </summary>
            [StringValue("Under Refund")]
            UnderRefund = 4,

            /// <summary>
            ///Charged
            /// </summary>
            [StringValue("Charged")]
            Charged = 5,

            /// <summary>
            ///Merged
            /// </summary>
            [StringValue("Merged")]
            Merged = 6
        }

        /// <summary>
        /// Insurance Types.
        /// </summary>
        /// <createdby>Pranav</createdby>
        /// <createdon>09/01/2018</createdon>
        public enum InsuranceTypes
        {
            /// <summary>
            ///Thrid Party
            /// </summary>
            [StringValue("Thrid Party")]
            ThridParty = 1,

            /// <summary>
            ///Comprehensive
            /// </summary>
            [StringValue("Comprehensive")]
            Comprehensive = 2,

            /// <summary>
            ///Travel
            /// </summary>
            [StringValue("Travel")]
            Travel = 3,

            /// <summary>
            ///Health
            /// </summary>
            [StringValue("Health")]
            Health = 4,

            /// <summary>
            ///SalvageV3
            /// </summary>
            [StringValue("AwalMazad")]
            SalvageV3AwalMazad = 53
        }

        /// <summary>
        /// Mechant Prefix for Payment (Payfort)
        /// </summary>
        /// <version>1.0    13th June 18     AhmedMustafa</version>
        public enum MerchantPrefix
        {
            [StringValue("AMZ")]
            AMZ
        }

        public enum AdditionalServiceResponseTypeMaster
        {
            [StringValue("Old")]
            Old = 1,

            [StringValue("New")]
            New = 2,

            [StringValue("Predefined")]
            Predefined = 3
        }

        /// <summary>
        /// Country 
        /// </summary>
        public enum Country
        {
            [StringValue("Saudi Arabia")]
            SaudiArabia = 1,

            [StringValue("United Arab Emirates")]
            UnitedArabEmirates = 2
        }

        /// <summary>
        /// BankTransferBankMaster
        /// </summary>
        /// <createdBy> AhmedMustafa </createdBy>
        /// <createdDate>26 Apr 2019 </createdDate>
        public enum BankTransferBankMaster
        {
            [StringValue("Riyadh Bank")]
            RiyadhBank = 1,

            [StringValue("United Arab Emirates Bank")]
            UnitedArabEmiratesBank = 2
        }

        /// <summary>
        /// Confirm POS response code
        /// </summary>
        public enum ConfirmPOSResponseCode
        {
            /// <summary>
            /// success
            /// </summary>
            Success = 2,

            /// <summary>
            /// confirm POS related error code
            /// </summary>
            ConfirmPOSError = 3,

            /// <summary>
            /// bidding minimum price required error code
            /// </summary>
            BiddingMinimumPriceRequired = 4,

            /// <summary>
            /// buy now greater then minimum bid amount error code
            /// </summary>
            BuyNowGreaterMinimum = 5,

            /// <summary>
            /// starting price must be less than bidding minimum price error code
            /// </summary>
            StartingPricemustbelessthanBiddingMinimumPrice = 6,

            /// <summary>
            /// Ownership document error code
            /// </summary>
            OwnershipDocumentError = 7
        }

        /// <summary>
        /// Watch list auction notification event types
        /// </summary>
        public enum WatchListAuctionNotificationEventType
        {
            /// <summary>
            /// 24 hours remaining for auction in watch list
            /// </summary>
            AuctionInWatchList24HoursRemainingNotification = 1,

            /// <summary>
            /// 4 hours remaining for auction in watch list
            /// </summary>
            AuctionInWatchList4HoursRemainingNotification = 2,

            /// <summary>
            /// 60 minutes remaining for auction in watch list
            /// </summary>
            AuctionInWatchList1HourRemainingNotification = 3
        }

        public enum NeedsReview
        {
            Yes = 1,
            No = 2,
            Return = 3
        }

        public enum ProofOwnershipRequestSearchBy
        {
            SalvageReferenceNumber = 1,
            AuctionID = 2,
            PlateNumber = 3,
            MobileNumber = 4,
            RequestTime = 5,
            ProofType = 6,
            ProofActionTime = 7,
            Status = 8
        }

        public enum WaiverLetterRequestSearchBy
        {
            SalvageReferenceNumber = 1,
            Claim = 2,
            RequestReference = 3,
            RequestedOn = 4
        }

        public enum ProofOwnershipRequestSearchOperator
        {
            [StringValue("Equal")]
            Equal = 1,

            [StringValue("NotEqual")]
            NotEqual = 2,

            [StringValue("Contains")]
            Contains = 3,

            [StringValue("Between")]
            Between = 4,

            [StringValue("Greater Than")]
            GreaterThan = 5,

            [StringValue("Less Than")]
            LessThan = 6,

            [StringValue("Greater Than or Equal")]
            GreaterThanOrEqual = 7,

            [StringValue("Less Than or Equal")]
            LessThanOrEqual = 8,
        }

        public enum WaiverLetterRequestSearchOperator
        {
            [StringValue("Equal")]
            Equal = 1,

            [StringValue("NotEqual")]
            NotEqual = 2,

            [StringValue("Contains")]
            Contains = 3,

            [StringValue("Between")]
            Between = 4,

            [StringValue("Greater Than")]
            GreaterThan = 5,

            [StringValue("Less Than")]
            LessThan = 6,

            [StringValue("Greater Than or Equal")]
            GreaterThanOrEqual = 7,

            [StringValue("Less Than or Equal")]
            LessThanOrEqual = 8,
        }

        /// <summary>
        /// Ownership transfer request status master
        /// </summary>
        public enum OwnershipTransferStatusMaster
        {
            UnderReview = 1,
            Approved = 2,
            Rejected = 3,
        }

        public enum PaymentSettlementTypeMaster
        {
            SoldSettlement = 1,
            UnsoldSettlement = 2
        }

        public enum SettlementProcessErrorCode
        {
            RecordAlreadyExist = 501,
            InvalidStatusStage = 502,
            InvoiceNetAmountZero = 503,
            AttachmentFileNotExists = 504,
            RecordNotFound = 505
        }

        public enum SettlementOperationType
        {
            /// <summary>
            /// Perform Normal Procedure. Create settlement and invoice record, create CR-DR Note pdf and send email to IC.
            /// </summary>
            All = 1,
            /// <summary>
            /// Create CR-DR Note pdf with existing invoice entries in DB and send email to IC.
            /// </summary>
            InvoicePdfAndEmail = 2,
            /// <summary>
            /// Create CR-DR Note pdf with existing invoice entries in DB.
            /// </summary>
            InvoicePdf = 3,
            /// <summary>
            /// Send last generated CR-DR Note pdf to IC via email.
            /// </summary>
            InvoiceEmail = 4

        }

        public enum WaiverLetterStatus
        {
            PendingAttestation = 1,
            PendingWaiverInformation = 2,
            Completed = 3
        }

        public enum RequestWaiverLetterErrorCodes
        {
            CutomerWaiverInfoNotExists = -1,
            InvalidStatusToRequestWaiver = -2,
            WaiverRequestNotExists = -3,
            IcInfoNotExists = -4,
            POSInfoNotExists = -5
        }

        public enum AdditionalServicesFeeType
        {
            [StringValue("Free")]
            Free = 1,

            [StringValue("Paid")]
            Paid = 2
        }
    }
}

/// <summary>
/// POS Auction Additional Services
/// </summary>
/// <version>1.0    13th June 18     AhmedMustafa</version>
public enum POSAuctionAdditionalServices
{
    [StringValue("AdditionalPhotoService")]
    AdditionalPhotoService = 1,

    [StringValue("FindRepairEstimation")]
    FindRepairEstimation = 2
}

/// <summary>
/// POS Auction Additional Services Type Code
/// </summary>
/// <version>1.0    13th June 18     AhmedMustafa</version>
public enum AdditionalServiceTypeCode
{
    [StringValue("RAP")]
    AdditionalPhotoService = 1,

    [StringValue("RFE")]
    FindRepairEstimation = 2
}

public enum AspNetUsersearchBy
{
    [StringValue("EmailAddress")]
    EmailAddress = 1,

    [StringValue("MobileNumber")]
    MobileNumber = 2,

    [StringValue("UserType")]
    UserType = 3,

    [StringValue("Company")]
    Company = 4,

    [StringValue("Status")]
    Status = 5,
}

public enum AspNetUsersearchOpreation
{
    /// <summary>
    /// Equal
    /// </summary>
    [StringValue("Equal")]
    Equal = 1,

    /// <summary>
    /// Contains
    /// </summary>
    [StringValue("NotEqual ")]
    NotEqual = 2,
}
public enum BwabatiGenricAspNetUserstatusMaster
{
    /// <summary>
    /// Equal
    /// </summary>
    [StringValue("Active")]
    Active = 1,

    /// <summary>
    /// Contains
    /// </summary>
    [StringValue("Suspended")]
    Suspended = 2,
}

public enum NetworkSearchBy
{
    [StringValue("NetworkName")]
    NetworkName = 1,



    [StringValue("NetworkType")]
    NetworkType = 2,

    [StringValue("ForIC")]
    ForIC = 3,
    [StringValue("City")]
    City = 4,
    [StringValue("ContactName")]
    ContactName = 5,
    [StringValue("ContactPhone")]
    ContactPhone = 6,
    [StringValue("ContactEmail")]
    ContactEmail = 7,
}

public enum NetworkSearchOpreation
{
    /// <summary>
    /// Equal
    /// </summary>
    [StringValue("Equal")]
    Equal = 1,

    /// <summary>
    /// Contains
    /// </summary>
    [StringValue("NotEqual ")]
    NotEqual = 2,
}


public enum SADADBillType
{
    [StringValue("Deposit Bill")]
    DEPOSIT = 1,

    [StringValue("Auction Won Bill")]
    AUCTIONWON = 2,

    [StringValue("Buy Now Bill")]
    BUYNOW = 3,

    [StringValue("Regenerate Bill")]
    REGENERATE = 4
}

public enum ImageSource
{
    [StringValue("Server")]
    Server = 1,

    [StringValue("AWS")]
    AWS = 2
}
public enum WebsiteStatus
{
    [StringValue("Sadad")]
    Sadad = 1,

    [StringValue("Auction")]
    Auction = 2
}
public enum AdditionalServiceStatus
{
    [StringValue("NEW")]
    NEW = 1,

    [StringValue("UNDERPROCESS")]
    UNDERPROCESS = 2,

    [StringValue("COMPLETED")]
    COMPLETED = 3,

    [StringValue("UNDERREFUND")]
    UNDERREFUND = 4,

    [StringValue("REFUNDED")]
    REFUNDED = 5,

    [StringValue("REJECTEDREFUNDED")]
    REJECTEDREFUNDED = 6,

    [StringValue("REJECTED")]
    REJECTED = 7
}

/// <summary>
/// Additional Service Action Type
/// </summary>
/// <version>1.0    13th June 18     AhmedMustafa</version>
public enum AdditionalServiceAction
{
    [StringValue("NEWREQUEST")]
    NEWREQUEST = 1,
    [StringValue("ACCEPTREQUEST")]
    ACCEPTREQUEST = 2,
    [StringValue("ADDPHOTOREQCOMP")]
    ADDPHOTOREQCOMP = 3,
    [StringValue("FINDREPAIRREQCOMP")]
    FINDREPAIRREQCOMP = 4,
    [StringValue("CANCELREQUEST")]
    CANCELREQUEST = 5,
    [StringValue("REFUNDREQUEST")]
    REFUNDREQUEST = 6,
    [StringValue("REJECTREFUNDREQUEST")]
    REJECTREFUNDREQUEST = 7,
}

public enum AdditionalRequestTypeMaster
{
    [StringValue("RequestAdditionalPhotos")]
    RequestAdditionalPhotos = 1,

    [StringValue("FindRepairEstimation")]
    FindRepairEstimation = 2
}
public enum AllowedGumUserType
{
    Internal = 1,
    Provider = 2,
    IC = 4
}

public enum UserRegistrationType
{
    Individual = 1,
    Commercial = 2
}

/// <summary>
/// role search by
/// </summary>
public enum VerifyUserAccountSearchBy
{
    [StringValue("Email")]
    Email = 1,

    [StringValue("CR Name")]
    CRName = 2,

    [StringValue("Alias Name")]
    AliasName = 3,

    [StringValue("CR Number")]
    CRNumber = 4,

    [StringValue("Mobile")]
    Mobile = 5,

    [StringValue("User Type")]
    UserType = 6,

    [StringValue("Country")]
    Country = 7,

    [StringValue("Status")]
    Status = 8
}
public enum VerifyUserAccountSearchOperator
{
    /// <summary>
    /// Equal
    /// </summary>
    [StringValue("Equal")]
    Equal = 1,

    /// <summary>
    /// Contains
    /// </summary>
    [StringValue("Contains")]
    Contains = 2,

    /// <summary>
    /// Equal
    /// </summary>
    [StringValue("Not Equal")]
    NotEqual = 3,

}

/// <summary>
/// Picture location
/// </summary>
public enum WatermarkPosition
{
    Absolute,
    TopLeft,
    TopRight,
    TopMiddle,
    BottomLeft,
    BottomRight,
    BottomMiddle,
    MiddleLeft,
    MiddleRight,
    Center
}

public enum ScreenMaster_
{
    Home = 1,
    Search = 2,
    FAQ = 3,
    ContactUs = 4,
    TermsConditions = 5,
    Declaration = 6,
    PrivacyPolicy = 7,
    ChooseAccountType = 8,
    Register = 9,
    POSAuction = 10,
    BiddingHistory = 11,
    ErrorPage = 12,
    PageNotFound = 13,
}