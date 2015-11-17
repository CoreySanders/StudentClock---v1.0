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
            if (IsValidStudentID(studentID) && CheckClass(studentID, classID) && CheckClockTime(DateTime.Now, studentID))
            {
                 
                if (IsClockedIn(studentID, classID))
                {
                    EFClock clock = schoolData.EFClocks.Where(c => c.StudentID == studentID && c.ClockedIn == true).Single();
                    clock.EndTime = DateTime.Now;
                    clock.ClockedIn = false;
                    clock.Absence = CheckClockTime(DateTime.Now, studentID) ? true : false;
                }
                else
                {
                    EFClock clock = new EFClock();
                    clock.StudentID = studentID;
                    clock.ClassID = classID;
                    clock.StartTime = DateTime.Now;
                    clock.ClockedIn = true;
                    clock.Absence = CheckClockTime(DateTime.Now, studentID) ? true : false;
                    schoolData.EFClocks.Add(clock);
                }
                schoolData.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean CheckClass(int studentID, int classID)
        {
            if (IsValidStudentID(studentID))
            {
                var clockedIn = from schedule in schoolData.EFSchedules
                                where schedule.StudentID == studentID
                                && schedule.ClassID == classID
                                && schedule.StartTime <= DateTime.Now
                                select new
                                {
                                    Student = schedule.StudentID
                                };
                bool clocked = clockedIn.Count() == 1 ? true : false;
                return clocked;
            }
            else
            {
                return false;
            }
        }

        public static Boolean IsClockedIn(int studentID, int classID)
        {
            if (IsValidStudentID(studentID) && CheckClass(studentID, classID))
            {
                var clock = (from clocks in schoolData.EFClocks
                             where (clocks.StudentID == studentID) &&
                             (clocks.ClassID == classID) &&
                             (clocks.ClockedIn == true)
                             select clocks);

                Boolean clockedIn = clock.Count() == 1 ? true : false;
                return clockedIn;
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

        public static Boolean CheckClockTime(DateTime clock, int studentID)
        {
            var schedule = (from schedules in schoolData.EFSchedules
                                  where (schedules.StudentID == studentID)
                                  && (schedules.StartTime <= clock)
                                  && (schedules.EndTime >= clock)
                                       select schedules);
            Boolean clockCheck = schedule.Count() > 0 ? true : false;
            return clockCheck;
        }
    }
}
