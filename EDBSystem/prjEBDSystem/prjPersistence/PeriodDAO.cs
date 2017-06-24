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
    /// Description:        Period Data Access Object
    /// Properties:         
    /// Constructors:       
    /// Methods:            
    /// Dependencies:       
    /// =======================================================================
    /// </summary>
    public class PeriodDAO : IDAO<TPeriod>
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

        public void Insert(TPeriod obj)
        {
            _objConnectionFactory.AddParameter("@pNamePeriod", obj.NamePeriod);
            _objConnectionFactory.AddParameter("@pStartDate", obj.StartDate);
            _objConnectionFactory.AddParameter("@pEndDate", obj.EndDate);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spInsertPeriod");
        }

        public List<TPeriod> Select()
        {
            DataTable dtPeriod = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectPeriod");

            TPeriod objPeriod = null;

            List<TPeriod> lstPeriod = new List<TPeriod>();

            foreach (DataRow row in dtPeriod.Rows)
            {
                objPeriod = new TPeriod(row);
                lstPeriod.Add(objPeriod);
                objPeriod = null;
            }

            return lstPeriod;
        }

        public List<TPeriod> Select(string search)
        {
            throw new NotImplementedException();
        }

        public TPeriod Select(int Id)
        {
            _objConnectionFactory.AddParameter("@pIdPeriod", Id);

            DataTable dtPeriod = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectPeriodById");

            TPeriod objPeriod = null;

            if (dtPeriod.Rows.Count > 0)
            {
                objPeriod = new TPeriod(dtPeriod.Rows[0]);
            }

            return objPeriod;
        }

        public void Update(TPeriod obj)
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
