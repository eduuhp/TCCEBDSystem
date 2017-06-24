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
    public class ClassEBDController : Controller, IControler<ClassEBD>
    {
        public ActionResult Create()
        {
            ViewBag.Departments = new DepartmentDAO(new ConnectionFactory()).Select();

            ViewBag.Periods = new PeriodDAO(new ConnectionFactory()).Select();

            return View(new ClassEBD());
        }

        public ActionResult delete(int id)
        {
            new ClassEBDDAO(new ConnectionFactory()).Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(new ClassEBDDAO(new ConnectionFactory()).Select(id));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return RedirectToAction("Create");
            try
            {
                ClassEBD classEBD = new ClassEBDDAO(new ConnectionFactory()).Select((int)id);
                ViewBag.Departments = new DepartmentDAO(new ConnectionFactory()).Select();
                ViewBag.Periods = new PeriodDAO(new ConnectionFactory()).Select();

                return View(classEBD);
            }
            catch (KeyNotFoundException ex)
            {
                TempData["ErrorMsg"] = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Erro ao editar a classe. {0}", ex.Message);
                return View();
            }
        }

        public ActionResult Index()
        {
            return View(new ClassEBDDAO(new ConnectionFactory()).Select());
        }

        [HttpPost]
        public ActionResult Save(ClassEBD obj, int?[] ids)
        {
            ConnectionFactory conex = null;
            try
            {
                conex = new ConnectionFactory();
                conex.BeginTran();

                if (obj.IdClassEBD == 0)
                {
                    new ClassEBDDAO(conex).Insert(obj);
                    TempData["SuccessMsg"] = "Classe salva com sucesso!";
                }
                else
                {
                    new ClassEBDDAO(conex).Update(obj);
                    TempData["SuccessMsg"] = "Classe editada com sucesso!";
                }

                conex.Commit();
            }
            catch (Exception ex)
            {
                conex.Rollback();
                TempData["SuccessMsg"] = "";
                TempData["ErrorMsg"] = String.Format("Falha ao salvar a classe. {0}", ex.Message);

                ViewBag.Departments = new DepartmentDAO(new ConnectionFactory()).Select();
                ViewBag.Periods = new PeriodDAO(new ConnectionFactory()).Select();

                return View("Create", obj);
            }


            return RedirectToAction("Index");
        }
    }
}