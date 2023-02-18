using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.WebApplication.Entities;
using Store.WebApplication.ViewModels;
using System.Linq;

namespace Store.WebApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly StoreDBContext _context;

        public ProductController(StoreDBContext context)
        {
            _context = context;
        }


        // GET: ProductController
        public ActionResult Index()
        {
            var data = new ProductViewModel
            {
                ProductList = _context.Product.ToList()
            };

            return View(data);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product productd)
        {
            _context.Product.Add(productd);
            _context.SaveChanges();

            return Json(new { message = "Se ha agregado con exito!", id = 1, url = Redirect("Index") });
        }

        // GET: ProductController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {

            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["id"] = id;
                var getProduct = _context.Product.Find(id);

                ViewBag.name = getProduct.Name;
                ViewBag.description = getProduct.Description;

            }

            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {

            _context.Product.Update(product);

            var result = _context.SaveChanges();

            if (result > 0)
            {
                return Json(new { message = "Se ha actualizado con exito", id = 1, url = Redirect("Index") });
            }
            else
            {
                return Json(new { message = "Valide que todos los campos hayan sido completados!", id = 2 });
            }
        }

        // GET: ProductController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var getProduct = _context.Product.Find(id);

            _context.Product.Remove(getProduct);
            _context.SaveChanges();

            return Json(new { message = "Se ha eliminado con exito!", id = 1 });
        }

        // POST: ProductController/Delete/5
      //  [HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, Product product)
        //{

        //    var getProduct = _context.Product.Find(id);
        //    _context.Product.Remove(getProduct);
        //    var result = _context.SaveChanges();

        //    if(result > 0)
        //    {
        //        return Json(new { message = "Se ha removido con exito!", id = 1 });
        //    }
        //    else
        //    {
        //        return Json(new { message = "No se ha podido eliminar", id = 2 });
        //    }
         
        //}
    }
}
