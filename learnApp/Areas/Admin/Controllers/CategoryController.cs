using AutoMapper;
using learnApp.Data;
using learnApp.Models;
using learnApp.services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace learnApp.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService categoryService;

        private readonly IMapper mapper;

        public CategoryController()
        {
            categoryService = new CategoryService();
            mapper = AutoMapperConfig.Mapper;
        }
        // GET: Admin/Category
        public ActionResult Index()
        {
            var categories = categoryService.ReadAll();

            var categoriesList = mapper.Map<List<categoryModel>>(categories);

            return View(categoriesList);
        }

        public ActionResult Create()
        {
            return View();
        }
        //git  data from GUI to DB 
        [HttpPost]
        public ActionResult Create(categoryModel data)
        {
            var newCategory = mapper.Map<category>(data);
            int creationResult = categoryService.Create(new Data.category
            {
                category_name = data.name
            });
            
            if(creationResult == -2)
            {
                ViewBag.Message = "Category Name is Exists!";
                return View(data);
            }
            return RedirectToAction("Index");
            
        }

        public ActionResult Edit(int? id)
        {
            //Edit data of Category was inter
            if(id == null || id == 0)
            {
                return RedirectToAction("index", "Home");
            }
            var currentCategory = categoryService.ReadById(id.Value);
            
            if(currentCategory == null)
            {
                return HttpNotFound($"This category ({id}) not found");
            }

            var CategoryModel = new categoryModel
            {
                Id = currentCategory.id,
                name = currentCategory.category_name,
                ParentId = currentCategory.parent_id,

            };
            return View(CategoryModel);
        }
        //Send the data was edit from Gui to DB
        [HttpPost]
        public ActionResult Edit(categoryModel data)
        {
            if (ModelState.IsValid)
            {
                var updatedcategory = new category
                {
                    id = data.Id,
                    category_name = data.name,
                    parent_id = data.ParentId,

                };
                var result = categoryService.Update(updatedcategory);

                if (result == -2)
                {
                    ViewBag.Message = $"Category Name is Exists!";
                    return View(data);
                }
                else if (result > 0)
                {
                    ViewBag.Success = true;
                    ViewBag.Message = $"Category ({data.Id}) updated successfully.";
                }
                else
                    ViewBag.Message = $"error occurred!";

            }
            return View(data);
        }
        //delet function futuer
        public ActionResult Delete( int? Id)
        {
            if(Id != null)
            {
                var category = categoryService.ReadById(Id.Value);
                var categoryInfo = new categoryModel
                {
                    Id = category.id,
                    name = category.category_name,
                    ParentName = category.category2?
.category_name
                };
                return View(categoryInfo);
            }
            return View();
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int? Id)
        {
            if(Id!= null)
            {
                var deleted = categoryService.Delete(Id.Value);
                if(deleted)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Delete", new { id = Id });
            }
            return HttpNotFound();
        }

    }
}