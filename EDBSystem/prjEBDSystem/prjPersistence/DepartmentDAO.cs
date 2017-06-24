using System;
using System.Collections.Generic;
using prjEntity;
using System.Data;
using prjConnectionFactory;

namespace prjPersistence
{
    /// <summary>
    /// =======================================================================
    /// Author:             Passos, Lucas
    /// Co-Author:          Henryque, Eduardo
    /// Create date:        02/06/2017
    /// Modification date:  02/06/2017
    /// Description:        Department Data Access Object
    /// Properties:         _objConnectionFactory
    /// Constructors:       DepartmentDAO(ConnectionFactory objConnectionFactory)
    /// Methods:            Insert(TDepartment obj),
    ///                     Update(TDepartment obj),
    ///                     Delete(int id),
    ///                     Select(),
    ///                     Select(int id),
    ///                     Select(string search)
    /// Dependencies:       System,
    ///                     System.Collections.Generic,
    ///                     prj.Entity
    ///                     System.Data,
    ///                     System.ConnectionFactory
    /// =======================================================================
    /// </summary>
    public class DepartmentDAO : IDAO<TDepartment>
    {
        #region PROPERTIES

        private ConnectionFactory _objConnectionFactory = null;

        #endregion

        #region CONSTRUCTORS

        public DepartmentDAO(ConnectionFactory objConnectionFactory)
        {
            _objConnectionFactory = objConnectionFactory;
        }

        #endregion

        #region METHODS

        public void Insert(TDepartment obj)
        {
            _objConnectionFactory.AddParameter("@pNameDepartment", obj.NameDepartment);
            _objConnectionFactory.AddParameter("@pDescriptionDepartment", obj.DescriptionDepartment);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spInsertDepartment");
        }

        public void Update(TDepartment obj)
        {
            _objConnectionFactory.AddParameter("@pIdDepartment", obj.IdDepartment);
            _objConnectionFactory.AddParameter("@pNameDepartment", obj.NameDepartment);
            _objConnectionFactory.AddParameter("@pDescriptionDepartment", obj.DescriptionDepartment);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spUpdateDepartment");
        }

        public void Delete(int id)
        {
            _objConnectionFactory.AddParameter("@pIdDepartment", id);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spDeleteDepartment");
        }

        public List<TDepartment> Select()
        {
            DataTable dtDepartment = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectDepartment");

            TDepartment objDepatment = null;

            List<TDepartment> lstDepartment = new List<TDepartment>();

            foreach (DataRow row in dtDepartment.Rows)
            {
                objDepatment = new TDepartment(row);
                lstDepartment.Add(objDepatment);
                objDepatment = null;
            }

            return lstDepartment;
        }

        public TDepartment Select(int id)
        {
            _objConnectionFactory.AddParameter("@pIdDepartment", id);

            DataTable dtDepartment = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectDepartmentById");

            TDepartment objDepatment = null;

            if (dtDepartment.Rows.Count > 0)
            {
                objDepatment = new TDepartment(dtDepartment.Rows[0]);
            }

            return objDepatment;
        }

        public List<TDepartment> Select(string search)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
