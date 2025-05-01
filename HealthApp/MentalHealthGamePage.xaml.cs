namespace HealthApp;
using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

public partial class MentalHealthGamePage : ContentPage
{
        string username9;
        private readonly HealthAppViewModel _viewModel; 
	    List<Point> Snake = new List<Point>();
        Point Food;
        Direction Direc = Direction.Right;
        bool IsGameOver = false;
        Random RandomNumber = new Random();
        const int GridSize = 10;
        List<String> Tips = new List<string>
        {
            "Spend more time in nature",
            "Plan a sleep schedule to ensure you get 7-9 hours of sleep",
            "Exercise more, as physical health can impact mental health",
            "Eat a balanced diet",
            "Plan things to look forward to",
            "Take breaks from work, when getting overly stressed",
            "Spend time with animals",
            "Talk to someone you trust",
            "Drink water regually",
            "Keep alcohol use low",
            "Decrease your screen time",
            "Do a relaxing activity, like have a bath, before bed",
            "Bring nature indoors, by purchasing plants",
            "Do something creative, like make a collage",
            "Learn to understand your emotions, so you can manage them",
            "Track gratitude and achievement with a journal",
            "Relax in a warm bath once a week",
            "Try prepping your lunches or picking out your clothes for the work week",
            "Work some omega-3 fatty acids into your diet",
             " Do something with friends and family"
        };

        public MentalHealthGamePage(string username)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            _viewModel = App.ViewModel;
            BindingContext = _viewModel;
            username9 = username;

			StartGame();
            Device.StartTimer(TimeSpan.FromMilliseconds(200), UpdateGame);
        }

		private void OnBackClick(object sender, EventArgs e)
	    {
		    Navigation.PopAsync();
	    }

        private void OnScoresClick(object sender, EventArgs e)
	    {
		    Navigation.PushAsync(new MentalHealthGameScores(username9));
	    }

		private void StartGame()
        {
            Snake.Clear();
            Snake.Add(new Point(6, 6));
            Food = GenerateFood();
            Direc = Direction.Right;
            IsGameOver = false;
			while (Food == Snake[0])
            {
                Food = GenerateFood();
            }
            Draw();
        }

        private bool UpdateGame()
        {
            if (IsGameOver) return false;

            MoveSnake();
            CheckCollision();
            Draw();
            return true;
        }

		private enum Direction { Up, Down, Left, Right }

        private void MoveSnake()
        {
             //snake is moved in direction of the key pressed
             // if there is food in the space it has moved to a tip will be shown and score will be updated
             // if there is snake in the space it has moved to the game will end
             Point head=Snake[0];
             Point newHead=head;

             if (Direc==Direction.Up)
             {
                newHead=new Point(head.X, head.Y-1);
             }

             else if (Direc==Direction.Down)
             {
                newHead=new Point(head.X, head.Y + 1);
             }

             else if (Direc==Direction.Left)
             {
                newHead=new Point(head.X-1, head.Y);
             }

             else if (Direc==Direction.Right)
             {
                newHead=new Point(head.X+1, head.Y);
             }

            Snake.Insert(0, newHead);

            if (newHead==Food)
            {
                Food=GenerateFood();
                DisplayAlert("Tip", GetTip(), "Okay");
            }
           
		    else
            {
               Snake.RemoveAt(Snake.Count-1);
            }
        }

        private String GetTip()
        {
            Random random = new Random();
            int randomIndex = random.Next(Tips.Count);
            string Tip = Tips[randomIndex];
            return Tip;
        }

       private void OnUpClick(object sender, EventArgs e)
       {
           if (Direc!=Direction.Down)
           {
               Direc=Direction.Up;
           }
       }

       private void OnDownClick(object sender, EventArgs e)
       {
            if (Direc!=Direction.Up) 
            {
                Direc=Direction.Down;
            }
       }

       private void OnLeftClick(object sender, EventArgs e)
       {
           if (Direc!=Direction.Right)
           {
               Direc=Direction.Left;
           }
       }

       private void OnRightClick(object sender, EventArgs e)
       {
           if (Direc!=Direction.Left)
           {
               Direc=Direction.Right;
           }
       }
        private async void CheckCollision()
        {
            Point head=Snake[0];

            for (int i=1; i<Snake.Count; i++)
            {
                 if (Snake[i]==head)
                 {
                     int Score = Snake.Count;
                     //await _viewModel.AddMentalHealthGameScore(await _viewModel.FetchUserId(username9), Score, DateTime.Today);
                     await DisplayAlert("Game Over", "You ran into yourself - Score: "+Score, "Okay");
                     IsGameOver=true;
                 }
            }
        }

        private Point GenerateFood()
        {
            return new Point(RandomNumber.Next(0, GridSize), RandomNumber.Next(0, GridSize));
        }


        private void Draw()
        {
            Grid.Children.Clear();

            foreach (var segment in Snake)
            {
                var SnakeSegment=new BoxView {Color=Colors.Green, WidthRequest=30, HeightRequest=30};
                Grid.Children.Add(SnakeSegment); 
                Grid.SetRow((IView)SnakeSegment, (int)segment.Y);
                Grid.SetColumn((IView)SnakeSegment, (int)segment.X);
            }

            var FoodSegment = new BoxView {Color=Colors.Red, WidthRequest=30, HeightRequest=30};
            Grid.Children.Add(FoodSegment); 
            Grid.SetRow((IView)FoodSegment, (int)Food.Y);
            Grid.SetColumn((IView)FoodSegment, (int)Food.X);
        }
}