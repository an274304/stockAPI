using ApplicationLayer;

namespace StockApproval.Utilities
{
	public class UrlService : IUrlService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public UrlService(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public string GetBaseUrl()
		{
			var request = _httpContextAccessor.HttpContext?.Request;
			if (request == null) return string.Empty;

			var scheme = request.Scheme; // e.g., http or https
			var host = request.Host;     // e.g., localhost:5000
			var pathBase = request.PathBase; // e.g., /api

			return $"{scheme}://{host}{pathBase}";
		}
	}
}
