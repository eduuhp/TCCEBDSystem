using prjConnectionFactory;
using prjEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPersistence
{
    /// <summary>
    /// =======================================================================
    /// Author:             Henryque, Eduardo
    /// Co-Author:          Passos, Lucas
    /// Create date:        05/06/2017
    /// Modification date:  05/06/2017
    /// Description:        ClassEBD Data Access Object
    /// Properties:         
    /// Constructors:       
    /// Methods:            
    /// Dependencies:       
    /// =======================================================================
    /// </summary>
    public class ClassEBDDAO : IDAO<TClassEBD>
    {
        #region PROPERTIES

        private ConnectionFactory _objConnectionFactory = null;

        #endregion

        #region CONSTRUCTORS

        public ClassEBDDAO(ConnectionFactory objConnectionFactory)
        {
            _objConnectionFactory = objConnectionFactory;
        }

        #endregion

        #region METHODS

        public void Delete(int id)
        {
            _objConnectionFactory.AddParameter("@pIdClassEBD", id);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spDeleteClass");
        }

        public void Insert(TClassEBD obj)
        {
            _objConnectionFactory.AddParameter("@pNameClassEBD", obj.NameClassEBD);
            _objConnectionFactory.AddParameter("@pIdDepartment", obj.Departament.IdDepartment);
            _objConnectionFactory.AddParameter("@pIdPeriod", obj.Period.IdPeriod);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spInsertClassEBD");
        }

        public List<TClassEBD> Select()
        {
            DataTable dtNotice = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectClassEBD");

            TClassEBD objClassEBD = null;

            List<TClassEBD> lstClassEBD = new List<TClassEBD>();

            foreach (DataRow row in dtNotice.Rows)
            {
                objClassEBD = new TClassEBD(row);
                lstClassEBD.Add(objClassEBD);
                objClassEBD = null;
            }

            return lstClassEBD;
        }

        public List<TClassEBD> Select(string search)
        {

            throw new NotImplementedException();
        }

        public TClassEBD Select(int id)
        {
            _objConnectionFactory.AddParameter("@pIdClassEBD", id);

            DataTable dtClassEBD = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectClassEBDById");

            TClassEBD objClassEBD = null;
            

            if(dtClassEBD.Rows.Count > 0)
            {
                objClassEBD = new TClassEBD(dtClassEBD.Rows[0]);
            }

            return objClassEBD;
        }

        public void Update(TClassEBD obj)
        {
            _objConnectionFactory.AddParameter("@pIdClassEBD", obj.IdClassEBD);
            _objConnectionFactory.AddParameter("@pNameClassEBD", obj.NameClassEBD);
            _objConnectionFactory.AddParameter("@pIdDepartment", obj.Departament.IdDepartment);
            _objConnectionFactory.AddParameter("@pIdPeriod", obj.Period.IdPeriod);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spUpdateClassEBD");
        }

        #endregion

    }
}
