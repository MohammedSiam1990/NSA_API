using POS.Data.Entities;

namespace POS.Service.IService
{
    public interface IPaymentMethodsService
    {
        int SavePaymentMethods(PaymentMethods paymentMethods);
        string GetPaymentMethods(int CompanyID);

    }
}
