namespace ToolsCatalog.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	using Microsoft.AspNet.Mvc;
	using ToolsCatalog.Models;

	public class LanguagesController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

		[HttpGet]
		public IEnumerable<Language> GetLanguages()
		{
			return new Language[] 
			{
				new Language { Lcid = 1033, PrimaryLangId = 9, SubLangId = 1, Name = "English US"},
				new Language { Lcid = 1031, PrimaryLangId = 7, SubLangId = 1, Name = "German DE"},
			};
		}
    }
}
