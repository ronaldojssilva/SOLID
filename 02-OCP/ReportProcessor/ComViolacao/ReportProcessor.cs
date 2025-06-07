namespace ReportProcessor.ComViolacao
{

    // provavelmente no inicio do projeto so tinha PDF
    // depois foi adicionado CSV e XML
    internal class ReportProcessor
    {
        public void Process(string reportType) {
            if (reportType == "PDF")
            {
                Console.WriteLine("Processing PDF report...");
                // Logic to process PDF report
            } 
            else if (reportType == "CSV")
            {
                Console.WriteLine("Processing CSV report...");
                // Logic to process CSV report
            }
            else if (reportType == "XML")
            {
                Console.WriteLine("Processing XML report...");
                // Logic to process XML report
            }
            else
            {
                throw new NotSupportedException($"IReport type '{reportType}' is not supported.");
            }
        }
    }
}
