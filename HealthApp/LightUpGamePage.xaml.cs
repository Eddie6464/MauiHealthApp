namespace HealthApp;

public partial class LightUpGamePage : ContentPage
{
    List<string> colors = new List<string>(); 
    int playerIndex = 0; 
    bool isPlayerTurn = false; 
    string username8;
    private readonly HealthAppViewModel _viewModel; 

    public LightUpGamePage(string username)
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        _viewModel = App.ViewModel;
        BindingContext = _viewModel;
        username8 = username;
    }

    private void OnBackClick(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void OnScoresClick(object sender, EventArgs e)
	{
		Navigation.PushAsync(new LightUpScores(username8));
	}

    private async void OnStartClick(object sender, EventArgs e)
    {
        colors.Clear();
        playerIndex = 0;
        isPlayerTurn = false;
        await NextRound();
    }

    private async Task NextRound()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 5);
        string randomColor = "Empty";
        if(randomNumber==1){
            randomColor = "Red";
        }
        else if(randomNumber==2){
            randomColor = "Blue";
        }
        else if(randomNumber==3){
            randomColor = "Green";
        }
        else if(randomNumber==4){
            randomColor = "Yellow";
        }
        colors.Add(randomColor); 
        
        foreach (var color in colors){
            Button buttonToFlash = GetButtonFromColor(color);
            if (buttonToFlash != null){
                await FlashButton(buttonToFlash, 500); 
            }
        } 

        playerIndex = 0;
        isPlayerTurn = true;
    }

    private async void OnClick(object sender, EventArgs e)
    {
        if (!isPlayerTurn) return; 

        Button clickedButton = (Button)sender;
        string clickedColor = GetColorFromButton(clickedButton); 
        if (clickedColor == colors[playerIndex]){
            playerIndex = playerIndex + 1;
            if (playerIndex == colors.Count){
                await DisplayAlert("Correct","Correct","Continue");
                await NextRound();
            }
        }

        else{
            await DisplayAlert("Game Over","Game Over","Try Again");
            string HighScoreString = playerIndex.ToString();
            HighScore.Text = "High Score: "+HighScoreString;
            //await _viewModel.AddLightUpGameScore(await _viewModel.FetchUserId(username8), playerIndex, DateTime.Today);
            colors.Clear(); 
            playerIndex = 0;
            isPlayerTurn = false;

        }
    }

    private async Task FlashButton(Button button, int duration = 300)
    {
        Color originalColor = button.BackgroundColor;
        button.BackgroundColor = Colors.White;
        await Task.Delay(duration);
        button.BackgroundColor = originalColor;  
    }

    private Button GetButtonFromColor(string color)
    {
        if(color=="Red"){
            return RedBtn;
        }
        else if(color=="Blue"){
            return BlueBtn;
        }
        else if(color=="Green"){
            return GreenBtn;
        }
        else if(color=="Yellow"){
            return YellowBtn;
        }
        else{
            return null;
        }
    }

    private string GetColorFromButton(Button button)
    {   if(button==RedBtn){
            return "Red";
        }
        else if(button==BlueBtn){
            return "Blue";
        }
        else if(button==GreenBtn){
            return "Green";
        }      
        else if(button==YellowBtn){
            return "Yellow";
        }
        else{
            return null;
        }
    }
}