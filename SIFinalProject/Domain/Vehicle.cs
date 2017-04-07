using System;
namespace SIFinalProject.Domain
{
	public class Vehicle
	{
		#region Constructors

		public Vehicle(int type, string model, int rentalPrice)
		{
			Type = type;
			Model = model;
			RentalPrice = rentalPrice;
		}

		#endregion

		#region Private Properties

		private int Type { get; set; }
		private string Model { get; set; }
		private int RentalPrice { get; set; }

		#endregion

		#region Public Methods

		public int CalculatePrice(int days)
		{
			return RentalPrice * days;
		}

		#endregion
	}
}
