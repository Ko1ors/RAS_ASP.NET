using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAS_ASP.NET.Models;
using System.Collections.Generic;
using WebApplication.Controllers;
using WebApplication.Data.DAO;
using WebApplication.Data.Entities;

namespace RAS_ASP.NET.Controllers
{
    public class Procedure3Controller : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procedure2Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CuisineEntity entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    var factory = new DAOFactory(session);
                    factory.GetCuisineDAO().GetTotalPrice((int)entity.ID);
                }
                return View(entity);
            }
            catch
            {
                return View(entity);
            }
        }
    }
}
