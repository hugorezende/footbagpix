namespace FootbagPix.Repository
{
    using System;
    using System.Collections.Generic;

    public interface IRepository<T>
        where T : class
    {
        T GetById(Guid gameID);

        IEnumerable<T> GetAll();

        void Add(T entity);

        void Remove(T entity);

        void SaveChanges();
    }
}
