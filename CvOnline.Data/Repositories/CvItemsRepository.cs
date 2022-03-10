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
    internal class CvItemsRepository : Repository<CvItems>
    {
        /// <summary>
        /// Contructor to inject the DbContext
        /// </summary>
        /// <param name="context"></param>
        public CvItemsRepository(DbContext context) : base(context)
        {
        }
    }
}
