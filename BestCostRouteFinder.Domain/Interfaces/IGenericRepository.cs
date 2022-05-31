using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BestCostRouteFinder.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns>A list of entities</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Finds a list of entities given the expression provided
        /// </summary>
        /// <param name="expression">The search expression</param>
        /// <returns>A list of entities</returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Adds a new entity
        /// </summary>
        /// <param name="entity">The entity to be added</param>
        /// <returns>The created entity</returns>
        T Add(T entity);

        /// <summary>
        /// Adds a list of entities
        /// </summary>
        /// <param name="entities">The list of entities to be added</param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Remove a entity
        /// </summary>
        /// <param name="entity">The entity to be removed</param>
        void Remove(T entity);

        /// <summary>
        /// Remove a list of entities
        /// </summary>
        /// <param name="entities">The list of entities to be removed</param>
        void RemoveRange(IEnumerable<T> entities);

        /// <summary>
        /// Commit the changes
        /// </summary>
        void SaveChanges();
    }
}
