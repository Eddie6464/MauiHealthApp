namespace EnergyHealthApp.Services;
using Microsoft.EntityFrameworkCore;
using EnergyHealthApp.Data;
using EnergyHealthApp.Data.Models;

public class EnergyHealthAppService
{
    private readonly AppDbContext _dbContext;

    public EnergyHealthAppService(AppDbContext dbContext) 
    {
        _dbContext = dbContext;
    }

    public async Task UpdateHeartRate(int id, int newHeartRate)
    {
        var energyProfile = await _dbContext.EnergyProfiles.FindAsync(id);
        if (energyProfile != null)
        {
            energyProfile.HeartRate = newHeartRate;
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateBloodPressure(int id, string newBloodPressure)
    {
        var energyProfile = await _dbContext.EnergyProfiles.FindAsync(id);
        if (energyProfile != null)
        {
            energyProfile.BloodPressure = newBloodPressure;
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateRespiratoryRate(int id, int newRespiratoryRate)
    {
        var energyProfile = await _dbContext.EnergyProfiles.FindAsync(id);
        if (energyProfile != null)
        {
            energyProfile.RespiratoryRate = newRespiratoryRate;
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task UpdateQuestionnaireResults(int id, int q1Answer, int q2Answer, int q3Answer,int q4Answer, int q5Answer)
    {
        var energyQuestionnaire = await _dbContext.EnergyQuestionnaires.FindAsync(id);
        if (energyQuestionnaire != null)
        {
            energyQuestionnaire.Q1Answer = q1Answer;
            energyQuestionnaire.Q2Answer = q2Answer;
            energyQuestionnaire.Q3Answer = q3Answer;
            energyQuestionnaire.Q4Answer = q4Answer;
            energyQuestionnaire.Q5Answer = q5Answer;

            energyQuestionnaire.CalculateScore();

            await _dbContext.SaveChangesAsync();
        }
    }

       public async Task <User?> GetUserById(int id)
    {
        return await _dbContext.Users
        .Include(u => u.EnergyProfile)
        .Include(u => u.EnergyQuestionnaire)
        .FirstOrDefaultAsync(u => u.Id == id);
    }
    
}