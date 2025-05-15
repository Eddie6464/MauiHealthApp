using Nutrition.Views;




namespace Nutrition;

public partial class AppShell : Shell
{
	public AppShell()
	{
		// Set the background path of the AppShell
		
		InitializeComponent();

		Routing.RegisterRoute("Question1", typeof(Question1));
		Routing.RegisterRoute("Question2", typeof(Question2));
		Routing.RegisterRoute("Question3", typeof(Question3));
		Routing.RegisterRoute("Question4", typeof(Question4));
		Routing.RegisterRoute("Question5", typeof(Question5));
		Routing.RegisterRoute("Question6", typeof(Question6));
		Routing.RegisterRoute("Question7", typeof(Question7));
		Routing.RegisterRoute("Question8", typeof(Question8));


		Routing.RegisterRoute("BestFoods", typeof(BestFoods));
		Routing.RegisterRoute("Recipes", typeof(Recipes));
		Routing.RegisterRoute("LowCalories", typeof(LowCalories));
		Routing.RegisterRoute("HighCalories", typeof(HighCalories));
		Routing.RegisterRoute("Snack", typeof(Snack));
		Routing.RegisterRoute("GlutenFree", typeof(GlutenFree));
		Routing.RegisterRoute("Lunch", typeof(Lunch));
		Routing.RegisterRoute("Breakfast", typeof(Breakfast));
		Routing.RegisterRoute("LowCaloriesSteps", typeof(LowCaloriesSteps));
		Routing.RegisterRoute("HighCaloriesSteps", typeof(HighCaloriesSteps));
		Routing.RegisterRoute("SnackSteps", typeof(SnackSteps));
		Routing.RegisterRoute("GlutenFreeSteps", typeof(GlutenFreeSteps));
		Routing.RegisterRoute("LunchSteps", typeof(LunchSteps));
		Routing.RegisterRoute("BreakfastSteps", typeof(BreakfastSteps));
		Routing.RegisterRoute("CalorieCounter", typeof(CalorieCounter));

	}
}

