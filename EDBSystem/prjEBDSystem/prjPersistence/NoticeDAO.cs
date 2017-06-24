using System;
using System.Collections.Generic;
using System.Data;
using prjConnectionFactory;
using prjEntity;


namespace prjPersistence
{
    /// <summary>
    /// =======================================================================
    /// Author:             Passos, Lucas
    /// Co-Author:          Henryque, Eduardo
    /// Create date:        02/06/2017
    /// Modification date:  05/06/2017
    /// Description:        Notice Data Access Object
    /// Properties:         _objConnectionFactory
    /// Constructors:       NoticeDAO(ConnectionFactory objConnectionFactory)
    /// Methods:            Insert(TNotice obj),
    ///                     Update(TNotice obj),
    ///                     Delete(int id),
    ///                     Select(),
    ///                     Select(int id),
    ///                     Select(string search)
    /// Dependencies:       System,
    ///                     System.Collections.Generic,
    ///                     System.Data,
    ///                     System.ConnectionFactory
    ///                     prjEBDSystem.Entity
    /// =======================================================================
    /// </summary>
    public class NoticeDAO : IDAO<TNotice>
    {
        #region PROPERTIES

        private ConnectionFactory _objConnectionFactory = null;

        #endregion

        #region CONSTRUCTORS

        public NoticeDAO(ConnectionFactory objConnectionFactory)
        {
            _objConnectionFactory = objConnectionFactory;
        }

        #endregion

        #region METHODS

        public void Insert(TNotice obj)
        {
            _objConnectionFactory.AddParameter("@pTitleNotice", obj.TitleNotice);
            _objConnectionFactory.AddParameter("@pContentNotice", obj.ContentNotice);

            obj.IdNotice = (byte)_objConnectionFactory.ExecuteStoredProcedureScalar("spInsertNotice");

            foreach (var item in obj.Departments)
            {
                _objConnectionFactory.AddParameter("@pIdNotice", obj.IdNotice);
                _objConnectionFactory.AddParameter("@pIdDepartment", item.IdDepartment);

                _objConnectionFactory.ExecuteStoredProcedureNonQuery("spInsertDepartmentNotice");
            }
        }

        public void Update(TNotice obj)
        {
            _objConnectionFactory.AddParameter("@pIdNotice", obj.IdNotice);
            _objConnectionFactory.AddParameter("@pTitleNotice", obj.TitleNotice);
            _objConnectionFactory.AddParameter("@pContentNotice", obj.ContentNotice);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spUpdateNotice");

            DeleteDepartmentNotice(obj.IdNotice);

            UpdateDepartmentNotice(obj);

        }

        public void UpdateDepartmentNotice(TNotice obj)
        { 
            foreach (var item in obj.Departments)
            {
                _objConnectionFactory.AddParameter("@pIdNotice", obj.IdNotice);
                _objConnectionFactory.AddParameter("@pIdDepartment", item.IdDepartment);

                _objConnectionFactory.ExecuteStoredProcedureNonQuery("spInsertDepartmentNotice");
            }

        }

        public void Delete(int id)
        {
            _objConnectionFactory.AddParameter("@pIdNotice", id);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spDeleteNotice");
        }

        public void DeleteDepartmentNotice(int id)
        {
            _objConnectionFactory.AddParameter("@pIdNotice", id);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spDeleteDepartmentNotice");
        }

        public List<TNotice> Select()
        {
            DataTable dtNotice = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectNotice");

            TNotice objNotice = null;

            List<TNotice> lstNotice = new List<TNotice>();

            foreach (DataRow row in dtNotice.Rows)
            {
                objNotice = new TNotice(row);

                _objConnectionFactory.AddParameter("@pIdNotice", objNotice.IdNotice);
                DataTable dtDepartmentNotice = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectDepartmentNoticeForNotice");
                TDepartment objDepartment = null;
                foreach (DataRow item in dtDepartmentNotice.Rows)
                {
                    objDepartment = new TDepartment(item);
                    objNotice.Departments.Add(objDepartment);
                    objDepartment = null;
                }

                lstNotice.Add(objNotice);
                objNotice = null;
            }

            return lstNotice;
        }

        public TNotice Select(int id)
        {
            _objConnectionFactory.AddParameter("@pIdNotice", id);
            DataTable dtNotice = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectNoticeById");

            TNotice objNotice = null;

            if (dtNotice.Rows.Count > 0)
            {
                objNotice = new TNotice(dtNotice.Rows[0]);

                _objConnectionFactory.AddParameter("@pIdNotice", objNotice.IdNotice);
                DataTable dtDepartmentNotice = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectDepartmentNoticeForNotice");
                TDepartment objDepartment = null;
                foreach (DataRow item in dtDepartmentNotice.Rows)
                {
                    objDepartment = new TDepartment(item);
                    objNotice.Departments.Add(objDepartment);
                    objDepartment = null;
                }
            }

            return objNotice;
        }

        public List<TNotice> Select(string search)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
