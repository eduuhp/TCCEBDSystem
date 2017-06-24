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
    /// Description:        User Data Access Object
    /// Properties:         
    /// Constructors:       
    /// Methods:            
    /// Dependencies:       
    /// =======================================================================
    /// </summary>
    public class UserDAO : IDAO<TUser>
    {

        #region PROPERTIES

        private ConnectionFactory _objConnectionFactory = null;

        #endregion

        #region CONSTRUCTORS

        public UserDAO(ConnectionFactory objConnectionFactory)
        {
            _objConnectionFactory = objConnectionFactory;
        }

        #endregion

        #region METHODS

        public void Delete(int id)
        {
            _objConnectionFactory.AddParameter("@pIdUser", id);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spDeleteUser");
        }

        public void Insert(TUser obj)
        {
            _objConnectionFactory.AddParameter("@pFirstNameUser", obj.FirstNameUser);
            _objConnectionFactory.AddParameter("@pLastNameUser", obj.LastNameUser);
            _objConnectionFactory.AddParameter("@pDateBirthUser", obj.DateBirthUser);
            _objConnectionFactory.AddParameter("@pLoginUser", obj.LoginUser);
            _objConnectionFactory.AddParameter("@pIdProfile", obj.Profile.IdProfile);
            _objConnectionFactory.AddParameter("@pIdClassEBD", obj.ClassEBD.IdClassEBD);

            if (_objConnectionFactory.ExecuteStoredProcedureNonQuery("spInsertUser") == 0)
            {
                throw new ArgumentException("Já existe um usuário com esse login.");
            }
            
        }

        public List<TUser> Select()
        {
            DataTable dtUser = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectUser");

            TUser objUser = null;

            List<TUser> lstUser = new List<TUser>();

            foreach (DataRow row in dtUser.Rows)
            {
                objUser = new TUser(row);
                lstUser.Add(objUser);
                objUser = null;
            }

            return lstUser; 
        }

        public List<TUser> Select(string search)
        {
            throw new NotImplementedException();
        }

        public TUser Select(int id)
        {
            _objConnectionFactory.AddParameter("@pIdUser", id);

            DataTable dtUser = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectUserById");

            TUser objUser = null;


            if (dtUser.Rows.Count > 0)
            {
                objUser = new TUser(dtUser.Rows[0]);
            }

            return objUser;
        }

        public void Update(TUser obj)
        {
            _objConnectionFactory.AddParameter("@pIdUser", obj.IdUser);
            _objConnectionFactory.AddParameter("@pFirstNameUser", obj.FirstNameUser);
            _objConnectionFactory.AddParameter("@pLastNameUser", obj.LastNameUser);
            _objConnectionFactory.AddParameter("@pDateBirthUser", obj.DateBirthUser);
            _objConnectionFactory.AddParameter("@pIdProfile", obj.Profile.IdProfile);
            _objConnectionFactory.AddParameter("@pIdClassEBD", obj.ClassEBD.IdClassEBD);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spUpdateUser");
        }

        #endregion
    }
}
