namespace FoodFactMauiApp.View;

public partial class MainPage : ContentPage
{
    ProductViewModel viewModel;

    public MainPage(ProductViewModel viewModel)
    {
        InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        //productsCollection.ItemsSource = viewModel.Products;    
        base.OnAppearing();
        viewModel.OnAppearing();
    }
}
