namespace EnergyHealthApp.Data.Models;

public class User
{
    public int Id {get; set;}
    public string? Username {get; set;}
    public string? EmailAddress {get; set;}
    public string? Password {get; set;}
    public EnergyProfile? EnergyProfile {get; set;}
    public EnergyQuestionnaire? EnergyQuestionnaire {get; set;}

}