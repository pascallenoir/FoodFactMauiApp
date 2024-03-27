namespace FoodFactMauiApp.View;

public partial class DetailsPage : ContentPage
{
	ProductDetailsViewModel viewModel;
	public DetailsPage(ProductDetailsViewModel productDetailsViewModel)
	{
		InitializeComponent();
		this.viewModel = productDetailsViewModel;
		BindingContext = viewModel;
	}
}