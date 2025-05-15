using System.Collections.ObjectModel;

namespace Nutrition.Views;

public partial class Question7 : ContentPage
{
	public Question7()
	{
		InitializeComponent();
		this.BackgroundColor = Color.FromArgb("#F5CDAA"); // Light Orange color

       

		
	// Default values
    int stones = 0;
    int pounds = 0;

    //  values from SharedData
    if (!int.TryParse(Model.SharedData.StonesText, out stones)) stones = 0;
    if (!int.TryParse(Model.SharedData.PoundsText, out pounds)) pounds = 0;


    //Weight type
    String WeightType =  Model.SharedData.Weighttype;


    // Generate weight options
    List<string> weightOptions = GenerateWeightList(stones, pounds, WeightType);

    // Set Picker items
    myPicker.ItemsSource = weightOptions;
    myPicker.SelectedIndex = 0;
}

// Generate weight options by decrementing by 1 pound each step
private List<string> GenerateWeightList(int stones, int pounds, string WeightType)
{
    List<string> weightList = new List<string>();

    for (int i = 0; i < 14; i++) // Generate 14 options (adjustable)
    {
        // Add the current weight to the list
        weightList.Add($"{stones} st {pounds} lb");

        if (WeightType == "To lose weight")
        {

            // Decrease pounds by 1
            pounds--;

            // If pounds go below 0, decrease stones and reset pounds to 13
            if (pounds < 0)
            {
                if (stones > 0)
                {
                    stones--;
                    pounds = 13;
                }
                else
                {
                    break; // Stop if we can't go lower
                }
            }
        }
        
        else if (WeightType == "To gain weight")
        {
            // Increase pounds
            pounds++;

            // If pounds go above 13, increase stones and reset pounds
            if (pounds > 13)
            {
                stones++;
                pounds = 0;
            }
        }
        else if (WeightType == "Maintain weight")
        {
            weightList.Add($"{stones} st {pounds} lb");
            
           
        }

        
    }

    return weightList;

		
		
		
		
	


	

	
		
	}
    // Handle the Picker selection change event
	private async void OnPickerSelectedIndexChanged(object sender, EventArgs e)
	{
		 if (myPicker.SelectedIndex != -1)
        {
            string selectedWeight = myPicker.SelectedItem.ToString();
            selectedOptionLabel.Text = $"{selectedWeight}";

			Model.SharedData.SelectedDreamWeight = selectedWeight;

			

			string[] parts = selectedWeight.Split(new string[] { "st ", "lb" }, StringSplitOptions.RemoveEmptyEntries);

			if (parts.Length == 2) // Ensure valid format
			{
				Model.SharedData.DreamStone = parts[0]; // Stones part
				Model.SharedData.DreamPound = parts[1]; // Pounds part

			}
            selectedOptionLabel.Text = $" {selectedWeight}";
        }
	}

	private async void Question8_Clicked(object sender, EventArgs e)
	{
		// Handle the button click event here
		await Shell.Current.GoToAsync("Question8");
	}
}