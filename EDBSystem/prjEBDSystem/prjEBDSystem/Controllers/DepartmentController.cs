using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using prjEBDSystem.Models;
using prjConnectionFactory;
using prjEBDSystem.Filters;
using prjEBDSystem.Models.Persistence;

namespace prjEBDSystem.Controllers
{
    [Authentication]
    public class DepartmentController : Controller, IControler<Department>
    {
        // GET: Department
        public ActionResult Index()
        {
            return View(new DepartmentDAO(new ConnectionFactory()).Select());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Save(Department obj, int?[] ids)
        {
            ConnectionFactory conex = null;
            try
            {
                conex = new ConnectionFactory();
                conex.BeginTran();

                if (obj.IdDepartment == 0)
                {
                    new DepartmentDAO(conex).Insert(obj);
                    TempData["SuccessMsg"] = "Departamento salvo com sucesso!";
                }
                else
                {
                    new DepartmentDAO(conex).Update(obj);
                    TempData["SuccessMsg"] = "Departamento editado com sucesso!";
                }

                conex.Commit();
            }
            catch (Exception ex)
            {
                conex.Rollback();
                TempData["SuccessMsg"] = "";
                TempData["ErrorMsg"] = String.Format("Falha ao salvar o departamento. {0}", ex.Message);

                return View("Create",obj);
            }

            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return RedirectToAction("Create");
            try
            {
                return View(new DepartmentDAO(new ConnectionFactory()).Select((int)id));
            }
            catch (KeyNotFoundException ex)
            {
                TempData["ErrorMsg"] = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Erro ao editar o departamento. {0}", ex.Message);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            return View(new DepartmentDAO(new ConnectionFactory()).Select((int)id));
        }

        public ActionResult delete(int id)
        {
            new DepartmentDAO(new ConnectionFactory()).Delete(id);

            return RedirectToAction("Index");
        }
    }
}