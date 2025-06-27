using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using web_nha_sach_lt.Models;

namespace web_nha_sach_lt.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Sach> Sach { get; set; }
    }
}
