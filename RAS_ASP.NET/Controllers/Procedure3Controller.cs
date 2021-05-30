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
            return View(new CuisineProcedure());
        }

        // POST: Procedure2Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CuisineProcedure entity)
        {
            try
            {
                using (NHibernate.ISession session = NHibernateManager.OpenSession())
                {
                    entity.CuisineTotalRecord = new DAOFactory(session).GetCuisineDAO().GetTotalPrice(entity.ID);
                    if(!entity.CuisineTotalRecord.IsEmpty)
                        entity.Status = "Successful";
                    else
                        entity.Status = "Error";
                }
                return View(entity);
            }
            catch
            {
                entity.Status = "Error";
                return View(entity);
            }
        }
    }
}
