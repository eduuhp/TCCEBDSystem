using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjConnectionFactory;
using prjEntity;

namespace prjPersistence
{
    /// <summary>
    /// =======================================================================
    /// Author:             Henryque, Eduardo
    /// Co-Author:          Passos, Lucas
    /// Create date:        05/06/2017
    /// Modification date:  05/06/2017
    /// Description:        RelatoryClass Data Access Object
    /// Properties:         
    /// Constructors:       
    /// Methods:            
    /// Dependencies:       
    /// =======================================================================
    /// </summary>
    class RelatoryClassDAO : IDAO<TRelatoryClass>
    {

        #region PROPERTIES

        private ConnectionFactory _objConnectionFactory = null;

        #endregion

        #region CONSTRUCTORS

        public RelatoryClassDAO(ConnectionFactory objConnectionFactory)
        {
            _objConnectionFactory = objConnectionFactory;
        }

        #endregion

        #region METHODS

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TRelatoryClass obj)
        {
            throw new NotImplementedException();
        }

        public List<TRelatoryClass> Select()
        {
            throw new NotImplementedException();
        }

        public List<TRelatoryClass> Select(string search)
        {
            throw new NotImplementedException();
        }

        public TRelatoryClass Select(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TRelatoryClass obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
