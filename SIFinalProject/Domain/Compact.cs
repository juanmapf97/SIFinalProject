using System;
using SIFinalProject.Domain;
namespace SIFinalProject
{
	public class Compact : Vehicle
	{
		#region Constructors

		public Compact(string model) : base(model, 2, 510)
		{

		}

		#endregion

		#region Private Properties

		private int _completeRental;

		#endregion

		#region Public Properties

		public int CompleteRental
		{
			get { return _completeRental; }
			set { _completeRental = value; }
		}

		#endregion
	}
}
