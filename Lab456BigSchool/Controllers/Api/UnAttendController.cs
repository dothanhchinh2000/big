﻿using Lab456BigSchool.DTOs;
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
    public class UnAttendController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public UnAttendController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult UnAttend(AttendanceDto attendanceDto)
        {
            var userId = User.Identity.GetUserId();

            var AttendToDel = _dbContext
                .Attendances
                .FirstOrDefault(a => a.AttendeeId == userId && a.CourseId == attendanceDto.CourseId);

            if (AttendToDel == null)
            {
                return BadRequest("The Attendence  is not exists!");
            }
            _dbContext.Attendances.Remove(AttendToDel);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
