using prjConnectionFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace prjEBDSystem.Models.Persistence
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
    public class RestrictionDAO : IDAO<Restriction>
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

        public void Insert(Restriction obj)
        {
            throw new NotImplementedException();
        }

        public List<Restriction> Select()
        {
            DataTable dtRestriction = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectRestriction");

            Restriction objRestriction = null;

            List<Restriction> lstRestriction = new List<Restriction>();

            foreach (DataRow row in dtRestriction.Rows)
            {
                objRestriction = new Restriction(row);
                lstRestriction.Add(objRestriction);
                objRestriction = null;
            }

            return lstRestriction;
        }

        public List<Restriction> Select(string search)
        {
            throw new NotImplementedException();
        }

        public Restriction Select(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Restriction obj)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}