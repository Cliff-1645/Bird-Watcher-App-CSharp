using BirdWatchingMaui.Models;

namespace BirdWatchingMaui;

public partial class MainPage : ContentPage
{
    private readonly BirdSightingsViewModel _viewModel;

    public MainPage(BirdSightingsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadDataCommand.ExecuteAsync(null);
    }

    private void OnBirdSelected(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Bird bird)
        {
            Navigation.PushAsync(new BirdDetailsPage(bird));
            ((CollectionView)sender!).SelectedItem = null;
        }
    }

    private void OnBirdTapped(object? sender, EventArgs e)
    {
        if (sender is BindableObject bindable && bindable.BindingContext is Bird bird)
        {
            Navigation.PushAsync(new BirdDetailsPage(bird));
        }
    }
}

