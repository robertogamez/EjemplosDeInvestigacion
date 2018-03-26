using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Log4netExampleApp.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog Logger 
            = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        // GET: Home
        public ActionResult Index()
        {
            try
            {
                Logger.Info("Info logging");
            }
            catch (Exception)
            {
                
            }

            return View();
        }

        public ActionResult Error()
        {
            try
            {
                throw new Exception("Error interno!");
            }
            catch (Exception ex)
            {
                Logger.Error("Error interno en controller", ex);
            }

            return View();
        }
    }
}