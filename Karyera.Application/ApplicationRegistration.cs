using Karyera.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();
                CreateRoles(roleManager).Wait();
            }

            return services;
        }

        private static async Task CreateRoles(RoleManager<AppRole> roleManager)
        {
            // Define roles
            string[] roleNames = { "Admin", "User", "Manager" };

            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new AppRole
                    {
                        Name= roleName,
                    });
                }
            }
        }
    }
}
