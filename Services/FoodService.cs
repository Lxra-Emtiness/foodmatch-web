using FoodMatchWeb.Models;

namespace FoodMatchWeb.Services;

public class FoodService
{
    private readonly List<Food> _foods = new()
    {
        new Food
        {
            Name = "กะเพราหมู",
            Price = 60,
            Ingredient = "หมู",
            Taste = "เผ็ด",
            Type = "อาหารจานเดียว",
            Rating = 4.7
        },

        new Food
        {
            Name = "กะเพราไก่",
            Price = 55,
            Ingredient = "ไก่",
            Taste = "เผ็ด",
            Type = "อาหารจานเดียว",
            Rating = 4.6
        },

        new Food
        {
            Name = "ข้าวมันไก่",
            Price = 50,
            Ingredient = "ไก่",
            Taste = "ไม่เผ็ด",
            Type = "อาหารจานเดียว",
            Rating = 4.5
        },

        new Food
        {
            Name = "ก๋วยเตี๋ยวหมู",
            Price = 50,
            Ingredient = "หมู",
            Taste = "เค็ม",
            Type = "เส้น",
            Rating = 4.3
        },

        new Food
        {
            Name = "ก๋วยเตี๋ยวต้มยำ",
            Price = 60,
            Ingredient = "หมู",
            Taste = "เผ็ด",
            Type = "เส้น",
            Rating = 4.6
        },

        new Food
        {
            Name = "ผัดไทยกุ้ง",
            Price = 80,
            Ingredient = "ทะเล",
            Taste = "หวาน",
            Type = "เส้น",
            Rating = 4.8
        },

        new Food
        {
            Name = "ข้าวผัดกุ้ง",
            Price = 75,
            Ingredient = "ทะเล",
            Taste = "เค็ม",
            Type = "อาหารจานเดียว",
            Rating = 4.5
        },

        new Food
        {
            Name = "ข้าวผัดเนื้อ",
            Price = 90,
            Ingredient = "เนื้อ",
            Taste = "เค็ม",
            Type = "อาหารจานเดียว",
            Rating = 4.4
        },

        new Food
        {
            Name = "ส้มตำไก่ย่าง",
            Price = 70,
            Ingredient = "ไก่",
            Taste = "เผ็ด",
            Type = "อาหารจานเดียว",
            Rating = 4.8
        },

        new Food
        {
            Name = "ข้าวไข่เจียว",
            Price = 40,
            Ingredient = "ไข่",
            Taste = "เค็ม",
            Type = "อาหารจานเดียว",
            Rating = 4.2
        },

        new Food
        {
            Name = "มาม่าหมู",
            Price = 45,
            Ingredient = "หมู",
            Taste = "เผ็ด",
            Type = "เส้น",
            Rating = 4.1
        },

        new Food
        {
            Name = "สปาเกตตีไก่",
            Price = 80,
            Ingredient = "ไก่",
            Taste = "ไม่เผ็ด",
            Type = "เส้น",
            Rating = 4.4
        },

        new Food
        {
            Name = "ชาบู",
            Price = 150,
            Ingredient = "หมู",
            Taste = "เผ็ด",
            Type = "บุฟเฟต์",
            Rating = 4.9
        },

        new Food
        {
            Name = "หมูกระทะ",
            Price = 150,
            Ingredient = "หมู",
            Taste = "เค็ม",
            Type = "บุฟเฟต์",
            Rating = 4.9
        },

        new Food
        {
            Name = "ข้าวหน้าปลา",
            Price = 100,
            Ingredient = "ทะเล",
            Taste = "เค็ม",
            Type = "อาหารจานเดียว",
            Rating = 4.5
        }
    };

    public List<Food> GetFoods()
    {
        return _foods;
    }

    public Food? GetFood(string name)
    {
        return _foods.FirstOrDefault(x => x.Name == name);
    }

    public Food? GetRandomFood()
    {
        Random random = new();

        return _foods[random.Next(_foods.Count)];
    }
}