using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Reporting.WinForms;
using SchoolDB;

namespace TestProject
{
    /// <summary>
    /// Interaction logic for ClockReport.xaml
    /// </summary>
    public partial class ClockReport : Window
    {
        public ClockReport()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            repView.LocalReport.ReportEmbeddedResource = "Report1.rdlc";
            repView.LocalReport.ReportPath = "C:\\Users\\corey.sanders\\Documents\\GitHub\\StudentClock---v1.0\\TestProject\\Report1.rdlc";
            repView.LocalReport.DataSources.Clear();
            repView.LocalReport.DataSources.Add(InstructorDB.GetClockTimes(DateTime.Now.AddDays(-300), DateTime.Now));
            repView.ZoomMode = ZoomMode.PageWidth;
            repView.RefreshReport();
        }
    }
}
