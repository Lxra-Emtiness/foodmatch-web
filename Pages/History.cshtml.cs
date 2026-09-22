using FoodMatchWeb.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodMatchWeb.Pages;

public class HistoryModel : PageModel
{
    private readonly HistoryService _historyService;

    public List<HistoryItem> History { get; set; } = new();

    public HistoryModel(HistoryService historyService)
    {
        _historyService = historyService;
    }

    public void OnGet()
    {
        LoadHistory();
    }

    public IActionResult OnPostRemove(string foodName)
    {
        _historyService.RemoveHistory(foodName);

        return RedirectToPage();
    }

    public IActionResult OnPostClear()
    {
        _historyService.ClearHistory();

        return RedirectToPage();
    }

    private void LoadHistory()
    {
        History = _historyService.GetHistory();
    }
}