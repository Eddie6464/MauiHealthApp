namespace EnergyHealthApp.ViewModels;
using EnergyHealthApp.Services;

public class UpdateQuestionnaireViewModel(EnergyHealthAppService service)
{
    private readonly EnergyHealthAppService _service = service;

    public async Task UpdateQuestionnaireResults(int userId, int q1, int q2, int q3, int q4, int q5)
    {
        await _service.UpdateQuestionnaireResults(userId, q1, q2, q3, q4, q5);
    }

}
