using System.Text;
using System.Text.Json;
using FormulaOne.Shared.Models;

namespace FormulaOne.Client.Services;

public class DriverService : IDriverService
{
    private readonly HttpClient _httpClient;

    public DriverService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool?> AddDriver(Driver driver)
    {
        try
        {
            var itemJson = new StringContent(JsonSerializer.Serialize(driver), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/drivers", itemJson);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStreamAsync();

                return response.IsSuccessStatusCode;
            }

            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex}");
            throw;
        }
    }

    public async Task<IEnumerable<Driver>?> All()
    {
        try
        {
            var apiResponse = await _httpClient.GetStreamAsync("api/drivers");

            var drivers = await JsonSerializer.DeserializeAsync<IEnumerable<Driver>>(apiResponse,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return drivers;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/drivers/{id}");

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }

    public async Task<Driver?> GetDriver(int id)
    {
        try
        {
            var apiResponse = await _httpClient.GetStreamAsync($"api/drivers/{id}");

            var driver = await JsonSerializer.DeserializeAsync<Driver>(apiResponse,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return driver;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }


    public async Task<bool> Update(Driver driver)
    {
        try
        {
            var itemJson = new StringContent(JsonSerializer.Serialize(driver), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"api/drivers/{driver.Id}", itemJson);

            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            throw;
        }
    }
}