namespace ToolsCatalog.Services
{
	using Microsoft.AspNet.Hosting;
	using Newtonsoft.Json.Linq;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;
	using System.Threading.Tasks;

	class ToolsCatalogService : IToolsCatalogService
	{
		private readonly IHostingEnvironment _hostingEnvironment;

		public ToolsCatalogService(IHostingEnvironment hostingEnvironment)
		{
			if (hostingEnvironment == null)
			{
				throw new ArgumentNullException("hostingEnvironment");
			}

			_hostingEnvironment = hostingEnvironment;
		}

		public async Task<IEnumerable<ToolEntry>> GetToolsAsync()
		{
			var items = new List<ToolEntry>();
			var path = Path.Combine(_hostingEnvironment.WebRootPath, "data", "tools.json");

			using (var reader = new System.IO.StreamReader(System.IO.File.OpenRead(path)))
			{
				var json = await reader.ReadToEndAsync().ConfigureAwait(false);
				var jObj = JObject.Parse(json);

				var toolsProp = jObj.Property("tools");
				if (toolsProp != null && toolsProp.Value != null)
				{
					var tools = toolsProp.Value as JArray;

					if (tools != null)
					{
						foreach (var to in tools.OfType<JObject>())
						{
							items.Add(
								new ToolEntry
								{
									Name = to.Property("name")?.Value?.Value<string>(),
									Title = to.Property("title")?.Value?.Value<string>(),
									Url = to.Property("url")?.Value?.Value<string>(),
								});
						}
					}
				}
			}

			return items;
		}
    }
}
