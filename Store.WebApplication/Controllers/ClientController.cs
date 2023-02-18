using Microsoft.AspNetCore.Mvc;
using Store.WebApplication.Entities;
using Store.WebApplication.ViewModels;
using System.Linq;

namespace Store.WebApplication.Controllers
{
    public class ClientController : Controller
    {

        private readonly StoreDBContext _context;

        public ClientController(StoreDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllClient()
        {
            var data = _context.Client.ToList();

            var result = new ClientViewModel
            {
                clientList = data
            };



            return View(result);
        }

        [HttpGet]
        public ActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddClient(Client client)
        {

            _context.Client.Add(client);

            var result = _context.SaveChanges();

            if(result > 0)
            {
                return Json(new { message = "Se ha agregado con exito!", id = 1, url= Redirect("GetAllClient") });
            }
            else
            {
                return Json(new { message = "Asegurese de que la información agregada sea correcta!", id = 2});
            }
        }



        [HttpGet]
        public ActionResult UpdateClients(int id)
        {
            if(id == 0)
            {
               return RedirectToAction("GetAllClient");
            }
            else
            {
                TempData["Id"] = id;

                var result = _context.Client.Find(id);

                ViewBag.name = result.Name;
                ViewBag.lastName = result.LastName;
                ViewBag.telephone = result.Telephone;
            }

            return View();
        }


        [HttpPost]
        public JsonResult UpdateClient(Client client)
        {

            int id = int.Parse(TempData["Id"].ToString());

            var getClient = _context.Client.Find(id);

            getClient.Name = client.Name;
            getClient.LastName = client.LastName;
            getClient.Telephone = client.Telephone;

            _context.Client.Update(getClient);

            var result = _context.SaveChanges();

            if(result > 0)
            {
                return Json(new { message = "Se ha actualizado con exito!", id = 1, url = Redirect("GetAllClient") });
            }
            else
            {
                return Json(new { message = "No se ha podido actualizar", id = 2 });
            }

        }


        [HttpPost]
        public JsonResult RemoveClient(int id)
        {
            var result = _context.Client.Find(id);

            _context.Client.Remove(result);

            _context.SaveChanges();

            return Json(new { message = "Se ha removido con exito!", id = 1 });
        }

    }
}
