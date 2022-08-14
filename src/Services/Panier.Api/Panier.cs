using System;
using System.Collections.Generic;

namespace Panier.Api
{
    public class Panier
    {
        public string UserName { get; set; }
        public List<PanierItem> Items { get; set; } = new List<PanierItem>();

        public Panier()
        {
        }

        public Panier(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }
                return totalprice;
            }
        }
    }
}
