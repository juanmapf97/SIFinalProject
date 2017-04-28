using System;
using SIFinalProject.Domain;
namespace SIFinalProject
{
	public class Economy : Vehicle
	{
		#region Constructors

		public Economy(string model) : base(model, 1, 480)
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
