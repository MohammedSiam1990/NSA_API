using NSR.Data.Entities;
using NSR.IService.Base;
using NSR.Service.IService;

namespace NSR.Service.Services
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
