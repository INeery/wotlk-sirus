using System.Net.Http.Json;
using SirusDbScrapper.Api.DTOs;

namespace SirusDbScrapper.Api;

public class SirusApiClient
{
	private readonly HttpClient _httpClient = new SirusHttpClient();

	public async Task<ItemDetails?> GetItemDetails(string itemId, string realmName = "x1")
	{
		return await _httpClient.GetFromJsonAsync<ItemDetails?>(
			$"https://sirus.su/api/base/{realmName}/details/item/{itemId}", CancellationToken.None);
	}
}
