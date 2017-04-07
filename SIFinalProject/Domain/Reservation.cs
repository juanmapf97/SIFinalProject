using System;
namespace SIFinalProject.Domain
{
	public class Reservation
	{

		#region Constructors

		public Reservation(DateTime pickupDate, string pickupLocation, DateTime returnDate, string returnLocation, Vehicle vehicle, int vehicleType = 0)
		{
			PickupDate = pickupDate;
			PickupLocation = pickupLocation;
			ReturnDate = returnDate;
			ReturnLocation = returnLocation;
			VehicleType = vehicleType;
			Vehicle = vehicle;
		}

		public Reservation()
		{
			
		}

  		#endregion

		#region Private Properties

		private DateTime PickupDate { get; set; }
		private string PickupLocation { get; set; }
		private DateTime ReturnDate { get; set; }
		private string ReturnLocation { get; set; }
		private int VehicleType { get; set; }
		private Vehicle Vehicle { get; set; }

		#endregion

	}
}
