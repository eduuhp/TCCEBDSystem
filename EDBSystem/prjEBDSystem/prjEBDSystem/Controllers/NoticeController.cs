using prjConnectionFactory;
using prjEBDSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using prjEBDSystem.Filters;
using prjEBDSystem.Models.Persistence;

namespace prjEBDSystem.Controllers
{
    [Authentication]
    public class NoticeController : Controller, IControler<Notice>
    {
        public ActionResult Create()
        {
            Notice notice = new Notice();
            notice.Departments = new DepartmentDAO(new ConnectionFactory()).Select();

            return View(notice);
        }

        public ActionResult delete(int id)
        {
            new NoticeDAO(new ConnectionFactory()).Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(new NoticeDAO(new ConnectionFactory()).Select(id));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return RedirectToAction("Create");
            try
            {
                Notice notice = new NoticeDAO(new ConnectionFactory()).Select((int)id);

                List<Department> departments = new DepartmentDAO(new ConnectionFactory()).Select();

                foreach (var department in departments)
                {
                    foreach (var departmentNotice in notice.Departments)
                    {
                        if (department.IdDepartment == departmentNotice.IdDepartment)
                        {
                            department.Checked = "checked";
                            break;
                        }
                        else
                        {
                            department.Checked = "";
                        }
                    }
                }


                notice.Departments = departments;

                return View(notice);
            }
            catch (KeyNotFoundException ex)
            {
                TempData["ErrorMsg"] = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Erro ao editar o noticía. {0}", ex.Message);
                return View();
            }
        }

        // GET: Notice
        public ActionResult Index()
        {
            return View(new NoticeDAO(new ConnectionFactory()).Select());
        }

        public ActionResult Save(Notice obj, int?[] ids)
        {
            ConnectionFactory conex = null;
            try
            {
                List<Department> lst = new List<Department>();

                foreach (var item in ids)
                {
                    lst.Add(new Department { IdDepartment = (byte)item });
                }

                obj.Departments = lst;

                conex = new ConnectionFactory();
                NoticeDAO dao = new NoticeDAO(conex);
                conex.BeginTran();

                if (obj.IdNotice == 0)
                {
                    dao.Insert(obj);
                    TempData["SuccessMsg"] = "Notícia salva com sucesso!";
                }
                else
                {
                    dao.Update(obj);
                    TempData["SuccessMsg"] = "Notícia Editada com sucesso!";
                }

                conex.Commit();
            }
            catch (Exception ex)
            {
                conex.Rollback();
                TempData["SuccessMsg"] = "";
                TempData["ErrorMsg"] = String.Format("Falha ao salvar o notícia. {0}", ex.Message);

                return View("Create", obj);
            }


            return RedirectToAction("Index");
        }
    }
}