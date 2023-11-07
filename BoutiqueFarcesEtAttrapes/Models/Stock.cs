using System.ComponentModel.DataAnnotations;

namespace BoutiqueFarcesEtAttrapes.Models
{
    public class Stock
    {
        [Key]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
