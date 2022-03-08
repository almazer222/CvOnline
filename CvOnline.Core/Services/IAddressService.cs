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
        Task<IEnumerable<Address>> GetAllAddress();
        Task<Address> GetAddressById(int id);
        Task CreateAddress(Address address);
        Task UpdateAddress(Address address);
        Task RemoveAddress(Address address);
    }
}
