using E_G_Lab09Auth.Models.Entities;

namespace E_G_Lab09Auth.Services
{
    public interface IUserrepository
    {
        Task<ApplicationUser?> ReadByUserNameAsync(string userName);
    }
}
