using NSR.Entities;
using System.Collections.Generic;

namespace NSR.Service.IService
{
    public interface ISoldierService
    {


        Soldier GetSoldierID(int SoldierID);
        Soldier GetSoldier(int InsertedBy);
        List<Soldier> GetSoldiers();
        void AddSoldier(Soldier Soldier);
        void UpdateSoldier(Soldier Soldier);
        int SaveSoldier(Soldier Soldier, string Img);
        void DeleteSoldier(int SoldierId);
        Soldier ValidateAlreadyExist(Soldier model);

        string GetProSoldiersAll();

    }
}
