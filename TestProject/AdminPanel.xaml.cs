using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Data;
using Microsoft.Reporting.WinForms;
using SchoolDB;
using System.Drawing;

namespace TestProject
{
    /// <summary>
    /// Interaction logic for AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        EFStudent oldStudent;
        bool editMode = false;
        public MainWindow mainWindow = new MainWindow();
        SchoolDataEntities schoolData = new SchoolDataEntities();

        public AdminPanel()
        {
            InitializeComponent();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnPrintReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //EFClock[] clockArray = schoolData.EFClocks.Where(c => c.Clock.Value.Day == DateTime.Now.Day).ToArray();
                //ArrayList clockReports = new ArrayList();
                //for (int i = 0; i < clockArray.Length; i++)
                //{
                //    clockReports.Add(StudentDB.GetStudentNameByID(clockArray[i].StudentID) + " - " + clockArray[i].Clock.Value.ToString("MMMM dd, yyyy hh:mm:ss tt"));
                //}
                //PrintRecord print = new PrintRecord(clockReports);
                //print.Print();
                ClockReport report = new ClockReport();
                report.Show();
            }
            catch (Exception)
            {

            }
        }

        private void btnAdminClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblCurrentClass.Content = "Current Class: " + mainWindow.currentClassID.ToString();
            var states = (from state in schoolData.EFStates
                         orderby state.StateName
                         select new
                         {
                             state.StateName,
                             state.StateCode
                         }).ToList();
            cboStates.ItemsSource = states;
            cboStates.DisplayMemberPath = "StateName";
            cboStates.SelectedValuePath = "StateCode";
        }

        private void btnClassChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int classID = int.Parse(txtClassChange.Text);
                if (classID > 0)
                {
                    mainWindow.currentClassID = classID;
                    lblCurrentClass.Content = "Current Class: " + mainWindow.currentClassID.ToString();
                }
                else
                {
                    MessageBox.Show("Please insert a valid class ID.");
                    txtClassChange.Clear();
                    txtClassChange.Focus();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Class ID must be a number.");
                txtClassChange.Clear();
                txtClassChange.Focus();
            }
            catch
            {
                MessageBox.Show("Please insert a valid class number");
                txtClassChange.Clear();
                txtClassChange.Focus();
            }
        }

        private void btnFindStudent_Click(object sender, RoutedEventArgs e)
        {
            int studentID = 0;
            if (SchoolValidation.StringToInt(txtStudentFind.Text, out studentID))
            {
                if (StudentDB.IsValidStudentID(studentID))
                {
                    EFStudent student = schoolData.EFStudents.Where(s => s.StudentID == studentID).Single();
                    oldStudent = student;
                    txtFirstName.Text = student.First_Name.Trim();
                    txtLastName.Text = student.Last_Name.Trim();
                    txtAddress.Text = student.Address.Trim();
                    txtZip.Text = student.ZipCode.ToString();
                    cboStates.SelectedValue = student.StateCode;
                    lblStudentFullName.Content = student.First_Name.Trim() + " " + student.Last_Name.Trim();
                    lblStudentID.Content = studentID.ToString();
                    if (student.Photo != null)
                    {
                        StringtoImage(student.Photo.Trim());
                    }
                    else
                    {
                        StringtoImage("http://i882.photobucket.com/albums/ac22/CoreySanders/noImage_zpsctmad3nk.png");
                    }
                    ToggleEditMode();
                }
                else
                {
                    MessageBox.Show("Is not a valid student");
                }
            }
            else
            {
                MessageBox.Show("Please insert a valid student id (number between 0 - 1000000)");
            }
        }

        private void ToggleEditMode()
        {
            TextBox[] textboxes = {txtFirstName, txtLastName, txtAddress,
                                      txtZip};
            editMode = editMode == false ? true : false;

            if (editMode == false)
            {
                btnFindStudent.IsEnabled = true;
                txtStudentFind.IsEnabled = true;
                pnlStudent.IsEnabled = false;
                txtFirstName.IsEnabled = false;
                txtLastName.IsEnabled = false;
                txtAddress.IsEnabled = false;
                cboStates.IsEnabled = false;
                txtZip.IsEnabled = false;
                lblStudentFullName.Content = "";
                lblStudentID.Content = "";
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtAddress.Text = "";
                cboStates.SelectedValue = "";
                txtZip.Text = "";
                btnEdit.IsEnabled = false;
                btnCancel.IsEnabled = false;
                StringtoImage("http://i882.photobucket.com/albums/ac22/CoreySanders/noImage_zpsctmad3nk.png");
            }
            else
            {
                btnFindStudent.IsEnabled = false;
                txtStudentFind.IsEnabled = false;
                pnlStudent.IsEnabled = true;
                txtFirstName.IsEnabled = true;
                txtLastName.IsEnabled = true;
                txtAddress.IsEnabled = true;
                cboStates.IsEnabled = true;
                txtZip.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnCancel.IsEnabled = true;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (txtZip.Text.Length == 5)
            {
                EFStudent student = oldStudent;
                student.First_Name = txtFirstName.Text;
                student.Last_Name = txtLastName.Text;
                student.Address = txtAddress.Text;
                student.StateCode = cboStates.SelectedValue.ToString();
                student.ZipCode = int.Parse(txtZip.Text);
                schoolData.SaveChanges();
                var entry = schoolData.Entry(student);
                entry.Reload();
                ToggleEditMode();
            }
            else
            {
                MessageBox.Show("Insert a valid zipcode");
            }
        }

        private void NumericTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ToggleEditMode();
        }

        private void StringtoImage(string imageSource)
        {
            string fullFilePath = imageSource;
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bi.EndInit();


            imgStudentPicture.Source = bi;
        }
    }
}
