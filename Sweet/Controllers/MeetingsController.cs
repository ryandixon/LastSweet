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
        // GET: Appointments

        public async Task<ActionResult> Index(string str)
        {
            var user = User.Identity.GetUserName();
            if (user.Equals(""))
            {
                return RedirectToAction("Index", new RouteValueDictionary(
                    new { controller = "Home", action = "Home" })
                );
            }
            else
            {
                var meetings = from m in _dbContext.Meetings
                                   select m;
                if (!string.IsNullOrEmpty(str))
                {
                    meetings = meetings.Where(s => s.UserName.Contains(str));
                }
                return View(await meetings.ToListAsync());
            }



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
            var appointment = _dbContext.Meetings.SingleOrDefault(v => v.MeetingId == id);

            if (appointment == null)
                return HttpNotFound();

            return View(appointment);
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