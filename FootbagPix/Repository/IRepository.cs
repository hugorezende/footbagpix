// <copyright file="IRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FootbagPix.Repository
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface of a Repository class.
    /// </summary>
    /// <typeparam name="T">The entity we wish to store operate on with the repository.</typeparam>
    public interface IRepository<T>
        where T : class
    {
        /// <summary>
        /// Gets a T object with the given ID.
        /// </summary>
        /// <param name="gameID">The ID of the T object we wish to get.</param>
        /// <returns>The T object with the given ID.</returns>
        T GetById(Guid gameID);

        /// <summary>
        /// Gets all T objects.
        /// </summary>
        /// <returns>All T objects.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Adds a new T object.
        /// </summary>
        /// <param name="entity">The T we wish to add.</param>
        void Add(T entity);

        /// <summary>
        /// Removes a T object.
        /// </summary>
        /// <param name="entity">The T object we wish to remove.</param>
        void Remove(T entity);

        /// <summary>
        /// Saves the changes performed on the the list of objects.
        /// </summary>
        void SaveChanges();
    }
}
