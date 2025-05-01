using System;

public class DBLightUpGameScore
{
    public int Id { get; set; }  // primary key
    public int Score { get; set; } 
    public DateTime Date { get; set; }  

    public int UserId { get; set; }  // foreign key
    public DBUser? DBUser { get; set; }  // navigation property

    //connections to other tables set
    public ICollection<DBUser> DBUsers { get; set; } = new List<DBUser>();
    public ICollection<DBMentalHealthGameScore> DBMentalHealthGameScores { get; set; } = new List<DBMentalHealthGameScore>();
    public ICollection<DBPlan> DBPlans { get; set; } = new List<DBPlan>();
    public ICollection<DBQuestionaire> DBQuestionaires { get; set; } = new List<DBQuestionaire>();
}