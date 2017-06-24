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
    public class PeriodController : Controller, IControler<Period>
    {

        // GET: Period
        public ActionResult Index()
        {
            return View(new PeriodDAO(new ConnectionFactory()).Select());
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            return View(new PeriodDAO(new ConnectionFactory()).Select((int)id));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return RedirectToAction("Create");
            try
            {
                return View(new PeriodDAO(new ConnectionFactory()).Select((int)id));
            }
            catch (KeyNotFoundException ex)
            {
                TempData["ErrorMsg"] = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Erro ao editar o Periodo. {0}", ex.Message);
                return View();
            }
        }

        public ActionResult Save(Period obj, int?[] ids)
        {
            ConnectionFactory conex = null;
            try
            {
                conex = new ConnectionFactory();
                conex.BeginTran();

                if (obj.IdPeriod == 0)
                {
                    new PeriodDAO(conex).Insert(obj);
                    TempData["SuccessMsg"] = "Periodo salvo com sucesso!";
                }
                else
                {
                    new PeriodDAO(conex).Update(obj);
                    TempData["SuccessMsg"] = "Periodo editado com sucesso!";
                }

                conex.Commit();
            }
            catch (Exception ex)
            {
                conex.Rollback();
                TempData["SuccessMsg"] = "";
                TempData["ErrorMsg"] = String.Format("Falha ao salvar o periodo. {0}", ex.Message);

                return View("Create", obj);
            }


            return RedirectToAction("Index");
        }

        public ActionResult delete(int id)
        {
            new PeriodDAO(new ConnectionFactory()).Delete(id);

            return RedirectToAction("Index");
        }
    }
}