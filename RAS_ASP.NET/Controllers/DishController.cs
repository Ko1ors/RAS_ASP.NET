﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAS_ASP.NET.Services;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Controllers
{
    public class DishController : Controller
    {
        private readonly DishService _service;

        public DishController()
        {
            _service = new DishService(this.ModelState, new DAOFactory(NHibernateManager.OpenSession()).GetDishDAO());
        }


        // GET: DishController
        public ActionResult Index()
        {
            return View(_service.List());
        }

        // GET: DishController/Details/5
        public ActionResult Details(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
        }

        // GET: DishController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DishController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DishEntity entity)
        {
            if (!_service.Create(entity))
                return View();
            return RedirectToAction("Index");
        }

        // GET: DishController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
        }

        // POST: DishController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DishEntity entity)
        {
            if (!_service.Edit(id, entity))
                return View();
            return RedirectToAction(nameof(Index));
        }

        // GET: DishController/Delete/5
        public ActionResult Delete(int id)
        {
            if (!_service.Exists(id))
                return View();
            return View(_service.Get(id));
        }

        // POST: DishController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, DishEntity entity)
        {
            if (!_service.Delete(entity))
                return View();
            return RedirectToAction(nameof(Index));
        }
    }
}
