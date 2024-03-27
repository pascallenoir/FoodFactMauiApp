using System.Net.Http.Json;

namespace FoodFactMauiApp.Services;

public class ProductServices
{
    const string BASE_SEARCH_URL = "https://fr.openfoodfacts.org/cgi/search.pl?action=process&json=true";

    HttpClient client;
    public ProductServices() 
    { 
        client = new();
    }

    public async Task<List<Product>> GetRandomProductsAsync() 
    {
        var page = new Random().Next(1, 1000);
        
        var url = $"{BASE_SEARCH_URL}&page={page}&page_size=10";

        var response = await client.GetAsync(url);

        var products = await GetProductAsync(response);

        return products;
    }

    private async Task<List<Product>> GetProductAsync(HttpResponseMessage responseMessage)
    {
        List<Product> products = new();

        if ( responseMessage.IsSuccessStatusCode) 
        {
            products = (await responseMessage.Content.ReadFromJsonAsync<ProductsResult>()).Products;
        }

        return products;
    }
}

