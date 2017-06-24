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
 /// Description:        Frequency Data Access Object
 /// Properties:         
 /// Constructors:       
 /// Methods:            
 /// Dependencies:       
 /// =======================================================================
 /// </summary>
    class FrequencyDAO : IDAO<Frequency>
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
            _objConnectionFactory.AddParameter("@pIdFrequency", id);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spDeleteFrequency");
        }

        public void Insert(Frequency obj)
        {
            _objConnectionFactory.AddParameter("@pDateFrequency", obj.DateFrequency);

            obj.IdFrequency = (byte)_objConnectionFactory.ExecuteStoredProcedureScalar("spInsertFrequency");

            foreach (var item in obj.Users)
            {
                _objConnectionFactory.AddParameter("@pIdFrequency", obj.IdFrequency);
                _objConnectionFactory.AddParameter("@pIdUser", item.IdUser);

                _objConnectionFactory.ExecuteStoredProcedureNonQuery("spInsertUserFrequency");
            }
        }

        public List<Frequency> Select()
        {
            DataTable dtFrequency = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectFrequency");

            Frequency objFrequency = null;

            List<Frequency> lstFrequency = new List<Frequency>();

            foreach (DataRow row in dtFrequency.Rows)
            {
                objFrequency = new Frequency(row);
                lstFrequency.Add(objFrequency);
                objFrequency = null;
            }

            return lstFrequency;
        }

        public List<Frequency> Select(string search)
        {
            throw new NotImplementedException();
        }

        public Frequency Select(int id)
        {
            _objConnectionFactory.AddParameter("@pIdNotice", id);
            DataTable dtFrequency = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectNoticeById");

            Frequency objFrequency = null;

            if (dtFrequency.Rows.Count > 0)
            {
                objFrequency = new Frequency(dtFrequency.Rows[0]);

                _objConnectionFactory.AddParameter("@pIdFrequency", objFrequency.IdFrequency);
                DataTable dtUserFrequency = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectUserForFrequency");
                User objUser = null;
                foreach (DataRow item in dtUserFrequency.Rows)
                {
                    objUser = new User(item);
                    objFrequency.Users.Add(objUser);
                    objUser = null;
                }
            }

            return objFrequency;
        }

        public void Update(Frequency obj)
        {
            _objConnectionFactory.AddParameter("@pIdFrequency", obj.IdFrequency);
            _objConnectionFactory.AddParameter("@pDateFrequency", obj.DateFrequency);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spUpdateFrequecy");

            UpdateUserFrequency(obj);

            DeleteUserFrequency(obj.IdFrequency);

        }

        public void UpdateUserFrequency(Frequency obj)
        {
            foreach (var item in obj.Users)
            {
                _objConnectionFactory.AddParameter("@pIdFrequency", obj.IdFrequency);
                _objConnectionFactory.AddParameter("@pIdUser", item.IdUser);

                _objConnectionFactory.ExecuteStoredProcedureNonQuery("spInsertUserFrequency");
            }

        }

        public void DeleteUserFrequency(int id)
        {
            _objConnectionFactory.AddParameter("@pIdFrequency", id);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spDeleteUserFrequency");
        }

        #endregion
    }
}