using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Linq;
using Nutrition.Model;
using Nutrition.Services;
using System.Windows.Input;
using System.ComponentModel;
using Nutrition.Views; // Add the namespace where ExerciseSelection is defined



namespace Nutrition.ViewModel;

 public class CalorieCounterViewModel : INotifyPropertyChanged
 {
    

     private readonly DatabaseService _databaseService;
     private readonly INavigation _navigation;

    /// Observable collections for food items
    public ObservableCollection<FoodItem> Foods { get; set; } = new ObservableCollection<FoodItem>();
    public ObservableCollection<FoodItem> LunchFoodItem { get; set; } = new ObservableCollection<FoodItem>();
    public ObservableCollection<FoodItem> DinnerFoodItem { get; set; } = new ObservableCollection<FoodItem>();
    public ObservableCollection<FoodItem> SnackFoodItem { get; set; } = new ObservableCollection<FoodItem>();
    public ObservableCollection<FoodItem> SportItem { get; set; } = new ObservableCollection<FoodItem>();
    public ObservableCollection<FoodItem> FilteredFoods { get; set; } = new ObservableCollection<FoodItem>();


    // Properties for displaying data
    private int _goalTarget;
        public int GoalTarget
        {
            get => _goalTarget;
            set
            {
                _goalTarget = value;
                OnPropertyChanged(nameof(GoalTarget));
            }
        }

    private int _HealthyLabel;
        public int HealthyLabel
        {
            get => _HealthyLabel;
            set
            {
                _HealthyLabel = value;
                OnPropertyChanged(nameof(HealthyLabel));
            }
        }

    private int _WaterCountLabel;
    public int WaterCountLabel
    {
        get => _WaterCountLabel;
        set
        {
            _WaterCountLabel = value;
            OnPropertyChanged(nameof(WaterCountLabel));
        }
    }
    
    private int _breakfastcalories;
        public int BreakfastCalories
        {
            get => _breakfastcalories;
            set
            {
                _breakfastcalories = value;
                OnPropertyChanged(nameof(BreakfastCalories));
            }
        }
    private int _lunchcalories;
        public int LunchCalories
        {
            get => _lunchcalories;
            set
            {
                _lunchcalories = value;
                OnPropertyChanged(nameof(LunchCalories));
            }
        }

    private int _dinnercalories;
        public int DinnerCalories
        {
            get => _dinnercalories;
            set
            {
                _dinnercalories = value;
                OnPropertyChanged(nameof(DinnerCalories));
            }
        }

    private int _snackcalories;
        public int SnackCalories
        {
            get => _snackcalories;
            set
            {
                _snackcalories = value;
                OnPropertyChanged(nameof(SnackCalories));
            }
        }

    private int _exercisecalories;
        public int ExerciseCalories
        {
            get => _exercisecalories;
            set
            {
                _exercisecalories = value;
                OnPropertyChanged(nameof(ExerciseCalories));
            }
        }

    private int _totalCalories;
        public int TotalCalories
        {
            get => _totalCalories;
            set
            {
                _totalCalories = value;
                OnPropertyChanged(nameof(TotalCalories));
            }
        }
    
    private int _remainingCalories;
        public int RemainingCalories
        {
            get => _remainingCalories;
            set
            {
                _remainingCalories = value;
                OnPropertyChanged(nameof(RemainingCalories));
            }
        }

    private bool _isListVisible = false;
    public bool IsListVisible
    {
        get => _isListVisible;
        set
        {
            _isListVisible = value;
            OnPropertyChanged(nameof(IsListVisible));
        }
    }



    public ICommand DeleteCommand { get; private set; }
    public CalorieCounterViewModel(DatabaseService databaseService, INavigation navigation)
    {
         
         _databaseService = databaseService;
         _navigation = navigation;
 
         InitializeViewModel();
			
         SubscribeToMessages();

         LoadUserData();

         DeleteCommand = new Command<FoodItem>(async (food) => await DeleteFoodAsync(food));



    }

    // receive messages from other pages so we can update the food list
    private void SubscribeToMessages()
        {
            MessagingCenter.Subscribe<BreakfastSelection>(this, "RefreshFoods", (sender) => {LoadFoods(); LoadWaterCount(); LoadHealthyCount(); });
            MessagingCenter.Subscribe<LunchSelectionPage>(this, "RefreshFoods", (sender) =>{LoadFoods(); LoadWaterCount(); LoadHealthyCount(); });
            MessagingCenter.Subscribe<DinnerSelection>(this, "RefreshFoods", (sender) => {LoadFoods(); LoadWaterCount(); LoadHealthyCount(); });
            MessagingCenter.Subscribe<SnackSelection>(this, "RefreshFoods", (sender) => {LoadFoods(); LoadWaterCount(); LoadHealthyCount(); });
            MessagingCenter.Subscribe<ExerciseSelection>(this, "RefreshFoods", (sender) =>{LoadFoods(); LoadWaterCount(); LoadHealthyCount(); });
        }




    private void InitializeViewModel()
    {
            // You can call your custom methods here
            LoadFoods();
            LoadWaterCount();
            LoadHealthyCount();
    }




    public void LoadUserData()
    {
        
        //age
        double Age = 0; 

        if (double.TryParse(Model.SharedData.ageText  , out double age))
        {
            Age = age;
            
        }

        //weight in kg
        double StoneKG = 0;
        double PoundKG = 0;
        double Kilogram;

        if (double.TryParse(Model.SharedData.StonesText  , out double stones))
        {
            StoneKG = stones * 6.350293; 
        }
        
        if (double.TryParse(Model.SharedData.PoundsText  , out double Pounds))
        {
            PoundKG = Pounds * 0.453592;  
        }
       
        Kilogram = StoneKG + PoundKG;
        Kilogram = RoundDown(Kilogram, 4);
        


        //height in cm
        double FeetCM = 0;
        double InchesCM = 0;
        double HeightCM = 0;
        
        if (double.TryParse(Model.SharedData.FeetText  , out double Feet))
        {
            FeetCM = Feet * 30.48; 
        }
        
        if (double.TryParse(Model.SharedData.InchesText  , out double Inches))
        {
            InchesCM = Inches * 2.54;  
        }
       
        HeightCM = FeetCM + InchesCM;
     


        //Calculate BMR

        double BMR = 0;

        if (Model.SharedData.GenderText == "Male")
        {
            BMR = (10 * Kilogram) + (6.25 * HeightCM) - (5 * Age) + 5;
        }
        else if (Model.SharedData.GenderText == "Female")
        {
            BMR = (10 * Kilogram) + (6.25 * HeightCM) - (5 * Age) - 161;
        }
        else {
            BMR = 0;
        }

        BMR = RoundDown(BMR, 1);
       
        
        //Activity level factor

        double activityFactory = 0;

         if (Model.SharedData.activeText == "Light")
        {
            activityFactory = 1.375;
        }
        else if (Model.SharedData.activeText == "Moderate")
        {
            activityFactory = 1.55;
        }
        else
        {
            activityFactory = 1.9;
        }

       

       //Calculate total daily energy expenditure
       double TDEE = BMR * activityFactory;
       TDEE = RoundDown(TDEE, 2);
    
       


       //Dreamweight
       double DreamWeight = 0;

        double FutureStoneKG = 0;
        double FuturePoundKG = 0;
        

        if (double.TryParse(Model.SharedData.DreamStone , out double Futurestones))
        {
           FutureStoneKG = Futurestones * 6.350293; 
        }
        
        if (double.TryParse(Model.SharedData.DreamPound  , out double FuturePounds))
        {
            FuturePoundKG = FuturePounds * 0.453592;  
        }
       
       DreamWeight = FutureStoneKG + FuturePoundKG;
       DreamWeight = RoundDown(DreamWeight, 4);

       
       
       //Adjust Calories base on weight goal
       double WeightChangeKG = 0;
       
       if (double.TryParse(Model.SharedData.AmountText  , out double AmountWeight))
       {
        WeightChangeKG = AmountWeight * 0.453592;
       }
       double calorieAdjustment = (WeightChangeKG * 7700) / 7; //1kg = 7700 kcal
     

       // Adjust for weight goals
        double dailyCalories = 0;

        if (Model.SharedData.Weighttype == "To lose weight")
        {
            dailyCalories = TDEE - calorieAdjustment;

        }
        else if (Model.SharedData.Weighttype == "Maintain weight")
        {
             dailyCalories = TDEE;
        }
        else
        {
            dailyCalories = TDEE + calorieAdjustment;
        }

        dailyCalories = RoundDown(dailyCalories, 0);
        Model.SharedData.TotalCalories = dailyCalories.ToString();
        GoalTarget = (int)dailyCalories;



    }
    public double RoundDown(double value, int decimalPlaces)
    {
                double factor = Math.Pow(10, decimalPlaces);
                return Math.Floor(value * factor) / factor;
    }





    // Load existing food choices from database
    public async Task LoadFoods()
    {
            var foods = await _databaseService.GetFoodsAsync();
           
            Foods.Clear();
            LunchFoodItem.Clear();
            DinnerFoodItem.Clear();
            SnackFoodItem.Clear();
            SportItem.Clear();
            FilteredFoods.Clear();

            BreakfastCalories = 0;
            LunchCalories = 0;
            DinnerCalories = 0;
            SnackCalories = 0;
            ExerciseCalories = 0;
            
            foreach (var food in foods)
            {
                if (food.MealType == "Breakfast")
                {
                    Foods.Add(food);
                    BreakfastCalories += food.Calories;
                    FilteredFoods.Add(food);
                }
                else if (food.MealType == "Lunch")
                {
                    LunchFoodItem.Add(food);
                    LunchCalories += food.Calories;
                    FilteredFoods.Add(food);
                }
                else if (food.MealType == "Dinner")
                {
                    DinnerFoodItem.Add(food);
                    DinnerCalories += food.Calories;
                    FilteredFoods.Add(food);
                }
                else if (food.MealType == "Snack")
                {
                    SnackFoodItem.Add(food);
                    SnackCalories += food.Calories;
                    FilteredFoods.Add(food);
                }
                else if (food.MealType == "Exercise")
                {
                    SportItem.Add(food);
                    ExerciseCalories += food.Calories;
                    FilteredFoods.Add(food);
                }
            }

            TotalCalories = BreakfastCalories + LunchCalories + DinnerCalories + SnackCalories;
            
            if (int.TryParse(Model.SharedData.TotalCalories, out int dailyCaloriesGoal))
            {
                RemainingCalories = dailyCaloriesGoal - TotalCalories + ExerciseCalories;
            }
            else
            {
                RemainingCalories = 0; // Default if there's an error
            }
    
    }

    public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Delete food item when button clicked 
	    private async void OnDeleteClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button?.CommandParameter is FoodItem foodToDelete)
            {
                await _databaseService.DeleteFoodAsync(foodToDelete);
                LoadFoods();
                LoadWaterCount();
                LoadHealthyCount();
               
            }
        }


       

        // Call this when page appears
        protected void OnAppearing()
        {
            LoadFoods();
            LoadWaterCount();
            LoadHealthyCount();
        }




    
        public async Task DeleteFoodAsync(FoodItem foodToDelete)
        {
            if (foodToDelete != null)
            {
                await _databaseService.DeleteFoodAsync(foodToDelete);
                LoadFoods();  // Reload the foods after deletion
                LoadWaterCount();  // Refresh water count
                LoadHealthyCount();  // Refresh healthy count
            }
        }

        private async void LoadWaterCount()
        {
            int WaterCount = await _databaseService.GetWaterCountAsync();
            WaterCountLabel = (int) WaterCount ;
        }

        private async void LoadHealthyCount()
        {
            int HealthCount = await _databaseService.GetHealthCountAsync();
            HealthyLabel = (int) HealthCount;
            
        }

        // **Search Functionality**
        public void OnSearchTextChanged(object sender, TextChangedEventArgs e)

        {
            
            string searchText = e.NewTextValue.ToLower();

            FilteredFoods.Clear();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                IsListVisible = false; // Hide list when search is empty
                return;
            }


            var allItems = Foods.Concat(LunchFoodItem)
                        .Concat(DinnerFoodItem)
                        .Concat(SnackFoodItem)
                        .Concat(SportItem)
                        .ToList();

            foreach (var food in allItems)
            {
                 if (food.Name.ToLower().Contains(searchText) || food.MealType.ToLower().Contains(searchText))
                {
                    FilteredFoods.Add(food);
                }
            }

            IsListVisible = FilteredFoods.Count > 0;
        }


}

