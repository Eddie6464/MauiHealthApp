namespace EnergyHealthApp.ViewModels;
using System.ComponentModel;
using EnergyHealthApp.Services;
using EnergyHealthApp.Data.Models;

public class ViewQuestionnaireResultsViewModel(EnergyHealthAppService service) : INotifyPropertyChanged
{

    private readonly EnergyHealthAppService _service = service;
    private User? _user;
    public User? User{
        get => _user;
        set 
        {
            _user = value;
            OnPropertyChanged(nameof(User));
        }
    }

    private EnergyQuestionnaire? _energyQuestionnaire;
    public EnergyQuestionnaire? EnergyQuestionnaire
    {
        get => _energyQuestionnaire;
        set{
            _energyQuestionnaire = value;
            OnPropertyChanged(nameof(EnergyQuestionnaire));
        }
    }

    public async Task LoadUserData(int userId)
    {
        User = await _service.GetUserById(userId);
        EnergyQuestionnaire = User?.EnergyQuestionnaire;
        EnergyQuestionnaire?.CalculateScore();
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}