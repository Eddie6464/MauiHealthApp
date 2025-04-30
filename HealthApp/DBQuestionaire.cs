using System;

public class DBQuestionaire
{
    public int Id { get; set; }  // Primary Key
    public int Question1 { get; set; } 
    public int Question2 { get; set; } 
    public int Question3 { get; set; } 
    public int Question4 { get; set; } 
    public int Question5 { get; set; } 
    public int Question6 { get; set; } 

    public int UserId { get; set; }  // Foreign Key
    public DBUser? DBUser { get; set; }  // Navigation Property

    public ICollection<DBUser> DBUsers { get; set; } = new List<DBUser>();
    public ICollection<DBMentalHealthGameScore> DBMentalHealthGameScores { get; set; } = new List<DBMentalHealthGameScore>();
    public ICollection<DBLightUpGameScore> DBLightUpGameScores { get; set; } = new List<DBLightUpGameScore>();
    public ICollection<DBPlan> DBPlans { get; set; } = new List<DBPlan>();
}