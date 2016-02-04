namespace ToolsCatalog.Languages
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Reflection;

	using ToolsCatalog.Languages.Dto;

	using Newtonsoft.Json;

	/// <summary>
	/// Provides functionality for accessing language translations.
	/// </summary>
	internal class LanguageDisplayNameProvider
	{
		private object _translationsCacheSyncRoot = new object();

		/// <summary>
		/// The translations cache.
		/// </summary>
		private readonly Dictionary<Locale, Dictionary<int, LanguageDisplayName>> _translationsCache =
			new Dictionary<Locale, Dictionary<int, LanguageDisplayName>>();

		/// <summary>
		/// Returns the display name of the specified language in the specified locale.
		/// </summary>
		/// <param name="locale">The target locale.</param>
		/// <param name="lcid">
		/// LCID of the language whose display name is requested.
		/// </param>
		/// <returns>
		/// An instance of <see cref="LanguageDisplayName"/>.
		/// </returns>
		public LanguageDisplayName GetDisplayName(Locale locale, int lcid)
		{
			LanguageDisplayName result;
			if (!GetDisplayNames(locale).TryGetValue(lcid, out result))
			{
				throw new KeyNotFoundException(string.Format(
					"Lcid '{0}' has no corresponding translation on the locale '{1}'.",
					lcid,
					locale));
			}

			return result;
		}

		/// <summary>
		/// Retrieves translations for the specified culture name from the embedded resource.
		/// </summary>
		/// <param name="locale">Target locale.</param>
		/// <returns>
		/// A dictionary of LCID - language display name, where names are localized.
		/// </returns>
		private static Dictionary<int, LanguageDisplayName> LoadDisplayNames(Locale locale)
		{
			string cultureName;
			switch (locale)
			{
				case Locale.English:
					cultureName = "en";
					break;
				case Locale.French:
					cultureName = "fr";
					break;
				case Locale.German:
					cultureName = "de";
					break;
				default:
					throw new NotSupportedException("Locale '" + locale + "' is not supported.");
			}

			//Properties.Resources.ResourceManager.GetString();

			//using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(
			//	typeof(LanguagesProvider), 
			//	"Translations." + cultureName + ".json"))
			//{
			//	if (stream == null)
			//	{
			//		throw new FileNotFoundException(
			//			"Cannot find translations for the locale '" + cultureName + "'.");
			//	}

			//	using (var sr = new StreamReader(stream))
			//	using (var jsonTextReader = new JsonTextReader(sr))
			//	{
			//		return new JsonSerializer()
			//			.Deserialize<TranslationDto[]>(jsonTextReader)
			//			.ToDictionary(
			//				x => x.Lcid,
			//				x => new LanguageDisplayName(x.LanguageName, x.CountryName));
			//	}
			//}

			throw new NotImplementedException();
		}

		/// <summary>
		/// Returns all language display names for the requested locale.
		/// </summary>
		/// <param name="locale">The target locale.</param>
		/// <returns>
		/// A dictionary of LCID - language display name, where names are localized.
		/// </returns>
		private Dictionary<int, LanguageDisplayName> GetDisplayNames(Locale locale)
		{
			Dictionary<int, LanguageDisplayName> result = null;
			if (!_translationsCache.TryGetValue(locale, out result))
			{
				lock (_translationsCacheSyncRoot)
				{
					if (!_translationsCache.TryGetValue(locale, out result))
					{
						result = LoadDisplayNames(locale);
					}
				}
			}
			return result;
		}
	}
}
