using System.Web.Mvc;

namespace prjEBDSystem.Controllers
{
    interface IControler<T> where T : class
    {
        ActionResult Index();
        ActionResult Create();
        ActionResult Save(T obj, int?[] ids);
        ActionResult Edit(int? id);
        ActionResult Details(int id);
        ActionResult delete(int id);
    }
}
