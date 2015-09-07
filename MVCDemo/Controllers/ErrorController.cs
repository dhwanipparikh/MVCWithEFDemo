using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class ErrorController : BaseController
    {
        public ActionResult NotFound()
        {
            return View();
        }
        public ActionResult NotAccess()
        {
            return View();
        }
    }
}