using System;
using SIFinalProject.Domain;
namespace SIFinalProject
{
	public class Standard : Vehicle
	{

		#region Constructors

		public Standard(string model) : base(model, 0, 480)
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
