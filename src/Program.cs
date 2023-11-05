// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using CsvHelper;
using System.Globalization;


           string outPutFolder = "output/";
            string jsonFilePath = Path.Combine("data", "testsResult.json");
            string csvFilePath = Path.Combine(outPutFolder,  "test_results.csv");
           string htmlFilePath = Path.Combine(outPutFolder,"test_results.html");


            // Load the JSON file
            List<TestResult> testResults;
            try
            {
                string jsonContent = File.ReadAllText(jsonFilePath);
                testResults = JsonConvert.DeserializeObject<List<TestResult>>(jsonContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON file: {ex.Message}");
                return;
            }

             ITestResultExporter csvExporter = new CsvTestResultExporter();
            csvExporter.Export(testResults, csvFilePath);

              // Generate an HTML report
            ITestMetricsCalculator metricsCalculator = new TestMetricsCalculator();
            var reportGenerator = new HtmlReportGenerator(metricsCalculator);
            reportGenerator.GenerateHtmlReport(testResults, htmlFilePath);

            Console.WriteLine($"Total Test Cases Executed: {testResults.Count}");
            Console.WriteLine($"Number of Test Cases Passed: {testResults.Count(r => r.Passed)}");
            Console.WriteLine($"Number of Test Cases Failed: {testResults.Count(r => !r.Passed)}");
            Console.WriteLine($"Average Execution Time: {metricsCalculator.CalculateMetrics(testResults).avgExecutionTime} seconds");
            Console.WriteLine($"Minimum Execution Time: {metricsCalculator.CalculateMetrics(testResults).minExecutionTime} seconds");
            Console.WriteLine($"Maximum Execution Time: {metricsCalculator.CalculateMetrics(testResults).maxExecutionTime} seconds");
        
        
        
