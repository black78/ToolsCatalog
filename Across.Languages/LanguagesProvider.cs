namespace Across.Languages
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Runtime.InteropServices;

	using Across.Languages.Dto;

	using Newtonsoft.Json;

	/// <summary>
	/// Allows to retrieve Across languages.
	/// </summary>
	[ComVisible(true)]
	[Guid("C5DAE5D6-ACA5-4463-8BF3-8881C8F948A1")]
	[ClassInterface(ClassInterfaceType.AutoDual)]
	public class LanguagesProvider : ILanguagesProvider
	{
		/// <summary>
		/// The data transfer object for language.
		/// </summary>
		private readonly LanguageDto[] _languageDtos;

		/// <summary>
		/// The names provider.
		/// </summary>
		private readonly LanguageDisplayNameProvider _namesProvider;

		/// <summary>
		/// The hierarchical languages.
		/// </summary>
		private readonly Lazy<LanguageCollection> _hierarchicalLanguages;

		/// <summary>
		/// The flat languages.
		/// </summary>
		private readonly Lazy<LanguageCollection> _flatLanguages;

		/// <summary>
		/// Initializes a new instance of the <see cref="LanguagesProvider"/> class.
		/// </summary>
		public LanguagesProvider()
		{
			_namesProvider = new LanguageDisplayNameProvider();

			//using (Stream languagesStream = typeof(LanguagesProvider).Assembly.GetManifestResourceStream(
			//	typeof(LanguagesProvider),
			//	"Languages.json"))
			//{
			//	if (languagesStream == null)
			//	{
			//		throw new FileNotFoundException("Cannot find languages resource.");
			//	}

			//	using (var sr = new StreamReader(languagesStream))
			//	using (var jsonTextReader = new JsonTextReader(sr))
			//	{
			//		_languageDtos = new JsonSerializer()
			//			.Deserialize<LanguageDto[]>(jsonTextReader);
			//	}
			//}
			throw new NotImplementedException();

			_hierarchicalLanguages = new Lazy<LanguageCollection>(BuildHierarchicalLanguages);
			_flatLanguages = new Lazy<LanguageCollection>(BuildFlatLanguages);
		}

		/// <summary>
		/// Returns a collection of languages with parent-child relations.
		/// </summary>
		/// <returns>A hierarchical collection of languages.</returns>
		public LanguageCollection GetLanguages()
		{
			return _hierarchicalLanguages.Value;
		}

		/// <summary>
		/// Returns a flat collection of languages (languages and sublanguages in the same collection).
		/// </summary>
		/// <returns>A flat collection of languages.</returns>
		public LanguageCollection GetFlatLanguages()
		{
			return _flatLanguages.Value;
		}

		/// <summary>
		/// Initializes the hierarchical language structure.
		/// </summary>
		/// <returns>
		/// The <see cref="Language"/> array.
		/// </returns>
		private LanguageCollection BuildHierarchicalLanguages()
		{
			return new LanguageCollection(_languageDtos
				.Select(x => new Language(x, _namesProvider, false))
				.ToList());
		}

		/// <summary>
		/// Initializes a flat collection of languages (languages and sublanguages in the same collection).
		/// </summary>
		/// <returns>
		/// The <see cref="Language"/> array.
		/// </returns>
		private LanguageCollection BuildFlatLanguages()
		{
			var result =
				from neutralLanguage in _languageDtos
				from language in (new[] { neutralLanguage }).Union(neutralLanguage.Children)
				select new Language(language, _namesProvider, true);

			return new LanguageCollection(result.ToList());
		}
	}
}
