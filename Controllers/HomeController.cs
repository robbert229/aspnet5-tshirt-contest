using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using TShirtVoter.Models;

namespace TShirtVoter.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Vote");
        }

        public IActionResult Register(){
            return View();
        }
        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(ContestEntry entry)
        {
            if(ModelState.IsValid){
                return RedirectToAction("Vote");    
            } else {
                return View(entry);
            }
        }
               
        public IActionResult Vote(){
            var entries = new List<ContestEntry>();
            
            return View(entries);
        }
    }
}
