﻿using System.Text.Json.Serialization;

namespace FoodFactMauiApp.Model;

public class Product
{
    public string Code { get; set; }

    public string Url { get; set; }

    [JsonPropertyName("product_name")]
    public string ProductName { get; set; }   

    public string GenericName { get; set; }

    public string Quantity { get; set; }

    [JsonPropertyName("ingredients_text")]
    public string IngredientsText { get; set; }  
    
    public string Brands {  get; set; }

    [JsonPropertyName("nutriscore_grade")]
    public string NutriscoreGrade { get; set; }

    public string NutriscoreGradeimage 
    { 
        get => $"nutriscore_{NutriscoreGrade}.png"; 

    }

    [JsonPropertyName("image_url")]
    public string ImageUrl { get; set; }  
}
