namespace MorpheusSoft.Azure.Blob.Service.Exceptions
{
    public class ContainerAlreadyExistException : Exception
    {
        public ContainerAlreadyExistException(string message, Exception? innerException = null) : base(message, innerException)
        {

        }
    }
    public class ContainerNotFoundException : Exception
    {
        public ContainerNotFoundException(string message, Exception? innerException = null) : base(message, innerException)
        {

        }
    }

    public class BlobDeleteException : Exception
    {
        public BlobDeleteException(string message, Exception? innerException = null) : base(message, innerException)
        {

        }
    }
    public class BlobUploadException : Exception
    {
        public BlobUploadException(string message, Exception? innerException = null) : base(message, innerException)
        {

        }
    }
    public class BlobNotFoundException : Exception
    {
        public BlobNotFoundException(string message, Exception? innerException = null) : base(message, innerException)
        {

        }
    }
}
