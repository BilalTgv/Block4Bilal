using CommunityToolkit.Mvvm.ComponentModel;


namespace Block4Bilal.Menu
{
    [INotifyPropertyChanged]
    [QueryProperty("Dish", "Dish")]
    public partial class DishViewModel
    {
        [ObservableProperty]
        private Dish _dish;
    }
}
