using FoodMatchWeb.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMatchWeb.Pages;

public class StatisticsModel : PageModel
{
    private readonly HistoryService _historyService;

    public int TotalFoods { get; set; }

    public double AveragePrice { get; set; }

    public double AverageRating { get; set; }

    public string? MostSelectedFood { get; set; }

    public string MostSelectedTaste { get; set; } = "-";

    public string MostSelectedIngredient { get; set; } = "-";

    public string MostSelectedType { get; set; } = "-";

    public StatisticsModel(HistoryService historyService)
    {
        _historyService = historyService;
    }

    public void OnGet()
    {
        var history = _historyService.GetHistory();

        if (history.Count == 0)
        {
            return;
        }

        TotalFoods = history.Count;

        AveragePrice = history
            .Average(x => x.Food.Price);

        AverageRating = history
            .Average(x => x.Food.Rating);

        MostSelectedFood = history
            .GroupBy(x => x.Food.Name)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;

        MostSelectedTaste = history
            .GroupBy(x => x.Food.Taste)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;

        MostSelectedIngredient = history
            .GroupBy(x => x.Food.Ingredient)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;

        MostSelectedType = history
            .GroupBy(x => x.Food.Type)
            .OrderByDescending(x => x.Count())
            .First()
            .Key;
    }
}