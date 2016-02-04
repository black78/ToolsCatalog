namespace ToolsCatalog.Languages
{
	using System.Runtime.InteropServices;

	/// <summary>
	/// The Language interface.
	/// </summary>
	[ComVisible(true)]
	[Guid("0FE448EB-ECC7-44E2-92D5-C9B808EE7DDA")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface ILanguage
	{
		/// <summary>
		/// Gets the ToolsCatalog specific LCID.
		/// </summary>
		int Lcid { get; }

		/// <summary>
		/// Gets the Windows compatible LCID.
		/// </summary>
		int SystemLcid { get; }

		/// <summary>
		/// Gets a value indicating whether the language is specific to ToolsCatalog and is not supported by Windows.
		/// </summary>
		bool IsToolsCatalogSpecific { get; }

		/// <summary>
		/// Gets a value indicating whether the language represents a neutral culture, i.e. it is not country specific.
		/// </summary>
		bool IsNeutral { get; }

		/// <summary>
		/// Gets a value indicating whether the language is simplified.
		/// Some languages have a "native" simplified variation (e.g. Chinese), others don't.
		/// The latter will still get an artificial simplified language created by ToolsCatalog.
		/// </summary>
		bool IsSimplified { get; }

		/// <summary>
		/// Gets a value indicating whether the language is surrogate and created by ToolsCatalog. Content written in this language
		/// is treated as not processed by a corrector.
		/// </summary>
		bool IsUncorrected { get; }

		/// <summary>
		/// Gets the name. The name is abbreviation, same as <c>CultureInfo.Name</c>.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Gets the abbreviation.
		/// </summary>
		string Abbreviation { get; }

		/// <summary>
		/// Gets the default code page.
		/// </summary>
		int DefaultCodePage { get; }

		/// <summary>
		/// Gets the primary language corresponding to this sub language
		/// (if this is actually a sublanguage; otherwise null).
		/// </summary>
		Language Parent { get; }

		/// <summary>
		/// Gets the sub languages of this language.
		/// </summary>
		LanguageCollection Children { get; }

		/// <summary>
		/// Retrieves the name of this language in the specified locale.
		/// </summary>
		/// <param name="locale">
		/// Target locale.
		/// </param>
		/// <returns>
		/// The <see cref="LanguageDisplayName"/>.
		/// </returns>
		LanguageDisplayName GetDisplayName(Locale locale);
	}
}