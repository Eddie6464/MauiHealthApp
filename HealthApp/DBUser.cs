using System;

public class DBUser
{
    public int Id { get; set; }  // primary Key
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;  

    //connections to other tables set
    public ICollection<DBLightUpGameScore> DBLightUpGameScores { get; set; } = new List<DBLightUpGameScore>();
    public ICollection<DBMentalHealthGameScore> DBMentalHealthGameScores { get; set; } = new List<DBMentalHealthGameScore>();
    public ICollection<DBPlan> DBPlans { get; set; } = new List<DBPlan>();
    public ICollection<DBQuestionaire> DBQuestionaires { get; set; } = new List<DBQuestionaire>();
}