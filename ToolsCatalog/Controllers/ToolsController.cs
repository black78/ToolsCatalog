// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860
namespace ToolsCatalog.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNet.Mvc;
	using Services;

	public class ToolsController : Controller
	{
		private IToolsCatalogService _toolsCatalogService;

		public ToolsController(IToolsCatalogService toolsCatalogService)
		{
			if (toolsCatalogService == null)
			{
				throw new ArgumentNullException("toolsCatalogService");
			}

			_toolsCatalogService = toolsCatalogService;
		}

		// GET: /<controller>/
		public async Task<IActionResult> Index()
		{
			ViewData["Tools"] = await _toolsCatalogService.GetToolsAsync();
			return View();
		}
	}
}
