using CvOnline.Domain.Models;
using CvOnline.Domain.Repositories;
using CvOnline.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CvOnlineDbContext _context;
        private IUserRepository _userRepository;
        private IRepository<Entreprise> _entrepriseRepository;
        private IRepository<Address> _addressRepository;


        public UnitOfWork(CvOnlineDbContext context)
        {
            _context = context;
        }

        public IRepository<Entreprise> EntrepriseRepository
        {
            get
            {
                if (_entrepriseRepository == null)
                {
                    _entrepriseRepository = new EntrepriseRepository(_context);
                }
                return _entrepriseRepository;
            }
        }

        public IRepository<Address> AddressRepository
        {
            get
            {
                if (_addressRepository == null)
                {
                    _addressRepository = new AddressRepository(_context);
                }
                return _addressRepository;
            }
        }

        public IUserRepository UserRepository => _userRepository = _userRepository ?? new UserRepository(_context);

        /// <summary>
        /// Le commit est appliqué quand plusieurs opérations sont éffectués.
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
