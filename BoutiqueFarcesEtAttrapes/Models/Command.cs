using System;

namespace BoutiqueFarcesEtAttrapes.Models
{
    public class Command
    {
        public int CommandId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
