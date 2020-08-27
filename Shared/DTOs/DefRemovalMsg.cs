using System;
using System.Collections.Generic;
using System.Text;

namespace bdis_meistrija.Shared.DTOs
{
    public class DefRemovalMsg
    {
        public int DefId { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? ActionId { get; set; }
    }
}
