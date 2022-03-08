using CvOnline.Domain.Models;
using CvOnline.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CvOnline.Infrastructure.Repositories
{
    public class EntrepriseRepository : Repository<Entreprise>
    {
        public EntrepriseRepository(CvOnlineDbContext context) : base (context)
        {

        }
    }
}
