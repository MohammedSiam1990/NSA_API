using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
   public interface IBranchWorkStationsService
    {
        bool ValidateBranchWorkStations(BranchWorkStations branchWorkStations);
        void AddBranchWorkStations(BranchWorkStations branchWorkStations);
        void UpdateBranchWorkStations(BranchWorkStations branchWorkStations);
        int ValidateNameAlreadyExist(BranchWorkStations branchWorkStations);
        string GetPendingWorkStations();

    }
}
