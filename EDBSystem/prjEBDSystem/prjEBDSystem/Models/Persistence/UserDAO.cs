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
 /// Description:        User Data Access Object
 /// Properties:         
 /// Constructors:       
 /// Methods:            
 /// Dependencies:       
 /// =======================================================================
 /// </summary>
    public class UserDAO : IDAO<User>
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

        public void Insert(User obj)
        {
            _objConnectionFactory.AddParameter("@pFirstNameUser", obj.FirstNameUser);
            _objConnectionFactory.AddParameter("@pLastNameUser", obj.LastNameUser);
            _objConnectionFactory.AddParameter("@pDateBirthUser", obj.DateBirthUser.ToString("yyyyMMdd"));
            _objConnectionFactory.AddParameter("@pLoginUser", obj.LoginUser);
            _objConnectionFactory.AddParameter("@pIdProfile", obj.Profile.IdProfile);
            _objConnectionFactory.AddParameter("@pIdClassEBD", obj.ClassEBD.IdClassEBD);

            int validate = (int)_objConnectionFactory.ExecuteStoredProcedureScalar("spInsertUser");

            if (validate == 0)
            {
                throw new ArgumentException("Já existe um usuário com esse login.");
            }

        }

        public List<User> Select()
        {
            DataTable dtUser = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectUser");

            User objUser = null;

            List<User> lstUser = new List<User>();

            foreach (DataRow row in dtUser.Rows)
            {
                objUser = new User(row);
                lstUser.Add(objUser);
                objUser = null;
            }

            return lstUser;
        }
        
        public List<User> Select(string search)
        {
            _objConnectionFactory.AddParameter("@pidClassEBD", int.Parse(search));
            DataTable dtUser = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectUserForClassEBD");

            User objUser = null;

            List<User> lstUser = new List<User>();

            foreach (DataRow row in dtUser.Rows)
            {
                objUser = new User(row);
                lstUser.Add(objUser);
                objUser = null;
            }

            return lstUser;
        }

        public User Select(int id)
        {
            _objConnectionFactory.AddParameter("@pIdUser", id);

            DataTable dtUser = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectUserById");

            User objUser = null;


            if (dtUser.Rows.Count > 0)
            {
                objUser = new User(dtUser.Rows[0]);
            }

            return objUser;
        }

        public void Update(User obj)
        {
            _objConnectionFactory.AddParameter("@pIdUser", obj.IdUser);
            _objConnectionFactory.AddParameter("@pFirstNameUser", obj.FirstNameUser);
            _objConnectionFactory.AddParameter("@pLastNameUser", obj.LastNameUser);
            _objConnectionFactory.AddParameter("@pDateBirthUser", obj.DateBirthUser);
            _objConnectionFactory.AddParameter("@pIdProfile", obj.Profile.IdProfile);
            _objConnectionFactory.AddParameter("@pIdClassEBD", obj.ClassEBD.IdClassEBD);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spUpdateUser");
        }

        public User ConfirmLogin(User obj)
        {
            _objConnectionFactory.AddParameter("@pLoginUser", obj.LoginUser);

            DataTable dtUser = _objConnectionFactory.ExecuteStoredProcedureQuery("spConfirmLogin");

            User objUser = null;


            if (dtUser.Rows.Count > 0)
            {
                objUser = new User(dtUser.Rows[0]);
            }

            return objUser;
        }

        public User ConfirmPassword(User obj)
        {
            _objConnectionFactory.AddParameter("@pIdUser", obj.IdUser);
            _objConnectionFactory.AddParameter("@pPasswordUser", obj.PasswordUser);

            DataTable dtUser = _objConnectionFactory.ExecuteStoredProcedureQuery("spConfirmPassword");

            User objUser = null;


            if (dtUser.Rows.Count > 0)
            {
                objUser = new User(dtUser.Rows[0]);
            }

            return objUser;
        }



        #endregion
    }
}