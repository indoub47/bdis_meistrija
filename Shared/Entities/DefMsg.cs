using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdis_meistrija.Shared.Entities
{
    public class DefMsg
    {
        public DefMsg()
        { }

        public DefMsg(int id, int linijaId, string kelias, int km, int? pk, int? m, string? siule, string kodas, string pavoj, string btipas, DateTime aptikta, DateTime? terminas, DateTime? actionDate, string? actionId)
        {
            this.Id = id;
            this.Linija = linijaId;
            this.Kelias = kelias;
            this.Km = km;
            this.Pk = pk;
            this.M = m;
            this.Siule = siule;
            this.Kodas = kodas;
            this.Pavoj = pavoj;
            this.Btipas = btipas;
            this.Aptikta = aptikta;
            this.Terminas = terminas;
            this.ActionDate = actionDate;
            this.ActionId = actionId;
        }
        public int Id { get; set; }
        public int Linija { get; set; }
        public string Kelias { get;  set; }
        public int Km { get; set; }
        public int? Pk { get; set; }
        public int? M { get; set; }
        public string? Siule { get; set; }
        public string Kodas { get; set; }
        public string Pavoj { get; set; }
        public string Btipas { get; set; }
        public DateTime Aptikta { get; set; }
        public DateTime? Terminas { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? ActionId { get; set; }
    }
}
