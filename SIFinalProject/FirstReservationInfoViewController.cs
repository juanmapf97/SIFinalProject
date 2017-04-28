using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using SIFinalProject.Domain;

namespace SIFinalProject
{
	public partial class FirstReservationInfoViewController : AppKit.NSViewController
	{
		#region Constructors

		// Called when created from unmanaged code
		public FirstReservationInfoViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public FirstReservationInfoViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public FirstReservationInfoViewController() : base("FirstReservationInfoView", NSBundle.MainBundle)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion

		#region Public Properties

		public Reservation ControllerReservation { get; set; }

		#endregion

		#region Override Methods

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			PickupDatePicker.MinDate = NSDate.Now;
			ReturnDatePicker.MinDate = NSDate.Now;

			PickupDatePicker.DateValue = ControllerReservation.GetNSDate(ControllerReservation.PickupDate) ?? NSDate.Now;
			ReturnDatePicker.DateValue = ControllerReservation.GetNSDate(ControllerReservation.ReturnDate) ?? NSDate.FromTimeIntervalSinceNow(86400);
			SelectLocationNSTag(PickupLocationPicker, ControllerReservation.PickupLocation);
			SelectLocationNSTag(ReturnLocationPicker, ControllerReservation.ReturnLocation);
			VehicleTypePicker.SelectItemWithTag(ControllerReservation.VehicleType);
		}

		public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			switch (segue.Identifier)
			{
				case "OpenTableSegue":
					var controller = segue.DestinationController as TableHandlerViewController;
					controller.ControllerReservation = ControllerReservation;
					break;
			}
		}

		#endregion

		#region Private Methods

		private void SelectLocationNSTag(NSPopUpButton button, string s)
		{
			switch (s.ToLower())
			{
				case ("aeropuerto de monterrey"):
					button.SelectItemWithTag(1);
					break;
				case ("aeropuerto de cancún"):
					button.SelectItemWithTag(2);
					break;
				case ("ciudad/centro de cancún"):
					button.SelectItemWithTag(3);
					break;
				default:
					button.SelectItemWithTag(1);
					break;
			}
		}

		private bool ValidateReservationInfo()
		{
			if (PickupDatePicker.DateValue.Compare(ReturnDatePicker.DateValue) == NSComparisonResult.Descending)
			{
				return false;
			}
			return true;
		}

		#endregion

		#region Public Methods

		public void SetControllerReservation(Reservation res)
		{
			ControllerReservation = res;
		}

		public DateTime ConvertNsDateToDateTime(NSDate date)
		{
			var newDate = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
			return newDate.AddSeconds(date.SecondsSinceReferenceDate);
		}

		#endregion

		#region Actions

		partial void Confirm(NSObject sender)
		{
			if (ValidateReservationInfo())
			{
				ControllerReservation.PickupLocation = PickupLocationPicker.Title;
				ControllerReservation.ReturnLocation = ReturnLocationPicker.Title;
				ControllerReservation.PickupDate = ConvertNsDateToDateTime(PickupDatePicker.DateValue);
				ControllerReservation.ReturnDate = ConvertNsDateToDateTime(ReturnDatePicker.DateValue);
				ControllerReservation.VehicleType = (int)VehicleTypePicker.SelectedTag;
				PerformSegue("OpenTableSegue", this);
			}
			else
			{
				var alert = new NSAlert()
				{
					AlertStyle = NSAlertStyle.Informational,
					InformativeText = "La fecha de entrega no puede ser menor a la fecha de recogida.",
					MessageText = "Fechas"
				};
				alert.RunModal();
			}
		}

		#endregion

		//strongly typed view accessor
		public new FirstReservationInfoView View
		{
			get
			{
				return (FirstReservationInfoView)base.View;
			}
		}
	}
}
