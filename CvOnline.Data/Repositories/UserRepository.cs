using CvOnline.Domain.Models;
using CvOnline.Domain.Repositories;
using CvOnline.Infrastructure;
using CvOnline.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CvOnline.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private CvOnlineDbContext CvOnlineDbContext
        {
            get { return _context as CvOnlineDbContext; }
        }
        public UserRepository(CvOnlineDbContext context) : base(context)
        { }

        /// <summary>
        /// Methode d'authentification
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">Mot de passe</param>
        /// <returns>l'utilisateur si il est connecté</returns>
        public async Task<User> AuthentificateAsync(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)) return null;

            var user = await CvOnlineDbContext.User.SingleOrDefaultAsync(u => u.Email == email);

            if (user == null) return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt)) return null;

            return user;
        }

        /// <summary>
        /// Creation d'un utilisateur
        /// </summary>
        /// <param name="user">utilisateur à créer</param>
        /// <param name="password">mot de passe</param>
        /// <returns>utilisateur</returns>
        public async Task<User> CreateAsync(User user, string password)
        {
            if (user == null || string.IsNullOrEmpty(password)) return null;

            try
            {
                var userFind = await CvOnlineDbContext.User.AnyAsync(u => u.Email == user.Email);
                if (userFind) throw new Exception("User already used.");

                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                var newUser = await CvOnlineDbContext.User.AddAsync(user);

                return newUser.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// methode de mise à jour de l'utilisateur.
        /// </summary>
        /// <param name="user">utilisateur modifier</param>
        /// <param name="password">mot de passe</param>
        /// <returns>utilisateur</returns>
        public async Task<User> UpdateAsync(User user, string password = null)
        {
            var result = await CvOnlineDbContext.User.AnyAsync(u => u.Email == user.Email);
            if (!result) throw new Exception("User not found");

            var userFind = await CvOnlineDbContext.User.FindAsync(user);

            if (user.Email != userFind.Email)
            {
                var emailAlreadyUse = await CvOnlineDbContext.User.AnyAsync(x => x.Email == user.Email);
                if (emailAlreadyUse)
                {
                    throw new Exception("This email's already used.");
                }
            }

            if (!string.IsNullOrEmpty(password))
            {
                CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordSalt = passwordSalt;
                user.PasswordHash = passwordHash;
            }

            CvOnlineDbContext.Update(user);

            return user;
        }

        /// <summary>
        /// Methode poru récuperer un utlisateur par identifiant.
        /// </summary>
        /// <param name="id">Identifiant.</param>
        /// <returns>utilisateur trouvé.</returns>
        public async Task<User> GetUserByIdAsync(int id)
        {
           var user =  await CvOnlineDbContext.User
                                    .Include(u => u.Entreprise)
                                    .ThenInclude(e => e.Address)
                                    .SingleOrDefaultAsync(x => x.Id == id);

            return user;
        }

        /// <summary>
        /// Methode pour supprimer un utilisateur.
        /// </summary>
        /// <param name="user">Utilisateur à supprimer</param>
        public void Remove(User user)
        {
            CvOnlineDbContext.User.Remove(user);
        }

        #region Methods private
        /// <summary>
        /// Méthode de hashage d'un mot de passe pour un nouvel utilisateur.
        /// </summary>
        /// <param name="password">Mdp rentré par l'utilisateur</param>
        /// <param name="passwordHash">Mdp se hash</param>
        /// <param name="passwordSalt">Mdp qui se salt</param>
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        /// <summary>
        /// Methode de vérification du hashage du mot de passe
        /// </summary>
        /// <param name="password">Mot de passe entrée par l'utilisateur</param>
        /// <param name="storedHash">Hash enregistré en base</param>
        /// <param name="storedSalt">Salt enregistré en base</param>
        /// <returns>True : Mdp correct, False : Mdp incorrect </returns>
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
        #endregion
    }
}
