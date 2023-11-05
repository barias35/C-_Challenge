 public interface ITestResultExporter
    {
        void Export(List<TestResult> testResults, string filePath);
    }