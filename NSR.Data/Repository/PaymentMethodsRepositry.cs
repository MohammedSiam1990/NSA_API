using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NSR.Data.DataContext;
using NSR.Data.Entities;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using System;
using System.Linq;

namespace NSR.Data.Repository
{
    public class PaymentMethodsRepositry : Repository<PaymentMethods>, IPaymentMethodsRepositry
    {
        public PaymentMethodsRepositry(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        [Obsolete]
        public string GetPaymentMethods(int CompanyID)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetPaymentMethod @CompanyID";
                var data = DbContext.JsonData.FromSqlRaw(Sql, new SqlParameter("@CompanyID", CompanyID)
                    ).AsEnumerable().FirstOrDefault().Data;

                return data.ToString();
            }

        }

        [Obsolete]
        public int SavePaymentMethods(PaymentMethods paymentMethods)
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC SavePaymentMethod @PaymentMethodID,@CompanyID,@TypeID,@PaymentMethodName,@PaymentMethodNameAr," +
                    "@CommissionPrcnt,@CalcCommissionTax,@CommissionOnClient,@FreePaymentTypeID,@CalcTaxOnFreePM,@InsertedBy,@ModifiedBy,@StatusID";

                int result = DbContext.ReturnResult.FromSqlRaw(Sql, new object[] {
                                                new SqlParameter("@PaymentMethodID", paymentMethods.PaymentMethodID),
                                                new SqlParameter("@CompanyID"  ,paymentMethods.CompanyID),
                                                new SqlParameter("@TypeID" , paymentMethods.TypeID?? (object)DBNull.Value),
                                                new SqlParameter("@PaymentMethodName" , paymentMethods.PaymentMethodName ?? (object)DBNull.Value),
                                                new SqlParameter("@PaymentMethodNameAr" , paymentMethods.PaymentMethodNameAr ?? (object)DBNull.Value),
                                                new SqlParameter("@CommissionPrcnt" , paymentMethods.CommissionPrcnt ),
                                                new SqlParameter("@CalcCommissionTax" , paymentMethods.CalcCommissionTax),
                                                new SqlParameter("@CommissionOnClient" , paymentMethods.CommissionOnClient ?? (object)DBNull.Value),
                                                new SqlParameter("@FreePaymentTypeID"  , paymentMethods.FreePaymentTypeID ?? (object)DBNull.Value),
                                                new SqlParameter("@CalcTaxOnFreePM"  , paymentMethods.CalcTaxOnFreePM ?? (object)DBNull.Value),
                                                new SqlParameter("@InsertedBy"   , paymentMethods.InsertedBy ?? (object)DBNull.Value),
                                                new SqlParameter("@ModifiedBy"    , paymentMethods.ModifiedBy ?? (object)DBNull.Value),
                                                new SqlParameter("@StatusID"  , paymentMethods.StatusID ?? (object)DBNull.Value)

                                            }).AsEnumerable().FirstOrDefault().ReturnValue;

                return result;
            }

        }
    }
}
