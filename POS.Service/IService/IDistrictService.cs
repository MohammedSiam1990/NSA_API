using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
  public interface IDistrictService
  {
    District GetDistrict(int DistrictId);
    List<District> GetDistricts();
    List<District> GetDistricts(Expression<Func<District, bool>> where);
    void AddDistrict(District district);
    void UpdateDistrict(District district);
    void SaveDistrict(District district);
    void DeleteDistrict(int DistrictId);
    District ValidateAlreadyExist(District model);
  }
}
