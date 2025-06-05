namespace FileUploadService.SemViolacao
{
    class FileUploadService
    {
        private readonly FileCompressor _fileCompressor;
        private readonly ClouUploader _clouUploader;
        public FileUploadService(FileCompressor fileCompressor, ClouUploader clouUploader)
        {
            _fileCompressor = fileCompressor;
            _clouUploader = clouUploader;
        }
        public void UploadFile(Stream fileStream, string destination)
        {
            // Comprime o arquivo
            var compressedFile = _fileCompressor.CompressFile(fileStream);
            // Envia o arquivo comprimido
            _clouUploader.UploadFile(compressedFile, destination);
        }
    }

    class FileCompressor
    {
        public Stream CompressFile(Stream fileStream)
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

    class ClouUploader
    {
        public void UploadFile(Stream fileStream, string destination)
        {
            // Envio do arquivo
            Console.WriteLine($"Enviando arquivo para {destination}");
        }
    }
}
