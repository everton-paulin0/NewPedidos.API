

namespace Newpedidos.Application.Model
{
    public class UpdateProductInputModel
    {
        public int IdProduct { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalCost { get; set; }

    }
}
