using Newtonsoft.Json;

namespace BirdWatchingMaui.Models;

public class Bird
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("tripId")]
    public long TripId { get; set; }

    [JsonProperty("species")]
    public string Species { get; set; } = string.Empty;

    [JsonProperty("location")]
    public string Location { get; set; } = string.Empty;

    [JsonProperty("quantity")]
    public int Quantity { get; set; }

    [JsonProperty("comments")]
    public string? Comments { get; set; }

    [JsonProperty("imagePath")]
    public string? ImagePath { get; set; }

    [JsonProperty("latitude")]
    public double? Latitude { get; set; }

    [JsonProperty("longitude")]
    public double? Longitude { get; set; }

    [JsonProperty("spottedTime")]
    public string? SpottedTime { get; set; }

    [JsonProperty("uploaded")]
    public bool Uploaded { get; set; }
}

