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
    public class UserController : Controller, IControler<User>
    {
        public ActionResult Create()
        {
            ViewBag.Profile = new ProfileDAO(new ConnectionFactory()).Select();
            ViewBag.ClassEBD = new ClassEBDDAO(new ConnectionFactory()).Select();

            return View(new User());

        }

        public ActionResult delete(int id)
        {
            new UserDAO(new ConnectionFactory()).Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(new UserDAO(new ConnectionFactory()).Select(id));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return RedirectToAction("Create");
            try
            {
                User classEBD = new UserDAO(new ConnectionFactory()).Select((int)id);

                ViewBag.Profile = new ProfileDAO(new ConnectionFactory()).Select();
                ViewBag.ClassEBD = new ClassEBDDAO(new ConnectionFactory()).Select();

                return View(classEBD);
            }
            catch (KeyNotFoundException ex)
            {
                TempData["ErrorMsg"] = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Erro ao editar o usuário. {0}", ex.Message);
                return View();
            }
        }

        // GET: User
        public ActionResult Index()
        {
            return View(new UserDAO(new ConnectionFactory()).Select());
        }

        public ActionResult Save(User obj, int?[] ids)
        {

            ConnectionFactory conex = null;
            try
            {
                conex = new ConnectionFactory();
                conex.BeginTran();

                if (obj.IdUser == 0)
                {
                    new UserDAO(conex).Insert(obj);
                    TempData["SuccessMsg"] = "usuário salvo com sucesso!";
                }
                else
                {
                    new UserDAO(conex).Update(obj);
                    TempData["SuccessMsg"] = "Classe editado com sucesso!";
                }

                conex.Commit();
            }
            catch (ArgumentException ex)
            {
                conex.Rollback();
                TempData["SuccessMsg"] = "";
                TempData["ErrorMsg"] = String.Format(ex.Message);

                ViewBag.Profile = new ProfileDAO(new ConnectionFactory()).Select();
                ViewBag.ClassEBD = new ClassEBDDAO(new ConnectionFactory()).Select();

                return View("Create", obj);
            }
            catch (Exception ex)
            {
                conex.Rollback();
                TempData["SuccessMsg"] = "";
                TempData["ErrorMsg"] = String.Format("Falha ao salvar o usuário. {0}", ex.Message);

                ViewBag.Profile = new ProfileDAO(new ConnectionFactory()).Select();
                ViewBag.ClassEBD = new ClassEBDDAO(new ConnectionFactory()).Select();

                return View("Create", obj);
            }


            return RedirectToAction("Index");
        }
    }
}