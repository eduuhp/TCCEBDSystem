using prjConnectionFactory;
using prjEBDSystem.Models;
using prjEBDSystem.Models.Persistence;
using System;
using System.Web;
using System.Web.Mvc;

namespace prjEBDSystem.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public ActionResult ConfirmLogin()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult ConfirmPassword(User obj)
        {
            try
            {
                User user = new UserDAO(new ConnectionFactory()).ConfirmLogin(obj);

                user.LoginUser = obj.LoginUser;
                return View(user);
            }
            catch (Exception)
            {
                TempData["ErrorMsg"] = String.Format("Login não encontrado.");
                return View("ConfirmLogin", obj);
            }

        }

        [AllowAnonymous]
        public ActionResult Logar(User obj)
        {
            try
            {
                User user = new UserDAO(new ConnectionFactory()).ConfirmPassword(obj);

                user.LoginUser = obj.LoginUser;

                HttpCookie cookie = new HttpCookie("User", "True/"+
                    user.IdUser.ToString() + "/" +
                    user.LoginUser + "/" +
                    user.FirstNameUser + "/" +
                    user.LastNameUser + "/" +
                    user.Profile.IdProfile.ToString() + "/" +
                    user.ClassEBD.IdClassEBD.ToString());
                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                TempData["ErrorMsg"] = String.Format("Senha incorreta.");
                return View("ConfirmPassword", obj);
            }
        }
    }
}