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
    public class ProfileController : Controller, IControler<Profile>
    {
        public ActionResult Create()
        {
            Profile profile = new Profile();
            profile.Restrictions = new RestrictionDAO(new ConnectionFactory()).Select();

            return View(profile);
        }

        public ActionResult delete(int id)
        {
            new ProfileDAO(new ConnectionFactory()).Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(new ProfileDAO(new ConnectionFactory()).Select(id));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return RedirectToAction("Create");
            try
            {
                Profile profile = new ProfileDAO(new ConnectionFactory()).Select((int)id);

                List<Restriction> restrictions = new RestrictionDAO(new ConnectionFactory()).Select();

                foreach (var restriction in restrictions)
                {
                    foreach (var profileRestriction in profile.Restrictions)
                    {
                        if (restriction.IdRestriction == profileRestriction.IdRestriction)
                        {
                            restriction.Checked = "checked";
                            break;
                        }
                        else
                        {
                            restriction.Checked = "";
                        }
                    }
                }

                profile.Restrictions = restrictions;

                return View(profile);

            }
            catch (KeyNotFoundException ex)
            {
                TempData["ErrorMsg"] = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Erro ao editar o Perfil. {0}", ex.Message);
                return View();
            }
        }

        public ActionResult Index()
        {
            return View(new ProfileDAO(new ConnectionFactory()).Select());
        }

        public ActionResult Save(Profile obj, int?[] ids)
        {
            ConnectionFactory conex = null;
            try
            {
                List<Restriction> lst = new List<Restriction>();

                foreach (var item in ids)
                {
                    lst.Add(new Restriction { IdRestriction = (byte)item });
                }

                obj.Restrictions = lst;

                conex = new ConnectionFactory();
                ProfileDAO dao = new ProfileDAO(conex);
                conex.BeginTran();

                if (obj.IdProfile == 0)
                {
                    dao.Insert(obj);
                    TempData["SuccessMsg"] = "Perfil salva com sucesso!";
                }
                else
                {
                    dao.Update(obj);
                    TempData["SuccessMsg"] = "Perfil Editada com sucesso!";
                }

                conex.Commit();
            }
            catch (Exception ex)
            {
                conex.Rollback();
                TempData["SuccessMsg"] = "";
                TempData["ErrorMsg"] = String.Format("Falha ao salvar o perfil. {0}", ex.Message);

                return View("Create", obj);
            }


            return RedirectToAction("Index");
        }
    }
}
