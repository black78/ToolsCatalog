namespace Across.Languages
{
	using System.Runtime.InteropServices;

	/// <summary>
	/// The LanguagesProvider interface.
	/// </summary>
	[Guid("DC583FA8-4C7B-4B1D-AC28-43A78BFF1C43")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface ILanguagesProvider
	{
		/// <summary>
		/// Returns a collection of languages with parent-child relations.
		/// </summary>
		/// <returns>A hierarchical collection of languages.</returns>
		LanguageCollection GetLanguages();

		/// <summary>
		/// Returns a flat collection of languages (languages and sub languages in the same collection).
		/// </summary>
		/// <returns>A flat collection of languages.</returns>
		LanguageCollection GetFlatLanguages();
	}
}