namespace ToolsCatalog.Languages
{
	using System.Collections.Generic;
	using System.Runtime.InteropServices;

	using ToolsCatalog.Languages.Dto;

	/// <summary>
	/// Represents a language with parent-child relations.
	/// </summary>
	[ComVisible(true)]
	[Guid("ECB9DFAA-E570-438B-8AEB-674767B25250")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class Language : ILanguage
	{
		/// <summary>
		/// The display name provider.
		/// </summary>
		private readonly LanguageDisplayNameProvider _displayNameProvider;

		/// <summary>
		/// Initializes a new instance of the <see cref="Language"/> class.
		/// </summary>
		/// <param name="languageDto">
		/// The data transfer object with language data.
		/// </param>
		/// <param name="displayNameProvider">
		/// A language name translation provider.
		/// </param>
		/// <param name="flat">Indicates that no children should be created.</param>
		internal Language(
			LanguageDto languageDto,
			LanguageDisplayNameProvider displayNameProvider,
			bool flat)
		{
			_displayNameProvider = displayNameProvider;

			Lcid = languageDto.Lcid;
			SystemLcid = languageDto.SystemLcid;
			IsNeutral = languageDto.IsNeutral;
			IsToolsCatalogSpecific = languageDto.IsToolsCatalogSpecific;
			IsSimplified = languageDto.IsSimplified;
			IsUncorrected = languageDto.IsUncorrected;
			Name = languageDto.Name;
			DefaultCodePage = languageDto.DefaultCodePage;
			Abbreviation = languageDto.Abbreviation;

			var children = new List<Language>();

			if (!flat)
			{
				foreach (LanguageDto child in languageDto.Children)
				{
					var childLanguage = new Language(child, displayNameProvider, false) { Parent = this };
					children.Add(childLanguage);
				}
			}

			Children = new LanguageCollection(children);
		}

		/// <summary>
		/// Gets the ToolsCatalog specific LCID.
		/// </summary>
		public int Lcid { get; private set; }

		/// <summary>
		/// Gets the Windows compatible LCID.
		/// </summary>
		public int SystemLcid { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the language is specific to ToolsCatalog and is not supported by Windows.
		/// </summary>
		public bool IsToolsCatalogSpecific { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the language represents a neutral culture, i.e. it is not country specific.
		/// </summary>
		public bool IsNeutral { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the language is simplified.
		/// Some languages have a "native" simplified variation (e.g. Chinese), others don't.
		/// The latter will still get an artificial simplified language created by ToolsCatalog.
		/// </summary>
		public bool IsSimplified { get; private set; }

		/// <summary>
		/// Gets a value indicating whether the language is surrogate and created by ToolsCatalog. Content written in this language
		/// is treated as not processed by a corrector.
		/// </summary>
		public bool IsUncorrected { get; private set; }

		/// <summary>
		/// Gets the name. The name is abbreviation, same as <c>CultureInfo.Name</c>.
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Gets the abbreviation.
		/// </summary>
		public string Abbreviation { get; private set; }

		/// <summary>
		/// Gets the default code page.
		/// </summary>
		public int DefaultCodePage { get; private set; }

		/// <summary>
		/// Gets the primary language corresponding to this sublanguage
		/// (if this is actually a sublanguage; otherwise null).
		/// </summary>
		public Language Parent { get; private set; }

		/// <summary>
		/// Gets the sublanguages of this language.
		/// </summary>
		public LanguageCollection Children { get; private set; }

		/// <summary>
		/// Retrieves the name of this language in the specified locale.
		/// </summary>
		/// <param name="locale">
		/// Target locale.
		/// </param>
		/// <returns>
		/// The <see cref="LanguageDisplayName"/>.
		/// </returns>
		public LanguageDisplayName GetDisplayName(Locale locale)
		{
			return _displayNameProvider.GetDisplayName(locale, Lcid);
		}
	}
}
