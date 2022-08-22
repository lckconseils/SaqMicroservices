using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Promotion.Grpc.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly IConfiguration _configuration;

        public PromotionRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<bool> CreatePromotion(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected =
                await connection.ExecuteAsync
                    ("INSERT INTO Coupon (ProductName, Description, Montant) VALUES (@ProductName, @Description, @Montant)",
                            new { ProductName = coupon.ProductName, Description = coupon.Description, Montant = coupon.Montant });

            if (affected == 0)
                return false;

            return true;
        }

        public async Task<bool> DeletePromotion(string productName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName",
                new { ProductName = productName });

            if (affected == 0)
                return false;

            return true;
        }

        public async Task<Coupon> GetPromotion(string productName)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

            if (coupon == null)
                return new Coupon { ProductName = "No Discount", Montant = 0, Description = "No Discount Desc" };
            return coupon;
        }

        public async Task<bool> UpdatePromotion(Coupon coupon)
        {
            using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync
                    ("UPDATE Coupon SET ProductName=@ProductName, Description = @Description, Montant = @Montant WHERE Id = @Id",
                            new { ProductName = coupon.ProductName, Description = coupon.Description, Montant = coupon.Montant, Id = coupon.Id });

            if (affected == 0)
                return false;

            return true;
        }
    }
}
