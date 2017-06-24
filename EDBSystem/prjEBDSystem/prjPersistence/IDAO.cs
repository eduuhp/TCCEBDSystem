using System.Collections.Generic;

namespace prjPersistence
{
    /// <summary>
    /// =======================================================================
    /// Author:             Passos, Lucas
    /// Co-Author:          Henryque, Eduardo
    /// Create date:        02/06/2017
    /// Modification date:  02/06/2017
    /// Description:        Interface Data Access Object
    /// Methods:            Insert(T obj),
    ///                     Update(T obj),
    ///                     Delete(int id),
    ///                     Select(),
    ///                     Select(int id),
    ///                     Select(string search)
    /// Dependencies:       System.Collections.Generic;
    /// =======================================================================
    /// </summary>
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
