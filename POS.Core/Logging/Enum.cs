namespace POS.Core.Logging
{
	/// <summary>
	/// Enumeration for the types of different loggers used by the system
	/// </summary>
	public enum Logger : byte
	{
		/// <summary> Application </summary>
		Application,
        AuctionEndOperation,
        ThumbNails,
        SadadBillCheck,
        Escalation,
        DepositBillCheckOperation,
        SadadBillQueueOperation,
        LookupOperation,
        WebsiteAvailabilityOperation,
        VehiclePaymentIntermediateReminder,
        AdditionalRequestFindRepair,
        AdditionalRequestRefund,
        PayfortOperation,
        DeleteTempFiles,
        PubNubQueueOperation,
        HeartBeatingService,
        SadadSuccessPaymentOperation,
        SadadCancelBillQueueOperation,
        WatchListAuctionNotification,
        SettlementOperation
    }

	/// <summary>
	/// Enumeration for the levels of logs
	/// </summary>
	public enum LogLevel : byte
	{
		/// <summary> Debug </summary>
		Debug,
		/// <summary> Diagnostic </summary>
		Diagnostic,
		/// <summary> Info </summary>
		Info,
		/// <summary> Warn </summary>
		Warn,
		/// <summary> Error </summary>
		Error
	}
}