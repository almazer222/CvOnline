using CvOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Domain.Services
{
    public interface ICvItemService
    {
        Task<CV> GetCvItemByIdAsync(int id);
        Task CreateCvItemAsync(CV cvItem);
        Task UpdateCvItemAsync(CV cvItem);
        Task RemoveCvItemAsync(CV cvItem);
    }
}
