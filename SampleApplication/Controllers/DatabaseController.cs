using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleApplication.Models;

namespace SampleApplication.Controllers
{
    public class DatabaseController : Controller
    {
        //
        // GET: /Database/
        /// <summary>
        /// Shows the list of databases for the server
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Databases = MongoMetaDataService.AllDatabases();
            return View();
        }
        /// <summary>
        /// Show the collections in a given database
        /// </summary>
        /// <param name="database"></param>
        /// <returns></returns>
        public ActionResult View(string database)
        {
            ViewBag.database = database;
            ViewBag.Collections = MongoMetaDataService.AllCollections(database);
            return View();
        }
    }
}
