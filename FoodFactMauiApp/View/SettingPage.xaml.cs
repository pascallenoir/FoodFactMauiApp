namespace FoodFactMauiApp.View;

public partial class SettingPage : ContentPage
{
	public SettingPage(SettingsViewModel settingsViewModel)
	{
		InitializeComponent();
		BindingContext = settingsViewModel;
	}

    protected override void OnAppearing()
    {
        var nutriScore = Settings.NutriScore;

        var radioButtons = nutriScoreStackLayout.Children.Where(x => x is RadioButton);
        foreach (RadioButton radioButton in radioButtons)
        {
            if (radioButton.Value.ToString() == nutriScore)
            {
                radioButton.IsChecked = true;
                break;
            }
        }

        base.OnAppearing();
    }


    private void OnNutriScoreCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
       var nutriscore = ((RadioButton)sender).Value.ToString();

        Settings.NutriScore = nutriscore;

    }
}