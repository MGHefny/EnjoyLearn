﻿using AutoMapper;
using learnApp.Data;
using learnApp.Models;
using learnApp.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//instractour featcher  will completein future
namespace learnApp.Areas.Admin.Controllers
{
    public class TrainerController : Controller
    {
        private readonly IMapper mapper;
        private readonly TrainerService trainerService;
        public TrainerController()
        {
            mapper = AutoMapperConfig.Mapper;
            trainerService = new TrainerService();
        }
        // GET: Admin/Trainer
        public ActionResult Index()
        {
            var trainersList = trainerService.ReadAll();

            var mappedTrainersList = mapper.Map<IEnumerable<TrainerModel>>(trainersList);

            return View(mappedTrainersList);
        }

        // GET: Admin/Trainer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Trainer/Create
        public ActionResult Create()
        {
            return View();
        }
        // instactours login 1
        // POST: Admin/Trainer/Create
        [HttpPost]
        public ActionResult Create(TrainerModel trainerData)
        {
            try
            {
                var trainerDTO = mapper.Map<instractor>(trainerData);
                int result = trainerService.Creat(trainerDTO);
                if (result >= 1)
                {
                    return RedirectToAction("Index");
                }
                else if(result == -2)
                {
                    ViewBag.Message = "This Email is Exists!";
                    
                }
                else
                {
                    ViewBag.Message = "Error occurred!";
                    
                }
                return View(trainerData);

            }
            catch(Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(trainerData);
            }
        }

        // GET: Admin/Trainer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Trainer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Trainer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Trainer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
