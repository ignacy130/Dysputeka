using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dysputeka.Core.Infrastructure.Data;
using NHibernate.Tool.hbm2ddl;

namespace Dysputeka.Web.Controllers
{
    public class SchemaController : Controller
    {
        // GET: Schema
        public ActionResult Sql()
        {
            return Content(Schema.Sql, "text/html");
        }
        // GET: Schema

        public ActionResult Hbm()
        {
            return Content(Schema.Hbm, "text/xml");
        }
    }
}