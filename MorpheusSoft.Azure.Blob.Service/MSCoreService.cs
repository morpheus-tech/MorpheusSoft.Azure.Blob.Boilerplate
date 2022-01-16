using Azure.Storage.Blobs.Models;
using MorpheusSoft.Azure.Blob.Service.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorpheusSoft.Azure.Blob.Service
{
    internal sealed class MSCoreService
    {
        public static string PrepareExceptionMessage(string msg,params string[] message)
        {
            return string.Format(msg, message);
        }
        public static PublicAccessType AccessTypeConversion(AccessType accessType)
        {
            switch (accessType)
            {
                case AccessType.None:
                    return PublicAccessType.None;
                case AccessType.BlobAndContainer:
                    return PublicAccessType.BlobContainer;
                case AccessType.OnlyBlob:
                    return PublicAccessType.Blob;
                default:
                    return PublicAccessType.BlobContainer;
            }
        }
        public static string GetMimeType(string extension)
        {
            if (extension == null)
            {
                throw new ArgumentNullException("extension can not be null");
            }

            if (!extension.StartsWith("."))
            {
                extension = "." + extension;
            }

            string mime;

            return AppConstants.MimeTypes.TryGetValue(extension, value: out mime) ? mime : "application/octet-stream";
        }
    }
}
