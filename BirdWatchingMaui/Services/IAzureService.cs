using BirdWatchingMaui.Models;

namespace BirdWatchingMaui.Services;

public interface IAzureService
{
    Task<List<Trip>> GetTripsAsync();
    Task<List<Bird>> GetBirdsAsync(string? species = null);
    Task<List<Bird>> SearchBirdsAsync(string query);
}

