using POS.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class MajorServicesService : BaseService, IMajorServicesService
    {
        public MajorServicesService()
        {

        }

        public MajorServices GetMajorService(int ServiceId)
        {
            return PosService.MajorServiceRepository.GetMajorService(ServiceId);
        }

        public List<MajorServices> GetMajorServices()
        {
            return PosService.MajorServiceRepository.GetMajorServices();
        }

    }
}
