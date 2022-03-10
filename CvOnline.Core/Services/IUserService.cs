using CvOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Domain.Services
{
    public interface IUserService
    {
        Task<User> AuthentificateAsync(string email, string password);
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserWithEntrepriseAndAddressAsync(User user, string password, Entreprise entreprise, Address address);
        Task UpdateUserAsync(User user, string password = null);
        Task RemoveUserAsync(User user);
    }
}
