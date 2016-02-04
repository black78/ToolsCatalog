namespace ToolsCatalog.Languages
{
	using System.Collections;
	using System.Runtime.InteropServices;

	/// <summary>
	/// The LanguageCollection interface.
	/// </summary>
	[ComVisible(true)]
	[Guid("D0215F5B-605A-49F1-99B7-156C711ABDE9")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface ILanguageCollection
	{
		/// <summary>
		/// Gets the count.
		/// </summary>
		int Count { get; }

		/// <summary>
		/// The this accessor.
		/// </summary>
		/// <param name="index">
		/// The index.
		/// </param>
		/// <returns>
		/// The language.
		/// </returns>
		Language this[int index] { get; }

		/// <summary>
		/// The new enumerator.
		/// </summary>
		/// <returns>
		/// The <see cref="IEnumerator"/>.
		/// </returns>
		IEnumerator _NewEnum();

		/// <summary>
		/// Checks the collection for containing element.
		/// </summary>
		/// <param name="item">
		/// The language.
		/// </param>
		/// <returns>
		/// true is exist,false otherwise.
		/// </returns>
		bool Contains(Language item);

		/// <summary>
		/// Gets index of element in collection.
		/// </summary>
		/// <param name="item">
		/// The language.
		/// </param>
		/// <returns>
		/// The index of language.
		/// </returns>
		int IndexOf(Language item);

		/// <summary>
		/// Gets the language.
		/// </summary>
		/// <param name="lcid">
		/// The lcid.
		/// </param>
		/// <returns>
		/// The language.
		/// </returns>
		Language GetLanguage(uint lcid);
	}
}