namespace ToolsCatalog.Languages.Dto
{
	/// <summary>
	/// A data transfer object for a language.
	/// </summary>
	internal class LanguageDto
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LanguageDto"/> class.
		/// </summary>
		public LanguageDto()
		{
			Children = new LanguageDto[0];
		}

		/// <summary>
		/// Gets or sets the ToolsCatalog specific LCID.
		/// </summary>
		public int Lcid { get; set; }

		/// <summary>
		/// Gets or sets the Windows compatible LCID.
		/// </summary>
		public int SystemLcid { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the language is neutral.
		/// </summary>
		public bool IsNeutral { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the language is ToolsCatalog specific.
		/// </summary>
		public bool IsToolsCatalogSpecific { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the language is simplified.
		/// </summary>
		public bool IsSimplified { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the language is uncorrected.
		/// </summary>
		public bool IsUncorrected { get; set; }

		/// <summary>
		/// Gets or sets the language name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the default code page.
		/// </summary>
		public int DefaultCodePage { get; set; }

		/// <summary>
		/// Gets or sets the abbreviation.
		/// </summary>
		public string Abbreviation { get; set; }

		/// <summary>
		/// Gets or sets the children.
		/// </summary>
		public LanguageDto[] Children { get; set; }
	}
}
