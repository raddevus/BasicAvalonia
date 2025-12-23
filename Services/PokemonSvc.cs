using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BasicAvalonia.Models;

namespace BasicAvalonia.Services;

public interface IPokeService
{
    Task<PokeData?> GetDataAsync();
}

public class PokeApiService : IPokeService
{
    private readonly HttpClient _http = new();

    public async Task<PokeData?> GetDataAsync()
    {
        var url = "https://pokeapi.co/api/v2/pokemon/";

        var response = await _http.GetAsync(url);
        System.Console.WriteLine($"response: {response}");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
         System.Console.WriteLine($"json: {json}");
        return JsonSerializer.Deserialize<PokeData>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
    }
}

