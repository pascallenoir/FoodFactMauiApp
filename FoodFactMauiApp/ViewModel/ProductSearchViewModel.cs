namespace FoodFactMauiApp.ViewModel;

public partial class ProductSearchViewModel: BaseViewModel
{
    public ObservableCollection<string> SearchTermsHistory { get; } = new();

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(isSearchTermsHistoryNotEmpty))]
    bool isSearchTermsHistoryEmpty = true; 

    public bool isSearchTermsHistoryNotEmpty => !isSearchTermsHistoryEmpty;


    public ProductSearchViewModel() 
    {
        Title = "Rechercher";
    }


    [RelayCommand]
    async Task SearchProductsAsync(string searchTerm)
    {
        SearchTermsHistory.Add(searchTerm);

        if (SearchTermsHistory.Count > 0) 
        {
            IsSearchTermsHistoryEmpty = false;
        }

        await Shell.Current.GoToAsync(nameof(MainPage), true, new Dictionary<string, object>
        {
            { "SearchTerm", searchTerm }
        });
    }


    [RelayCommand]
    void ClearSearchTermsHistory()
    {
        SearchTermsHistory.Clear();

        IsSearchTermsHistoryEmpty = true;
    }

}
