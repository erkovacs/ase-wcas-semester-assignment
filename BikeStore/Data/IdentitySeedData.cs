using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Data
{
    public static class IdentitySeedData
    {
        private const string defaultPassword = "$Testpassword1234";

        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var userManager = serviceProvider
                .GetRequiredService<UserManager<IdentityUser>>())
            {

                // Create roles
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                List<string> roles = new List<string> { "ProductReadOnly", "ProductManagement" };
                foreach (string role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                List<IdentityUser> admins = new List<IdentityUser> {
                    new IdentityUser { UserName = "viewerAdmin@admin.com", Email = "viewerAdmin@admin.com" },
                    new IdentityUser { UserName = "editorAdmin@admin.com", Email = "editorAdmin@admin.com" },
                };
                foreach (IdentityUser admin in admins)
                {
                    if (null == await userManager.FindByEmailAsync(admin.Email))
                    {
                        var res = await userManager.CreateAsync(admin, defaultPassword);
                        string role = null;
                        if (admin.Email.StartsWith("viewer"))
                        {
                            role = roles[0];
                        }
                        else if (admin.Email.StartsWith("editor"))
                        {
                            role = roles[1];
                        }
                        if (null != role)
                        {
                            await userManager.AddToRoleAsync(admin, role);
                        }
                    }
                }
            }
        }
    }
}
