using bdis_meistrija.Shared.Entities;
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

        public async Task<IEnumerable<DefMsg>> GetMeistrijaDefMsgsAsync()
        {
            List<DefMsg> defMsgs = new List<DefMsg>();
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
                        defMsgs.Add(new DefMsg(
                            reader.GetInt32(reader.GetOrdinal("id")),
                            Convert.ToInt32(reader.GetInt16(reader.GetOrdinal("linijaid"))),
                            reader.GetString(reader.GetOrdinal("kelias")),
                            reader.GetInt32(reader.GetOrdinal("km")),
                            Utils.GetValueOrNull<Int32>("pk", reader),
                            Utils.GetValueOrNull<Int32>("m", reader),
                            Utils.GetStringOrNull<string>("siule", reader),
                            reader.GetString(reader.GetOrdinal("kodas")),
                            reader.GetString(reader.GetOrdinal("pavoj")),
                            reader.GetString(reader.GetOrdinal("btipas")),
                            reader.GetDateTime(reader.GetOrdinal("aptikta")),
                            Utils.GetValueOrNull<DateTime>("terminas", reader),
                            Utils.GetValueOrNull<DateTime>("actionDate", reader),
                            Utils.GetStringOrNull<string>("actionid", reader)
                            ));
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return defMsgs;
        }


        public async Task<ActionResult<Message>> SaveMeistrijaMessageAsync(Message message)
        {
            using SqlConnection connection = new SqlConnection(connectionStrings.DefaultConnection);
            try
            {
                connection.Open();
                const string sqlInsert = @"insert into meistrijamsg (defid, author, actiondate, actionid) values (@defid, SYSTEM_USER, @actiondate, @actionid)";

                using SqlCommand command = new SqlCommand(sqlInsert, connection);

                command.Parameters.AddWithValue("@defid", message.DefId);
                Utils.AddNullableParameter("@actiondate", SqlDbType.DateTime, message.ActionDate, command.Parameters);
                Utils.AddNullableParameter("@actionid", SqlDbType.NVarChar, message.ActionId, command.Parameters, 5);

                int result = await command.ExecuteNonQueryAsync();
                if (result == 1)
                {
                    return message;
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
