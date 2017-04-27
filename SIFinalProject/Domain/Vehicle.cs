using System;
namespace SIFinalProject.Domain
{
	public class Vehicle
	{
		#region Constructors

		public Vehicle(string model, int type, int rentalPrice)
		{
			Type = type;
			Model = model;
			RentalPrice = rentalPrice;
		}

		#endregion

		#region Private Properties

		private int _type;
		private string _model;
		private int _rentalPrice;

		#endregion

		#region Public Properties

		public int Type { 
			get { return _type; } 
			set { _type = value; } 
		}
		public string Model {  
			get { return _model; }
			set { _model = value; } 
		}
		public int RentalPrice {
			get { return _rentalPrice; }
			set { _rentalPrice = value; }
		}

		#endregion

		#region Public Methods

		public int CalculatePrice(int days)
		{
			return RentalPrice * days;
		}

		#endregion
	}
}
