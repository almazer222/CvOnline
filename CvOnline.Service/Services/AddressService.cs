using CvOnline.Domain.Models;
using CvOnline.Domain.Repositories;
using CvOnline.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CvOnline.Service.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateAddress(Address address)
        {
            await _unitOfWork.AddressRepository.AddAsync(address);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAddress(Address address)
        {
            _unitOfWork.AddressRepository.Remove(address);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> GetAllAddress()
        {
            return await _unitOfWork.AddressRepository.GetAllAsync();
        }

        public async Task<Address> GetAddressById(int id)
        {
            return await _unitOfWork.AddressRepository.GetByIdAsync(id);
        }

        public async Task UpdateAddress(Address address)
        {
            _unitOfWork.AddressRepository.Update(address);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
