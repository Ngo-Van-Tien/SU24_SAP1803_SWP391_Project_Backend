using Azure.Core;
using Infrastructure.Constans;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SWP.Infrastrcuture;
using SWP.Infrastrcuture.Entities;
namespace Infrastructure
{
    public static class DbInitializer
    {
        public async static Task Initialize(UserManager<AppUser> _userManager, RoleManager<IdentityRole> _roleManager, SWPDbContext _context)
        {
            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Name = UserRolesConstant.Admin,
                    NormalizedName = UserRolesConstant.Admin.ToUpper(),
                },
                new IdentityRole()
                {
                    Name = UserRolesConstant.Staff,
                    NormalizedName = UserRolesConstant.Staff.ToUpper(),
                },
                new IdentityRole()
                {
                    Name = UserRolesConstant.Customer,
                    NormalizedName = UserRolesConstant.Customer.ToUpper(),
                },
            };
            if (!_context.Roles.Any(x => x.Name == UserRolesConstant.Admin) && !_context.Roles.Any(x => x.Name == UserRolesConstant.Staff) && !_context.Roles.Any(x => x.Name == UserRolesConstant.Customer))
            {

                await _context.Roles.AddRangeAsync(roles);
                await _context.SaveChangesAsync();
            }
            if (!_context.AppUsers.Any(x => x.Email == "admin@email.com"))
            {
                var user = new AppUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "admin@email.com",
                    FirstName = "admin",
                    LastName = "admin",
                    UserName = "admin@email.com",
                    NormalizedEmail = "ADMIN@EMAIL.COM",
                    NormalizedUserName = "ADMIN@EMAIL.COM",
                    Address = "Location",
                    PhoneNumber = "+111111111111",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };

                await _userManager.CreateAsync(user, "P@ssw0rd");

                await _context.SaveChangesAsync();

                var userRole = new IdentityUserRole<string>()
                {
                    UserId = user.Id,
                    RoleId = roles.FirstOrDefault(x => x.Name == UserRolesConstant.Admin).Id
                };

                await _userManager.AddToRoleAsync(user, UserRolesConstant.Admin);
                // await _context.UserRoles.AddAsync(userRole);

                await _context.SaveChangesAsync();
            }
        }
    }
}
