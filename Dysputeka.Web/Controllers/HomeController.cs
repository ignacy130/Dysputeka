using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using NHibernate.Linq;
using Dysputeka.Core.Domain.Entities;
using Dysputeka.Web.Infrastructure;

namespace Dysputeka.Web.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Organizations
        public ActionResult Index()
        {
            Question[] question = Data.Query<Question>().ToArray();

            return View(question);
        }

        
    }
}