using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRUDSeries.Entites.Interfaces;

namespace CRUDSeries
{
    internal class SerieRepository : IRepository<Serie>
    {
        List<Serie> serieList = new List<Serie>();
        public void Insert(Serie entity)
        {
            serieList.Add(entity);
        }

        public List<Serie> List()
        {
            return serieList;
        }

        public int NextId()
        {
            return serieList.Count;
        }

        public void Remove(int id)
        {
            serieList[id].Remove();
        }

        public Serie ReturnById(int id)
        {
            return serieList[id];
        }

        public void Update(int id, Serie entity)
        {
            serieList[id] = entity;
        }
    }
}
