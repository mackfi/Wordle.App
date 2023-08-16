using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Graphics;
using System;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Wordle;

public partial class MainPage : ContentPage
{
	private String wordleWord;
    private List<String> wordleData = new List<String>();
    Random rand = new Random();
    private String wordCheck;
	private int guesses = 0;
	public MainPage()
	{
		InitializeComponent();
        SetupWordle();
        
    }

    private void SetupWordle()
    {
        string filePath =
        @$"C://Users/mackf/source/repos/mackfi/Wordle.App/Wordle/5_letters.csv";
        
        try
        {
            
            //using var stream = await FileSystem.OpenAppPackageFileAsync("5_letters.csv");
            using var reader = new StreamReader(filePath);
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
            reader.Close();
        }
        catch
        {
            Console.WriteLine("File doesn't exist");
        }
        
        wordleWord = wordleData.ElementAt(rand.Next(0, wordleData.Count() - 1));
    }

	private void OnStartClicked(object sender, EventArgs e)
	{
		
            Home.IsEnabled = false;
            Home.IsVisible = false;
            WordleGame.IsEnabled = true;
            WordleGame.IsVisible = true;
			
            ResetWordleBoard();
        
	}

    /// <summary>
    /// Called whenever the user enters text into the guessBox entry.
    /// Handles most of the logic behind the Wordle game, including
    /// parsing the guess and determining which letters were correct.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void guessBox_Completed(object sender, EventArgs e)
    {
		if (guessBox.Text.Length != 5) 
		{
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
                        guess1.Add(new Border
                        {
                            Stroke = Color.FromArgb("#56887d"),
                            BackgroundColor = Color.FromArgb("#56887d"),
                            StrokeThickness = 1,
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill = Color.FromArgb("#56887d"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
                        });
                    }
                }

                for (int i = 0; i < 5; i++)
				{
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i)) { continue; }
					if (wordCheck.Contains(guessBox.Text.ElementAt(i)))
					{
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess1.Insert(i, new Border
                        {
                            Stroke = Color.FromArgb("#b1cdc2"),
                            StrokeThickness= 1,
                            BackgroundColor = Color.FromArgb("#b1cdc2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill= Color.FromArgb("#b1cdc2"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
                        });
                    }
					else
					{
                        guess1.Insert(i, new Border
                        {
                            Stroke = Color.FromArgb("#e5e4e2"),
                            StrokeThickness= 1,
                            BackgroundColor = Color.FromArgb("#e5e4e2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill = Color.FromArgb("#e5e4e2"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
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
                        guess2.Add(new Border
                        {
                            Stroke = Color.FromArgb("#56887d"),
                            BackgroundColor = Color.FromArgb("#56887d"),
                            StrokeThickness = 1,
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill = Color.FromArgb("#56887d"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
                        });
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i)) { continue; }
                    if (wordCheck.Contains(guessBox.Text.ElementAt(i)))
                    {
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess2.Insert(i, new Border
                        {
                            Stroke = Color.FromArgb("#b1cdc2"),
                            StrokeThickness = 1,
                            BackgroundColor = Color.FromArgb("#b1cdc2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill = Color.FromArgb("#b1cdc2"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
                        });
                    }
                    else
                    {
                        guess2.Insert(i, new Border
                        {
                            Stroke = Color.FromArgb("#e5e4e2"),
                            StrokeThickness = 1,
                            BackgroundColor = Color.FromArgb("#e5e4e2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill = Color.FromArgb("#e5e4e2"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
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
                        guess3.Add(new Border
                        {
                            Stroke = Color.FromArgb("#56887d"),
                            BackgroundColor = Color.FromArgb("#56887d"),
                            StrokeThickness = 1,
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill = Color.FromArgb("#56887d"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
                        });
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i)) { continue; }
                    if (wordCheck.Contains(guessBox.Text.ElementAt(i)))
                    {
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess3.Insert(i, new Border
                        {
                            Stroke = Color.FromArgb("#b1cdc2"),
                            StrokeThickness = 1,
                            BackgroundColor = Color.FromArgb("#b1cdc2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill = Color.FromArgb("#b1cdc2"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
                        });
                    }
                    else
                    {
                        guess3.Insert(i, new Border
                        {
                            Stroke = Color.FromArgb("#e5e4e2"),
                            StrokeThickness = 1,
                            BackgroundColor = Color.FromArgb("#e5e4e2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill = Color.FromArgb("#e5e4e2"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
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
                        guess4.Add(new Border
                        {
                            Stroke = Color.FromArgb("#56887d"),
                            BackgroundColor = Color.FromArgb("#56887d"),
                            StrokeThickness = 1,
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill = Color.FromArgb("#56887d"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
                        });
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i)) { continue; }
                    if (wordCheck.Contains(guessBox.Text.ElementAt(i)))
                    {
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess4.Insert(i, new Border
                        {
                            Stroke = Color.FromArgb("#b1cdc2"),
                            StrokeThickness = 1,
                            BackgroundColor = Color.FromArgb("#b1cdc2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill = Color.FromArgb("#b1cdc2"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
                        });
                    }
                    else
                    {
                        guess4.Insert(i, new Border
                        {
                            Stroke = Color.FromArgb("#e5e4e2"),
                            StrokeThickness = 1,
                            BackgroundColor = Color.FromArgb("#e5e4e2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill = Color.FromArgb("#e5e4e2"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
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
                        guess5.Add(new Border
                        {
                            Stroke = Color.FromArgb("#56887d"),
                            BackgroundColor = Color.FromArgb("#56887d"),
                            StrokeThickness = 1,
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill = Color.FromArgb("#56887d"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
                        });
                    }
                }

                for (int i = 0; i < 5; i++)
                {
                    if (guessBox.Text.ElementAt(i) == wordleWord.ElementAt(i)) { continue; }
                    if (wordCheck.Contains(guessBox.Text.ElementAt(i)))
                    {
                        wordCheck = wordCheck.Remove(wordCheck.IndexOf(guessBox.Text.ElementAt(i)), 1);
                        guess5.Insert(i, new Border
                        {
                            Stroke = Color.FromArgb("#b1cdc2"),
                            StrokeThickness = 1,
                            BackgroundColor = Color.FromArgb("#b1cdc2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill = Color.FromArgb("#b1cdc2"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
                        });
                    }
                    else
                    {
                        guess5.Insert(i, new Border
                        {
                            Stroke = Color.FromArgb("#e5e4e2"),
                            StrokeThickness = 1,
                            BackgroundColor = Color.FromArgb("#e5e4e2"),
                            WidthRequest = 100,
                            HeightRequest = 100,
                            StrokeShape = new Rectangle
                            {
                                Fill = Color.FromArgb("#e5e4e2"),
                                RadiusX = 30,
                                RadiusY = 30
                            },
                            Content = new Label
                            {
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.Center,
                                Text = guessBox.Text.ToUpper().ElementAt(i).ToString(),
                                TextColor = Colors.White,
                                FontSize = 48,
                                FontAttributes = FontAttributes.Bold
                            }
                        });
                    }
                }

                break;
        }


        guessBox.Text = "";
		guesses++;
    }

    private void WordleReset_Clicked(object sender, EventArgs e)
    {
        ResetWordleBoard();
    }
    /// <summary>
    /// Selects a new Wordle word, and resets the board and amount of guesses.
    /// </summary>
    void ResetWordleBoard()
    {
        guesses = 0;
        wordleWord = wordleData.ElementAt(rand.Next(0, wordleData.Count() - 1));
        Cheatcode.Text = wordleWord;
        guessBox.Text = "";

        while (guess1.Count > 0) guess1.RemoveAt(0);
        while (guess2.Count > 0) guess2.RemoveAt(0);
        while (guess3.Count > 0) guess3.RemoveAt(0);
        while (guess4.Count > 0) guess4.RemoveAt(0);
        while (guess5.Count > 0) guess5.RemoveAt(0);

        for (int i = 0; i < 5; i++)
        {
            
            guess1.Add(new Rectangle
            {
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

    private void HomeNav_Clicked(object sender, EventArgs e)
    {
        Home.IsEnabled = true;
        Home.IsVisible = true;
        WordleGame.IsEnabled = false;
        WordleGame.IsVisible = false;
    }
}

