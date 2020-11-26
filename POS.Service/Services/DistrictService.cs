using POS.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
  public class DistrictService : BaseService, IDistrictService
  {
    public void AddDistrict(District district)
    {
      PosService.DistrictRepository.AddDistrict(district);
    }

    public void DeleteDistrict(int DistrictId)
    {
      PosService.DistrictRepository.DeleteDistrict(DistrictId);
    }

    public District GetDistrict(int DistrictId)
    {
     return PosService.DistrictRepository.GetDistrict(DistrictId);
    }
    public List<District> GetDistricts(int CityId)
    {
     return PosService.DistrictRepository.GetDistricts(CityId);
    }
    public List<District> GetDistricts()
    {
      return PosService.DistrictRepository.GetDistricts();
    }

    public List<District> GetDistricts(Expression<Func<District, bool>> where)
    {
      return PosService.DistrictRepository.GetDistricts();
    }

    public void SaveDistrict(District district)
    {
      throw new NotImplementedException();
    }

    public void UpdateDistrict(District district)
    {
       PosService.DistrictRepository.UpdateDistrict(district);
    }

    public District ValidateAlreadyExist(District model)
    {
      return PosService.DistrictRepository.ValidateAlreadyExist(model);

    }
  }
}
