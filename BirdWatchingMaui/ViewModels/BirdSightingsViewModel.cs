using BirdWatchingMaui.Models;
using BirdWatchingMaui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BirdWatchingMaui;

public partial class BirdSightingsViewModel : ObservableObject
{
    private readonly IAzureService _azureService;

    [ObservableProperty]
    private List<Bird> birds = new();

    [ObservableProperty]
    private List<Trip> trips = new();

    [ObservableProperty]
    private bool isLoading;

    [ObservableProperty]
    private string searchQuery = string.Empty;

    public BirdSightingsViewModel(IAzureService azureService)
    {
        _azureService = azureService;
    }

    [RelayCommand]
    public async Task LoadDataAsync()
    {
        IsLoading = true;
        try
        {
            Trips = await _azureService.GetTripsAsync();
            Birds = await _azureService.GetBirdsAsync();
        }
        finally
        {
            IsLoading = false;
        }
    }

    [RelayCommand]
    public async Task SearchBirdsAsync()
    {
        if (string.IsNullOrWhiteSpace(SearchQuery))
        {
            await LoadDataAsync();
            return;
        }

        IsLoading = true;
        try
        {
            Birds = await _azureService.SearchBirdsAsync(SearchQuery);
        }
        finally
        {
            IsLoading = false;
        }
    }
}

