using Microsoft.EntityFrameworkCore;
namespace HealthApp;

public class HealthAppService
{
    private readonly AppDbContext _dbContext;

    public DbSet<DBUser> DBUsers { get; set; }

    public HealthAppService(AppDbContext dbContext)
    {
        //connects database
        _dbContext = dbContext;
    }

    public async Task<int?> GetUserIdByUsername(string username)
    {
    return await _dbContext.DBUsers
        .Where(u => u.Username == username)
        .Select(u => (int?)u.Id)                              
        .FirstOrDefaultAsync();
    }

    public async Task<bool> DoesUsernameExist(string username)
    {
    return await _dbContext.DBUsers.AnyAsync(u => u.Username == username);
    }

    public async Task<bool> ValidateUserCredentials(string username, string password)
    {
    return await _dbContext.DBUsers.AnyAsync(u => u.Username == username && u.Password == password);
    }

    public async Task<bool> CreateNewUser(string username, string password)
{
    bool userExists = await _dbContext.DBUsers.AnyAsync(u => u.Username == username);
    if (userExists)
    {
        return false; 
    }

    var newUser = new DBUser
    {
        Id = await GetNextAvailableUserId(),
        Username = username,
        Password = password
    };

    await _dbContext.DBUsers.AddAsync(newUser);
    await _dbContext.SaveChangesAsync();
    return true;
}

    public async Task AddLightUpGameScore(int UserId, int newScore, DateTime newDate)
    {
        var newScoreEntry = new DBLightUpGameScore
        {
            UserId = UserId,
            Id = await GetNextAvailableLightUpGameId(),
            Score = newScore,
            Date = newDate
        };

        await _dbContext.DBLightUpGameScores.AddAsync(newScoreEntry);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddMentalHealthGameScore(int UserId, int newScore, DateTime newDate)
    {
        var newScoreEntry = new DBLightUpGameScore
        {
            UserId = UserId,
            Id = await GetNextAvailableMentalHealthId(),
            Score = newScore,
            Date = newDate
        };

        await _dbContext.DBLightUpGameScores.AddAsync(newScoreEntry);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddQuestions(int UserId, int newQuestion1, int newQuestion2, int newQuestion3, int newQuestion4, int newQuestion5, int newQuestion6)
    {
        var newQuestionEntry = new DBQuestionaire
        {
            UserId = UserId,
            Id = await GetNextAvailableQuestionaireId(),
            Question1 = newQuestion1,
            Question2 = newQuestion2,
            Question3 = newQuestion3,
            Question4 = newQuestion4,
            Question5 = newQuestion5,
            Question6 = newQuestion6,
        };

        await _dbContext.DBQuestionaires.AddAsync(newQuestionEntry);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddSteps(int UserId, string newStep1, string newStep2, string newStep3, string newStep4)
    {
        var newStepEntry = new DBPlan
        {
            UserId = UserId,
            Id = await GetNextAvailablePlanId(),
            Step1 = newStep1,
            Step2 = newStep2,
            Step3 = newStep3,
            Step4 = newStep4,
        };

        await _dbContext.DBPlans.AddAsync(newStepEntry);
        await _dbContext.SaveChangesAsync();
    }
   
    public async Task<List<DBLightUpGameScore>> GetLightUpGameScores(string username, DateTime startDate, DateTime endDate)
    {
    return await _dbContext.DBLightUpGameScores
        .Where(score => score.Date.Date >= startDate.Date &&
                        score.Date.Date <= endDate.Date &&
                        score.DBUser.Username == username)
        .ToListAsync();
    }

    public async Task<List<DBMentalHealthGameScore>> GetMentalHealthGameScores(string username, DateTime startDate, DateTime endDate)
    {
    return await _dbContext.DBMentalHealthGameScores
        .Where(score => score.Date.Date >= startDate.Date &&
                        score.Date.Date <= endDate.Date &&
                        score.DBUser.Username == username)
        .ToListAsync();
    }

    public async Task<int?> GetQuestion1(string username, int id)
    {
    return await _dbContext.DBQuestionaires
        .Where(q => q.Id == id && q.DBUser.Username == username)
        .Select(q => q.Question1)
        .FirstOrDefaultAsync();
    } 

    public async Task<int?> GetQuestion2(string username, int id)
    {
    return await _dbContext.DBQuestionaires
        .Where(q => q.Id == id && q.DBUser.Username == username)
        .Select(q => q.Question1)
        .FirstOrDefaultAsync();
    } 

    public async Task<int?> GetQuestion3(string username, int id)
    {
    return await _dbContext.DBQuestionaires
        .Where(q => q.Id == id && q.DBUser.Username == username)
        .Select(q => q.Question1)
        .FirstOrDefaultAsync();
    } 

    public async Task<int?> GetQuestion4(string username, int id)
    {
    return await _dbContext.DBQuestionaires
        .Where(q => q.Id == id && q.DBUser.Username == username)
        .Select(q => q.Question1)
        .FirstOrDefaultAsync();
    } 

    public async Task<int?> GetQuestion5(string username, int id)
    {
    return await _dbContext.DBQuestionaires
        .Where(q => q.Id == id && q.DBUser.Username == username)
        .Select(q => q.Question1)
        .FirstOrDefaultAsync();
    } 

    public async Task<int?> GetQuestion6(string username, int id)
    {
    return await _dbContext.DBQuestionaires
        .Where(q => q.Id == id && q.DBUser.Username == username)
        .Select(q => q.Question1)
        .FirstOrDefaultAsync();
    } 

    public async Task<string?> GetStep1(string username, int id)
    {
    return await _dbContext.DBPlans
        .Where(p => p.Id == id && p.DBUser.Username == username)
        .Select(p => p.Step1)
        .FirstOrDefaultAsync();
    } 
    public async Task<string?> GetStep2(string username, int id)
    {
    return await _dbContext.DBPlans
        .Where(p => p.Id == id && p.DBUser.Username == username)
        .Select(p => p.Step1)
        .FirstOrDefaultAsync();
    } 

    public async Task<string?> GetStep3(string username, int id)
    {
    return await _dbContext.DBPlans
        .Where(p => p.Id == id && p.DBUser.Username == username)
        .Select(p => p.Step1)
        .FirstOrDefaultAsync();
    } 
    
    public async Task<string?> GetStep4(string username, int id)
    {
    return await _dbContext.DBPlans
        .Where(p => p.Id == id && p.DBUser.Username == username)
        .Select(p => p.Step1)
        .FirstOrDefaultAsync();
    } 

        public async Task<List<DBUser>> GetUsersAsync()
    {
        return await _dbContext.DBUsers.ToListAsync();
    }

    public async Task<int> GetNextAvailableUserId()
    {
    int? maxId = await _dbContext.DBUsers.MaxAsync(u => (int)u.Id);
    return (maxId ?? 0) + 1; // If no users exist, start from 1
    }

    private async Task<int> GetNextAvailableLightUpGameId()
    {
    int? maxId = await _dbContext.DBLightUpGameScores.MaxAsync(u => (int?)u.Id);
    return (maxId ?? 0) + 1; // If no users exist, start from 1
    }

    private async Task<int> GetNextAvailableMentalHealthId()
    {
    int? maxId = await _dbContext.DBMentalHealthGameScores.MaxAsync(u => (int?)u.Id);
    return (maxId ?? 0) + 1; // If no users exist, start from 1
    }

    public async Task<int> GetNextAvailableQuestionaireId()
    {
    int? maxId = await _dbContext.DBQuestionaires.MaxAsync(u => (int?)u.Id);
    return (maxId ?? 0) + 1; // If no users exist, start from 1
    }

    public async Task<int> GetQuestionaireId()
    {
    int? maxId = await _dbContext.DBQuestionaires.MaxAsync(u => (int?)u.Id);
    return (maxId ?? 0) ; 
    }

    private async Task<int> GetNextAvailablePlanId()
    {
    int? maxId = await _dbContext.DBPlans.MaxAsync(u => (int?)u.Id);
    return (maxId ?? 0) + 1; // If no users exist, start from 1
    }
}