using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace EnergyHealthApp.Data.Models;

public class EnergyProfile
{
    [Key, ForeignKey("User")]
    public int UserId {get; set;}
    public int? HeartRate {get; set;} = null;
    public string BloodPressure {get; set;} = "";
    public int? RespiratoryRate {get; set;} = null;
    public int Score {get; private set;} = 0;

    public User? User {get; set;}

    public void CalculateScore()
    {
        int heartRateScore = GetHeartRateScore();
        int bloodPressureScore = GetBloodPressureScore();
        int respiratoryRateScore = GetRespiratoryRateScore();

        double scoresMean = (heartRateScore + bloodPressureScore + respiratoryRateScore) / 3.0;

        Score = (int)Math.Round(scoresMean, MidpointRounding.AwayFromZero);

    }

    public int GetHeartRateScore()
    {
        int heartRateScore;
        if (HeartRate < 50 || HeartRate > 110){
            heartRateScore = 1;
        }
        else if (HeartRate >= 100 && HeartRate <= 110 || HeartRate >= 50 && HeartRate <=60){
            heartRateScore = 2;
        }
        else if (HeartRate >= 80 && HeartRate < 100){
            heartRateScore = 3;
        }
        else if (HeartRate >= 70 && HeartRate <= 80){
            heartRateScore = 4;
        }
        else
        {
            heartRateScore = 5;
        }
        return heartRateScore;
    }

    public int GetBloodPressureScore(){
        int bloodPressureScore;
        
        var bloodPressureConverted = ConvertBloodPressureToInt();
        int systolic = bloodPressureConverted.Item1;
        int diastolic = bloodPressureConverted.Item2;

        if (systolic > 180 || diastolic > 120){
            bloodPressureScore = 1;
        }
        else if (systolic > 140 || diastolic > 90){
            bloodPressureScore = 2;
        }
        else if (systolic <= 139 && systolic >= 130 || diastolic <= 89 && diastolic >= 80){
            bloodPressureScore = 3;
        }
        else if (systolic <= 129 && systolic >= 120 || diastolic < 80){
            bloodPressureScore = 4;
        }
        else{
            bloodPressureScore = 5;
        }


        return bloodPressureScore;
    }

    public (int, int) ConvertBloodPressureToInt(){
        try{
            string[] split = BloodPressure.Split('/');
            int systolic = int.Parse(split[0]);
            int diastolic = int.Parse(split[1]);

            return (systolic, diastolic);
        }
        catch(FormatException)
        {
            return (0, 0);
        }
    }

    public int GetRespiratoryRateScore(){
        int respiratoryRateScore;
        if (RespiratoryRate < 14 || RespiratoryRate > 24){
            respiratoryRateScore = 1;
        }
        else if (RespiratoryRate >= 21 && RespiratoryRate >= 23){
            respiratoryRateScore = 2;
        }
        else if (RespiratoryRate >= 14 && RespiratoryRate <= 15){
            respiratoryRateScore = 3;
        }
        else if (RespiratoryRate >= 17 && RespiratoryRate <= 20){
            respiratoryRateScore = 4;
        }
        else if ((RespiratoryRate >= 12 && RespiratoryRate <= 13) || RespiratoryRate == 16){
            respiratoryRateScore = 5;
        }
        else{
            respiratoryRateScore = 0;
        }

        return respiratoryRateScore;
    }
}