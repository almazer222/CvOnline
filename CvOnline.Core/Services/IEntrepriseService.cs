using CvOnline.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CvOnline.Domain.Services
{
    public interface IEntrepriseService
    {
        Task<IEnumerable<Entreprise>> GetAllEntreprises();
        Task<Entreprise> GetEntrepriseById(int id);
        Task CreateEntreprise(Entreprise entreprise);
        Task UpdateEntreprise(Entreprise entreprise);
        Task RemoveEntreprise(Entreprise entreprise);
    }
}
