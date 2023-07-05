using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using System;
using System.Text;

namespace Wordle;

public partial class MainPage : ContentPage
{
	private bool isHome;
	private String wordleWord;
    private List<String> wordleData = new List<String>();
    Random rand = new Random();
    private String wordCheck;
	private int guesses = 0;
	public MainPage()
	{
		InitializeComponent();

        string filePath =
        @"C:\Users\mackf\Downloads\archive (1)\5_letters.csv";
        StreamReader reader = null;
        if (File.Exists(filePath))
        {
            reader = new StreamReader(File.OpenRead(filePath));
            List<string> listA = new List<string>();
            StringBuilder sb = new StringBuilder();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                foreach (var item in values)
                {
                    sb.Append(item);
                }
                wordleData.Add(sb.ToString());
                sb = new StringBuilder();
            }
        }
        else
        {
            Console.WriteLine("File doesn't exist");
        }
        //Console.ReadLine();
        reader.Close();
        wordleWord = wordleData.ElementAt(rand.Next(0, wordleData.Count() - 1));
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

    private void guessBox_Completed(object sender, EventArgs e)
    {
		if (guessBox.Text.Length != 5) 
		{
			//guessBox.Unfocus();
			return;
		}
        wordCheck = wordleWord;

        guessBox.Text = guessBox.Text.ToLower();

        switch (guesses)
		{ 
			case 0:
				while (guess1.Count > 0) guess1.RemoveAt(0);

                for (int i = 0; i < 5; i++)
                {
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i))
                    {
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess1.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#56887d"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                }

                for (int i = 0; i < 5; i++)
				{
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i)) { continue; }
					if (wordCheck.Contains(guessBox.Text.ElementAt(i)))
					{
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess1.Insert(i, new Rectangle
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
                        guess1.Insert(i, new Rectangle
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
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess2.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#56887d"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i)) { continue; }
                    if (wordCheck.Contains(guessBox.Text.ElementAt(i)))
                    {
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess2.Insert(i, new Rectangle
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
                        guess2.Insert(i, new Rectangle
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
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess3.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#56887d"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i)) { continue; }
                    if (wordCheck.Contains(guessBox.Text.ElementAt(i)))
                    {
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess3.Insert(i, new Rectangle
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
                        guess3.Insert(i, new Rectangle
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
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess4.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#56887d"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i)) { continue; }
                    if (wordCheck.Contains(guessBox.Text.ElementAt(i)))
                    {
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess4.Insert(i, new Rectangle
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
                        guess4.Insert(i, new Rectangle
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
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess5.Add(new Rectangle
                        {
                            Fill = Color.FromArgb("#56887d"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            RadiusX = 30,
                            RadiusY = 30,
                        });
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i)) { continue; }
                    if (wordCheck.Contains(guessBox.Text.ElementAt(i)))
                    {
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess5.Insert(i, new Rectangle
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
                        guess5.Insert(i, new Rectangle
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

    private void WordleReset_Clicked(object sender, EventArgs e)
    {
        guesses = 0;
        wordleWord = wordleData.ElementAt(rand.Next(0, wordleData.Count() - 1));

        while (guess1.Count > 0) guess1.RemoveAt(0);
        while (guess2.Count > 0) guess2.RemoveAt(0);
        while (guess3.Count > 0) guess3.RemoveAt(0);
        while (guess4.Count > 0) guess4.RemoveAt(0);
        while (guess5.Count > 0) guess5.RemoveAt(0);
        for (int i = 0; i < 5; i++)
        {
            guess1.Add( new Rectangle {
                        Fill = Color.FromArgb("#e5e4e2"),
                        Stroke = Colors.Gray,
                        StrokeThickness = 2,
                        WidthRequest = 100,
                        HeightRequest = 100,
                        RadiusX = 30,
                        RadiusY = 30
            });
            guess2.Add(new Rectangle
            {
                Fill = Color.FromArgb("#e5e4e2"),
                Stroke = Colors.Gray,
                StrokeThickness = 2,
                WidthRequest = 100,
                HeightRequest = 100,
                RadiusX = 30,
                RadiusY = 30
            });
            guess3.Add(new Rectangle
            {
                Fill = Color.FromArgb("#e5e4e2"),
                Stroke = Colors.Gray,
                StrokeThickness = 2,
                WidthRequest = 100,
                HeightRequest = 100,
                RadiusX = 30,
                RadiusY = 30
            });
            guess4.Add(new Rectangle
            {
                Fill = Color.FromArgb("#e5e4e2"),
                Stroke = Colors.Gray,
                StrokeThickness = 2,
                WidthRequest = 100,
                HeightRequest = 100,
                RadiusX = 30,
                RadiusY = 30
            });
            guess5.Add(new Rectangle
            {
                Fill = Color.FromArgb("#e5e4e2"),
                Stroke = Colors.Gray,
                StrokeThickness = 2,
                WidthRequest = 100,
                HeightRequest = 100,
                RadiusX = 30,
                RadiusY = 30
            });
        }
    }
}

