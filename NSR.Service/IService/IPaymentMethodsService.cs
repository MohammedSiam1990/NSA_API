using NSR.Data.Entities;

namespace NSR.Service.IService
{
    public interface IPaymentMethodsService
    {
        int SavePaymentMethods(PaymentMethods paymentMethods);
        string GetPaymentMethods(int CompanyID);

    }
}
