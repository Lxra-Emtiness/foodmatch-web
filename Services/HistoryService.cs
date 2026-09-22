using FoodMatchWeb.Models;

namespace FoodMatchWeb.Services;

public class HistoryService
{
    private readonly List<HistoryItem> _history = new();

    public List<HistoryItem> GetHistory()
    {
        return _history;
    }

    public void AddHistory(Food food)
    {
        // ถ้ามีเมนูเดิมอยู่แล้ว ให้ลบของเก่าออก
        _history.RemoveAll(x => x.Food.Name == food.Name);

        // เพิ่มรายการใหม่ไว้ด้านบน
        _history.Insert(0, new HistoryItem
        {
            Food = food,
            DateTime = System.DateTime.Now
        });

        // เก็บสูงสุด 20 รายการ
        if (_history.Count > 20)
        {
            _history.RemoveAt(_history.Count - 1);
        }
    }

    public void RemoveHistory(string foodName)
    {
        var item = _history.FirstOrDefault(
            x => x.Food.Name == foodName
        );

        if (item != null)
        {
            _history.Remove(item);
        }
    }

    public void ClearHistory()
    {
        _history.Clear();
    }
}

public class HistoryItem
{
    public Food Food { get; set; } = new();

    public System.DateTime DateTime { get; set; }
}