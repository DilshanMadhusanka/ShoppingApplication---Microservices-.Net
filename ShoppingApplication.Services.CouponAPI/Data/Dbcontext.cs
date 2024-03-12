using Microsoft.EntityFrameworkCore;

namespace ShoppingApplication.Services.CouponAPI.Data
{
    public class Dbcontext
    {
        private DbContextOptions<AppDbContext> options;

        public Dbcontext(DbContextOptions<AppDbContext> options)
        {
            this.options = options;
        }
    }
}