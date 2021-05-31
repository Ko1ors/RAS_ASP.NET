using Microsoft.AspNetCore.Mvc;
using WebApplication.Controllers;
using WebApplication.Data.DAO;

namespace RAS_ASP.NET.Controllers
{
    public class OrderSummaryController : Controller
    {
        // GET: OrderSummaryController
        public ActionResult Index()
        {
            using (NHibernate.ISession session = NHibernateManager.OpenSession())
            {
                var orders = new DAOFactory(session).GetOrderSummaryDAO().GetAll();
                return View(orders);
            }
        }
    }
}
