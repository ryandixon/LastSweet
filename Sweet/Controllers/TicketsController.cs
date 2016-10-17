using System.Linq;
using System.Web.Mvc;
using Sweet.Models;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Web.Routing;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Sweet.Controllers
{
    public class TicketsController : Controller
    {
        private ApplicationDbContext _dbContext;

        public TicketsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = _dbContext.Tickets.ToList();

            return View(tickets);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Add(Ticket ticket)
        {
            _dbContext.Tickets.Add(ticket);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var ticket = _dbContext.Tickets.SingleOrDefault(v => v.TicketId == id);

            if (ticket == null)
                return HttpNotFound();

            return View(ticket);
        }

        [HttpPost]
        public ActionResult Update(Ticket ticket)
        {
            var ticketInDb = _dbContext.Tickets.SingleOrDefault(v => v.TicketId == ticket.TicketId);

            if (ticketInDb == null)
                return HttpNotFound();

            ticketInDb.Title = ticket.Title;
            ticketInDb.Description = ticket.Description;
            ticketInDb.UserName = ticket.UserName;
            ticketInDb.Resolve = ticket.Resolve;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            var ticket = _dbContext.Tickets.SingleOrDefault(v => v.TicketId == id);

            if (ticket == null)
                return HttpNotFound();

            return View(ticket);
        }

        [HttpPost]
        public ActionResult DoDelete(int id)
        {
            var ticket = _dbContext.Tickets.SingleOrDefault(v => v.TicketId == id);

            if (ticket == null)
                return HttpNotFound();

            _dbContext.Tickets.Remove(ticket);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}