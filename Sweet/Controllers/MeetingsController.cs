using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sweet.Models;

namespace Sweet.Controllers
{
    public class MeetingsController : Controller
    {

        private ApplicationDbContext _dbContext;

        public MeetingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Meetings
        public ActionResult Index()
        {
            var meetings = _dbContext.Meetings.ToList();

            return View(meetings);
        }

        public ActionResult Add(Meeting meeting)
        {
            _dbContext.Meetings.Add(meeting);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult New()
        {
            return View();
        }
    }
}