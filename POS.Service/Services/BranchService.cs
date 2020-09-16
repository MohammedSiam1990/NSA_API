using Pos.IService;
using POS.Common;
using POS.Entities;
using POS.IService.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static POS.Common.Enums;

namespace Pos.Service
{
    /// <summary>
    /// BRANCH Service {Add-update-Delete-GetById-GetAll}.
    /// </summary>
    /// <createdby>Ahmed Hamdan </createdby>
    /// <createdon>05/07/2020</createdon>
    
    public class BranchService : BaseService, IBranchService
    {
        public void AddBranch(Branches Branch)
        {
            PosService.BranchRepository.AddBranch(Branch);
        }

        public void DeleteBranch(long BranchId)
        {
            PosService.BranchRepository.DeleteBranch(BranchId);
        }

        public Branches GetBranch(long BranchId)
        {
            return PosService.BranchRepository.GetBranch(BranchId);
        }

        public List<Branches> GetBranchesByCompany(int CompanyId)
        {
            return PosService.BranchRepository.GetBranch(e => true);
        }
        public List<Branches> GetBranchesByBrand(int BrandId)
        {
            return PosService.BranchRepository.GetBranch(e => e.BrandId == BrandId);
        }
        public List<Branches> GetBranches()
        {
            return PosService.BranchRepository.GetBranches();
        }

        public void UpdateBranch(Branches Branch)
        {
            PosService.BranchRepository.UpdateBranch(Branch);
        }

        public bool ValidateBranch(Branches Branch)
        {
            return PosService.BranchRepository.ValidateBranch(Branch);
        }

        public bool ValidateCodeorNameAlreadyExist(long BranchId, int CompanyId, string BranchCode, string BranchName)
        {
            return PosService.BranchRepository.ValidateCodeorNameAlreadyExist(e => e.BranchId != BranchId  &&(  e.BranchName == BranchName));
        }

        public void SaveProcBranch(Branches Branch)
        {
            PosService.BranchRepository.SaveProcBranch(Branch);
        }

        public GetBranches GetProcBranches(int BrandID, string ImageURL)
        {
            return PosService.BranchRepository.GetProcBranches(BrandID, ImageURL);
        }
    }
    }
