using Microsoft.Maui;

namespace Block4Bilal.Profile;

public partial class ProfilePageEdit : ContentPage
{
    private readonly ProfileService _databaseService;
    private readonly Profile _profileToEdit;
    public ProfilePageEdit(Profile profile)
    {
        InitializeComponent();
        _databaseService = new ProfileService();
        _profileToEdit = profile;

        BindingContext = _profileToEdit;
    }

    private async void OnSaveChangesClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(fullnameEntry.Text)
            || string.IsNullOrEmpty(streetEntry.Text)
            || string.IsNullOrEmpty(zipEntry.Text)
            || string.IsNullOrEmpty(cityEntry.Text)
            || string.IsNullOrEmpty(phoneEntry.Text))
        {
            await DisplayAlert("Error", "alle felder müssen gefüllt werden", "ok");
            return;
        }

        _profileToEdit.FullName = fullnameEntry.Text;
        _profileToEdit.Street = streetEntry.Text;
        _profileToEdit.Zip = zipEntry.Text;
        _profileToEdit.City = cityEntry.Text;
        _profileToEdit.Phone = phoneEntry.Text;

        var result = await _databaseService.SaveProfileAsync(_profileToEdit);
        if (result > 0)
        {
            await DisplayAlert("Erfolg", "Gespeichert", "ok");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "nicht geändert", "ok");
        }
    }
}
