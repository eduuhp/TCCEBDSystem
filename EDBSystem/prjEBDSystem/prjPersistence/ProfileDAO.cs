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
    public class ProfileDAO : IDAO<TProfile>
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

        public void Insert(TProfile obj)
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

        public List<TProfile> Select()
        {
            DataTable dtProfile = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectProfile");

            TProfile objProfile = null;

            List<TProfile> lstProfile = new List<TProfile>();

            foreach (DataRow row in dtProfile.Rows)
            {
                objProfile = new TProfile(row);

                _objConnectionFactory.AddParameter("@pIdProfile", objProfile.IdProfile);
                DataTable dtProfileRestriction = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectProfileRestrictionForProfile");
                TRestriction objRestriction = null;
                foreach (DataRow item in dtProfileRestriction.Rows)
                {
                    objRestriction = new TRestriction(item);
                    objProfile.Restrictions.Add(objRestriction);
                    objRestriction = null;
                }

                lstProfile.Add(objProfile);
                objProfile = null;
            }

            return lstProfile;
        }

        public List<TProfile> Select(string search)
        {
            throw new NotImplementedException();
        }

        public TProfile Select(int id)
        {
            _objConnectionFactory.AddParameter("@pIdProfile", id);
            DataTable dtProfile = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectProfileById");

            TProfile objProfile = null;

            if (dtProfile.Rows.Count > 0)
            {
                objProfile = new TProfile(dtProfile.Rows[0]);

                _objConnectionFactory.AddParameter("@pIdProfile", objProfile.IdProfile);
                DataTable dtProfileRestriction = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectProfileRestrictionForProfile");
                TRestriction objRestriction = null;
                foreach (DataRow item in dtProfileRestriction.Rows)
                {
                    objRestriction = new TRestriction(item);
                    objProfile.Restrictions.Add(objRestriction);
                    objRestriction = null;
                }
            }

            return objProfile;
        }

        public void Update(TProfile obj)
        {
            _objConnectionFactory.AddParameter("@pIdProfile", obj.IdProfile);
            _objConnectionFactory.AddParameter("@pNameProfile", obj.NameProfile);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spUpdateProfile");

            DeleteProfileRestriction(obj.IdProfile);

            UpdateProfileRestriction(obj);
        }

        private void UpdateProfileRestriction(TProfile obj)
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
