namespace FoodFactMauiApp.ViewModel;

public partial class ProductViewModel : BaseViewModel
{
    ProductServices productServices;

    public ObservableCollection<Product> Products { get; set; } = new();

    public bool FirstRun { get; set; } = true;

    [ObservableProperty]
    bool isRefreshing;

    public ProductViewModel(ProductServices productServices)
    {
        Title = "Produits";
        this.productServices = productServices;
    }


    [RelayCommand]
    async Task GetRandomProductsAsync()
    {
        if (IsBusy) 
            return;

        try
        {
            IsBusy = true;

            var products = await productServices.GetRandomProductsAsync();

            Products.Clear();
            foreach (var item in products)
            {
                Products.Add(item);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            await Shell.Current.DisplayAlert("Erreur", "Impossible de recuperer la liste des produits", "Ok");

        }
        finally 
        {
            IsBusy = false;
            IsRefreshing = false;
        }

    }

    [RelayCommand]
    async Task GoToDetailsAsync(Product product)
    {
        if (product is null)
            return;

        await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
        {
            { "Product", product }
        });
    }

    public async void OnAppearing()
    {
       if (FirstRun && GetRandomProductsCommand.CanExecute(null)) 
        {
            await GetRandomProductsCommand.ExecuteAsync(null);
            FirstRun = false;
        }
    }
}
