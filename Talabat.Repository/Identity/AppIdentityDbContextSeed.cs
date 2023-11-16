using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Identity;

namespace Talabat.Repository.Identity
{
    public static class AppIdentityDbContextSeed
    {

        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Ameen Muhammad",
                    Email = "hosan2662000@gmail.com",
                    UserName = "ameen2606",
                    PhoneNumber = "123456789"
                };

                await userManager.CreateAsync(user);
            }
        }

    }
}
