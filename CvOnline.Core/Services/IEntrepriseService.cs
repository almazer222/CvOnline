using CvOnline.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CvOnline.Domain.Services
{
    public interface IEntrepriseService
    {
        Task<IEnumerable<Entreprise>> GetAllEntreprisesAsync();
        Task<Entreprise> GetEntrepriseByIdAsync(int id);
        Task CreateEntrepriseAsync(Entreprise entreprise);
        Task UpdateEntrepriseAsync(Entreprise entreprise);
        Task RemoveEntrepriseAsync(Entreprise entreprise);
    }
}
