using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Gighub.Dtos;
using Gighub.Models;
using Microsoft.AspNet.Identity;

namespace Gighub.Controllers

{
    public partial class FollowingsController : ApiController
    {

        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Following(FollowingDto dto)
        {
            if (_context.Followings.Any(
                f => f.FolloweeId == User.Identity.GetUserId() && f.FolloweeId == dto.FolloweeId))
            {
                return BadRequest("Already Exists.");
            }

            var following = new Following()
            {
                FollowerId = User.Identity.GetUserId(),
                FolloweeId = dto.FolloweeId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();
            return Ok();

        }
    }
}
