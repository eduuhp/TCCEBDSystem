using prjConnectionFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace prjEBDSystem.Models.Persistence
{/// <summary>
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
    public class ClassEBDDAO : IDAO<ClassEBD>
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

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spDeleteClassEBD");
        }

        public void Insert(ClassEBD obj)
        {
            _objConnectionFactory.AddParameter("@pNameClassEBD", obj.NameClassEBD);
            _objConnectionFactory.AddParameter("@pIdDepartment", obj.Departament.IdDepartment);
            _objConnectionFactory.AddParameter("@pIdPeriod", obj.Period.IdPeriod);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spInsertClassEBD");
        }

        public List<ClassEBD> Select()
        {
            DataTable dtNotice = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectClassEBD");

            ClassEBD objClassEBD = null;

            List<ClassEBD> lstClassEBD = new List<ClassEBD>();

            foreach (DataRow row in dtNotice.Rows)
            {
                objClassEBD = new ClassEBD(row);
                lstClassEBD.Add(objClassEBD);
                objClassEBD = null;
            }

            return lstClassEBD;
        }

        public List<ClassEBD> Select(string search)
        {

            throw new NotImplementedException();
        }

        public ClassEBD Select(int id)
        {
            _objConnectionFactory.AddParameter("@pIdClassEBD", id);

            DataTable dtClassEBD = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectClassEBDById");

            ClassEBD objClassEBD = null;


            if (dtClassEBD.Rows.Count > 0)
            {
                objClassEBD = new ClassEBD(dtClassEBD.Rows[0]);
            }

            return objClassEBD;
        }

        public void Update(ClassEBD obj)
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