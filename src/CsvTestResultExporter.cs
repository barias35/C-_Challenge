  using CsvHelper;
  using System.Globalization;
  
  public class CsvTestResultExporter : ITestResultExporter
    {
        public void Export(List<TestResult> testResults, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.CurrentCulture))
            {
                csv.WriteRecords(testResults);
            }
        }
    }