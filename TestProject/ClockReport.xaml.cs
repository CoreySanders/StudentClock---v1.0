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
            repView.LocalReport.ReportEmbeddedResource = "TestProject.Report1.rdlc";
            GenerateNewReport(DateTime.Now.AddDays(-1), DateTime.Now);
        }

        private void btnSearchClocks_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = DateTime.Parse(txtFromDate.Text);
            DateTime endDate = DateTime.Parse(txtToDate.Text);
            GenerateNewReport(startDate, endDate);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void GenerateNewReport(DateTime startTime, DateTime endTime)
        {
            endTime = endTime <= DateTime.Now ? endTime : DateTime.Now;
            repView.LocalReport.DataSources.Clear();
            repView.LocalReport.DataSources.Add(InstructorDB.GetClockTimes(startTime, endTime));
            repView.ZoomMode = ZoomMode.PageWidth;
            repView.RefreshReport();
        }
    }
}
