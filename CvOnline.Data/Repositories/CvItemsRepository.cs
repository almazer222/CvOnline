using CvOnline.Domain.Models;
using CvOnline.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Infrastructure.Repositories
{
    internal class CvItemsRepository : Repository<CV>, ICvItemsRepository
    {
        private CvOnlineDbContext CvOnlineDbContext
        {
            get { return _context as CvOnlineDbContext; }
        }

        /// <summary>
        /// Contructor to inject the DbContext
        /// </summary>
        /// <param name="context"></param>
        public CvItemsRepository(DbContext context) : base(context)
        {
        }


        /// <summary>
        /// Methode poru récuperer un utlisateur par identifiant.
        /// </summary>
        /// <param name="id">Identifiant.</param>
        /// <returns>utilisateur trouvé.</returns>
        public async Task<CV> GetCvItemsByIdAsync(int id)
        {
            return await CvOnlineDbContext.CV
                                     .Include(i => i.Identities)
                                     .ThenInclude(e => e.Address)
                                     .Include(i => i.Certifications)
                                     .Include(i => i.Socials)
                                     .Include(i => i.Skills)
                                     .ThenInclude(e => e.SkillItems)
                                     .Include(i => i.Interests)
                                     .Include(i => i.Educations)
                                     .Include(i => i.Experiances)
                                     .SingleOrDefaultAsync(x => x.Id == id);

        }
    }
}
