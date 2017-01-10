using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAPOnlineKredit.web.Controllers
{
    public class FreigabeController : Controller
    {
        [HttpGet]
        public ActionResult Index(bool erfolgreich)
        {
            Debug.WriteLine("");
            Debug.Indent();

            Debug.Unindent();
            return View(erfolgreich);
        }
    }
}