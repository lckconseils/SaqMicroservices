using System;
using System.Collections.Generic;

namespace Shopping.Aggregator.Models
{
    public class ShoppingModel
    {
        public string UserName { get; set; }
        public PanierModel PanierWithProducts { get; set; }
        public IEnumerable<CommandeResponseModel> Commandes { get; set; }
    }
}
