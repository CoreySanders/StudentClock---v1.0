using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SchoolDB
{
    public static class StudentDB
    {
        //School Entity Framework
        private static SchoolDataEntities schoolData = new SchoolDataEntities();

        public static EFStudent GetStudentByID(int studentID)
        {
            EFStudent student = (from students in schoolData.EFStudents
                                 where students.StudentID == studentID
                                 select students).Single();
            return student;
        }

        public static Boolean IsValidStudentID(int studentID)
        {
            int validStudent = schoolData.EFStudents.Where(s => s.StudentID == studentID).Count();
            bool studentValid = validStudent > 0 ? true : false;
            return studentValid;
        }

        public static Boolean StudentClockIn(int studentID, int classID)
        {
            if (IsValidStudentID(studentID))
            {
                EFClock clock = new EFClock();
                clock.StudentID = studentID;
                clock.ClassID = classID;
                clock.Clock = DateTime.Now;
                clock.ClockID = 56;
                schoolData.EFClocks.Add(clock);
                schoolData.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetStudentNameByID(int studentID)
        {
            if (IsValidStudentID(studentID))
            {
                EFStudent student = schoolData.EFStudents.Where(c => c.StudentID == studentID).Single();
                string name = student.First_Name.Trim() + " " + student.Last_Name.Trim();
                return name;
            }
            else
            {
                return " ";
            }
        }
    }
}
