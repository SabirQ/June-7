using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController:Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            List<Service> services = _context.Services.ToList();
            return View(services);
        }
        public ActionResult Detail(int? id)
        {
            if (id==null)
            {
                return RedirectToAction("Index");
            }

            Service service = _context.Services.FirstOrDefault(x => x.Id == id);
            return View(service);
            
        }
    }
}
