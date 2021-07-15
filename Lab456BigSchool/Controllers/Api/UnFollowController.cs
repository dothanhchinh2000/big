using Lab456BigSchool.DTOs;
using Lab456BigSchool.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab456BigSchool.Controllers.Api
{
    public class UnFollowController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public UnFollowController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult UnFollow(FollowingDto followDto)
        {
            var userId = User.Identity.GetUserId();

            var FollowToDel = _dbContext
                .Followings
                .FirstOrDefault(a => a.FollowerId == userId && a.FolloweeId == followDto.FolloweeId);

            if (FollowToDel == null)
            {
                return BadRequest("The Follow  is not exists!");
            }
            _dbContext.Followings.Remove(FollowToDel);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
