using System;

public class DBLightUpGameScore
{
    public int Id { get; set; }  // Primary Key
    public int Score { get; set; } 
    public DateTime Date { get; set; }  // New column

    public int UserId { get; set; }  // Foreign Key
    public DBUser? DBUser { get; set; }  // Navigation Property

    public ICollection<DBUser> DBUsers { get; set; } = new List<DBUser>();
    public ICollection<DBMentalHealthGameScore> DBMentalHealthGameScores { get; set; } = new List<DBMentalHealthGameScore>();
    public ICollection<DBPlan> DBPlans { get; set; } = new List<DBPlan>();
    public ICollection<DBQuestionaire> DBQuestionaires { get; set; } = new List<DBQuestionaire>();
}