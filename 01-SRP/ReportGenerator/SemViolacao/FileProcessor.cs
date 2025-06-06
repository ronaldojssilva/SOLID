using System.Text.Json;

namespace ReportGenerator.SemViolacao;

// Dica : Sempre tentar identificar o que está entrando e o que está entrando na "aplicação" (Metodo, classe, ...)
// nesse caso, o que entra é o arquivo para fazer a leitura.
// na saida estamos pegando um outro formato para retornar.
// A idéia é que o que estou trazendo de dados eu posso mudar esse formato?
//  O que eu estou trazendo de dados eu posso mudar? (CSV, XML, JSON, ...)
// E o que eu estou develvendo de dados eu posso mudar?
//  o que estou desenvolvendo de dados é o relatório, que pode ser em JSON, XML, HTML, etc.


class ReportService
{
    private readonly CSVFileReader _csvFileReader; //lembrando que aqui devem ser interfaces
    private readonly JSONExporter _jsonExporter;   //lembrando que aqui devem ser interfaces
    public ReportService(CSVFileReader csvFileReader, JSONExporter jsonExporter)
    {
        _csvFileReader = csvFileReader;
        _jsonExporter = jsonExporter;
    }
    public string GenerateReport(string file)
    {
        // Ler arquivo CSV
        var data = _csvFileReader.Read(file);

        // Exportar relatório em JSON
        return _jsonExporter.Export(data);
    }
}

class CSVFileReader
{
    public List<object> Read(string file)
    {
        Console.WriteLine($"Lendo arquivo CS: {file}");
        // Dados simulados
        return new List<object>
        {
            new { name = "Alice", value = 100 }
        };
    }
}

class JSONExporter
{
    public string Export(List<object> data)
    {
        // Serializar para JSON
        string jsonReport = JsonSerializer.Serialize(data);
        Console.WriteLine($"Exportando relatório em: {jsonReport}");
        return jsonReport;
    }
}