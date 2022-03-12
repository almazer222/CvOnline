using CvOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Domain.Repositories
{
    public interface ICvItemsRepository : IRepository<CV>
    {
        Task<CV> GetCvItemsByIdAsync(int id);
    }
}
