using NSR.Entities;
using NSR.IService.Base;
using NSR.Service.IService;
using System.Collections.Generic;

namespace NSR.Service.Services
{
    public class MajorServiceTypesService : BaseService, IMajorServiceTypesService
    {
        public MajorServiceTypesService()
        {

        }

        public void AddMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes)
        {
            PosService.MajorServiceTypesRepository.AddMajorServiceTypes(MajorServiceTypes);
        }

        public void DeleteMajorServiceTypes(int MajorServiceTypesId)
        {
            PosService.MajorServiceTypesRepository.DeleteMajorServiceTypes(MajorServiceTypesId);
        }

        public List<MajorServiceTypes> GetMajorServiceTypes(int ServiceId)
        {
            return PosService.MajorServiceTypesRepository.GetMajorServiceTypes(ServiceId);
        }

        public List<MajorServiceTypes> GetMajorServiceTypes()
        {
            return PosService.MajorServiceTypesRepository.GetMajorServiceTypes();
        }

        public int SaveMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes)
        {
            return PosService.MajorServiceTypesRepository.SaveMajorServiceTypes(MajorServiceTypes);
        }

        public void UpdateMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes)
        {
            PosService.MajorServiceTypesRepository.UpdateMajorServiceTypes(MajorServiceTypes);
        }

        public MajorServiceTypes ValidateAlreadyExist(MajorServiceTypes model)
        {
            return PosService.MajorServiceTypesRepository.ValidateAlreadyExist(model);
        }
    }
}
