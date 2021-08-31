using Microsoft.EntityFrameworkCore;
using NSR.Data.DataContext;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NSR.Data.Repository
{
    public class SoldierRepository : Repository<Soldier>, ISoldierRepository
    {
        public SoldierRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public List<Soldier> GetSoldiers()
        {
            var Soldier = base.Table().ToList(); 
            base.DbContext.Dispose();
            base.DbContext = null;
            return Soldier;
        }
        
        public Soldier GetSoldier(int InsertedBy)
        {
            var Soldier = base.Table().Where(e => e.InsertedBy == InsertedBy).FirstOrDefault();
 
            base.DbContext.Dispose();
            base.DbContext = null;
            return Soldier;
        }

        public Soldier GetSoldierID(int SoldierID)
        {
            var Soldier = base.Table().Where(e => e.SoldierId == SoldierID).FirstOrDefault();

            base.DbContext.Dispose();
            base.DbContext = null;
            return Soldier;
        }


        public void AddSoldier(Soldier Soldier)
        {
            Soldier.CreateDate = DateTime.Now;
            Add(Soldier);
        }
        public void UpdateSoldier(Soldier Soldier)
        {
            Soldier.LastModifyDate = DateTime.Now;
            Update(Soldier);
        }
        public int SaveSoldier(Soldier Soldier, string Img)
        {

            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    if (Soldier.SoldierId == 0) 
                    {
                        Soldier.CreateDate = DateTime.Now;
                        context.Add(Soldier);
                     }
                    if (Soldier.SoldierId > 0)
                    {
                        Soldier.LastModifyDate = DateTime.Now;

                        if (Soldier.ApprovedBy > 0 && Soldier.ApprovedBy != null && Soldier.ManagementAction == 4)
                        {
                            Soldier.ApprovedDate = DateTime.Now;
                        }
                        context.Update(Soldier);
                    }
                    context.SaveChanges();
                    transaction.Commit();
                }
                return 1;

            }
        }

        public void DeleteSoldier(int SoldierId)
        {
            Delete(SoldierId);
        }

        public Soldier ValidateAlreadyExist(Soldier model)
        {
            return GetById(e => e.SoldierId != model.SoldierId  && (e.SoldierName1 == model.SoldierName1 || e.SoldierName2 == model.SoldierName2 ||
            e.SoldierName3 == model.SoldierName3 || e.SoldierName4 == model.SoldierName4 || e.SoldierNameEN == model.SoldierNameEN));
        }


        [Obsolete]
        public string GetProSoldiersAll()
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetSoldiersAll ";
                var data = DbContext.JsonData.FromSql(Sql).AsEnumerable().FirstOrDefault().Data;
                return data.ToString();
            }
        }
    }
}
