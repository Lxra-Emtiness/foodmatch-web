using FoodMatchWeb.Models;
using FoodMatchWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMatchWeb.Pages;

public class FavoritesModel : PageModel
{
    private readonly FavoriteService _favoriteService;

    public List<Food> Favorites { get; set; } = new();

    public FavoritesModel(FavoriteService favoriteService)
    {
        _favoriteService = favoriteService;
    }

    public void OnGet()
    {
        LoadFavorites();
    }

    public IActionResult OnPostRemove(string foodName)
    {
        _favoriteService.RemoveFavorite(foodName);

        return RedirectToPage();
    }

    private void LoadFavorites()
    {
        Favorites = _favoriteService.GetFavorites();
    }
}