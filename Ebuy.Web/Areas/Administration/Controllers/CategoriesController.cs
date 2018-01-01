namespace Ebuy.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using Ebuy.Services.Data.Categories;
    using Ebuy.Web.Areas.Administration.Models.Categories;
    using Ebuy.Web.Common.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CategoriesController : AdministrationBaseController
    {
        private readonly ICategoriesDataService categoriesData;

        public CategoriesController(ICategoriesDataService categoriesData)
        {
            this.categoriesData = categoriesData;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Create()
        {
            this.PrepareViewBag();
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                this.ModelState.AddModelError(nameof(model.Name), "Name is required");
            }

            if (!this.ModelState.IsValid)
            {
                this.PrepareViewBag();
                return this.View();
            }

            this.categoriesData.CreateNewByNameOrderAndParentId(model.Name, model.Order, model.ParentId);

            this.TempData.AddSuccessMessage($"Successfully created new category {model.Name}");
            return this.RedirectToAction("Index", "Categories", new {area = "Products"});
        }

        public IActionResult Edit(int id)
        {
            var category = this.categoriesData
                .GetByIdQuery(id)
                .ProjectTo<CategoryCreateViewModel>()
                .FirstOrDefault();

            if (category == null)
            {
                this.TempData.AddErrorMessage($"Category with id {id} does not exist");
                return this.RedirectToAction("Index", "Categories", new {area = "Products"});
            }

            this.PrepareViewBag();
            return this.View(category);
        }

        [HttpPost]
        public IActionResult Edit(CategoryCreateViewModel model)
        {
            var category = this.categoriesData.GetById(model.Id);

            if (category == null)
            {
                this.TempData.AddErrorMessage($"Category with id {model.Id} does not exist");
                return this.RedirectToAction("Index", "Categories", new { area = "Products" });
            }

            if (!this.ModelState.IsValid)
            {
                this.PrepareViewBag();
                return this.View();
            }

            category.Name = model.Name;
            category.Order = model.Order;
            category.ParentId = model.ParentId;

            this.categoriesData.Update(category);

            return this.RedirectToAction("Index", "Categories", new { area = "Products" });
        }

        public IActionResult Delete(int id)
        {
            var category = this.categoriesData
                .GetByIdQuery(id)
                .ProjectTo<CategoryDeleteViewModel>()
                .FirstOrDefault();

            if (category == null)
            {
                this.TempData.AddErrorMessage($"Category with Id {id} does not exist");
                return this.RedirectToAction("Index", "Categories", new { area = "Products" });
            }

            return this.View(category);
        }

        [HttpPost]
        public IActionResult Delete(CategoryDeleteViewModel model)
        {
            var category = this.categoriesData.GetById(model.Id);
            if (category == null)
            {
                this.TempData.AddErrorMessage($"Category with Id {model.Id} does not exist");
                return this.RedirectToAction("Index", "Categories", new { area = "Products" });
            }

            foreach (var child in category.Children)
            {
                this.categoriesData.Delete(child);
            }

            this.categoriesData.Delete(category);

            return this.RedirectToAction("Index", "Categories", new { area = "Products" });
        }

        private void PrepareViewBag()
        {
            this.ViewBag.ParentCategoriesDropDown = this.categoriesData.GetAll().Select(c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            });
        }
    }
}