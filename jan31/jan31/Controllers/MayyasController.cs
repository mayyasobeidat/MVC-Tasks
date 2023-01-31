using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jan31.Controllers
{
    public class MayyasController : Controller
    {
        // GET: Mayyas
        public ActionResult Name()
        {
            return Content("<p>mayyas obeidat</p>\r\n");
        }

        public ActionResult Photo()
        {
            return Content("<img src=\"../img.jpg\"> width=\"100px\"");
        }

        public ActionResult Link()
        {
            return Content("<a href=\"https://www.instagram.com/mayyasobeidatt/\">Mayyas</a>");

        }

        public ActionResult table()
        {
            return Content(" <table>\r\n        <tr>\r\n            <td>instagram</td>\r\n            <td>facebook</td>\r\n            <td>linkedin</td>\r\n        </tr>\r\n        <tr>\r\n            <td><a href=\"https://www.instagram.com/mayyasobeidatt/\">Mayyas</a></td>\r\n            <td><a href=\"https://www.facebook.com/mayyasobeidat/\">Mayyas</a></td>\r\n            <td><a href=\"https://www.linkedin.com/in/mayyasobeidat/\">Mayyas</a></td>\r\n        </tr>\r\n    </table>");

        }
    }
}