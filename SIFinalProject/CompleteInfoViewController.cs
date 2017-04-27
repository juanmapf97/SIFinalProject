using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using SIFinalProject.Domain;

namespace SIFinalProject
{
	public partial class CompleteInfoViewController : AppKit.NSViewController
	{
		#region Constructors

		// Called when created from unmanaged code
		public CompleteInfoViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public CompleteInfoViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public CompleteInfoViewController() : base("CompleteInfoView", NSBundle.MainBundle)
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

		public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			switch (segue.Identifier)
			{
				case "OpenUserInfoSegue":
					var controller = segue.DestinationController as FirstReservationInfoViewController;
					controller.ControllerReservation = ControllerReservation;
					break;
				case "CancelFullInfoSegue":
					var controller2 = segue.DestinationController as TableHandlerViewController;
					controller2.ControllerReservation = ControllerReservation;
					break;
				default:
					break;
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			SelectImage(VehicleImage, ControllerReservation.VehicleType);
			ModelLabel.StringValue = ControllerReservation.Vehicle.Model;
			PriceLabel.StringValue = ControllerReservation.Vehicle.RentalPrice.ToString("C");
			TypeLabel.StringValue = ControllerReservation.VehicleType.ToString();
			PickupDatePicker.DateValue = ControllerReservation.GetNSDate(ControllerReservation.PickupDate);
			SelectLocationNSTag(PickupLocation, ControllerReservation.PickupLocation);
			SelectLocationNSTag(ReturnLocation, ControllerReservation.ReturnLocation);
			ReturnDatePicker.DateValue = ControllerReservation.GetNSDate(ControllerReservation.ReturnDate);
		}

		#endregion

		#region Private Methods

		private void SelectImage(NSImageView view, int type)
		{
			switch (type)
			{
				case 0:
					view.Image = NSImage.ImageNamed("Toyota.png");
					break;
				case 1:
					view.Image = NSImage.ImageNamed("Nissan.png");
					break;
				case 2:
					view.Image = NSImage.ImageNamed("Kia.png");
					break;
				case 3:
					view.Image = NSImage.ImageNamed("BMW.png");
					break;
				default:
					view.Image = NSImage.ImageNamed("Toyota.png");
					break;
			}
		}

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
				ControllerReservation.PickupLocation = PickupLocation.Title;
				ControllerReservation.ReturnLocation = ReturnLocation.Title;
				ControllerReservation.PickupDate = ConvertNsDateToDateTime(PickupDatePicker.DateValue);
				ControllerReservation.ReturnDate = ConvertNsDateToDateTime(ReturnDatePicker.DateValue);
				PerformSegue("OpenUserInfoSegue", this);
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

		partial void CancelButton(NSObject sender)
		{
			ControllerReservation.Vehicle = null;
			PerformSegue("CancelFullInfoSegue", this);
		}

		#endregion

		//strongly typed view accessor
		public new CompleteInfoView View
		{
			get
			{
				return (CompleteInfoView)base.View;
			}
		}
	}
}
