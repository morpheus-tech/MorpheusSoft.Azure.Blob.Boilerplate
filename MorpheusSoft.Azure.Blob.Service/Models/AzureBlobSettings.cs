namespace MorpheusSoft.Azure.Blob.Service.Models
{
    public class AzureBlobSettings
    {
        public string AccessKey { get; set; }
        public string ConnectionString { get; set; }
        public string BlobDomain { get; set; }
        public bool CreateAutoContainer { get; set; }
    }
}
