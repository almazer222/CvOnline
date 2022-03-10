using CvOnline.Domain.Models;
using CvOnline.Domain.Repositories;
using CvOnline.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvOnline.Service.Services
{
    internal class CvItemService : ICvItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CvItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// To create a new item cv on asynchronyms
        /// </summary>
        /// <param name="cvItem">object cv</param>
        /// <returns></returns>
        public async Task CreateCvItemAsync(CvItems cvItem)
        {
            await _unitOfWork.CvItemRepository.AddAsync(cvItem);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// To get items Cv by id on async. 
        /// </summary>
        /// <param name="id">Id of cv</param>
        /// <returns></returns>
        public async Task<CvItems> GetCvItemByIdAsync(int id)
        {
          return await _unitOfWork.CvItemRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// To remove a cv on async
        /// </summary>
        /// <param name="cvItem"></param>
        /// <returns></returns>
        public async Task RemoveCvItemAsync(CvItems cvItem)
        {
            _unitOfWork.CvItemRepository.Remove(cvItem);
            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// To update a cv on async
        /// </summary>
        /// <param name="cvItem"></param>
        /// <returns></returns>
        public async Task UpdateCvItemAsync(CvItems cvItem)
        {
            _unitOfWork.CvItemRepository.Update(cvItem);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
