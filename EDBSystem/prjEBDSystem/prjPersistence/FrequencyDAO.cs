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
    /// Description:        Frequency Data Access Object
    /// Properties:         
    /// Constructors:       
    /// Methods:            
    /// Dependencies:       
    /// =======================================================================
    /// </summary>
    class FrequencyDAO :IDAO<TFrequency> 
    {

        #region PROPERTIES

        private ConnectionFactory _objConnectionFactory = null;

        #endregion

        #region CONSTRUCTORS

        public FrequencyDAO(ConnectionFactory objConnectionFactory)
        {
            _objConnectionFactory = objConnectionFactory;
        }

        #endregion

        #region METHODS

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TFrequency obj)
        {
            throw new NotImplementedException();
        }

        public List<TFrequency> Select()
        {
            throw new NotImplementedException();
        }

        public List<TFrequency> Select(string search)
        {
            throw new NotImplementedException();
        }

        public TFrequency Select(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TFrequency obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
