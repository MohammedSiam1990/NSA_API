using POS.API.Helpers;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
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

        public void UpdateBranchWorkStations(BranchWorkStations branchWorkStations)
        {
            try
            {
                Update(branchWorkStations);
                PosDbContext.SaveChanges();
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
            && (e.WorkstationName == model.WorkstationName));

            if (branchWorkStations == null) return 1;

            if (branchWorkStations.WorkstationName == model.WorkstationName)
                return -2;

            return 1;
        }
    }
}
