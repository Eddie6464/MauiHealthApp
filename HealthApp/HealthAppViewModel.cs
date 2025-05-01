using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace HealthApp;

public class HealthAppViewModel : INotifyPropertyChanged
{
    //connects to healthappservice
    private readonly HealthAppService _service;

    //ensures each table is created and updated when it is changed
    private DBUser? _DBuser;
    public DBUser? DBUser{
        get => _DBuser;
        set 
        {
            _DBuser = value;
            OnPropertyChanged(nameof(DBUser));
        }
    }

    private DBQuestionaire? _DBquestionaire;
    public DBQuestionaire? DBQuestionaire
    {
        get => _DBquestionaire;
        set{
            _DBquestionaire = value;
            OnPropertyChanged(nameof(DBQuestionaire));
        }
    }

    private DBPlan? _DBplan;
    public DBPlan? DBPlan
    {
        get => _DBplan;
        set{
            _DBplan = value;
            OnPropertyChanged(nameof(DBPlan));
        }
    }

    private DBMentalHealthGameScore? _DBmentalHealthGameScore;
    public DBMentalHealthGameScore? DBMentalHealthGameScore
    {
        get => _DBmentalHealthGameScore;
        set{
            _DBmentalHealthGameScore = value;
            OnPropertyChanged(nameof(DBMentalHealthGameScore));
        }
    }

    private DBLightUpGameScore? _DBlightUpGameScore;
    public DBLightUpGameScore? DBLightUpGameScore
    {
        get => _DBlightUpGameScore;
        set{
            _DBlightUpGameScore = value;
            OnPropertyChanged(nameof(DBLightUpGameScore));
        }
    }

    public async Task<int> FetchUserId(string username)
    {
    return (int)await _service.GetUserIdByUsername(username);
    }

    public async Task<bool> CheckIfUsernameExists(string username)
    {
        return await _service.DoesUsernameExist(username);
    }

    public async Task<bool> IsValidUser(string username, string password)
    {
    return await _service.ValidateUserCredentials(username, password);
    }

    public async Task<bool> RegisterUser(string username, string password)
    {
    return await _service.CreateNewUser(username, password);
    }

    public async Task AddLightUpGameScore(int UserId, int newScore, DateTime newDate)
    {
        await _service.AddLightUpGameScore(UserId, newScore, newDate);
    }

    public async Task AddMentalHealthGameScore(int UserId, int newScore, DateTime newDate)
    {
        await _service.AddLightUpGameScore(UserId, newScore, newDate);
    }

    public async Task AddQuestions(int UserId, int newQuestion1, int newQuestion2, int newQuestion3, int newQuestion4, int newQuestion5, int newQuestion6)
    {
        await _service.AddQuestions(UserId, newQuestion1, newQuestion2, newQuestion3, newQuestion4, newQuestion5, newQuestion6);
    }

    public async Task AddSteps(int UserId, string newStep1, string newStep2, string newStep3, string newStep4)
    {
        await _service.AddSteps(UserId, newStep1, newStep2, newStep3, newStep4);
    }

    public async Task GetLightUpGameScores(string username, DateTime startDate, DateTime endDate)
    {
        await _service.GetLightUpGameScores(username, startDate, endDate);
    }

    public async Task GetMentalHealthGameScores(string username, DateTime startDate, DateTime endDate)
    {
        await _service.GetMentalHealthGameScores(username, startDate, endDate);
    }

    public async Task<int> GetNextAvailableQuestionaireId()
    {
        return (int)await _service.GetNextAvailableQuestionaireId();
    }

    public async Task<int> GetQuestionaireId()
    {
        return (int)await _service.GetQuestionaireId();
    }

    public async Task<int> GetQuestion1(string username, int id)
    {
        return (int)await _service.GetQuestion1(username, id);
    }

    public async Task<int> GetQuestion2(string username, int id)
    {
        return (int)await _service.GetQuestion2(username, id);
    }

    public async Task<int> GetQuestion3(string username, int id)
    {
        return (int)await _service.GetQuestion3(username, id);
    }

    public async Task<int> GetQuestion4(string username, int id)
    {
        return (int)await _service.GetQuestion4(username, id);
    }

    public async Task<int> GetQuestion5(string username, int id)
    {
        return (int)await _service.GetQuestion5(username, id);
    }

    public async Task<int> GetQuestion6(string username, int id)
    {
        return (int)await _service.GetQuestion6(username, id);
    }

    public async Task<string> GetStep1(string username, int id)
    {
        return await _service.GetStep1(username, id);
    }

    public async Task<string> GetStep2(string username, int id)
    {
        return await _service.GetStep2(username, id);
    }

    public async Task<string> GetStep3(string username, int id)
    {
        return await _service.GetStep3(username, id);
    }

    public async Task<string> GetStep4(string username, int id)
    {
        return await _service.GetStep4(username, id);
    }

        public HealthAppViewModel(HealthAppService service) 
    {
        _service = service;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
