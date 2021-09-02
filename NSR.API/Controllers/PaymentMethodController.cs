using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSR.Common;
using NSR.Core.Resources;
using NSR.Data.Entities;
using NSR.Service.IService;

namespace NSR.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]

    public class PaymentMethodController : Controller
    {
        private IPaymentMethodsService PaymentMethod;

        public PaymentMethodController(IPaymentMethodsService _PaymentMethod)
        {
            PaymentMethod = _PaymentMethod;
        }

        [AllowAnonymous]
        [HttpGet("GetPaymentMethod")]
        public IActionResult GetPaymentMethod(int CompanyID, string Lang = "en")
        {

            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);

                var data = PaymentMethod.GetPaymentMethods(CompanyID);

                if (data == null)
                {
                    return Ok(new { success = false, message = lang.No_data_available });
                }
                else
                {
                    return Ok(new { success = true, message = "", datalist = JsonConvert.DeserializeObject(data) });
                }
            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });

        }
        [AllowAnonymous]
        [HttpPost("SavePaymentMethods")]

        public IActionResult SavePaymentMethods(PaymentMethods payment, string Lang = "en")
        {
            try
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(Lang);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Lang);
                string ParamName;
                bool valid = CommandTextValidator.ValidateStatement(out ParamName, payment.PaymentMethodName, payment.PaymentMethodNameAr);
                if (valid == false)
                {
                    return Ok(new { success = false, Name = ParamName, message = lang.Please_Remove_special_characters });
                }

                int ItemData = PaymentMethod.SavePaymentMethods(payment);
                if (ItemData == 1)
                    return Ok(new { success = true, message = lang.Saved_successfully_completed });
                else if (ItemData == -1)
                    return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
                else if (ItemData == -2)
                    return Ok(new { success = false, message = lang.Payment_method_already_exists });
                else if (ItemData == -3)
                    return Ok(new { success = false, message = lang.Free_payment_method_already_exists });
                else if (ItemData == -4)
                    return Ok(new { success = false, message = lang.English_name_already_exists, repeated = "PaymentMethodName" });
                else if (ItemData == -5)
                    return Ok(new { success = false, message = lang.Arabic_name_already_exists, repeated = "PaymentMethodNameAr" });

            }
            catch (Exception ex)
            {
                ExceptionError.SaveException(ex);
            }
            return Ok(new { success = false, message = lang.An_error_occurred_while_processing_your_request });
        }

    }
}