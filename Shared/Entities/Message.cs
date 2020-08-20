using System;
using System.Collections.Generic;
using System.Text;

namespace bdis_meistrija.Shared.Entities
{
    public class Message
    {
        public int DefId { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? ActionId { get; set; }

        public Message()
        {

        }

        public Message(int defId, DateTime? actionDate, string? actionId)
        {
            DefId = defId;
            ActionDate = actionDate;
            ActionId = actionId;
        }



    }
}
