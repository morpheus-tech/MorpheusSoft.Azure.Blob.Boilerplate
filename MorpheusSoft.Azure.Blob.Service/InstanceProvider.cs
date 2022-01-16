using Microsoft.AspNetCore.Mvc;
using MorpheusSoft.Azure.Blob.Service.Constants;
using MorpheusSoft.Azure.Blob.Service.Models;
using MorpheusSoft.Azure.Blob.Service.Services;

namespace MorpheusSoft.Azure.Blob.Service
{
    public static class InstanceProvider
    {
        public static IAzureBlobConnectionService GetBlobConnection(string connectionString)
        {
            return new AzureBlobConnectionService(connectionString);
        }
        public static IAzureBlobService GetBlobClient(IAzureBlobConnectionService blobClient)
        {
            return new AzureBlobService(blobClient);
        }
        public static FileStreamResult FileResultProvider(this AzureBlobResponseModel azureBlobResponseModel)
        {
            return new FileStreamResult(azureBlobResponseModel.FileStream, AppConstants.MimeTypes[azureBlobResponseModel.FileType]);
        }
    }
}
