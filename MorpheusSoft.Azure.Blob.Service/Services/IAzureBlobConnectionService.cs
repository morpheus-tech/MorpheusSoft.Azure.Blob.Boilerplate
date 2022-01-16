using Azure.Storage.Blobs;

namespace MorpheusSoft.Azure.Blob.Service.Services
{
    public interface IAzureBlobConnectionService
    {
        bool CreateAutoContainer { get; set; }
        /// <summary>
        /// Get Blob Service Client
        /// </summary>
        /// <returns></returns>
        Task<BlobServiceClient> GetConnectionAsync();
        /// <summary>
        /// Get Azure Blob Service Client
        /// </summary>
        /// <returns></returns>
        BlobServiceClient GetConnection();
        /// <summary>
        /// Change Blob Client Connection
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        Task ChangeConnectionAsync(string connectionString);
    }
}
