using System;

namespace NSR.Core.Logging
{
	/// <summary>
	/// 
	/// </summary>
	public class LogProvider
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="level"></param>
		/// <param name="message"></param>
		public void Log(Logger logger, LogLevel level, string message)
		{
			Log(logger, level, message, null);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="level"></param>
		/// <param name="exception"></param>
		public void Log(Logger logger, LogLevel level, Exception exception)
		{
			LogHelper.Log(logger, level, exception);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="logger"></param>
		/// <param name="level"></param>
		/// <param name="message"></param>
		/// <param name="exception"></param>
		public void Log(Logger logger, LogLevel level, string message, Exception exception)
		{
			LogHelper.Log(logger, level, message, exception);
		}
	}
}
