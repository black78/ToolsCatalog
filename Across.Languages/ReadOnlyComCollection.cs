namespace Across.Languages
{
	using System.Collections;
	using System.Collections.Generic;

	/// <summary>
	/// The read only com collection.
	/// </summary>
	/// <typeparam name="T">
	/// Element type inside collection.
	/// </typeparam>
	public class ReadOnlyComCollection<T> : System.Collections.ObjectModel.ReadOnlyCollection<T>
	{
		#region Constructors and Destructors

		/// <summary>
		/// Initializes a new instance of the <see cref="ReadOnlyComCollection{T}"/> class.
		/// </summary>
		/// <param name="collection">
		/// The collection.
		/// </param>
		public ReadOnlyComCollection(IList<T> collection)
			: base(collection)
		{
		}

		#endregion

		#region Public Methods and Operators

		/// <summary>
		/// The new enumerator.
		/// </summary>
		/// <returns>
		/// The Enumerator.
		/// </returns>
		public IEnumerator _NewEnum()
		{
			return GetEnumerator();
		}

		#endregion
	}
}