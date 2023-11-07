namespace BoutiqueFarcesEtAttrapes.Models
{
    public class CommandRow
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int CommandId { get; set; }
        public virtual Command Command { get; set; }
        public int Quantity { get; set; }
    }
}
