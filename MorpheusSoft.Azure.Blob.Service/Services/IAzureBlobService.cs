using MorpheusSoft.Azure.Blob.Service.Constants;
using MorpheusSoft.Azure.Blob.Service.Models;

namespace MorpheusSoft.Azure.Blob.Service.Services
{
    public interface IAzureBlobService
    {
        /// <summary>
        /// Create Blob Container Azure
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        Task CreateContainerAsync(string containerName, AccessType accessType = AccessType.BlobAndContainer);
        /// <summary>
        /// Delete Azure Blob Container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        Task DeleteContainerAsync(string containerName);
        /// <summary>
        /// Save a file without publicLink
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        Task SaveFileAsync(Stream file, string fileName, string containerName);
        /// <summary>
        /// Save file with Public Link
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <param name="containerName"></param>
        /// <param name="publicLink"></param>
        /// <returns></returns>
        Task SavePublicFileAsync(Stream file, string fileName, string containerName, out string publicLink);
        /// <summary>
        /// Get Blob as Stream
        /// </summary>
        /// <param name="blobName"></param>
        /// <param name="filePath"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        Task<AzureBlobResponseModel?> GetFileAsync(string blobName, string containerName);
        /// <summary>
        /// Delete Blob from Container
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        Task DeleteFileAsync(string fileName, string containerName);
    }
}
