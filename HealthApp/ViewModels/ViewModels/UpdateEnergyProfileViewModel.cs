namespace EnergyHealthApp.ViewModels;
using EnergyHealthApp.Services;

public class UpdateEnergyProfileViewModel(EnergyHealthAppService service)
{
    private readonly EnergyHealthAppService _service = service;

    public async Task UpdateHeartRate(int userId, int newHeartRate)
    {
        await _service.UpdateHeartRate(userId, newHeartRate);
    }

    public async Task UpdateBloodPressure(int userId, string newBloodPressure)
    {
        await _service.UpdateBloodPressure(userId, newBloodPressure);
    }

    public async Task UpdateRespiratoryRate(int userId, int newRespiratoryRate)
    {
        await _service.UpdateRespiratoryRate(userId, newRespiratoryRate);
    }

}