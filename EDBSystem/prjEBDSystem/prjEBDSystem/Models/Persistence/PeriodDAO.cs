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
    /// Description:        Period Data Access Object
    /// Properties:         
    /// Constructors:       
    /// Methods:            
    /// Dependencies:       
    /// =======================================================================
    /// </summary>
    public class PeriodDAO : IDAO<Period>
    {

        #region PROPERTIES

        private ConnectionFactory _objConnectionFactory = null;

        #endregion

        #region CONSTRUCTORS

        public PeriodDAO(ConnectionFactory objConnectionFactory)
        {
            _objConnectionFactory = objConnectionFactory;
        }

        #endregion

        #region METHODS

        public void Delete(int Id)
        {
            _objConnectionFactory.AddParameter("@pIdPeriod", Id);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spDeletePeriod");
        }

        public void Insert(Period obj)
        {
            _objConnectionFactory.AddParameter("@pNamePeriod", obj.NamePeriod);
            _objConnectionFactory.AddParameter("@pStartDate", obj.StartDate);
            _objConnectionFactory.AddParameter("@pEndDate", obj.EndDate);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spInsertPeriod");
        }

        public List<Period> Select()
        {
            DataTable dtPeriod = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectPeriod");

            Period objPeriod = null;

            List<Period> lstPeriod = new List<Period>();

            foreach (DataRow row in dtPeriod.Rows)
            {
                objPeriod = new Period(row);
                lstPeriod.Add(objPeriod);
                objPeriod = null;
            }

            return lstPeriod;
        }

        public List<Period> Select(string search)
        {
            throw new NotImplementedException();
        }

        public Period Select(int Id)
        {
            _objConnectionFactory.AddParameter("@pIdPeriod", Id);

            DataTable dtPeriod = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectPeriodById");

            Period objPeriod = null;

            if (dtPeriod.Rows.Count > 0)
            {
                objPeriod = new Period(dtPeriod.Rows[0]);
            }

            return objPeriod;
        }

        public void Update(Period obj)
        {
            _objConnectionFactory.AddParameter("@pIdPeriod", obj.IdPeriod);
            _objConnectionFactory.AddParameter("@pNamePeriod", obj.NamePeriod);
            _objConnectionFactory.AddParameter("@pStartDate", obj.StartDate);
            _objConnectionFactory.AddParameter("@pEndDate", obj.EndDate);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spUpdatePeriod");
        }

        #endregion
    }
}