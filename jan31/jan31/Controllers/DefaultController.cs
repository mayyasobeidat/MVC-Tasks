using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jan31.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
       
            public ActionResult Index()
            {
                return Content("<p>Click on the image to download it:<p>" +
                        "\r\n<a href=\"/img.jpg\" download>" +
                        "\r\n  <img src=\"/img.jpg\" alt=\"Photographer\" " +
                        "width=\"304\" height=\"142\">\r\n</a>");

            }

        public ActionResult about()
        {
            return Content(" <div style=\"text-align:center;\">\r\n    <h1>About Us</h1>\r\n    <p>Lorem ipsum, dolor sit amet consectetur adipisicing elit. Sint, velit. Aut, eveniet deserunt culpa consequatur sunt et. In, perferendis! Nemo beatae corrupti dolorum doloremque vitae ut doloribus sequi accusantium adipisci!</p>\r\n    </div>");
        }

        public ActionResult contact()
        {
            return Content("   <div style=\"text-align:center;\">\r\n    <h1>Contact Us</h1>\r\n    <ul style=\"list-style-type: none;\">\r\n        <li>Phone : 0797383346</li>\r\n        <li>Email : mayyasobeidat@gmail.com</li>\r\n        <li>Address : Irbid</li>\r\n        <li>Instagram : @mayyasobeidatt</li>\r\n    </ul>\r\n    </div>");
        }

    }
    }
