using Gighub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace Gighub.Controllers
{
    [Authorize]
    public class AttedancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttedancesController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend([FromBody]int gigId)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == gigId))
            {
                return BadRequest("Already Exists.");
            }

            var attendance = new Attendance
            {
                GigId = gigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return Ok();
        }
    }
}
