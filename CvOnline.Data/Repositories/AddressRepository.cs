using CvOnline.Domain.Models;
using CvOnline.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CvOnline.Infrastructure.Repositories
{
    public class AddressRepository : Repository<Address>
    {
        public AddressRepository(CvOnlineDbContext context) : base(context)
        {

        }
    }
}
