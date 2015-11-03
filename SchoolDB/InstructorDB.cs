using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Reporting.WinForms;

namespace SchoolDB
{
    public static class InstructorDB
    {
        //School Entity Framework
        private static SchoolDataEntities schoolData = new SchoolDataEntities();

        public static EFInstructor GetInstructorByID(int instructorID)
        {
            var instructor = (from instructors in schoolData.EFInstructors
                              where instructors.InstructorID == instructorID
                              select instructors).Single();
            return instructor;
        }

        public static Boolean IsValidInstructorID(int instructorID)
        {
            int validInstructor = schoolData.EFInstructors.Where(i => i.InstructorID == instructorID).Count();
            if (validInstructor > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static ReportDataSource GetClockTimes(DateTime startDate, DateTime endDate)
        {
            try
            {
                var clocks = (from clock in schoolData.EFClocks
                              join student in schoolData.EFStudents on clock.StudentID equals student.StudentID
                              where clock.Clock > startDate && clock.Clock < endDate
                              select new
                              {
                                  Name = student.First_Name.Trim() + " " + student.Last_Name,
                                  Clock = clock.Clock,
                                  ClassID = clock.ClassID
                              }).AsQueryable();
                ReportDataSource ds = new ReportDataSource("Clocks", clocks);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
