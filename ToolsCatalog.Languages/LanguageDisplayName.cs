namespace ToolsCatalog.Languages
{
	using System;
	using System.Runtime.InteropServices;

	/// <summary>
	/// Represents the name of a language.
	/// </summary>
	[ComVisible(true)]
	[Guid("32AD908D-C5CF-4BCF-9B62-6951DDDF7118")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class LanguageDisplayName : ILanguageDisplayName
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="LanguageDisplayName"/> class for a neutral culture.
		/// </summary>
		/// <param name="languageName">Name of the language.</param>
		internal LanguageDisplayName(string languageName)
			: this(languageName, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LanguageDisplayName"/> class.
		/// </summary>
		/// <param name="languageName">Name of the language.</param>
		/// <param name="countryName">
		/// Name of the country. Pass null if this language is neutral.
		/// </param>
		internal LanguageDisplayName(string languageName, string countryName)
		{
			if (languageName == null)
			{
				throw new ArgumentNullException("languageName");
			}

			LanguageName = languageName;
			CountryName = countryName;

			FullName = languageName;
			if (countryName != null)
			{
				FullName += " (" + countryName + ")";
			}
		}

		/// <summary>
		/// Gets the full name.
		/// </summary>
		public string FullName { get; private set; }

		/// <summary>
		/// Gets the name of the language.
		/// </summary>
		public string LanguageName { get; private set; }

		/// <summary>
		/// Gets the name of the country.
		/// </summary>
		public string CountryName { get; private set; }

		/// <summary>
		/// Returns a string that represents the current object.
		/// </summary>
		/// <returns>
		/// A string that represents the current object.
		/// </returns>
		public override string ToString()
		{
			return FullName;
		}
	}
}
