using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using MorpheusSoft.Azure.Blob.Service.Models;
namespace MorpheusSoft.Azure.Blob.Service.Services
{
    public class AzureBlobConnectionService : IAzureBlobConnectionService
    {
        private BlobServiceClient _blobServiceClient;
        public bool CreateAutoContainer { get; set; }
        public AzureBlobConnectionService(IOptions<AzureBlobSettings> options)
        {
            _blobServiceClient = new BlobServiceClient(options.Value.ConnectionString);
            CreateAutoContainer = options.Value.CreateAutoContainer;
        }
        public AzureBlobConnectionService(string connectionString)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public Task ChangeConnectionAsync(string connectionString)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
            return Task.CompletedTask;
        }

        public BlobServiceClient GetConnection()
        {
            return _blobServiceClient;
        }

        public Task<BlobServiceClient> GetConnectionAsync()
        {
            return Task.FromResult(_blobServiceClient);
        }
    }
}
