using Block4Bilal.Menu;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Block4Bilal;

[INotifyPropertyChanged]
public partial class MainPageViewModel
{
    private readonly IMenuService _menuService;

    public ObservableCollection<Category> Categories { get; } = new ObservableCollection<Category>();

    public MainPageViewModel(IMenuService menuService)
    {
        _menuService = menuService;
    }

    public async Task InitializeAsync()
    {
        Categories.Clear();
        var categories = await _menuService.GetCategoriesAsync();

        foreach (var category in categories)
        {
            Categories.Add(category);
        }
    }

    [RelayCommand]
    private async Task NavigateToCategory(Category category)
    {
        var navigationParameter = new Dictionary<string, object>
        {
            { "Category", category}
        };
        await Shell.Current.GoToAsync(nameof(CategoriesPage), navigationParameter);
    }
}
