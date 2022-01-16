using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MorpheusSoft.Azure.Blob.Service.Models;
using MorpheusSoft.Azure.Blob.Service.Services;

namespace MorpheusSoft.Azure.Blob.Service
{
    public static class ServiceStartup
    {
        public static void AddMSBlobService(this IServiceCollection service, IConfiguration configuration)
        {

            service.Configure<AzureBlobSettings>(op =>
            {
                op.ConnectionString = configuration.GetSection("AzureBlobSettings:ConnectionString").Value;
                op.AccessKey = configuration.GetSection("AzureBlobSettings:AccessKey").Value;
                op.BlobDomain = configuration.GetSection("AzureBlobSettings:BlobDomain").Value;
                op.CreateAutoContainer = Convert.ToBoolean(configuration.GetSection("AzureBlobSettings:CreateAutoContainer").Value);
            });
            service.AddScoped<IAzureBlobConnectionService, AzureBlobConnectionService>();
            service.AddScoped<IAzureBlobService, AzureBlobService>();
        }
        public static void AddMSBlobService(this IServiceCollection service, string appSettingsToken, IConfiguration configuration)
        {
            service.Configure<AzureBlobSettings>(op =>
            {
                op.ConnectionString = configuration.GetSection($"{appSettingsToken}:ConnectionString").Value;
                op.AccessKey = configuration.GetSection($"{appSettingsToken}:AccessKey").Value;
                op.BlobDomain = configuration.GetSection($"{appSettingsToken}:BlobDomain").Value;
                op.CreateAutoContainer = Convert.ToBoolean(configuration.GetSection($"{appSettingsToken}:CreateAutoContainer").Value);
            });
            service.AddOptions<AzureBlobSettings>(appSettingsToken);
            service.AddScoped<IAzureBlobConnectionService, AzureBlobConnectionService>();
            service.AddScoped<IAzureBlobService, AzureBlobService>();
        }

        public static void AddMSBlobService(this IServiceCollection service, Action<AzureBlobSettings> action)
        {
            service.Configure<AzureBlobSettings>(action);
            service.AddScoped<IAzureBlobConnectionService, AzureBlobConnectionService>();
            service.AddScoped<IAzureBlobService, AzureBlobService>();
        }
    }
}
