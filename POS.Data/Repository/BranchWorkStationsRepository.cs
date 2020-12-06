using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Linq;

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
            branchWorkStations.CreateDate = DateTime.Now;
            Add(branchWorkStations);
        }

        [Obsolete]
        public string GetWorkStations()
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetWorkStations ";
                var data = DbContext.JsonData.FromSql(Sql).AsEnumerable().FirstOrDefault().Data;
                return data.ToString();
            }
        }

        public void UpdateBranchWorkStations(BranchWorkStations branchWorkStations)
        {
            Update(branchWorkStations);
            PosDbContext.SaveChanges();
        }

        public bool ValidateBranchWorkStations(BranchWorkStations branchWorkStations)
        {
            if (branchWorkStations.WorkstationName != "")
                return true;
            else
                return false;
        }

        public int ValidateNameAlreadyExist(BranchWorkStations model)
        {

            var branchWorkStations = GetById(e => e.BranchWorkstationID != model.BranchWorkstationID
            && (e.WorkstationName == model.WorkstationName) && (e.BranchID == model.BranchID) && e.StatusID != 3);

            if (branchWorkStations == null) return 1;

            if (branchWorkStations.WorkstationName == model.WorkstationName)
                return -2;

            return 1;
        }
    }
}
