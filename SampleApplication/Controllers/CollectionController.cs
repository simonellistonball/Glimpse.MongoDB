using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleApplication.Models;

namespace SampleApplication.Controllers
{
    public class CollectionController : Controller
    {
        //
        // GET: /Collection/View

        /// <summary>
        /// Shows the contents of a collection
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public ActionResult View(string database, string collection)
        {
            ViewBag.Documents = MongoMetaDataService.Documents(database, collection);
            return View();
        }

    }
}
