using CvOnline.Domain.Models;
using System.Threading.Tasks;

namespace CvOnline.Domain.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Methode d'authentification
        /// </summary>
        /// <param name="email">Email de l'utilisateur</param>
        /// <param name="password">Mot de passe de l'utilisateur</param>
        /// <returns>Returne la connection de l'utilisateur.</returns>
        Task<User> AuthentificateAsync(string email, string password);
        /// <summary>
        /// Methode de création d'un utilisateur avec Token.
        /// </summary>
        /// <param name="user">Utilisateur à créer</param>
        /// <param name="password">Mot de passe entrée par l'utilisateur</param>
        /// <returns>Returne le nouvel utilisateur.</returns>
        Task<User> CreateAsync(User user, string password);
        /// <summary>
        /// Methode de mise à jour d'un utilisateur
        /// </summary>
        /// <param name="user">Utilisateur à créer</param>
        /// <param name="password">Mot de passe mis à jour par l'utilisateur</param>
        /// <returns>Returne l'utilisateur mis à jour.</returns>
        Task<User> UpdateAsync(User user, string password = null);
        /// <summary>
        /// Methode pour obtenir un utilisateur par identifiant.
        /// </summary>
        /// <param name="id">Identifiant</param>
        /// <returns>Returne l'utilisateur.</returns>
        Task<User> GetUserByIdAsync(int id);
        /// <summary>
        /// Methode pour supprimer un utilisateur.
        /// </summary>
        /// <param name="user">Utilisateur à supprimer</param>
        void Remove(User user);
    }
}
