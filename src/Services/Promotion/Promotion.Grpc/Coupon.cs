using System;

namespace Promotion.Grpc
{
    public class Coupon
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Montant { get; set; }
    }
}
