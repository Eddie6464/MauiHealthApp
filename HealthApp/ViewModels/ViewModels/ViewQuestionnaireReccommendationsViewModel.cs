namespace EnergyHealthApp.ViewModels;
using System.ComponentModel;
using EnergyHealthApp.Services;
using System.Collections.ObjectModel;


public class ViewQuestionnaireRecommendationsViewModel(EnergyHealthAppService _service)
{

    public ObservableCollection<string> Recommendations {get;} = new();

    public async Task LoadRecommendations(int userId)
    {
        var user = await _service.GetUserById(userId);
        var questionnaire = user?.EnergyQuestionnaire;

        if (questionnaire != null)
        {
            questionnaire.CalculateScore();
            var recs = questionnaire.GetRecommendations();

            Recommendations.Clear();
            foreach (var rec in recs)
            {
                Recommendations.Add(rec);
            }
        }
    }
    
}