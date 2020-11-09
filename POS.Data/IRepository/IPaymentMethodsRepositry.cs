using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IPaymentMethodsRepositry
    {
        int SavePaymentMethods(PaymentMethods paymentMethods);
        string GetPaymentMethods(int CompanyID);

    }
}
