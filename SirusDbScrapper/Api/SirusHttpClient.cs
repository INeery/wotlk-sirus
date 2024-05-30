using System.Net;
using System.Net.Http.Headers;

namespace SirusDbScrapper.Api;

public class SirusHttpClient : HttpClient
{
	private const string SirusBaseApiUrl = "https://sirus.su/api/base";

	private static readonly HttpClientHandler handler = new HttpClientHandler()
	{
		AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
	};

	public SirusHttpClient() : base(handler)
	{
		BaseAddress = new Uri(SirusBaseApiUrl);

		DefaultRequestVersion = HttpVersion.Version20;
		DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrLower;

		DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/html"));
		DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xhtml+xml"));
		DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
		DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/avif"));
		DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/webp"));
		DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/apng"));
		DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
		DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/signed-exchange"));


		DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
		DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
		DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("br"));
		DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("zstd"));

		DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("ru-RU"));
		DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("ru"));

		DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
		{
			MaxAge = TimeSpan.Zero
		};


		// DefaultRequestHeaders.TryAddWithoutValidation("Accept", new[] { "v=b3", "q=0.7", "q=0.8", "q=0.9" });
		// DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", new[] { "q=0.9" });
		//
		// DefaultRequestHeaders.TryAddWithoutValidation("Pragma", new[] { "no-cache" });
		// DefaultRequestHeaders.TryAddWithoutValidation("Priority", new[] { "u=0, i" });
		// DefaultRequestHeaders.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
		// DefaultRequestHeaders.TryAddWithoutValidation("Sec-Fetch-User", "?1");
		// DefaultRequestHeaders.TryAddWithoutValidation("Sec-Fetch-Site", "none");
		// DefaultRequestHeaders.TryAddWithoutValidation("Sec-Fetch-Mode", "navigate");
		// DefaultRequestHeaders.TryAddWithoutValidation("Sec-Fetch-Dest", "document");
		// DefaultRequestHeaders.TryAddWithoutValidation("Sec-Ch-Ua-Platform", "Linux");
		// DefaultRequestHeaders.TryAddWithoutValidation("Sec-Ch-Ua-Mobile", "?0");
		// DefaultRequestHeaders.TryAddWithoutValidation("Sec-Ch-Ua", "Google Chrome\";v=\"125\", \"Chromium\";v=\"125\", \"Not.A/Brand\";v=\"24");
		DefaultRequestHeaders.TryAddWithoutValidation("User-Agent",
			"Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/125.0.0.0 Safari/537.36");
	}
}
