using System;
using System.Collections.Generic;
using System.Text;

namespace Steander.Core.DTOs
{
   public class ConfirmEmail
    {
        public string Email { get; set; }
        public string VerficationCode { get; set; }
    }
}
