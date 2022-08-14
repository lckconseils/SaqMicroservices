using System;
namespace Panier.Api
{
    public class PanierItem
    {
        public PanierItem()
        {
        }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string CatalogId { get; set; }
        public string CatalogName { get; set; }
    }
}
