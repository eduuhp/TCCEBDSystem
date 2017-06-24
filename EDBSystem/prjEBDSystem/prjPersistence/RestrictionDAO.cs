using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjConnectionFactory;
using prjEntity;
using System.Data;

namespace prjPersistence
{
    /// <summary>
    /// =======================================================================
    /// Author:             Henryque, Eduardo
    /// Co-Author:          Passos, Lucas
    /// Create date:        05/06/2017
    /// Modification date:  05/06/2017
    /// Description:        Restriction Data Access Object
    /// Properties:         
    /// Constructors:       
    /// Methods:            
    /// Dependencies:       
    /// =======================================================================
    /// </summary>
    public class RestrictionDAO : IDAO<TRestriction>
    {

        #region PROPERTIES

        private ConnectionFactory _objConnectionFactory = null;

        #endregion

        #region CONSTRUCTORS

        public RestrictionDAO(ConnectionFactory objConnectionFactory)
        {
            _objConnectionFactory = objConnectionFactory;
        }

        #endregion

        #region METHODS

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(TRestriction obj)
        {
            throw new NotImplementedException();
        }

        public List<TRestriction> Select()
        {
            DataTable dtRestriction = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectRestriction");

            TRestriction objRestriction = null;

            List<TRestriction> lstRestriction = new List<TRestriction>();

            foreach (DataRow row in dtRestriction.Rows)
            {
                objRestriction = new TRestriction(row);
                lstRestriction.Add(objRestriction);
                objRestriction = null;
            }

            return lstRestriction;
        }

        public List<TRestriction> Select(string search)
        {
            throw new NotImplementedException();
        }

        public TRestriction Select(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TRestriction obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
