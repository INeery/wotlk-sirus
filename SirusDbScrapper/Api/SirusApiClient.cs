namespace SirusDbScrapper.Api;

public class SirusApiClient
{
    private readonly HttpClient _httpClient;
    
    // Итем с базы -  https://sirus.su/api/base/item/46200/42?lang=ru

    public SirusApiClient()
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://sirus.su/api/"),

        };
    }
}