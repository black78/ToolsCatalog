using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToolsCatalog.Services
{
	public interface IToolsCatalogService
	{
		Task<IEnumerable<ToolEntry>> GetToolsAsync();
	}
}