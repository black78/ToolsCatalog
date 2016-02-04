namespace ToolsCatalog.Languages
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.InteropServices;

	/// <summary>
	/// The language collection.
	/// </summary>
	[ComVisible(true)]
	[ClassInterface(ClassInterfaceType.None)]
	[Guid("E015E57C-1668-4C0A-8F96-B884785544A5")]
	public class LanguageCollection
		: ReadOnlyComCollection<Language>,
			ILanguageCollection
	{
		/// <summary>
		/// The map of items.
		/// </summary>
		private readonly Lazy<Dictionary<uint, Language>> _mapOfItems;

		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="LanguageCollection"/> class.
		/// </summary>
		/// <param name="collection">
		/// The collection.
		/// </param>
		internal LanguageCollection(IList<Language> collection)
			: base(collection)
		{
			_mapOfItems =
				new Lazy<Dictionary<uint, Language>>(() => Items.ToDictionary(language => (uint)language.Lcid));
		}

		#endregion

		/// <summary>
		/// Gets the language.
		/// </summary>
		/// <param name="lcid">
		/// The lcid.
		/// </param>
		/// <returns>
		/// The language.
		/// </returns>
		public Language GetLanguage(uint lcid)
		{
			Language language;
			_mapOfItems.Value.TryGetValue(lcid, out language);

			return language;
		}
	}
}