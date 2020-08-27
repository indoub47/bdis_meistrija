using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bdis_meistrija.Shared.DTOs
{
    public class DefWithMsg
    {
        public int Id { get; set; }
        public int Linija { get; set; }
        public string Kelias { get;  set; }
        public int Km { get; set; }
        public int? Pk { get; set; }
        public int? M { get; set; }
        public string? Siule { get; set; }
        public string Kodas { get; set; }
        public string Pavoj { get; set; }
        public string BTipas { get; set; }
        public DateTime Aptikta { get; set; }
        public DateTime? Terminas { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? ActionId { get; set; }
    }
}
