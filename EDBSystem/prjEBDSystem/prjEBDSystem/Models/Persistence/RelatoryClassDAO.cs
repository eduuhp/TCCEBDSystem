using prjConnectionFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjEBDSystem.Models.Persistence
{/// <summary>
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
    class RelatoryClassDAO : IDAO<RelatoryClass>
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

        public void Insert(RelatoryClass obj)
        {
            throw new NotImplementedException();
        }

        public List<RelatoryClass> Select()
        {
            throw new NotImplementedException();
        }

        public List<RelatoryClass> Select(string search)
        {
            throw new NotImplementedException();
        }

        public RelatoryClass Select(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(RelatoryClass obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}