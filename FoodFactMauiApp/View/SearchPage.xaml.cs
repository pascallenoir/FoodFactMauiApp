namespace FoodFactMauiApp.View;

public partial class SearchPage : ContentPage
{
    ProductSearchViewModel viewModel;


    public SearchPage(ProductSearchViewModel productSearchViewModel)
	{
		InitializeComponent();
        this.viewModel = productSearchViewModel;
        BindingContext = productSearchViewModel;
	}

    private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        await viewModel.SearchProductsCommand.ExecuteAsync(searchBar.Text);

        searchBar.Text = string.Empty;
    }
}