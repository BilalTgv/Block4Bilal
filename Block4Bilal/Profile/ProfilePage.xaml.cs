using Microsoft.Maui;

namespace Block4Bilal.Profile;

public partial class ProfilePage : ContentPage
{
    private readonly ProfileService _databaseService;
    public ProfilePage()
    {
        InitializeComponent();
        _databaseService = new ProfileService();
    }
    private async void OnSaveProfileClicked(object sender, EventArgs e)
    {
        var profile = new Profile
        {
            FullName = fullnameEntry.Text,
            Street = streetEntry.Text,
            Zip = zipEntry.Text,
            City = cityEntry.Text,
            Phone = phoneEntry.Text
        };

        if (string.IsNullOrEmpty(profile.FullName)
            || string.IsNullOrEmpty(profile.Street)
            || string.IsNullOrEmpty(profile.Zip)
            || string.IsNullOrEmpty(profile.City)
            || string.IsNullOrEmpty(profile.Phone))
        {
            await DisplayAlert("Error", "Bitte alle felder ausfllen", "OK");
            return;
        }

        await _databaseService.SaveProfileAsync(profile);
        await DisplayAlert("Success", "Profil gespeichert!", "OK");
    }
}

