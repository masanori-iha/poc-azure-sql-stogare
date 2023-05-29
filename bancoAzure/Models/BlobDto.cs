using Azure.Storage.Blobs;

namespace bancoAzure.Models
{
    public class BlobDto
    {
        public string? Uri  { get; set; }
        public string Name { get; set; }
        public  string? ContentType { get; set; }
        public Stream? Content { get; set; }
    }

    public class BlobResponseDto
    {
        public BlobResponseDto()
        {
            Blob = new BlobDto();
        }

        public string? Status { get; set; }
        public bool Error { get; set; }

        public BlobDto Blob { get; set; }
    }

    public class FileService
    {
        private IConfiguration _configuration;
        private readonly string _container = "dados";
        private readonly BlobContainerClient _fileContainer;
        private readonly string _key = "";
        private readonly string _baseUri = "";

        public FileService(IConfiguration configuration)
        {
            var blobServiceClient = new BlobServiceClient(new Uri($"{_baseUri}{_key}"));

            _fileContainer = blobServiceClient.GetBlobContainerClient(_container);
            _configuration = configuration;
            _key = _configuration.GetSection("keyAzure").Value ?? "";
            _baseUri =$"https://{_configuration.GetSection("azureStorage").Value ?? ""}.blob.core.windows.net/";
        }

        public async Task<BlobResponseDto> UploadAsync(IFormFile blob)
        {
            BlobResponseDto response = new();
            BlobClient client = _fileContainer.GetBlobClient(blob.FileName);

            await using(Stream? data = blob.OpenReadStream())
            {
                var resultado = await client.UploadAsync(data);
            }

            response.Status = $"File {blob.FileName} Uploaded successfully";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.Name = client.Name;

            return response;
        }

        public async Task<IEnumerable<BlobDto>> List()
        {
            List<BlobDto> files = new();
            
            await foreach (var blob in _fileContainer.GetBlobsAsync())
            {
                var name = blob.Name;
                var fullUri = $"{_baseUri}{_container}/{name}{_key}";

                files.Add(new BlobDto
                {
                    Uri = fullUri,
                    Name = name,
                    ContentType = blob.Properties.ContentType
                });
            }

            return files;
        }

        public async Task<BlobResponseDto> Excluir(string filename)
        {
            var file = _fileContainer.GetBlobClient(filename);

            await file.DeleteAsync();

            return new BlobResponseDto
            {
                Error = false,
                Status = $"Arquivo: {filename} excluído com sucesso"
            };
        }
    }
}
