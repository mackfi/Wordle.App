namespace Wordle;

public partial class MainPage : ContentPage
{
	private bool isHome;
	public MainPage()
	{
		InitializeComponent();
	}

	private void OnStartClicked(object sender, EventArgs e)
	{
		if (isHome)
		{
            Home.IsEnabled = false;
            Home.IsVisible = false;
            Game.IsEnabled = true;
            Game.IsVisible = true;
			isHome = false;
			NavButton.Text = "Home";
        }
		else
		{
			Home.IsEnabled = true;
			Home.IsVisible = true;
            Game.IsEnabled = false;
            Game.IsVisible = false;
			isHome = true;
			NavButton.Text = "Wordle";
        }
		
	}
}

