using System;
using Sushi.Interfaces;

// ReSharper disable UnusedMember.Global
namespace Sushi.TestModels
{
	/// <summary>
	///     Base implementation for a <see cref="ViewModel"/>.
	/// </summary>
	public class ViewModel : IScriptModel
	{
		/// <summary>
		///     The <see cref="Guid"/> Idenfifier.
		/// </summary>
		public Guid Guid { get; set; }

		/// <summary>
		///     The <see cref="DateTime"/> that this <see cref="ViewModel"/> was <see cref="CreatedOn"/>.
		/// </summary>
		public DateTime CreatedOn { get; set; } = DateTime.Now;
	}
}