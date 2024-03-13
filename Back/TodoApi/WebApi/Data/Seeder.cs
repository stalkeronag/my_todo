using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using WebApi.Models;

namespace WebApi.Data
{
    public static class Seeder
    { 
        public async static void Seed(UserManager<User> userManager,RoleManager<UserRole> roleManager,AppDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }
            var seedUsers = JsonConvert.DeserializeObject<SeedUserInfo>(File.ReadAllText("Resources/SeedUser.json"));
            foreach (var user in seedUsers.users)
            {
                await roleManager.CreateAsync(new UserRole()
                {
                    Name = user.Role
                });

                await context.SaveChangesAsync();

                User currentUser = new User()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };

                string hash = userManager.PasswordHasher.HashPassword(currentUser, user.Password);
                
                await userManager.AddPasswordAsync(currentUser, hash);

                await userManager.CreateAsync(currentUser);
                
                await context.SaveChangesAsync();

                User newUser = await userManager.FindByEmailAsync(user.Email);

                await userManager.AddToRoleAsync(newUser, user.Role);

                await context.SaveChangesAsync();
            }
        }
    }
}
