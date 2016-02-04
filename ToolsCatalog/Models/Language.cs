using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolsCatalog.Models
{
    public class Language
    {
		public int Lcid { get; set; }

		public int PrimaryLangId { get; set; }

		public int SubLangId { get; set; }

		public string Name { get; set; }
	}
}
