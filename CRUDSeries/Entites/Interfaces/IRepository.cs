using System;
using System.Collections.Generic;

namespace CRUDSeries.Entites.Interfaces
{
    internal interface IRepository<T>
    {
        List<T> List();
        T ReturnById(int id);
        void Insert(T entity);        
        void Remove(int id);
        void Update(int id, T entity);
        int NextId();

    }
}
