using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.Repository
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        T GetByUserNameAndPass(T obj);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
