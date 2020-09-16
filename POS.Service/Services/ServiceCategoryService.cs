
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
    public class MajorServiceTypesService : BaseService, IMajorServiceTypesService
    {
        public MajorServiceTypesService()
        {

        }
        public void AddMajorServiceTypes(MajorServiceTypes MajorServiceTypes)
        {
            PosService.MajorServiceTypesRepository.AddMajorServiceTypes(MajorServiceTypes);
        }

        public void DeleteMajorServiceTypes(int MajorServiceTypesId)
        {
            PosService.MajorServiceTypesRepository.DeleteMajorServiceTypes(MajorServiceTypesId);
        }

        public List<MajorServiceTypes> GetMajorServiceTypes()
        {
            return PosService.MajorServiceTypesRepository.GetMajorServiceTypes();
        }

        public List<MajorServiceTypes> GetMajorServiceTypesByMajorService(int ServiceId)
        {
            return PosService.MajorServiceTypesRepository.GetMajorServiceTypesByMajorService(e=>e.MajorServiceId == ServiceId);
        }

        public MajorServiceTypes GetMajorServiceTypes(int MajorServiceTypesId)
        {
            return PosService.MajorServiceTypesRepository.GetMajorServiceTypes(MajorServiceTypesId);
        }

        public void SaveMajorServiceTypes(MajorServiceTypes MajorServiceTypes)
        {
            PosService.MajorServiceTypesRepository.SaveMajorServiceTypes(MajorServiceTypes);
        }

        public void UpdateMajorServiceTypes(MajorServiceTypes MajorServiceTypes)
        {

             PosService.MajorServiceTypesRepository.UpdateMajorServiceTypes(MajorServiceTypes);
        }

        public bool ValidateMajorServiceTypes(MajorServiceTypes MajorServiceTypes)
        {
            return PosService.MajorServiceTypesRepository.ValidateMajorServiceTypes(MajorServiceTypes);
        }
    }
}
