using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace NSR.Data.IRepository
{
 public interface IDistrictRepository
  {
    District GetDistrict(int DistrictId);
    List<District> GetDistricts();
    List<District> GetDistricts(int CityId);
    List<District> GetDistricts(Expression<Func<District, bool>> where);
    void AddDistrict(District district);
    void UpdateDistrict(District district);
    void SaveDistrict(District district);
    void DeleteDistrict(int DistrictId);
    bool ValidateCodeorNameAlreadyExist(Expression<Func<District, bool>> where);
    bool ValidateCodeorNameArAlreadyExist(Expression<Func<District, bool>> where);
    District ValidateAlreadyExist(District model);
  }
}
