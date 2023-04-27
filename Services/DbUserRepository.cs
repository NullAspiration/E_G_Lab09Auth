using E_G_Lab09Auth.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace E_G_Lab09Auth.Services
{
    public class DbUserRepository : IUserrepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public DbUserRepository(ApplicationDbContext db, 
            UserManager<ApplicationUser> userManager)
        { 
            _db = db;
            _userManager =userManager;
        }

        public async Task<ApplicationUser?> ReadByUserNameAsync(string username)
        { 
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserName == username);
            return user;
        }
    }
}
