using System;
using SIFinalProject.Domain;

namespace SIFinalProject
{
	public class Premium: Vehicle
	{
		#region Constructors

		public Premium(string model) : base(model, 3, 1960)
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
