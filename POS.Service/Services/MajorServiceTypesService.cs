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

        public MajorServiceTypes GetMajorServiceTypes(int ServiceId)
        {
            return PosService.MajorServiceTypesRepository.GetMajorServiceTypes(ServiceId);
        }

        public List<MajorServiceTypes> GetMajorServiceTypes()
        {
            return PosService.MajorServiceTypesRepository.GetMajorServiceTypes();
        }

        public void SaveMajorServiceTypes(MajorServiceTypes MajorServiceTypes)
        {
            PosService.MajorServiceTypesRepository.SaveMajorServiceTypes(MajorServiceTypes);
        }

        public void UpdateMajorServiceTypes(MajorServiceTypes MajorServiceTypes)
        {
            PosService.MajorServiceTypesRepository.UpdateMajorServiceTypes(MajorServiceTypes);
        }
    }
}
