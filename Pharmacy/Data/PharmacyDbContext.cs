using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pharmacy.Models;

namespace Pharmacy.Data
{
    public class PharmacyDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public PharmacyDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
    }
}