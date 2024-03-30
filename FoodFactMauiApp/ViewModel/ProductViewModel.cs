using Microsoft.Maui.Graphics;

namespace FoodFactMauiApp.ViewModel;

[QueryProperty("SearchTerm", "SearchTerm")]
public partial class ProductViewModel : BaseViewModel
{
    ProductServices productServices;

    public ObservableCollection<Product> Products { get; } = new();

    public ObservableCollection<Product> SearchedProdutcs { get; } = new();

    public bool FirstRun { get; set; } = true;

    [ObservableProperty]
    bool isRefreshing;

    [ObservableProperty]
    string searchTerm;

    [ObservableProperty]
    string searchedTitle;


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

    [RelayCommand]
    async Task SearchProductAsync()
    {
        if (IsBusy) 
            return;

        try
        {
            IsBusy = true;

            SearchedTitle = SearchTerm;
            Title = SearchedTitle;

            SearchedProdutcs.Clear();

            var prodducts = await productServices.SearchProductAsync(SearchTerm);
            foreach (var itemProduct in prodducts)
            {
                SearchedProdutcs.Add(itemProduct);
            }
                
            SearchTerm = null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            await Shell.Current.DisplayAlert("Erreur", "Impossible de fair une recherche de produit", "Ok");
        }
        finally
        {
            IsBusy = false;
        } 

    }

}
