using Google.Protobuf;
using SirusDbScrapper.Api;
using SirusDbScrapper.UIDatabase;

namespace SirusDbScrapper;

internal class Program
{
	public static async Task Main(string[] args)
	{
		var uiDb = await GetUiDatabase();
		var apiClient = new SirusApiClient();

		if (args.Contains("updateItemStats"))
		{
			//TODO обновить статы вещей из списка UpdateStatsItems.txt
		}

		if ( true || args.Contains("updateUlduarPhaseItems"))
		{
			var updatedItems = await UpdateUlduarItemsStats(uiDb, apiClient);
		}

		JsonFormatter formatter = new JsonFormatter(JsonFormatter.Settings.Default.WithIndentation());
		var output = formatter.Format(uiDb);

		File.WriteAllText("db.json", output);

		Console.WriteLine("Saved");
	}

	private static async Task<UIItem[]> UpdateUlduarItemsStats(UIDatabase.UIDatabase uiDb, SirusApiClient apiClient)
	{
		var ulduarItems = uiDb.Items.Where(item => item.Phase == 2).ToList();

		foreach (var dbItem in ulduarItems)
		{
			var sirusItemDetails = await apiClient.GetItemDetails(dbItem.Id.ToString());
		}

		return null;
	}

	private static async Task<UIDatabase.UIDatabase> GetUiDatabase()
	{
		await using var dbInput = File.OpenRead("Database/originalSimDb.bin");
		return UIDatabase.UIDatabase.Parser.ParseFrom(dbInput);
	}
}
