 public class TestMetricsCalculator : ITestMetricsCalculator
    {
        public (int totalTestCases, int passedTestCases, int failedTestCases, double avgExecutionTime, double minExecutionTime, double maxExecutionTime) CalculateMetrics(List<TestResult> testResults)
        {
            int totalTestCases = testResults.Count;
            int passedTestCases = testResults.Count(r => r.Passed);
            int failedTestCases = totalTestCases - passedTestCases;
            double totalExecutionTime = testResults.Sum(r => r.ExecutionTime);
            double minExecutionTime = testResults.Min(r => r.ExecutionTime);
            double maxExecutionTime = testResults.Max(r => r.ExecutionTime);
            double avgExecutionTime = Math.Round(totalExecutionTime / totalTestCases, 2);

            return (totalTestCases, passedTestCases, failedTestCases, avgExecutionTime, minExecutionTime, maxExecutionTime);
        }
    }