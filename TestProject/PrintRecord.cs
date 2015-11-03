using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Print includes
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

class PrintRecord
{
    ArrayList PrintArray;
    public PrintRecord(ArrayList Array)
    {
        PrintArray = Array;
    }

    public void Print()
    {
        PrintDialog printDialog1 = new PrintDialog();
        printDialog1.Document = new PrintDocument();
        printDialog1.AllowPrintToFile = true;
        printDialog1.PrintToFile = false;
        if (printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            printDialog1.Document.DefaultPageSettings.PaperSize = new PaperSize("Letter", 1700, 2339);
            printDialog1.Document.PrinterSettings.PrintToFile = true;

            printDialog1.Document.PrintPage += delegate(object sender1, PrintPageEventArgs e1)
            {
                RectangleF page = printDialog1.Document.DefaultPageSettings.PrintableArea;
                float x = 50;
                float y = 50;
                Font printFont = new Font("Times New Roman", 12);
                int count = 0;

                foreach (var record in PrintArray)
                {
                    count++;
                    if (count != 10)
                    {
                        e1.Graphics.DrawString(record.ToString(), printFont,
                            new SolidBrush(Color.Black),
                            new RectangleF(x, y, page.Width, page.Height));
                        y += printFont.Height;
                    }
                }
            };
            try
            {
                printDialog1.Document.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occurred while printing", ex);
            }
        }

    }
}

