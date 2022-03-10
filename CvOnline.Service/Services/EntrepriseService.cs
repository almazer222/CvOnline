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
    public class EntrepriseService : IEntrepriseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EntrepriseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateEntrepriseAsync(Entreprise entreprise)
        {
            await _unitOfWork.EntrepriseRepository.AddAsync(entreprise);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateEntrepriseAsync(Entreprise entreprise)
        {
            _unitOfWork.EntrepriseRepository.Update(entreprise);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task RemoveEntrepriseAsync(Entreprise entreprise)
        {
            _unitOfWork.EntrepriseRepository.Remove(entreprise);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entreprise>> GetAllEntreprisesAsync()
        {
            return await _unitOfWork.EntrepriseRepository.GetAllAsync();
        }

        public async Task<Entreprise> GetEntrepriseByIdAsync(int id)
        {
            return await _unitOfWork.EntrepriseRepository.GetByIdAsync(id);
        }
    }
}
