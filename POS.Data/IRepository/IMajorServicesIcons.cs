using POS.Core.Repository.Infrastructure;
using POS.Entities;
using Steander.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.IRepository
{
  public  interface IMajorServicesIconsRepository
    {
        MajorServicesIcons GetMajorServicesIcons(int MajorServicesIconsId);
        string GetMajorServicesIcons(int? ServiceId);

        void SaveMajorServicesIcons(MajorServicesIcons MajorServicesIcons);
        void AddMajorServicesIcons(MajorServicesIcons MajorServicesIcons);
        void UpdateMajorServicesIcons(MajorServicesIcons MajorServicesIcons);
        void  DeleteMajorServicesIcons(int MajorServicesIconsId);


    }
}
