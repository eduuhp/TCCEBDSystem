using prjConnectionFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace prjEBDSystem.Models.Persistence
{/// <summary>
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
    public class NoticeDAO : IDAO<Notice>
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

        public void Insert(Notice obj)
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

        public void Update(Notice obj)
        {
            _objConnectionFactory.AddParameter("@pIdNotice", obj.IdNotice);
            _objConnectionFactory.AddParameter("@pTitleNotice", obj.TitleNotice);
            _objConnectionFactory.AddParameter("@pContentNotice", obj.ContentNotice);

            _objConnectionFactory.ExecuteStoredProcedureNonQuery("spUpdateNotice");

            DeleteDepartmentNotice(obj.IdNotice);

            UpdateDepartmentNotice(obj);

        }

        public void UpdateDepartmentNotice(Notice obj)
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

        public List<Notice> Select()
        {
            DataTable dtNotice = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectNotice");

            Notice objNotice = null;

            List<Notice> lstNotice = new List<Notice>();

            foreach (DataRow row in dtNotice.Rows)
            {
                objNotice = new Notice(row);

                _objConnectionFactory.AddParameter("@pIdNotice", objNotice.IdNotice);
                DataTable dtDepartmentNotice = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectDepartmentNoticeForNotice");
                Department objDepartment = null;
                foreach (DataRow item in dtDepartmentNotice.Rows)
                {
                    objDepartment = new Department(item);
                    objNotice.Departments.Add(objDepartment);
                    objDepartment = null;
                }

                lstNotice.Add(objNotice);
                objNotice = null;
            }

            return lstNotice;
        }

        public Notice Select(int id)
        {
            _objConnectionFactory.AddParameter("@pIdNotice", id);
            DataTable dtNotice = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectNoticeById");

            Notice objNotice = null;

            if (dtNotice.Rows.Count > 0)
            {
                objNotice = new Notice(dtNotice.Rows[0]);

                _objConnectionFactory.AddParameter("@pIdNotice", objNotice.IdNotice);
                DataTable dtDepartmentNotice = _objConnectionFactory.ExecuteStoredProcedureQuery("spSelectDepartmentNoticeForNotice");
                Department objDepartment = null;
                foreach (DataRow item in dtDepartmentNotice.Rows)
                {
                    objDepartment = new Department(item);
                    objNotice.Departments.Add(objDepartment);
                    objDepartment = null;
                }
            }

            return objNotice;
        }

        public List<Notice> Select(string search)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}