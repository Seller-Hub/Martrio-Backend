using Microsoft.EntityFrameworkCore;
using SellerHub.Models;
using System.Collections.Generic;

namespace SellerHub.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();
    }
}
