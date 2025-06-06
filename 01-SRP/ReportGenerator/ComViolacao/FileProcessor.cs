using System.Text.Json;

namespace ReportGenerator.ComViolacao;

public class FileProcessor
{
    public void ProcessFile(string file)
    {
        Console.WriteLine($"Lendo arquivo CS: {file}");

        // Dados simulados
        var data = new List<object>
        {
            new { name = "Alice", value = 100 }
        };

        // Serializar para JSON
        string jsonReport = JsonSerializer.Serialize(data);

        Console.WriteLine($"Exportando relatório em: {jsonReport}");
    }
}