using FoodMatchWeb.Models;
using FoodMatchWeb.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMatchWeb.Pages;

public class RandomFoodModel : PageModel
{
    private readonly HistoryService _historyService;
    private readonly FoodService _foodService;

    public RandomFoodModel(
        HistoryService historyService,
        FoodService foodService)
    {
        _historyService = historyService;
        _foodService = foodService;
    }

    public Food? RandomResult { get; set; }

    public void OnGet()
    {
    }

    public void OnPost()
    {
        RandomResult = _foodService.GetRandomFood();

        if (RandomResult != null)
        {
            _historyService.AddHistory(RandomResult);
        }
    }
}