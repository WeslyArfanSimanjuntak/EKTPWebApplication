using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EKTPWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public string CekNIK(string id, string getSOAPURL)
        {
            var clientService = new EKTPServiceWCF.EKTPServiceClient();
            if (getSOAPURL != null) {
                var soapURL = clientService.Endpoint.Address.ToString();
                clientService.Close();
                return soapURL;
            }
            var data = clientService.StringCekNIK(id);
            clientService.Close();
            return (data);

        }
        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
            //    db.Dispose();
            //}
            //base.Dispose(disposing);
        }
    }
}