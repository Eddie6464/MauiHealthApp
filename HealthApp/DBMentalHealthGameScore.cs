using System;

public class DBMentalHealthGameScore
{
    public int Id { get; set; }  // Primary Key
    public int Score { get; set; } 
    public DateTime Date { get; set; } // New column

    public int UserId { get; set; }  // Foreign Key
    public DBUser? DBUser { get; set; }  // Navigation Property

    public ICollection<DBUser> DBUsers { get; set; } = new List<DBUser>();
    public ICollection<DBLightUpGameScore> DBLightUpGameScores { get; set; } = new List<DBLightUpGameScore>();
    public ICollection<DBPlan> DBPlans { get; set; } = new List<DBPlan>();
    public ICollection<DBQuestionaire> DBQuestionaires { get; set; } = new List<DBQuestionaire>();
}