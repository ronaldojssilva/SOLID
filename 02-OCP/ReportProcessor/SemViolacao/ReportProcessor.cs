using System.Diagnostics;

namespace ReportProcessor.SemViolacao
{
    interface IReport { 
        void Process();
    }

    class PDFReport : IReport
    {
        public void Process()
        {
            Console.WriteLine("Processing PDF report...");
            // Logic to process PDF report
        }
    }

    class CSVReport : IReport
    {
        public void Process()
        {
            Console.WriteLine("Processing CSV report...");
            // Logic to process CSV report
        }
    }


    /// <summary>
    /// Essa classe esta fecha para modificações, ou seja, eu não preciso alterar ela para adicionar novos tipos de relatórios
    /// Importante: Quando digo que ela esta fechada para modificações, significa que não preciso alterar o código dela para adicionar novos tipos de relatórios.
    ///             Eu posso modicar-la com outra intenção, como por exemplo, adicionar logs, mas não para adicionar novos tipos de relatórios.
    /// </summary>
    internal class ReportProcessor
    { 
        public void Process(IReport report)
        {
            if (report == null)
            {
                throw new ArgumentNullException(nameof(report), "IReport cannot be null.");
            }
            report.Process();
        }
    }
}
