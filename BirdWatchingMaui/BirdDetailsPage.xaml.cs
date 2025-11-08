using BirdWatchingMaui.Models;

namespace BirdWatchingMaui;

public partial class BirdDetailsPage : ContentPage
{
    public BirdDetailsPage(Bird bird)
    {
        InitializeComponent();
        BindingContext = bird;
    }
}

