using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recruiting_Company_Web_API.Entities;
using TestApiJWT.Models;

namespace LinkDev.Task.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<ApplicationUser>().HasData(InitBranches());
            base.OnModelCreating(builder);
        }
        private IEnumerable<Branch> InitBranches() =>
            new List<Branch>()
            {
                new (){ BranchId=Guid.NewGuid(),OpeningHour = new TimeSpan(8,00,00),ClosingHour = new TimeSpan(23,30,00) , ManagerName = "Manger 1" , Title = "Department 1"},
                new (){ BranchId=Guid.NewGuid(),OpeningHour = new TimeSpan(9,00,00),ClosingHour = new TimeSpan(22,30,00) , ManagerName = "Manger 2" , Title = "Department 2"},
                new (){ BranchId=Guid.NewGuid(),OpeningHour = new TimeSpan(8,30,00),ClosingHour = new TimeSpan(22,00,00) , ManagerName = "Manger 3" , Title = "Department 3"},
                new (){ BranchId=Guid.NewGuid(),OpeningHour = new TimeSpan(10,00,00),ClosingHour = new TimeSpan(20,30,00) , ManagerName = "Manger 4" , Title = "Department 4"},
            };
    }
}