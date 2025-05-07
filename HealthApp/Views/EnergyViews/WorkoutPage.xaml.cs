namespace EnergyHealthApp.Views;
using System;
using System.Collections.Generic;


public partial class WorkoutPage : ContentPage
{

    private readonly List <string> Workouts = [
        "Run on the spot - 60s", 
        "Push ups - 60s", 
        "Sit ups - 60s", 
        "Lunges - 60s", 
        "Squats - 60s"
    ];
	public WorkoutPage()
	{
		InitializeComponent();
        DisplayWorkoutsAsync();
	}
    
    private async void HomeButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new EnergyMainPage());
	}

    private async void DisplayWorkoutsAsync()
    {
        var SelectedWorkouts = GetRandomWorkoutsAsync();
        Random random = new();
        foreach (var workout in SelectedWorkouts)
        {
            WorkoutLabel.Text = workout;
            await Task.Delay(5000); // Use 10 seconds for demonstration purposes
            WorkoutLabel.Text = "Rest for 30 seconds";
            await Task.Delay(3000); // Use 5 seconds for demonstration purposes
        }
        
        WorkoutLabel.Text = "Workout Complete!";

    }

    private List<string> GetRandomWorkoutsAsync()
    {
        List<string> WorkoutsCopy = [.. Workouts];
        List <string> SelectedWorkouts = [];
        Random random = new();
        for (int i = 0; i < 5; i++)
        {
            int index = random.Next(WorkoutsCopy.Count);
            string Workout = WorkoutsCopy[index];
            SelectedWorkouts.Add(Workout);
            WorkoutsCopy.RemoveAt(index);
        }

        return SelectedWorkouts;
    }


}