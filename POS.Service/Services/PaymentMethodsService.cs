using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class PaymentMethodsService : BaseService, IPaymentMethodsService
    {
        public string GetPaymentMethods(int CompanyID)
        {
           return PosService.PaymentMethodsRepositry.GetPaymentMethods(CompanyID);
        }

        public int SavePaymentMethods(PaymentMethods paymentMethods)
        {
            return PosService.PaymentMethodsRepositry.SavePaymentMethods(paymentMethods);
        }
    }
}
