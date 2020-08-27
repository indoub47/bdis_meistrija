using bdis_meistrija.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using bdis_meistrija.Server.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace bdis_meistrija.Server.Data
{
    public class MSSQLDefMsgRepo : IDefMsgRepo
    {
        readonly ConnectionStrings connectionStrings;

        public MSSQLDefMsgRepo(IOptions<ConnectionStrings> connectionStrings)
        {
            this.connectionStrings = connectionStrings.Value;
        }

        public async Task<IEnumerable<DefWithMsg>> GetMeistrijaDefMsgsAsync()
        {
            List<DefWithMsg> defWithMsgs = new List<DefWithMsg>();
            using (SqlConnection connection = new SqlConnection(connectionStrings.DefaultConnection))
            {
                try
                {
                    connection.Open();
                    const string sqlGet = @"select id, linijaid, kelias, km, pk, m, siule, kodas, pavoj, btipas, aptikta, terminas, meistrijamsgLeft.actiondate, meistrijamsgLeft.actionid
from
(select * from defmain where meistrijaid = @meistrijaid) as main
inner join 
(select * from defhistory where panaikinta is null) as history
on main.id = history.defmainid
left join 
meistrijamsg as meistrijamsgLeft
on main.id = meistrijamsgLeft.defid
left join 
meistrijamsg as meistrijamsgRight
on meistrijamsgLeft.defid = meistrijamsgRight.defid and meistrijamsgLeft.tmstp < meistrijamsgRight.tmstp
where meistrijamsgRight.defid is null
order by main.id";

                    using SqlCommand command = new SqlCommand(sqlGet, connection);
                    command.Parameters.AddWithValue("@meistrijaid", 406);
                    using SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        defWithMsgs.Add(new DefWithMsg()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("id")),
                            Linija = Convert.ToInt32(reader.GetInt16(reader.GetOrdinal("linijaid"))),
                            Kelias = reader.GetString(reader.GetOrdinal("kelias")),
                            Km = reader.GetInt32(reader.GetOrdinal("km")),
                            Pk = Utils.GetValueOrNull<Int32>("pk", reader),
                            M = Utils.GetValueOrNull<Int32>("m", reader),
                            Siule = Utils.GetStringOrNull<string>("siule", reader),
                            Kodas = reader.GetString(reader.GetOrdinal("kodas")),
                            Pavoj = reader.GetString(reader.GetOrdinal("pavoj")),
                            BTipas = reader.GetString(reader.GetOrdinal("btipas")),
                            Aptikta = reader.GetDateTime(reader.GetOrdinal("aptikta")),
                            Terminas = Utils.GetValueOrNull<DateTime>("terminas", reader),
                            ActionDate = Utils.GetValueOrNull<DateTime>("actionDate", reader),
                            ActionId = Utils.GetStringOrNull<string>("actionid", reader)
                        });
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return defWithMsgs;
        }


        public async Task<ActionResult<DefRemovalMsg>> SaveDefRemovalMsgAsync(DefRemovalMsg defRemovalMsg)
        {
            using SqlConnection connection = new SqlConnection(connectionStrings.DefaultConnection);
            try
            {
                connection.Open();
                const string sqlInsert = @"insert into meistrijamsg (defid, author, actiondate, actionid) values (@defid, SYSTEM_USER, @actiondate, @actionid)";

                using SqlCommand command = new SqlCommand(sqlInsert, connection);

                command.Parameters.AddWithValue("@defid", defRemovalMsg.DefId);
                Utils.AddNullableParameter("@actiondate", SqlDbType.DateTime, defRemovalMsg.ActionDate, command.Parameters);
                Utils.AddNullableParameter("@actionid", SqlDbType.NVarChar, defRemovalMsg.ActionId, command.Parameters, 5);

                int result = await command.ExecuteNonQueryAsync();
                if (result == 1)
                {
                    return defRemovalMsg;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
