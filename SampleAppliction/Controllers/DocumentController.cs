using SampleApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleAppliction.Controllers
{
    public class DocumentController : Controller
    {
        //
        // GET: /Document/

        public ActionResult View(string database, string collection, string document_id )
        {
            ViewBag.database = database;
            ViewBag.collection = collection;
            ViewBag.document = MongoMetaDataService.GetDocument(database, collection, document_id);
            return View();
        }

    }
}
