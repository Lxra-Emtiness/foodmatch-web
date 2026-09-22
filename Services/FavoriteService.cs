using FoodMatchWeb.Models;

namespace FoodMatchWeb.Services;

public class FavoriteService
{
    private readonly List<Food> _favorites = new();

    public List<Food> GetFavorites()
    {
        return _favorites;
    }

    public void AddFavorite(Food food)
    {
        if (!_favorites.Any(f => f.Name == food.Name))
        {
            _favorites.Add(food);
        }
    }

    public void RemoveFavorite(string foodName)
    {
        var food = _favorites.FirstOrDefault(f => f.Name == foodName);

        if (food != null)
        {
            _favorites.Remove(food);
        }
    }

    public bool IsFavorite(string foodName)
    {
        return _favorites.Any(f => f.Name == foodName);
    }
}