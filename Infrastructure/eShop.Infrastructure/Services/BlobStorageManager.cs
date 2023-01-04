namespace eShop.Infrastructure.Services;

public class BlobStorageManager : IStorageManager
{
    private readonly BlobStorageOptions _options;


    public BlobStorageManager(IOptions<BlobStorageOptions> options)
    {
        _options = options.Value;
    }


    public string GetSignedUrl(string filename)
    {
        var serviceClient = new BlobServiceClient(_options.ConnectionString);
        var containerClient = serviceClient.GetBlobContainerClient(_options.ContainerName);
        var blobClient = containerClient.GetBlobClient(filename);

        return blobClient.Uri.AbsoluteUri;
    }
    public async Task<string> GetSignedUrlAsync(string filename)
        => await Task.Factory.StartNew(() => GetSignedUrl(filename));

    public string UploadFile(IFormFile file, string filename)
    {
        ArgumentNullException.ThrowIfNull(file);

        var containerClient = new BlobContainerClient(_options.ConnectionString, _options.ContainerName);
        var blobClient = containerClient.GetBlobClient(filename);

        var header = new BlobHttpHeaders()
        {
            ContentType = file.ContentType
        };

        blobClient.Upload(file.OpenReadStream(), header);

        return blobClient.Uri.AbsoluteUri;
    }
    public async Task<string> UploadFileAsync(IFormFile file, string filename)
        => await Task.Factory.StartNew(() => UploadFile(file, filename));

    public bool DeleteFile(string filename)
    {
        var containerClient = new BlobContainerClient(_options.ConnectionString, _options.ContainerName);

        var response = containerClient.DeleteBlob(filename);

        return !response.IsError; 
    }
    public async Task<bool> DeleteFileAsync(string filename)
        => await Task.Factory.StartNew(() => DeleteFile(filename));
}
