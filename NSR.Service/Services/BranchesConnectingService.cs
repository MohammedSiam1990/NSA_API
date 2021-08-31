using NSR.Data.Entities;
using NSR.IService.Base;
using NSR.Service.IService;
using System;
using System.Collections.Generic;

namespace NSR.Service.Services
{
    public class BranchesConnectingService : BaseService, IBranchesConnectingService
    {
        public void SaveBranchesConnecting(List<BranchesConnecting> model, int BranchID, int TypeID)
        {
            for (int i = 0; i < model.Count; i++)
            {
                model[i].CreateDate = DateTime.Now;
            }
            PosService.BranchesConnectingRepository.SaveBranchesConnecting(model, BranchID, TypeID);
        }
    }
}
