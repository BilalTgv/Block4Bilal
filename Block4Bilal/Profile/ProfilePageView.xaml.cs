using System.Diagnostics;
namespace Block4Bilal.Profile;

public partial class ProfilePageView : ContentPage
{
    private readonly ProfileService _databaseService;
    public ProfilePageView()
    {
        InitializeComponent();
        _databaseService = new ProfileService();
    }


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var profiles = await _databaseService.GetAllProfilesAsync();

        profilesCollectionView.ItemsSource = profiles;
    }


    private async void OnDeleteProfileClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var profileToDelete = (Profile)button.BindingContext;

        var confirm = await DisplayAlert("Profil Löschen", "wollen sie es löschen?", "ja", "nein");

        if (confirm)
        {
            var result = await _databaseService.DeleteProfileAsync(profileToDelete);
            if (result > 0)
            {
                await DisplayAlert("Erfolg", "wurde entfernt :)", "OK");

                var profiles = await _databaseService.GetAllProfilesAsync();
                profilesCollectionView.ItemsSource = profiles;
            }
            else
            {
                await DisplayAlert("Error", "ein fehler ist aufgetreten", "OK");
            }
        }
    }

    // Funktion zum Editieren
    private async void OnEditProfileClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var profileToEdit = (Profile)button.BindingContext;

        await Navigation.PushAsync(new ProfilePageEdit(profileToEdit));
    }
}
