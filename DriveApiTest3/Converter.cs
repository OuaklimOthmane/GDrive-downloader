using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace DriveApiTest3
{
    class Converter
    {
        public static void CsvConverter(string fileId, string pathServiceAccount, string pathLocalStorage, string newPathLocalStorage)
        {
            var fileName = NameGetter.getName(fileId, pathServiceAccount);
            string csv = @pathLocalStorage+fileName+".csv";
            string xls = @newPathLocalStorage+"Converted"+" "+fileName+ ".xlsx";
            Excel.Application xl = new Excel.Application();

            // 1.Open Excel Workbook for conversion :
            Excel.Workbook wb = xl.Workbooks.Open(csv);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets.get_Item(1);

            // 2.Select The UsedRange :
            Excel.Range used = ws.UsedRange;

            // 3.Autofit The Columns :
            used.EntireColumn.AutoFit();

            // 4.Save file as csv file :
            wb.SaveAs(xls, 51);

            // 5.Close the Workbook :
            wb.Close();

            // 6.Quit Excel Application :
            xl.Quit();
        }
    }
}
