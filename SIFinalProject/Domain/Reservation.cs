using System;
using Foundation;
namespace SIFinalProject.Domain
{
	public class Reservation
	{

		#region Private Properties

		private DateTime _pickupDate;
		private string _pickupLocation;
		private DateTime _returnDate;
		private string _returnLocation;
		private int _vehicleType;
		private Vehicle _vehicle;
		private User _userInfo;

		#endregion

		#region Public Properties

		public DateTime PickupDate { 
			get { return _pickupDate; } 
			set { _pickupDate = value; } 
		}
		public string PickupLocation {
			get { return _pickupLocation; }
			set { _pickupLocation = value; }
		}
		public DateTime ReturnDate {
			get { return _returnDate; }
			set { _returnDate = value; }
		}
		public string ReturnLocation {
			get { return _returnLocation; }
			set { _returnLocation = value; }
		}
		public int VehicleType {
			get { return _vehicleType; }
			set { _vehicleType = value; }
		}
		public string StringedVehicleType {
			get {
				switch (_vehicleType)
				{
					case 0:
						return "Standard";
					case 1:
						return "Economy";
					case 2:
						return "Compact";
					case 3:
						return "Premium";
					default:
						return "Standard";
				}
			
			}
		}
		public Vehicle Vehicle {
			get { return _vehicle; }
			set { _vehicle = value; }
		}
		public User UserInfo {
			get { return _userInfo; }
			set { _userInfo = value; }
		}

		#endregion

		#region Constructors

		public Reservation(DateTime pickupDate, string pickupLocation, DateTime returnDate, string returnLocation, Vehicle vehicle, User userInfo, int vehicleType = 0)
		{
			PickupDate = pickupDate;
			PickupLocation = pickupLocation;
			ReturnDate = returnDate;
			ReturnLocation = returnLocation;
			VehicleType = vehicleType;
			UserInfo = userInfo;
			Vehicle = vehicle;
		}

		public Reservation()
		{

		}

		#endregion

		#region Public Methods

		public NSDate GetNSDate(DateTime date) {
			var newDate = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
			return NSDate.FromTimeIntervalSinceReferenceDate((date - newDate).TotalSeconds);
		}


		#endregion


	}
}
