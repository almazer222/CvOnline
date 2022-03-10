using CvOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Domain.Services
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> GetAllAddressAsync();
        Task<Address> GetAddressByIdAsync(int id);
        Task CreateAddressAsync(Address address);
        Task UpdateAddressAsync(Address address);
        Task RemoveAddressAsync(Address address);
    }
}
