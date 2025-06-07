// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


var processorComViolacao = new ReportProcessor.ComViolacao.ReportProcessor();
processorComViolacao.Process("PDF");
processorComViolacao.Process("CSV");


var processorSemViolacao = new ReportProcessor.SemViolacao.ReportProcessor();
processorSemViolacao.Process(new ReportProcessor.SemViolacao.PDFReport());
processorSemViolacao.Process(new ReportProcessor.SemViolacao.CSVReport());