namespace ToolsCatalog.Languages
{
	using System.Runtime.InteropServices;

	/// <summary>
	/// The LanguageDisplayName interface.
	/// </summary>
	[ComVisible(true)]
	[Guid("1EB3BAA1-31A4-455D-8D03-4D77BB763CE7")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface ILanguageDisplayName
	{
		/// <summary>
		/// Gets the full name.
		/// </summary>
		string FullName { get; }

		/// <summary>
		/// Gets the name of the language.
		/// </summary>
		string LanguageName { get; }

		/// <summary>
		/// Gets the name of the country.
		/// </summary>
		string CountryName { get; }
	}
}