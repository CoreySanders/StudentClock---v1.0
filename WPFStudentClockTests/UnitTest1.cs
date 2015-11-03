using System;
using SchoolDB;
using TestProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WPFStudentClockTests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Student Tests
        /// </summary>

        [TestMethod]
        public void StudentGetID()
        {
            //Arrange
            EFStudent student = StudentDB.GetStudentByID(1);
            
            //Assert
            Assert.AreEqual(student.StudentID, 1);
            Assert.AreEqual(student.First_Name.Trim(), "Corey");
        }

        [TestMethod]
        public void StudentIsValid()
        {
            //Arrange
            bool IsValid = StudentDB.IsValidStudentID(1);

            //Assert
            Assert.IsTrue(IsValid);
        }

        [TestMethod]
        public void ClockInValidation()
        {
            //Arrange
            bool clockIn = StudentDB.StudentClockIn(1, 1);

            //Assert
            Assert.IsTrue(clockIn);
        }

        [TestMethod]
        public void StudentFullName()
        {
            //Arrange
            string name = StudentDB.GetStudentNameByID(1);

            //Assert
            Assert.AreEqual(name, "Corey Sanders");
        }

        //Generally used for changing the text from text boxes, into ints to
        //query, or use the student IDs *Has other purposes as well*
        [TestMethod]
        public void StringToInt()
        {
            //Arrange
            string text = "5";
            int integer;

            //Act
            SchoolValidation.StringToInt(text, out integer);

            //Assert
            Assert.AreEqual(5, integer);
        }
    }
}
