using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FoodMatchWeb.Models;

namespace FoodMatchWeb.Pages;


public class IndexModel : PageModel
{
    public Food? ResultFood { get; set; }

    public int MatchScore { get; set; }

    [BindProperty]
    public int Budget { get; set; }

    [BindProperty]
    public string Taste { get; set; } = "";

    [BindProperty]
    public string Ingredient { get; set; } = "";

    [BindProperty]
    public string Type { get; set; } = "";

    private readonly List<Food> Foods = new()
    {
        new Food
        {
            Name = "กะเพราหมู",
            Price = 60,
            Ingredient = "หมู",
            Taste = "เผ็ด",
            Type = "อาหารจานเดียว"
        },

        new Food
        {
            Name = "กะเพราไก่",
            Price = 55,
            Ingredient = "ไก่",
            Taste = "เผ็ด",
            Type = "อาหารจานเดียว"
        },

        new Food
        {
            Name = "ข้าวมันไก่",
            Price = 50,
            Ingredient = "ไก่",
            Taste = "ไม่เผ็ด",
            Type = "อาหารจานเดียว"
        },

        new Food
        {
            Name = "ก๋วยเตี๋ยวต้มยำ",
            Price = 60,
            Ingredient = "หมู",
            Taste = "เผ็ด",
            Type = "เส้น"
        },

        new Food
        {
            Name = "ข้าวผัดกุ้ง",
            Price = 75,
            Ingredient = "ทะเล",
            Taste = "เค็ม",
            Type = "อาหารจานเดียว"
        },

        new Food
        {
            Name = "ข้าวไข่เจียว",
            Price = 40,
            Ingredient = "ไข่",
            Taste = "เค็ม",
            Type = "อาหารจานเดียว"
        }
    };

    public void OnGet()
    {
    }

    public void OnPost()
    {
        var results = new List<(Food Food, int Score)>();

        foreach (var food in Foods)
        {
            int score = 0;

            if (food.Price <= Budget)
            {
                score += 25;
            }
            else
            {
                continue;
            }

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

            results.Add((food, score));
        }

        if (results.Count > 0)
        {
            var best = results
                .OrderByDescending(x => x.Score)
                .First();

            ResultFood = best.Food;

            MatchScore = Math.Min(best.Score, 100);
        }
    }
}