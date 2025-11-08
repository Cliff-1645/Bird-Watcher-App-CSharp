using Newtonsoft.Json;

namespace BirdWatchingMaui.Models;

public class Trip
{
    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("tripName")]
    public string TripName { get; set; } = string.Empty;

    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("time")]
    public string Time { get; set; } = string.Empty;

    [JsonProperty("location")]
    public string Location { get; set; } = string.Empty;

    [JsonProperty("duration")]
    public string Duration { get; set; } = string.Empty;

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("weather")]
    public string? Weather { get; set; }

    [JsonProperty("temperature")]
    public string? Temperature { get; set; }

    [JsonProperty("companionCount")]
    public int CompanionCount { get; set; }

    [JsonProperty("imagePath")]
    public string? ImagePath { get; set; }

    [JsonProperty("latitude")]
    public double? Latitude { get; set; }

    [JsonProperty("longitude")]
    public double? Longitude { get; set; }

    [JsonProperty("uploaded")]
    public bool Uploaded { get; set; }

    [JsonProperty("uploadDate")]
    public DateTime? UploadDate { get; set; }
}

