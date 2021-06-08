using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Services
{
    public interface IService<T>
    {
        bool Validate(T entity);

        public IEnumerable<T> List();

        public bool Exists(int id);

        public T Get(int id);

        public bool Create(T entity);

        public bool Edit(int id, T entity);

        public bool Delete(T entity);
    }
}
