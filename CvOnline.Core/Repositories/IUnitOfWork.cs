using CvOnline.Domain.Models;
using System;
using System.Threading.Tasks;

namespace CvOnline.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IRepository<Entreprise> EntrepriseRepository { get; }
        IRepository<Address> AddressRepository { get; }
        IRepository<CvItems> CvItemRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
