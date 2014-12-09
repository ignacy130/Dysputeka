using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web.Mvc;
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
            IQueryable<Question> question = new[]
            {
                new Question()
                {
                    Content = "Treść",
                    Title = "Tytuł"
                }
                , new Question()
                {
                    Content = "Treść",
                    Title = "Tytuł"
                },
                new Question()
                {
                    Content = "Treść",
                    Title = "Tytuł"
                }
            }.AsQueryable();

            //Data.Query<Question>();

            return View(question);


            //return View(model);
        }
    }

    public class OrganizationsModel
    {
        public IEnumerable<OrganizationItemModel> Organizations { get; set; }
    }

    public class OrganizationItemModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}