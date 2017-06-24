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
 /// Co-Author:          Lucas, Passos
 /// Create date:        05/06/2017
 /// Modification date:  05/06/2017
 /// Description:        Profile Data Access Object
 /// Properties:         
 /// Constructors:       
 /// Methods:            
 /// Dependencies:       
 /// =======================================================================
 /// </summary>
    public class ProfileDAO : IDAO<Profile>
    {

        #region PROPERTIES

        private ConnectionFactory _objConnectionFactory = null;

        #endregion

        #region CONSTRUCTORS

        public ProfileDAO(ConnectionFactory objConnectionFactory)
        {
            _objConnectionFactory = objConnectionFactory;
        }

        #endregion

        #region METHODS

        public void Delete(int id)
        {
            _objConnectionFactory.AddParameter("@pIdProfile", id);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spDeleteProfile");
        }

        public void Insert(Profile obj)
        {
            _objConnectionFactory.AddParameter("@pNameProfile", obj.NameProfile);

            obj.IdProfile = (byte)_objConnectionFactory.ExecuteStoredProcedureScalar("spInsertProfile");

            foreach (var item in obj.Restrictions)
            {
                _objConnectionFactory.AddParameter("@pIdProfile", obj.IdProfile);
                _objConnectionFactory.AddParameter("@pIdRestriction", item.IdRestriction);

                _objConnectionFactory.ExecuteStoredProcedureNonQuery("spInsertProfileRestriction");
            }
        }

        public List<Profile> Select()
        {
            DataTable dtProfile = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectProfile");

            Profile objProfile = null;

            List<Profile> lstProfile = new List<Profile>();

            foreach (DataRow row in dtProfile.Rows)
            {
                objProfile = new Profile(row);

                _objConnectionFactory.AddParameter("@pIdProfile", objProfile.IdProfile);
                DataTable dtProfileRestriction = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectProfileRestrictionForProfile");
                Restriction objRestriction = null;
                foreach (DataRow item in dtProfileRestriction.Rows)
                {
                    objRestriction = new Restriction(item);
                    objProfile.Restrictions.Add(objRestriction);
                    objRestriction = null;
                }

                lstProfile.Add(objProfile);
                objProfile = null;
            }

            return lstProfile;
        }

        public List<Profile> Select(string search)
        {
            throw new NotImplementedException();
        }

        public Profile Select(int id)
        {
            _objConnectionFactory.AddParameter("@pIdProfile", id);
            DataTable dtProfile = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectProfileById");

            Profile objProfile = null;

            if (dtProfile.Rows.Count > 0)
            {
                objProfile = new Profile(dtProfile.Rows[0]);

                _objConnectionFactory.AddParameter("@pIdProfile", objProfile.IdProfile);
                DataTable dtProfileRestriction = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectProfileRestrictionForProfile");
                Restriction objRestriction = null;
                foreach (DataRow item in dtProfileRestriction.Rows)
                {
                    objRestriction = new Restriction(item);
                    objProfile.Restrictions.Add(objRestriction);
                    objRestriction = null;
                }
            }

            return objProfile;
        }

        public void Update(Profile obj)
        {
            _objConnectionFactory.AddParameter("@pIdProfile", obj.IdProfile);
            _objConnectionFactory.AddParameter("@pNameProfile", obj.NameProfile);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spUpdateProfile");

            DeleteProfileRestriction(obj.IdProfile);

            UpdateProfileRestriction(obj);
        }

        private void UpdateProfileRestriction(Profile obj)
        {
            foreach (var item in obj.Restrictions)
            {
                _objConnectionFactory.AddParameter("@pIdProfile", obj.IdProfile);
                _objConnectionFactory.AddParameter("@pIdRestriction", item.IdRestriction);

                _objConnectionFactory.ExecuteStoredProcedureNonQuery("spInsertProfileRestriction");
            }
        }

        private void DeleteProfileRestriction(int idProfile)
        {
            _objConnectionFactory.AddParameter("@pIdProfile", idProfile);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spDeleteProfileRestriction");
        }

        #endregion
    }
}