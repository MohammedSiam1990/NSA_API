using POS.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;

namespace POS.Service.Services
{
    public class MajorServicesService : BaseService, IMajorServicesService
    {
        public MajorServicesService()
        {

        }

        public void AddMajorServices(MajorServices MajorServices)
        {
            throw new NotImplementedException();
        }

        public void DeleteMajorServices(int MajorServicesId)
        {
            throw new NotImplementedException();
        }

        public MajorServices GetMajorService(int ServiceId)
        {
            return PosService.MajorServiceRepository.GetMajorService(ServiceId);
        }

        public List<MajorServices> GetMajorServices()
        {
            return PosService.MajorServiceRepository.GetMajorServices();
        }

        public void SaveMajorServices(MajorServices MajorServices)
        {
            PosService.MajorServiceRepository.SaveMajorServices(MajorServices);
        }

        public void UpdateMajorServices(MajorServices MajorServices)
        {
            PosService.MajorServiceRepository.UpdateMajorServices(MajorServices);
        }
    }
}
