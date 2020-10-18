using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class BranchWorkStationsRepository : Repository<BranchWorkStations>, IBranchWorkStationsRepository
    {
        public BranchWorkStationsRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public void AddBranchWorkStations(BranchWorkStations branchWorkStations)
        {
            try
            {
                branchWorkStations.CreateDate = DateTime.Now;
                Add(branchWorkStations);
                //  PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        [Obsolete]
        public string GetPendingWorkStations()
        {
            using (var DbContext = new PosDbContext())
            {
                try
                {
                    string Sql = "EXEC GetPendingWorkStations";
                    var data = DbContext.JsonData.FromSql(Sql).AsEnumerable().FirstOrDefault().Data;
                    return data.ToString();
                }
                catch (Exception ex)
                {
                    Exceptions.ExceptionError.SaveException(ex);
                }
                return null;

            }
        }

        public void UpdateBranchWorkStations(BranchWorkStations branchWorkStations , int? UserType)
        {
            try
            {
                if (branchWorkStations.StatusID == 7 && UserType==2)
                {
                    branchWorkStations.ApprovedDate = DateTime.Now;
                    branchWorkStations.Serial = Guid.NewGuid().ToString("D");
                    Update(branchWorkStations);
                    PosDbContext.SaveChanges();

                }
                else if((branchWorkStations.StatusID == 7 || branchWorkStations.StatusID == 6) && (UserType==1 || UserType==2))
                {
                    branchWorkStations.LastModifyDate = DateTime.Now;
                    Update(branchWorkStations);
                    PosDbContext.SaveChanges();

                }

            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public bool ValidateBranchWorkStations(BranchWorkStations branchWorkStations)
        {
            try
            {
                if (branchWorkStations.WorkstationName != "")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public int ValidateNameAlreadyExist(BranchWorkStations model)
        {

            var branchWorkStations = GetById(e => e.BranchWorkstationID != model.BranchWorkstationID
            && (e.WorkstationName == model.WorkstationName) && e.StatusID != 3);

            if (branchWorkStations == null) return 1;

            if (branchWorkStations.WorkstationName == model.WorkstationName)
                return -2;

            return 1;
        }
    }
}
