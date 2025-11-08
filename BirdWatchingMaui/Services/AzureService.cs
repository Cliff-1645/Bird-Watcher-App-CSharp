using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BirdWatchingMaui.Models;
using Newtonsoft.Json;

namespace BirdWatchingMaui.Services;

public class AzureService : IAzureService
{
    // TODO: Replace with your Azure Storage Account connection string
    private const string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=YOUR_ACCOUNT_NAME;AccountKey=YOUR_ACCOUNT_KEY;EndpointSuffix=core.windows.net";
    private const string ContainerName = "bird-watching-data";
    private readonly BlobServiceClient _blobServiceClient;
    private readonly BlobContainerClient _containerClient;

    public AzureService()
    {
        _blobServiceClient = new BlobServiceClient(ConnectionString);
        _containerClient = _blobServiceClient.GetBlobContainerClient(ContainerName);
    }

    public async Task<List<Trip>> GetTripsAsync()
    {
        try
        {
            var trips = new List<Trip>();
            await foreach (BlobItem blobItem in _containerClient.GetBlobsAsync(prefix: "trips/"))
            {
                if (blobItem.Name.EndsWith(".json"))
                {
                    var blobClient = _containerClient.GetBlobClient(blobItem.Name);
                    var response = await blobClient.DownloadContentAsync();
                    var json = response.Value.Content.ToString();
                    var trip = JsonConvert.DeserializeObject<Trip>(json);
                    if (trip != null)
                    {
                        trips.Add(trip);
                    }
                }
            }
            return trips.OrderByDescending(t => t.Date).ToList();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error fetching trips: {ex.Message}");
            return new List<Trip>();
        }
    }

    public async Task<List<Bird>> GetBirdsAsync(string? species = null)
    {
        try
        {
            var birds = new List<Bird>();
            await foreach (BlobItem blobItem in _containerClient.GetBlobsAsync(prefix: "birds/"))
            {
                if (blobItem.Name.EndsWith(".json"))
                {
                    var blobClient = _containerClient.GetBlobClient(blobItem.Name);
                    var response = await blobClient.DownloadContentAsync();
                    var json = response.Value.Content.ToString();
                    var bird = JsonConvert.DeserializeObject<Bird>(json);
                    if (bird != null)
                    {
                        if (string.IsNullOrEmpty(species) || 
                            bird.Species.Contains(species, StringComparison.OrdinalIgnoreCase))
                        {
                            birds.Add(bird);
                        }
                    }
                }
            }
            return birds.OrderByDescending(b => b.Id).ToList();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error fetching birds: {ex.Message}");
            return new List<Bird>();
        }
    }

    public async Task<List<Bird>> SearchBirdsAsync(string query)
    {
        try
        {
            var allBirds = await GetBirdsAsync();
            return allBirds.Where(b =>
                b.Species.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                b.Location.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                (b.Comments != null && b.Comments.Contains(query, StringComparison.OrdinalIgnoreCase))
            ).ToList();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error searching birds: {ex.Message}");
            return new List<Bird>();
        }
    }
}

