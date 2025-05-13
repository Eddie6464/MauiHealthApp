using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace EnergyHealthApp.Data.Models;

public class EnergyQuestionnaire{
    [Key, ForeignKey("User")]
    public int? UserId { get; set; } = null;
    public int? Q1Answer {get; set;} = null;
    public int? Q2Answer {get; set;} = null;
    public int? Q3Answer {get; set;} = null;
    public int? Q4Answer {get; set;} = null;
    public int? Q5Answer {get; set;} = null;
    public int? Score {get; private set;} = 0;

    public User? User {get; set;}

    public EnergyQuestionnaire(){}

    public void CalculateScore()
    {
        
        double meanScore = (Q1Answer!.Value + Q2Answer!.Value + Q3Answer!.Value + Q4Answer!.Value + Q5Answer!.Value) / 5.0;
        Score = (int)Math.Round(meanScore, MidpointRounding.AwayFromZero);
    }

    public List<String> GetRecommendations(){
        List<string> Recommendations = new List<string>();
        if (Q1Answer <= 3)
        {
            Recommendations.Add("You need to get more excersize. Try going for a 30 minuite jog each day.");
        }

        if (Q2Answer <= 3)
        {
            Recommendations.Add("You need to get more sleep. Try getting at least 8 hours sleep every night.");
        }

        if (Q3Answer <= 3)
        {
            Recommendations.Add("Why not try going to the gym more often. How about just going twice a week?");
        }

        if (Q4Answer <= 3)
        {
            Recommendations.Add("If you don't feel great, try getting more sleep and doing more excersize. Healthy eating can improve your overall wellbeing too."); 
        }

        if (Q5Answer <= 3)
        {
            Recommendations.Add("If you can, try walking to your place of work/education at least three times a week.");
        }

        return Recommendations;
    }

}