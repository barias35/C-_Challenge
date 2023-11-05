using System.Text;
using HtmlAgilityPack;
 public class HtmlReportGenerator
    {
        private readonly ITestMetricsCalculator metricsCalculator;

        public HtmlReportGenerator(ITestMetricsCalculator metricsCalculator)
        {
            this.metricsCalculator = metricsCalculator;
        }

        public void GenerateHtmlReport(List<TestResult> testResults, string htmlFilePath)
        {
            var doc = new HtmlDocument();
            var html = doc.DocumentNode;
            var body = html.AppendChild(doc.CreateElement("html")).AppendChild(doc.CreateElement("body"));
            body.AppendChild(doc.CreateElement("h1")).InnerHtml = "Test Results Report";

            var table = body.AppendChild(doc.CreateElement("table"));
            var tr1 = table.AppendChild(doc.CreateElement("tr"));
            tr1.AppendChild(doc.CreateElement("th")).InnerHtml = "Metric";
            tr1.AppendChild(doc.CreateElement("th")).InnerHtml = "Value";

            var metrics = metricsCalculator.CalculateMetrics(testResults);

            AddTableRow(doc, table, "Total Test Cases Executed", metrics.totalTestCases.ToString());
            AddTableRow(doc, table, "Number of Test Cases Passed", metrics.passedTestCases.ToString());
            AddTableRow(doc, table, "Number of Test Cases Failed", metrics.failedTestCases.ToString());
            AddTableRow(doc, table, "Average Execution Time (seconds)", metrics.avgExecutionTime.ToString());
            AddTableRow(doc, table, "Minimum Execution Time (seconds)", metrics.minExecutionTime.ToString());
            AddTableRow(doc, table, "Maximum Execution Time (seconds)", metrics.maxExecutionTime.ToString());

            using (var writer = new StreamWriter(htmlFilePath, false, Encoding.UTF8))
            {
                doc.Save(writer);
            }
        }

        private void AddTableRow(HtmlDocument doc, HtmlNode table, string metric, string value)
        {
            var tr = table.AppendChild(doc.CreateElement("tr"));
            tr.AppendChild(doc.CreateElement("td")).InnerHtml = metric;
            tr.AppendChild(doc.CreateElement("td")).InnerHtml = value;
        }
    }