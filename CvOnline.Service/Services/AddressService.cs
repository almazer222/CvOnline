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

        public async Task CreateAddressAsync(Address address)
        {
            await _unitOfWork.AddressRepository.AddAsync(address);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveAddressAsync(Address address)
        {
            _unitOfWork.AddressRepository.Remove(address);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> GetAllAddressAsync()
        {
            return await _unitOfWork.AddressRepository.GetAllAsync();
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _unitOfWork.AddressRepository.GetByIdAsync(id);
        }

        public async Task UpdateAddressAsync(Address address)
        {
            _unitOfWork.AddressRepository.Update(address);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
