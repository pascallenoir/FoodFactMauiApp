namespace FoodFactMauiApp.View;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(ProductDetailsViewModel productDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = productDetailsViewModel;
	}
}