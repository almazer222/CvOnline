using CvOnline.Domain.Models;
using CvOnline.Domain.Repositories;
using CvOnline.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> AuthentificateAsync(string email, string password)
        {
            return await _unitOfWork.UserRepository.AuthentificateAsync(email, password);
        }

        public async Task<User> CreateUserWithEntrepriseAndAddressAsync(User user, string password, Entreprise entreprise, Address address)
        {
            var newAddress = await _unitOfWork.AddressRepository.AddAsync(address);

            entreprise.Address = newAddress;

            var newEntreprise = await _unitOfWork.EntrepriseRepository.AddAsync(entreprise);

            user.Entreprise = newEntreprise;

            var newUser = await _unitOfWork.UserRepository.CreateAsync(user, password);
            await _unitOfWork.SaveChangesAsync();

            return newUser;
        }

        public async Task RemoveUserAsync(User user)
        {
            _unitOfWork.UserRepository.Remove(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.UserRepository.GetUserByIdAsync(id);
        }

        public async Task UpdateUserAsync(User user, string password = null)
        {
            await _unitOfWork.UserRepository.UpdateAsync(user, password);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
