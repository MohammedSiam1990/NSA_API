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
   public class MajorServicesService: BaseService,IMajorServicesService
    {
        public MajorServicesService()
        {

        }

        public void AddMajorService(MajorService majorService)
        {
            PosService.MajorServiceRepository.AddMajorService(majorService);
        }

        public void DeleteMajorService(int ServiceId)
        {
            PosService.MajorServiceRepository.DeleteMajorService(ServiceId);
        }

        public MajorService GetMajorService(int ServiceId)
        {
            return PosService.MajorServiceRepository.GetMajorService(ServiceId);
        }

        public List<MajorService> GetMajorServices()
        {
            return PosService.MajorServiceRepository.GetMajorServices();
        }

        public void SaveMajorService(MajorService majorService)
        {
            PosService.MajorServiceRepository.SaveMajorService(majorService);
        }

        public void UpdateMajorService(MajorService majorService)
        {
            PosService.MajorServiceRepository.SaveMajorService(majorService);
        }

        public bool ValidateMajorService(MajorService majorService)
        {
            return PosService.MajorServiceRepository.ValidateMajorService(majorService);
        }
    }
}
