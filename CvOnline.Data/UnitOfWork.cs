using CvOnline.Domain.Models;
using CvOnline.Domain.Repositories;
using CvOnline.Infrastructure.Repositories;
using System.Threading.Tasks;

namespace CvOnline.Infrastructure
{
    /// <summary>
    /// Class Unit of work is used to group one or more operations into a single transaction.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Properties
        private readonly CvOnlineDbContext _context;
        private IUserRepository _userRepository;
        private IRepository<Entreprise> _entrepriseRepository;
        private IRepository<Address> _addressRepository;
        private ICvItemsRepository _cvItemsRepository;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor to inject the DbContext 
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(CvOnlineDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public properties
        /// <summary>
        /// To inject the DBcontext in Cv Item repository
        /// </summary>
        public ICvItemsRepository CvItemRepository => _cvItemsRepository = _cvItemsRepository ?? new CvItemsRepository(_context);

        /// <summary>
        /// To inject the DBcontext in entreprise repository
        /// </summary>
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

        /// <summary>
        /// To inject the DBcontext in Adress repository
        /// </summary>
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

        /// <summary>
        /// If user repository don't exist, the debug inject the db context
        /// </summary>
        public IUserRepository UserRepository => _userRepository = _userRepository ?? new UserRepository(_context);

       
        #endregion

        #region Public method
        /// <summary>
        /// The commit is applied when several operations are performed.
        /// </summary>
        /// <returns></returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        } 
        #endregion
    }
}
