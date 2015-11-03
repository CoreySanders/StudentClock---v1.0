using System;
using System.Collections.Generic;
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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SchoolDB;
namespace TestProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int currentClassID = 1;

        public bool clockInAnimationEnded = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClockIn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!(txtStudentID.Text == "xadminx"))
            {
                try
                {
                    int studentID = int.Parse(txtStudentID.Text);

                    if (clockInAnimationEnded)
                    {
                        if (StudentDB.IsValidStudentID(studentID))
                        {
                            if (StudentDB.StudentClockIn(studentID, currentClassID))
                            {
                                txtStudentID.Text = "";
                                clockInAnimationEnded = false;
                                ClockInAnimation(studentID);
                            }
                            else
                            {
                                MessageBox.Show("Could not log student in.");
                                txtStudentID.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid student ID");
                            txtStudentID.Text = "";
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Student ID must be in numbers.");
                    txtStudentID.Text = "";
                }
            }
            else
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.mainWindow = this;
                txtStudentID.Text = "";
                adminPanel.ShowDialog();

            }
        }

        private void ClockInAnimation(int studentID)
        {
            Storyboard showResult;
            EFStudent student = StudentDB.GetStudentByID(studentID);
            lblResult.Content = "You have logged in, " + student.First_Name.Trim() + " " + student.Last_Name.Trim();
            rectBottom.Visibility = Visibility.Visible;
            grdBottom.Visibility = Visibility.Visible;
            showResult = (Storyboard)this.Resources["ScrollDown"];
            showResult.Begin();
            showResult = (Storyboard)this.Resources["FadeOut"];
            showResult.Begin();
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {
            clockInAnimationEnded = true;
            rectBottom.Opacity = 100;
            grdBottom.Opacity = 100;
            grdBottom.Visibility = Visibility.Hidden;
            rectBottom.Visibility = Visibility.Hidden;
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
