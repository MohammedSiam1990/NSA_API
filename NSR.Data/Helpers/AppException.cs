using Exceptions;
using System;
using System.Globalization;

namespace NSR.API.Helpers
{
    // Custom exception class for throwing application specific exceptions (e.g. for validation) 
    // that can be caught and handled within the application
    public class AppException : Exception
    {
        public AppException() : base() {}

        public AppException(string message) : base(message){
               Exception ex = new Exception(message);
               ExceptionError.SaveException(ex);
        }
        public AppException(string message ,Exception ex) : base(message)
        {
            ExceptionError.SaveException(ex);
        }
        public AppException(string message, params object[] args) 
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

    }
}