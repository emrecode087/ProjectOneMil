﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectOneMil.Data;

namespace ProjectOneMil.Models
{
    public class IdentitySeedData 
    {
        private const string adminUser = "admin";
        private const string adminPassword = "Admin_123";

        public static async void IdentityTestUser(IApplicationBuilder app)
            {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<IdentityContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            var userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            var user = await userManager.FindByNameAsync(adminUser);

            if( user == null)
            {
                user = new AppUser
                {
                    FullName = "Emre Baş",
                    UserName = adminUser,
                    Email = "admin@project.com",
                    PhoneNumber = "1234567890"
                };

                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
