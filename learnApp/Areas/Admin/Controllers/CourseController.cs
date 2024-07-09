using AutoMapper;
using learnApp.Data;
using learnApp.Models;
using learnApp.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace learnApp.Controllers
{//feature in futur admin can controle courses 
    public class courseController : Controller
    {
        private readonly IMapper mapper;
        private readonly CourseService courseService;
        public courseController()
        {
            mapper = AutoMapperConfig.Mapper;
            courseService = new CourseService();
        }
        // GET: course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CourseModel courseData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var courseDTO = mapper.Map<course_t>(courseData);
                    int result = courseService.Create(courseDTO);
                    if (result >= 1)
                    {
                        return RedirectToAction("Index");
                    }

                    ViewBag.Message = "Error Occurred";

                }
                return View(courseData);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(courseData);
            }

        }
    }
}