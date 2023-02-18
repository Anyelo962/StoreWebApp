using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Store.WebApplication.Entities;
using Store.WebApplication.ViewModels;
using System.Linq;

namespace Store.WebApplication.Controllers
{
    public class OrderController : Controller
    {


        private readonly StoreDBContext _context;

        public OrderController(StoreDBContext context)
        {
            _context = context;
        }
    
        public IActionResult Index()
        {
            var getProduct = new OrderViewModel
            {
                Orders = _context.Orders.ToList(),
                Products = _context.Product.ToList(),
                Clients = _context.Client.ToList()

            };

            return View(getProduct);
        }


        [HttpGet]
        public ActionResult AddOrder()
        {
            var data = new OrderViewModel
            {
                Products = _context.Product.ToList()
            };

            return View(data);
        }


        [HttpPost]
        public ActionResult AddOrder(Orders orders) 
        {

            _context.Orders.Add(orders);
            var result = _context.SaveChanges();

            if(result > 0)
            {
                return Json(new { message = "Se ha agregado con exito!", id = 1 });
            }
            else
            {
                return Json(new { message = "No se podido cargar la orden", id = 1 });
            }
;
        }


        public ActionResult UpdateOrder(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateOrder(Orders orders)
        {


            return Json(new { message = "Se ha agregado con exito!", id = 1 });
        }


        [HttpPost]
        public ActionResult DeleteOrder(int id)
        {

            return Json(new {message= "Se ha removido con exito!", id=id});
        }
    }
}
