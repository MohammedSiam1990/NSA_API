using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using log4net;

namespace POS.Core.Logging
{
    /// <summary>
    /// The log Helper class
    /// </summary>
    public static class LogHelper
	{
		#region Private fields

		private static bool _enableDiagnosticLogging = false;
		private static bool _enableDebugLogging = false;

		#endregion


		#region Public properties

		/// <summary>
		/// This configuration value is used to enable/disable some diagnostic log messages
		/// The associated web.config key name is: EnableDiagnosticLogging
		/// </summary>
		public static bool EnableDiagnosticLogging
		{
			get { return _enableDiagnosticLogging; }
			set { _enableDiagnosticLogging = value; }
		}

		/// <summary>
		/// This configuration value is used to enable/disable some debug log messages
		/// The associated web.config key name is: EnableDebugLogging
		/// </summary>
		public static bool EnableDebugLogging
		{
			get { return _enableDebugLogging; }
			set { _enableDebugLogging = value; }
		}

		#endregion


		#region Private Methods

		/// <summary>
		/// Cleans all line break characters as well as redundant white spaces
		/// </summary>
		/// <param name="text"></param>
		/// <returns>string</returns>
		private static string CleanUpXMLForLogging(string text)
		{
			text = text.Replace("\r", string.Empty)				//Remove carriage return
					.Replace("\n", string.Empty);				//Remove line feed
			text = Regex.Replace(text, @">\s{1,}<", "><");		//Remove redundant spaces
			text = Regex.Replace(text, @">\t{1,}<", "><");		//Remove redundant tabs

			return text;
		}

		#endregion


		#region Public Methods

		/// <summary>
		/// Logs the provided message to the appropriate logger
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="level"></param>
		/// <param name="message"></param>
		public static void Log(Logger logger, LogLevel level, string message)
		{
			Log(logger, level, message, null);
		}

		/// <summary>
		/// Logs the provided message to the appropriate logger
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="level"></param>
		/// <param name="exception"></param>
		public static void Log(Logger logger, LogLevel level, Exception exception)
		{
			if (level == LogLevel.Debug && !EnableDiagnosticLogging)
				return;

			Log(logger, level, string.Empty, exception);
		}

		/// <summary>
		/// Logs the provided message to the appropriate logger
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="level"></param>
		/// <param name="message"></param>
		/// <param name="exception"></param>
		public static void Log(Logger logger, LogLevel level, string message, Exception exception)
		{
			if (level == LogLevel.Debug)
			{
				if (!EnableDebugLogging)
					return;

				message = string.Format(
					"Task<{0}>\t{1}",
					Task.CurrentId.HasValue ? Task.CurrentId.Value.ToString() : "N/A",
					string.IsNullOrEmpty(message) ? string.Empty : message);
			}

			if (level == LogLevel.Diagnostic && !EnableDiagnosticLogging)
				return;

            ILog iLogger = null;
            bool logAsSingleLine = false;

            switch (logger)
            {
                case Logger.AuctionEndOperation:
                    iLogger = LogManager.GetLogger("AuctionEndOperation");
                    break;

                case Logger.ThumbNails:
                    iLogger = LogManager.GetLogger("ThumbNails");
                    logAsSingleLine = true;
                    break;

                case Logger.SadadBillCheck:
                    iLogger = LogManager.GetLogger("SadadBillCheck");
                    logAsSingleLine = true;
                    break;

                case Logger.Escalation:
                    iLogger = LogManager.GetLogger("Escalation");
                    logAsSingleLine = true;
                    break;

                case Logger.DepositBillCheckOperation:
                    iLogger = LogManager.GetLogger("DepositBillCheckOperation");
                    break;

                case Logger.SadadBillQueueOperation:
                    iLogger = LogManager.GetLogger("SadadBillQueueOperation");
                    logAsSingleLine = true;
                    break;

                case Logger.LookupOperation:
                    iLogger = LogManager.GetLogger("LookupOperation");
                    logAsSingleLine = true;
                    break;

                case Logger.WebsiteAvailabilityOperation:
                    iLogger = LogManager.GetLogger("WebsiteAvailabilityOperation");
                    logAsSingleLine = true;
                    break;

                case Logger.VehiclePaymentIntermediateReminder:
                    iLogger = LogManager.GetLogger("VehiclePaymentIntermediateReminder");
                    break;

                case Logger.AdditionalRequestFindRepair:
                    iLogger = LogManager.GetLogger("AdditionalRequestFindRepair");
                    break;

                case Logger.AdditionalRequestRefund:
                    iLogger = LogManager.GetLogger("AdditionalRequestRefund");
                    logAsSingleLine = true;
                    break;

                case Logger.PayfortOperation:
                    iLogger = LogManager.GetLogger("PayfortOperation");
                    logAsSingleLine = true;
                    break;

                case Logger.DeleteTempFiles:
                    iLogger = LogManager.GetLogger("DeleteTempFiles");
                    logAsSingleLine = true;
                    break;

                case Logger.PubNubQueueOperation:
                    iLogger = LogManager.GetLogger("PubNubQueueOperation");
                    logAsSingleLine = true;
                    break;

                case Logger.HeartBeatingService:
                    iLogger = LogManager.GetLogger("HeartBeatingService");
                    logAsSingleLine = true;
                    break;

                case Logger.SadadSuccessPaymentOperation:
                    iLogger = LogManager.GetLogger("SadadSuccessPaymentOperation");
                    logAsSingleLine = true;
                    break;

                case Logger.SadadCancelBillQueueOperation:
                    iLogger = LogManager.GetLogger("SadadCancelBillQueueOperation");
                    logAsSingleLine = true;
                    break;

                case Logger.WatchListAuctionNotification:
                    iLogger = LogManager.GetLogger("WatchListAuctionNotification");
                    logAsSingleLine = true;
                    break;

                case Logger.SettlementOperation:
                    iLogger = LogManager.GetLogger("SettlementOperation");
                    logAsSingleLine = true;
                    break;
                
                default:
                    iLogger = LogManager.GetLogger("Application");
                    break;
            }

            if (logAsSingleLine)
				message = CleanUpXMLForLogging(message);

			if (iLogger != null)
			{
				switch (level)
				{
					case LogLevel.Debug:
					case LogLevel.Diagnostic:
					case LogLevel.Info:
						if (exception == null)
							iLogger.Info(message);
						else
							iLogger.Info(message, exception);
						break;

					case LogLevel.Warn:
						if (exception == null)
							iLogger.Warn(message);
						else
							iLogger.Warn(message, exception);

						break;

					default:
						if (exception == null)
							iLogger.Error(message);
						else
							iLogger.Error(message, exception);
						break;
				}
			}
		}

		#endregion
	}
}