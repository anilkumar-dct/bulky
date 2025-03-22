using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    /// <summary>
    /// Generic repository interface to define common CRUD operations.
    /// This is used to provide an abstraction layer for data access.
    /// </summary>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Retrieves all records of type T from the database.
        /// </summary>
        /// <returns>Returns an IEnumerable of T.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Retrieves a single record based on a specified filter condition.
        /// </summary>
        /// <param name="filter">Lambda expression for filtering data (e.g., c => c.Id == 1)</param>
        /// <returns>Returns a single object of type T if found, otherwise null.</returns>
        T Get(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Adds a new record of type T to the database.
        /// </summary>
        /// <param name="item">The entity object to be added.</param>
        void Add(T item);

        /// <summary>
        /// Updates an existing record of type T in the database.
        /// </summary>
        /// <param name="item">The entity object with updated values.</param>
        void Update(T item);

        /// <summary>
        /// Removes a single record of type T from the database.
        /// </summary>
        /// <param name="item">The entity object to be deleted.</param>
        void Remove(T item);

        /// <summary>
        /// Removes multiple records from the database at once.
        /// </summary>
        /// <param name="items">A collection of entity objects to be deleted.</param>
        void RemoveRange(IEnumerable<T> items);
    }
}
