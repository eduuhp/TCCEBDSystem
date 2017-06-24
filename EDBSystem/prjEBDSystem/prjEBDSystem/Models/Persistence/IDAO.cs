using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjEBDSystem.Models.Persistence
{
    interface IDAO<T> where T : class
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        List<T> Select();
        T Select(int id);
        List<T> Select(string search);
    }
}
