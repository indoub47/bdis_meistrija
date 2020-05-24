using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdis_meistrija.Client.Entities
{
    public class Defect
    {
        public Defect(int id, int linija, string kelias, int km, int pk, int m, string siule, string kodas, string pavoj, string btipas, DateTime aptikta, DateTime? terminas, DateTime? atlikta, string actionId)
        {
            this.id = id;
            this.linija = linija;
            this.kelias = kelias;
            this.km = km;
            this.pk = pk;
            this.m = m;
            this.siule = siule;
            this.kodas = kodas;
            this.pavoj = pavoj;
            this.btipas = btipas;
            this.aptikta = aptikta;
            this.terminas = terminas;
            this.atlikta = atlikta;
            this.actionId = actionId;
        }
        public int id { get; set; }
        public int linija { get; set; }
        public string kelias { get;  set; }
        public int km { get; set; }
        public int pk { get; set; }
        public int m { get; set; }
        public string siule { get; set; }
        public string kodas { get; set; }
        public string pavoj { get; set; }
        public string btipas { get; set; }
        public DateTime aptikta { get; set; }
        public DateTime? terminas { get; set; }
        public DateTime? atlikta { get; set; }
        public string actionId { get; set; }

        public static readonly string sqlGet = "select id, linija, kelias, km, pk, m, siule, kodas, pavoj, btipas, aptikta, terminas, pastaba from {0} where meistrijaid = {1} and panaikinta is null order by linija, kelias, km, pk, m, siule";
        //public static readonly string sqlInsertMessage = "insert into craft.craftmessage (author, meistrijaid, defid, date, actionid, note) values ({0}, {1}, {2}, '{3}', '{4}', '{5}')";
        //public static readonly string sqlSetPanaikinta = "update defhistory set panaikinta = '{0}' where defmainid = {1} and panaikinta >= aptikta and {2} = (select meistrijaid from defmain where id = {3})";
    }
}
