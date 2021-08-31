using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
   public interface IBranchWorkStationsRepository
    {
        bool ValidateBranchWorkStations(BranchWorkStations branchWorkStations);
        void AddBranchWorkStations(BranchWorkStations branchWorkStations);
        void UpdateBranchWorkStations(BranchWorkStations branchWorkStations);
        int ValidateNameAlreadyExist(BranchWorkStations branchWorkStations);

        string GetWorkStations();
    }
}
