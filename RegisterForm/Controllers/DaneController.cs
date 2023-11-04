using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zajecia3.Models;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// klasa kontrolera - kontroler
// model - zwykła klasa
// widok - pusty widok razor
namespace zajecia3.Controllers
{
    public class DaneController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Form() {
            return View();
        }
        [HttpPost]
        public IActionResult Form(Dane dane)
        {
            if (ModelState.IsValid)
            {
                return View("Wynik", dane);
            }
            else return View();

        }
        public IActionResult Wynik(Dane dane) {
            return View(dane);
        }
    }
}
