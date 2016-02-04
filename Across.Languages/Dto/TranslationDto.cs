namespace Across.Languages.Dto
{
	/// <summary>
	/// A data transfer object for a translation.
	/// </summary>
	internal class TranslationDto
	{
		/// <summary>
		/// Gets or sets the LCID.
		/// </summary>
		public int Lcid { get; set; }

		/// <summary>
		/// Gets or sets the language name.
		/// </summary>
		public string LanguageName { get; set; }

		/// <summary>
		/// Gets or sets the country name.
		/// </summary>
		public string CountryName { get; set; }
	}
}
