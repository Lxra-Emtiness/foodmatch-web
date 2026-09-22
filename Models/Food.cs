namespace FoodMatchWeb.Models;

public class Food
{
    public string Name { get; set; } = "";

    public int Price { get; set; }

    public string Ingredient { get; set; } = "";

    public string Taste { get; set; } = "";

    public string Type { get; set; } = "";

    public double Rating { get; set; }
}