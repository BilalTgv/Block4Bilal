namespace Block4Bilal.Menu;

public partial class DishPage : ContentPage
{
    public DishPage(DishViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}