using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class MeistrijaDefectsData : IMeistrijaDefectsData
    {
        private readonly ISqlDataAccess _db;

        public MeistrijaDefectsData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<MeistrijaDefectModel>> FetchDefects()
        {
            string sql = @"select main.id, linija, kelias, km, pk, m, siule, kodas, pavoj, btipas, aptikta, terminas, pastaba, actiondate as atlikta, actionid
                from 
                dbo.defmain as main 
                inner join 
                dbo.defhistory as hist 
                on main.id = hist.defmainid
                left join
                (
                   select * from craftsmessage
                   where done = 0
                ) as cmessage
                on main.id = cmessage.defid
                where main.meistrijaid = 406 and hist.panaikinta is null 
                order by main.linija, main.kelias, main.km, main.pk, main.m, main.siule;";
            return _db.LoadData<MeistrijaDefectModel, dynamic>(sql, new { });
        }

        public Task SetDefectPanaikintas(MeistrijaDefectModel defect)
        {
            string sql = @"update dbo.defhistory set panaikinta=@panaikinta 
                    where 
                        defmainid=@id and 
                        panaikinta is null and 
                        406 = (select meistrijaid from defmain where id = @id);";
            return _db.SaveData(sql, defect);
        }
    }
}
