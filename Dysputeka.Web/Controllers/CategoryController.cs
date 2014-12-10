using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Dysputeka.Core.Domain.Commands;
using NHibernate.Linq;
using Dysputeka.Core.Domain.Entities;
using Dysputeka.Web.Infrastructure;

namespace Dysputeka.Web.Controllers
{
    public class CategoryController : BaseController
    {

        public ActionResult Index()
        {
            
            var categories = Data.Query<Category>().ToArray();
            return View(categories);
        }


        public ActionResult Create()
        {
            return Create(null);
        }

        [HttpPost]
        public ActionResult Create(CreateCategoryModel model)
        {
            
            if (ModelState.IsValid && model!=null)
            {
              //wprowadzone dane są ok, więc wprowadzamy je do bazy
                Please.Do(new CreateCategory(model.Name));
                return RedirectToAction("Index");
            }
            return View(model);
        }



        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            return Edit(null,id);
        }

        [HttpPost]
        public ActionResult Edit(EditCategoryModel model,Guid id)
        {

            if (ModelState.IsValid && model != null)
            {
                //wprowadzone dane są ok, więc wprowadzamy je do bazy
                Please.Do(new EditCategory(model.Id,model.Name));
                return RedirectToAction("Index");
            }

            var category = Data.Get<Category>(id);
            model = new EditCategoryModel()
            {
                Name = category.Name,
                Id = category.Id
            };
            return View(model);
        }

        
        public ActionResult Delete(Guid id)
        {
                Please.Do(new DeleteCategory(id));
                return RedirectToAction("Index");
        }

    }

    public class CreateCategoryModel
    {
        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
    }

    public class EditCategoryModel
    {
        [Required]
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }
        
        [Display(Name = "Nazwa")]
        [Required]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Name { get; set; }
    }
}