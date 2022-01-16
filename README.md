# Manage Azure Blob (Container, Files) using MorpheusSoft.Azure.Blob.Boilerplate

## Setup AppSettings or it has seperate way to configure options at start up.

### Startup Definition (Method 1)
``AddMSBlobService(configuration); \\IConfiguration``
```
"AzureBlobSettings": {
    "AccessKey": "AccessKeyofAzureBlobStorage",
    "ConnectionString": "BlobConnectionString",
    "BlobDomain": "BlobPublicDomain",
    "CreateAutoContainer": true
  }
```

### Startup Definition (Method 2)
#### appSettingsToken will be appsettings.json key appsettings.json will be same as Method 1
``AddMSBlobService(appSettingsToken,configuration); \\IConfiguration``


### Startup Definition (Method 3)
``AddMSBlobService(action); \\Action<AzureBlobSettings>``

## All the service will be added in the scope at start up of the application. 
### All Definition of the library (Note All the methods will be executed as per name no extra thinking is not required here)
```CreateContainerAsync(string containerName, AccessType accessType = AccessType.BlobAndContainer);
DeleteContainerAsync(string containerName);
SaveFileAsync(Stream file, string fileName, string containerName);
SavePublicFileAsync(Stream file, string fileName, string containerName, out string publicLink);
GetFileAsync(string blobName, string containerName);
DeleteFileAsync(string fileName, string containerName);```
