using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
   public interface IBranchWorkStationsRepository
    {
        bool ValidateBranchWorkStations(BranchWorkStations branchWorkStations);
        void AddBranchWorkStations(BranchWorkStations branchWorkStations);
        void UpdateBranchWorkStations(BranchWorkStations branchWorkStations, int? UserType);
        int ValidateNameAlreadyExist(BranchWorkStations branchWorkStations);

        string GetWorkStations();
    }
}
