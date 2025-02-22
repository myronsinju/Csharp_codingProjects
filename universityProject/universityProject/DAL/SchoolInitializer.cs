﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using universityProject.Models;

namespace universityProject.DAL
{
    public class SchoolInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>
            {
            new Student{FirstMidName="Blake",LastName="Shelton",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="Max",LastName="Finklestein",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Chad",LastName="Nuget",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Giannis",LastName="Antekntumpo",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Leah",LastName="Lost",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Monkey",LastName="Boy",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstMidName="Lisa",LastName="Simpleson",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Sylvester",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
            var courses = new List<Course>
            {
            new Course{CourseID=1050,Title="Chemistry",Credits=3,},
            new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
            new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
            new Course{CourseID=1045,Title="Calculus",Credits=4,},
            new Course{CourseID=3141,Title="Art",Credits=4,},
            new Course{CourseID=2021,Title="Composition",Credits=3,},
            new Course{CourseID=2042,Title="Literature",Credits=4,}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            var enrollments = new List<Enrollment>
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.A},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.D},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050,},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.D},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            enrollments.ForEach(s => context.Enrollments.Add(s));
            context.SaveChanges();
        }
    }
}