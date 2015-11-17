using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
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
            Boolean valid = validInstructor > 0 ? true : false;
            return valid;
        }

        public static ReportDataSource GetClockTimes(DateTime startDate, DateTime endDate)
        {
            try
            {
                var clocks = (from clock in schoolData.EFClocks.AsEnumerable()
                              join student in schoolData.EFStudents on clock.StudentID equals student.StudentID
                              join course in schoolData.EFCourses on clock.ClassID equals course.ClassID
                              where clock.StartTime > startDate && clock.EndTime < endDate
                              select new
                              {
                                  Name = student.First_Name.Trim() + " " + student.Last_Name,
                                  Clock = clock.StartTime.ToShortDateString() + " " + clock.StartTime.ToShortTimeString() + " - " + clock.EndTime.Value.ToShortTimeString(),
                                  ClassName = course.Description,
                                  RoomNumber = course.RoomNumber
                              }).AsEnumerable();
                ReportDataSource ds = new ReportDataSource("dsClocks", clocks);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
