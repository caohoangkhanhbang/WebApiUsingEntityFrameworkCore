using Microsoft.EntityFrameworkCore;
using WebApiUsingEntityFrameworkCore.Models;

namespace WebApiUsingEntityFrameworkCore.ADO
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options): base(options) { }

        public DbSet<SanPham> SanPham { get; set; }
    }
}
