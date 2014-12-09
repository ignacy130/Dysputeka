using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NHibernate.Linq;
using Dysputeka.Core.Domain.Entities;
using Dysputeka.Web.Infrastructure;

namespace Dysputeka.Web.Controllers
{
    public class OrganizationsController : BaseController
    {
        // GET: Organizations
        public ActionResult Index()
        {
            var organizations = Data.Query<Organization>()
                .Select(o => new OrganizationItemModel()
                {
                    Id = o.Id,
                    Name = o.Name,
                    Description = o.Description,
                    Tags = o.Tags.Select(t => t.Name)
                })
                .ToList();

            var model = new OrganizationsModel
            {
                Organizations = organizations
            };

            return View(model);
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