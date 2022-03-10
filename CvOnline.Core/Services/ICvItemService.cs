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
        Task<CvItems> GetCvItemByIdAsync(int id);
        Task CreateCvItemAsync(CvItems cvItem);
        Task UpdateCvItemAsync(CvItems cvItem);
        Task RemoveCvItemAsync(CvItems cvItem);
    }
}
