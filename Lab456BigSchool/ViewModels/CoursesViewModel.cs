using Lab456BigSchool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab456BigSchool.ViewModels
{
    public class CoursesViewModel

    {
        public IEnumerable<Course> UpcommingCourses { get; set; }
        public bool ShowAction { get; set; }
    }
}