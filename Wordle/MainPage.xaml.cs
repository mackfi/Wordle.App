using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;

namespace Wordle;

public partial class MainPage : ContentPage
{
	private bool isHome;
	private String wordleWord;
	private int guesses = 0;
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
			wordleWord = "hello";
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

    private void guessBox_Completed(object sender, EventArgs e)
    {
		if (guessBox.Text.Length != 5) 
		{
			//guessBox.Unfocus();
			return;
		}
		switch (guesses)
		{ 
			case 0:
				while (guess1.Count > 0) guess1.RemoveAt(0);
				for (int i = 0; i < 5; i++)
				{
					if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i))
					{
						guess1.Add(new Rectangle { 
                        Fill= Color.FromArgb("#56887d"),
                        WidthRequest =100,
                        HeightRequest=100,
                        RadiusX=30,
                        RadiusY=30,
                        });
					}
					else if (wordleWord.Contains(guessBox.Text.ElementAt(i)))
					{
                        guess1.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#b1cdc2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
					else
					{
                        guess1.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#e5e4e2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
				}

				break;

			case 1:
                while (guess2.Count > 0) guess2.RemoveAt(0);
                for (int i = 0; i < 5; i++)
                {
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i))
                    {
                        guess2.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#56887d"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                    else if (wordleWord.Contains(guessBox.Text.ElementAt(i)))
                    {
                        guess2.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#b1cdc2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                    else
                    {
                        guess2.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#e5e4e2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                }
                break;
            case 2:
                while (guess3.Count > 0) guess3.RemoveAt(0);
                for (int i = 0; i < 5; i++)
                {
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i))
                    {
                        guess3.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#56887d"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                    else if (wordleWord.Contains(guessBox.Text.ElementAt(i)))
                    {
                        guess3.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#b1cdc2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                    else
                    {
                        guess3.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#e5e4e2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                }
                break;
            case 3:
                while (guess4.Count > 0) guess4.RemoveAt(0);
                for (int i = 0; i < 5; i++)
                {
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i))
                    {
                        guess4.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#56887d"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                    else if (wordleWord.Contains(guessBox.Text.ElementAt(i)))
                    {
                        guess4.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#b1cdc2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                    else
                    {
                        guess4.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#e5e4e2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                }
                break;
			case 4:
                while (guess5.Count > 0) guess5.RemoveAt(0);
                for (int i = 0; i < 5; i++)
                {
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i))
                    {
                        guess5.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#56887d"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                    else if (wordleWord.Contains(guessBox.Text.ElementAt(i)))
                    {
                        guess5.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#b1cdc2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                    else
                    {
                        guess5.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#e5e4e2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                }
                break; 
        }



		guesses++;
    }
}

