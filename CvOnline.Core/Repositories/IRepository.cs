using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CvOnline.Domain.Repositories
{
    public interface IRepository <TEntity> where TEntity : class
    {
        /// <summary>
        /// Methode d'ajout d'une entity à une table
        /// </summary>
        /// <param name="entity">Entity voulue</param>
        /// <returns>L'entity nouvellement créée</returns>
        Task<TEntity> AddAsync(TEntity entity);
        /// <summary>
        /// Methode d'ajout d'une entity à une table
        /// </summary>
        /// <param name="entity">Entity voulue</param>
        /// <returns>L'entity nouvellement créée</returns>
        void Update(TEntity entity);
        /// <summary>
        /// Methode de suppression d'une entity à une table
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);
        /// <summary>
        /// Methode pour retourner tous les éléments d'une table
        /// </summary>
        /// <returns>Tous les éléments de l'entity</returns>
        ValueTask<IEnumerable<TEntity>> GetAllAsync();
        /// <summary>
        /// Methode pour retourner un élémenet spécifique d'une entité
        /// </summary>
        /// <param name="id">identifiant de l'élément</param>
        /// <returns>Element rechercher</returns>
        ValueTask<TEntity> GetByIdAsync(int id);
        /// <summary>
        /// methode pour trouver une seule et unique donnée via predicate
        /// </summary>
        /// <param name="predicate">predicate</param>
        /// <returns></returns>
        ValueTask<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// methode pour trouver une donnée via predicate
        /// </summary>
        /// <param name="predicate">predicate</param>
        /// <returns></returns>
        ValueTask<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);

       
    }
}
