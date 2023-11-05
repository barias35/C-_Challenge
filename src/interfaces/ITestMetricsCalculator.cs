 public interface ITestMetricsCalculator
    {
        (int totalTestCases, int passedTestCases, int failedTestCases, double avgExecutionTime, double minExecutionTime, double maxExecutionTime) CalculateMetrics(List<TestResult> testResults);
    }