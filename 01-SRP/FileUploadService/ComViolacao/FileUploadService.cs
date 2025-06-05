using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadService.ComViolacao
{
    internal class FileUploadService
    {
        public void UploadFile(Stream fileStream, string destination)
        {
            // Compressão do arquivo
            var compressedFile = CompressFile(fileStream);

            // Envio do arquivo
            Console.WriteLine($"Enviando arquivo para {destination}");
        }

        private object CompressFile(Stream fileStream)
        {
            Console.WriteLine("Comprimindo arquivo ...");

            // Garante que estamos no início do stream
            fileStream.Position = 0;

            // Calcula metade do tamanho original
            long halfLength = fileStream.Length / 2;

            // Copia apenas os primeiros bytes (simulação de compressão)
            byte[] buffer = new byte[halfLength];
            fileStream.Read(buffer, 0, (int)halfLength);

            // Retorna um novo stream com o conteúdo "comprimido"
            return new MemoryStream(buffer);
        }
    }
}