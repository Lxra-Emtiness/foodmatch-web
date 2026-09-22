using FoodMatchWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodMatchWeb.Models;

namespace FoodMatchWeb.Pages;

public class FindFoodModel : PageModel
{
    private readonly FavoriteService _favoriteService;
    private readonly HistoryService _historyService;
    private readonly FoodService _foodService;

    public FindFoodModel(
        FavoriteService favoriteService,
        HistoryService historyService,
        FoodService foodService)
    {
        _favoriteService = favoriteService;
        _historyService = historyService;
        _foodService = foodService;
    }

    [BindProperty]
    public int Budget { get; set; }

    [BindProperty]
    public string Taste { get; set; } = "อะไรก็ได้";

    [BindProperty]
    public string Ingredient { get; set; } = "อะไรก็ได้";

    [BindProperty]
    public string Type { get; set; } = "อะไรก็ได้";

    public bool HasSearched { get; set; }

    public List<FoodResult> Results { get; set; } = new();

    public void OnGet()
    {
    }

    public void OnPost()
    {
        HasSearched = true;

        var foods = _foodService.GetFoods();

        var scoredFoods = new List<FoodResult>();

        foreach (var food in foods)
        {
            if (food.Price > Budget)
            {
                continue;
            }

            int score = 0;

            score += 25;

            if (Ingredient == "อะไรก็ได้")
            {
                score += 20;
            }
            else if (food.Ingredient == Ingredient)
            {
                score += 30;
            }

            if (Taste == "อะไรก็ได้")
            {
                score += 20;
            }
            else if (food.Taste == Taste)
            {
                score += 30;
            }

            if (Type == "อะไรก็ได้")
            {
                score += 10;
            }
            else if (food.Type == Type)
            {
                score += 25;
            }

            score += (int)(food.Rating * 2);

            score = Math.Min(score, 100);

            scoredFoods.Add(new FoodResult
            {
                Food = food,
                Score = score
            });
        }

        Results = scoredFoods
            .OrderByDescending(x => x.Score)
            .Take(3)
            .ToList();

        for (int i = 0; i < Results.Count; i++)
        {
            Results[i].Rank = i + 1;
        }
    }

    public IActionResult OnPostFavorite(string foodName)
    {
        var food = _foodService.GetFood(foodName);

        if (food != null)
        {
            _favoriteService.AddFavorite(food);
        }

        return RedirectToPage("/Favorites");
    }

    public IActionResult OnPostHistory(string foodName)
    {
        var food = _foodService.GetFood(foodName);

        if (food != null)
        {
            _historyService.AddHistory(food);
        }

        return RedirectToPage("/History");
    }
}

public class FoodResult
{
    public int Rank { get; set; }

    public Food Food { get; set; } = new();

    public int Score { get; set; }
}