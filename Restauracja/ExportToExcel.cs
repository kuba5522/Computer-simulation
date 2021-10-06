using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace Restaurant
{
    public static class CreateExcelFile
    {
        public static int i = 1;
        public static ExcelWorksheet currentWorksheet;
        private static readonly ExcelPackage package;
        static CreateExcelFile()
        {
            FileInfo SpreadsheetPath = new FileInfo(@"C:\Users\Kuba\Desktop\Test.xlsx");
            package = new ExcelPackage(SpreadsheetPath);
            ExcelWorkbook workBook = package.Workbook;
            currentWorksheet = workBook.Worksheets.First();
        }
        public static void SaveToExcel(int value, int j) {
            currentWorksheet.SetValue(i, j, value);
        }
        public static void SaveToExcel(string value, int j)
        {
            currentWorksheet.SetValue(i, j, value);
        }
        public static void SaveFile()
        {
            package.Save();
        }
        
    }
}
