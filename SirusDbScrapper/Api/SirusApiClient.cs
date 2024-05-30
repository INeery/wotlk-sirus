using System.Net.Http.Json;
using SirusDbScrapper.Api.DTOs;

namespace SirusDbScrapper.Api;

public class SirusApiClient
{
	private const string ItemRelativePathTemplate = "/x1/tooltip/item/45456/";
	// Итем с базы -  https://sirus.su/api/base/item/46200/42?lang=ru

	private readonly HttpClient _httpClient = new SirusHttpClient();


	public async Task<ItemDetails?> GetItemDetails(string itemId, string realmName = "x1")
	{
		//var resp = await _httpClient.GetAsync($"https://sirus.su/api/base/{realmName}/details/item/{itemId}");

		return await _httpClient.GetFromJsonAsync<ItemDetails?>(
			$"https://sirus.su/api/base/{realmName}/details/item/{itemId}", CancellationToken.None);
	}
}
