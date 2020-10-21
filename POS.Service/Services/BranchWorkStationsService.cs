using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class BranchWorkStationsService : BaseService, IBranchWorkStationsService
    {
        public void AddBranchWorkStations(BranchWorkStations branchWorkStations)
        {
            PosService.branchWorkStationsRepository.AddBranchWorkStations(branchWorkStations);
        }

        public string GetWorkStations()
        {
            return PosService.branchWorkStationsRepository.GetWorkStations();
        }

        public void UpdateBranchWorkStations(BranchWorkStations branchWorkStations)
        {
            PosService.branchWorkStationsRepository.UpdateBranchWorkStations(branchWorkStations);
        }

        public bool ValidateBranchWorkStations(BranchWorkStations branchWorkStations)
        {
         return  PosService.branchWorkStationsRepository.ValidateBranchWorkStations(branchWorkStations);
        }

        public int ValidateNameAlreadyExist(BranchWorkStations branchWorkStations)
        {
            return PosService.branchWorkStationsRepository.ValidateNameAlreadyExist(branchWorkStations);
        }
    }
}
