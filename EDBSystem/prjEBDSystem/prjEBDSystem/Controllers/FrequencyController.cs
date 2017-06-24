using prjConnectionFactory;
using prjEBDSystem.Filters;
using prjEBDSystem.Models;
using prjEBDSystem.Models.Persistence;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace prjEBDSystem.Controllers
{
    [Authentication]
    public class FrequencyController : Controller, IControler<Frequency>
    {
        public ActionResult Create()
        {
            Frequency frequency = new Frequency();
            frequency.DateFrequency = DateTime.Today;
            frequency.Users = new UserDAO(new ConnectionFactory()).Select(Request.Cookies["User"].Value.Split('/')[6]);

            return View(frequency);
        }

        public ActionResult delete(int id)
        {
            new FrequencyDAO(new ConnectionFactory()).Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View(new FrequencyDAO(new ConnectionFactory()).Select(id));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return RedirectToAction("Create");
            try
            {
                Frequency frequency = new FrequencyDAO(new ConnectionFactory()).Select((int)id);

                List<User> users = new UserDAO(new ConnectionFactory()).Select();

                foreach (var user in users)
                {
                    foreach (var frequencyUser in frequency.Users)
                    {
                        if (user.IdUser == frequencyUser.IdUser)
                        {
                            user.Checked = "checked";
                            break;
                        }
                        else
                        {
                            user.Checked = "";
                        }
                    }
                }


                frequency.Users = users;

                return View(frequency);
            }
            catch (KeyNotFoundException ex)
            {
                TempData["ErrorMsg"] = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Erro ao editar o chamada. {0}", ex.Message);
                return View();
            }
        }

        // GET: Frequency
        public ActionResult Index()
        {
            return View(new FrequencyDAO(new ConnectionFactory()).Select());
        }

        public ActionResult Save(Frequency obj, int?[] ids)
        {
            ConnectionFactory conex = null;
            try
            {
                List<User> lst = new List<User>();

                foreach (var item in ids)
                {
                    lst.Add(new User { IdUser = (byte)item });
                }

                obj.Users = lst;

                conex = new ConnectionFactory();
                FrequencyDAO dao = new FrequencyDAO(conex);
                conex.BeginTran();

                if (obj.IdFrequency == 0)
                {
                    dao.Insert(obj);
                    TempData["SuccessMsg"] = "Chamada salva com sucesso!";
                }
                else
                {
                    dao.Update(obj);
                    TempData["SuccessMsg"] = "Chamada Editada com sucesso!";
                }

                conex.Commit();
            }
            catch (Exception ex)
            {
                conex.Rollback();
                TempData["SuccessMsg"] = "";
                TempData["ErrorMsg"] = String.Format("Falha ao salvar a chamada. {0}", ex.Message);

                return View("Create", obj);
            }


            return RedirectToAction("Index");
        }
    }
}