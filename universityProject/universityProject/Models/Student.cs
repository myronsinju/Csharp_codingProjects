﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace universityProject.Models
{
    public class Student
    {
        public int ID { get; set; }//property this whole class is
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}