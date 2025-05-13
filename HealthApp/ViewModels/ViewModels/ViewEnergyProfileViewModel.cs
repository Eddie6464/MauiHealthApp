namespace EnergyHealthApp.ViewModels;
using System.ComponentModel;
using EnergyHealthApp.Services;
using EnergyHealthApp.Data.Models;

public class ViewEnergyProfileViewModel(EnergyHealthAppService service) : INotifyPropertyChanged
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

    private EnergyProfile? _energyProfile;
    public EnergyProfile? EnergyProfile
    {
        get => _energyProfile;
        set{
            _energyProfile = value;
            OnPropertyChanged(nameof(EnergyProfile));
        }
    }

    public async Task LoadUserData(int userId)
    {
        User = await _service.GetUserById(userId);
        EnergyProfile = User?.EnergyProfile;
        EnergyProfile?.CalculateScore();
    }



    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}