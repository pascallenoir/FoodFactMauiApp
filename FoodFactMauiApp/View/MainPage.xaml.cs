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

    protected override async void OnAppearing()
    {
        productsCollection.ItemsSource = viewModel.Products;

        if (viewModel.FirstRun && viewModel.GetRandomProductsCommand.CanExecute(null))
        {
            await viewModel.GetRandomProductsCommand.ExecuteAsync(null);
            viewModel.FirstRun = false;
        }

        base.OnAppearing();
        
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs e)
    {
        if (!string.IsNullOrEmpty(viewModel.SearchTerm))
        {
            await viewModel.SearchProductCommand.ExecuteAsync(null);
        }


        if (Parent is ShellSection && ((ShellSection)Parent).Route == nameof(SearchPage))
        {
            viewModel.Title = viewModel.SearchedTitle;
            productsCollection.ItemsSource = viewModel.SearchedProdutcs;
        }
        else
        {
            viewModel.Title = "Produits";
            productsCollection.ItemsSource = viewModel.Products;
        }
        base.OnNavigatedTo(e);

    }
}
