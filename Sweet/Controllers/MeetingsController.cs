using System.Linq;
using System.Web.Mvc;
using Sweet.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Web.Routing;

namespace FinalSweet.Controllers
{
    public class MeetingsController : Controller
    {
        private ApplicationDbContext _dbContext;
        public MeetingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Meeetings

        public ActionResult Index()
        {
            var meeting = _dbContext.Meetings.ToList();

            return View(meeting);
        }
        public ActionResult New()
        {
            return View();
        }

        public ActionResult Add(Meeting meeting)
        {
            _dbContext.Meetings.Add(meeting);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var meeting = _dbContext.Meetings.SingleOrDefault(v => v.MeetingId == id);

            if (meeting == null)
                return HttpNotFound();

            return View(meeting);
        }
        [HttpPost]
        public ActionResult Update(Meeting meeting)
        {
            var appointmentInDb = _dbContext.Meetings.SingleOrDefault(v => v.MeetingId == meeting.MeetingId);

            if (appointmentInDb == null)
                return HttpNotFound();

            appointmentInDb.UserName = meeting.UserName;
            appointmentInDb.Schedule = meeting.Schedule;
            appointmentInDb.Time = meeting.Time;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var appointment = _dbContext.Meetings.SingleOrDefault(v => v.MeetingId == id);

            if (appointment == null)
                return HttpNotFound();

            return View(appointment);
        }
        [HttpPost]
        public ActionResult DoDelete(int id)
        {
            var appointment = _dbContext.Meetings.SingleOrDefault(v => v.MeetingId == id);
            if (appointment == null)
                return HttpNotFound();
            _dbContext.Meetings.Remove(appointment);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}