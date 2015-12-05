using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using TShirtVoter.Models;

namespace TShirtVoter.Controllers
{

    public class HomeController : Controller
    {
        [FromServices]
        public ContestDbContext ContestContext { get; set; }

        public IActionResult Register(){
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(ContestEntry entry)
        {
            if(ModelState.IsValid)
            {
                if (ContestContext.Entries.Any(e => e.StudentId == entry.StudentId))
                {
                    return RedirectToAction("AlreadyRegistered");
                }

                ContestContext.Entries.Add(entry);
                ContestContext.SaveChanges();
                
                return RedirectToAction("Index");    
            } else {
                return View(entry);
            }
        }
               
        public IActionResult Index()
        {
            var entries = ContestContext.Entries.ToList();
            return View(entries);
        }

        public IActionResult Vote(int? id)
        {
            if(id == null)
                return RedirectToAction("Index");

            ViewBag.EntryId = id;
            return View(new ContestVote());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Vote(ContestVote vote)
        {
            if (ModelState.IsValid)
            {
                if (ContestContext.Votes.Any(e => e.StudentId == vote.StudentId))
                {
                    return RedirectToAction("AlreadyVoted");
                }

                ContestContext.Votes.Add(vote);
                ContestContext.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(vote);
            }
        }

        public IActionResult Status(int code)
        {
            if (code != 1337)
            {
                return RedirectToAction("Error");
            }

            var status = new ContestStatus();

            var winner = ContestContext.Entries.First();
            var winnerVotes = 0;

            ContestContext.Entries.ToList().ForEach(e =>
            {
                var entryVotes = ContestContext.Votes.Count(v => v.EntryId == e.EntryId);

                if (entryVotes > winnerVotes){
                    winner = e;
                    winnerVotes = entryVotes;
                }
            });


            status.Winner = winner;
            status.Votes = ContestContext.Votes.ToList();

            return View(status);
        }

        public IActionResult AlreadyVoted()
        {
            return View();
        }

        public IActionResult AlreadyRegistered()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
