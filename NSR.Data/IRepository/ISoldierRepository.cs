using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Data.IRepository
{
    public interface ISoldierRepository
    {
        Soldier GetSoldier(int InsertedBy);
        List<Soldier> GetSoldiers();
        void AddSoldier(Soldier Soldier);
        void UpdateSoldier(Soldier Soldier);
        int SaveSoldier(Soldier Soldier, string Img);
        void DeleteSoldier(int SoldierId);
        Soldier ValidateAlreadyExist(Soldier model);

        Soldier GetSoldierID(int SoldierID);

        string GetProSoldiersAll();

       

    }
}
