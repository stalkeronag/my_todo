using Microsoft.AspNetCore.Identity;
using WebApi.Data;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class UserService : IUserService
    {
        private AppDbContext context;

        private UserManager<User> userManager;


        public UserService(AppDbContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public Task AddRoleInUserById(string id, string role = "user")
        {
            throw new NotImplementedException();
        }

        public async Task AddUser(User user)
        {
            await userManager.CreateAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task DeleteUserById(string id)
        {
            await userManager.DeleteAsync(context.Users.Where(user => user.Id.Equals(id)).First());
            await context.SaveChangesAsync();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            IEnumerable<User> users = context.Users.AsEnumerable();

            return Task.FromResult(users);
        }

        public Task<User> GetUserByEmail(string email)
        {
            return userManager.FindByEmailAsync(email);
        }

        public Task<User> GetUserById(string id)
        {
            User user = context.Users.Where(user => user.Id.Equals(id)).First();
            return Task.FromResult<User>(user);
        }

        public Task UpdateUserById(string id)
        {
            throw new NotImplementedException();
        }

    }
}
