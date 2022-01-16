using Azure.Storage.Blobs;
using MorpheusSoft.Azure.Blob.Service.Constants;
using MorpheusSoft.Azure.Blob.Service.Exceptions;
using MorpheusSoft.Azure.Blob.Service.Models;
namespace MorpheusSoft.Azure.Blob.Service.Services
{
    public class AzureBlobService : IAzureBlobService
    {
        private BlobServiceClient _serviceClient;
        public bool CreateAutoContainer { get; set; }
        public AzureBlobService(IAzureBlobConnectionService azureBlobConnectionService)
        {
            _serviceClient = azureBlobConnectionService.GetConnection();
            CreateAutoContainer = azureBlobConnectionService.CreateAutoContainer;
        }
        public Task CreateContainerAsync(string containerName, AccessType accessType)
        {
            var container = _serviceClient.GetBlobContainerClient(containerName);
            if (container == null)
            {
                throw new ContainerAlreadyExistException(
                    MSCoreService
                    .PrepareExceptionMessage(AppConstants.CONTAINER_ALREADY_EXIST_ERROR_MESSAGE, containerName)
                    );
            }
            _serviceClient.CreateBlobContainer(containerName, MSCoreService.AccessTypeConversion(accessType));
            return Task.CompletedTask;
        }

        public Task DeleteContainerAsync(string containerName)
        {
            var container = _serviceClient.GetBlobContainerClient(containerName);
            if (container == null)
            {
                throw new ContainerNotFoundException(
                    MSCoreService
                    .PrepareExceptionMessage(AppConstants.CONTAINER_ALREADY_EXIST_ERROR_MESSAGE, containerName)
                    );
            }
            _serviceClient.DeleteBlobContainer(containerName);
            return Task.CompletedTask;
        }

        public Task DeleteFileAsync(string fileName, string containerName)
        {
            try
            {
                var container = _serviceClient.GetBlobContainerClient(containerName);
                if (container == null)
                {
                    throw new ContainerNotFoundException(
                        MSCoreService
                        .PrepareExceptionMessage(AppConstants.CONTAINER_ALREADY_EXIST_ERROR_MESSAGE, containerName)
                        );
                }
                container.GetBlobClient(fileName).Delete();
            }
            catch (Exception ex)
            {
                throw new BlobDeleteException("Blob Delete Failed " + fileName, ex);
            }
            return Task.CompletedTask;
        }

        public Task DeleteFileAsync(string fileName, string containerName, out string publicLink)
        {
            throw new NotImplementedException();
        }

        public async Task<AzureBlobResponseModel?> GetFileAsync(string blobName, string containerName)
        {
            var file = await _serviceClient.GetBlobContainerClient(containerName).GetBlobClient(blobName).DownloadContentAsync();
            if (file == null)
            {
                throw new BlobNotFoundException($"Can not find any file or container with name container: {containerName},fileName: {blobName}");
            }
            return new AzureBlobResponseModel()
            {
                FileName = blobName,
                FileType = MSCoreService.GetMimeType(blobName),
                FileStream = file.Value.Content.ToStream(),
            };
        }

        public Task SaveFileAsync(Stream file, string fileName, string containerName)
        {
            try
            {

                var container = _serviceClient.GetBlobContainerClient(containerName);
                if (container == null)
                {
                    if (CreateAutoContainer)
                    {
                        CreateContainerAsync(containerName, AccessType.BlobAndContainer);
                        container = _serviceClient.GetBlobContainerClient(containerName);
                    }
                    else
                    {
                        throw new ContainerNotFoundException($"Container not found {containerName}");
                    }
                }
                container.GetBlobClient(fileName).Upload(file);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new BlobUploadException("Blob upload failed " + fileName, ex);
            }

        }
        public Task SavePublicFileAsync(Stream file, string fileName, string containerName, out string publicLink)
        {
            try
            {
                var container = _serviceClient.GetBlobContainerClient(containerName);
                if (container == null)
                {
                    if (CreateAutoContainer)
                    {
                        CreateContainerAsync(containerName, AccessType.BlobAndContainer);
                        container = _serviceClient.GetBlobContainerClient(containerName);
                    }
                    else
                    {
                        throw new ContainerNotFoundException($"Container not found {containerName}");
                    }
                }
                    
                var result = container.GetBlobClient(fileName).Upload(file);
                publicLink = container.GetBlobClient(fileName).Uri.AbsoluteUri;
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new BlobUploadException("Blob upload failed " + fileName, ex);
            }

        }
    }
}
