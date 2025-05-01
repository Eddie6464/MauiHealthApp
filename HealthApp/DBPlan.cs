using System;

public class DBPlan
{
    public int Id { get; set; }  // primary key
    public string Step1 { get; set; } = string.Empty;
    public string Step2 { get; set; } = string.Empty;
    public string Step3 { get; set; } = string.Empty;
    public string Step4 { get; set; } = string.Empty;

    public int UserId { get; set; }  // foreign key
    public DBUser? DBUser { get; set; }  // navigation property
    
    //connections to other tables set
    public ICollection<DBUser> DBUsers { get; set; } = new List<DBUser>();
    public ICollection<DBMentalHealthGameScore> DBMentalHealthGameScores { get; set; } = new List<DBMentalHealthGameScore>();
    public ICollection<DBLightUpGameScore> DBLightUpGameScores { get; set; } = new List<DBLightUpGameScore>();
    public ICollection<DBQuestionaire> DBQuestionaires { get; set; } = new List<DBQuestionaire>();
}