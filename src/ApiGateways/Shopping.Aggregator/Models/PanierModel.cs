using System;
using System.Collections.Generic;

namespace Shopping.Aggregator.Models
{
    public class PanierModel
    {
        public string UserName { get; set; }
        public List<PanierItemExtendedModel> Items { get; set; } = new List<PanierItemExtendedModel>();
        public decimal TotalPrice { get; set; }
    }
}
