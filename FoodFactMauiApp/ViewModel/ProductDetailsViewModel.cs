namespace FoodFactMauiApp.ViewModel;

[QueryProperty("Product", "Product")]
public partial class ProductDetailsViewModel :BaseViewModel
{
    [ObservableProperty]
    Product product;
}
