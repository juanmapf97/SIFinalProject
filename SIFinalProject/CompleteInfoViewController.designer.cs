// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SIFinalProject
{
	[Register ("CompleteInfoViewController")]
	partial class CompleteInfoViewController
	{
		[Outlet]
		AppKit.NSTextField ModelLabel { get; set; }

		[Outlet]
		AppKit.NSDatePicker PickupDatePicker { get; set; }

		[Outlet]
		AppKit.NSPopUpButton PickupLocation { get; set; }

		[Outlet]
		AppKit.NSTextField PriceLabel { get; set; }

		[Outlet]
		AppKit.NSDatePicker ReturnDatePicker { get; set; }

		[Outlet]
		AppKit.NSPopUpButton ReturnLocation { get; set; }

		[Outlet]
		AppKit.NSTextField TypeLabel { get; set; }

		[Outlet]
		AppKit.NSImageView VehicleImage { get; set; }

		[Action ("CancelButton:")]
		partial void CancelButton (Foundation.NSObject sender);

		[Action ("Confirm:")]
		partial void Confirm (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (ModelLabel != null) {
				ModelLabel.Dispose ();
				ModelLabel = null;
			}

			if (PriceLabel != null) {
				PriceLabel.Dispose ();
				PriceLabel = null;
			}

			if (TypeLabel != null) {
				TypeLabel.Dispose ();
				TypeLabel = null;
			}

			if (PickupDatePicker != null) {
				PickupDatePicker.Dispose ();
				PickupDatePicker = null;
			}

			if (PickupLocation != null) {
				PickupLocation.Dispose ();
				PickupLocation = null;
			}

			if (ReturnDatePicker != null) {
				ReturnDatePicker.Dispose ();
				ReturnDatePicker = null;
			}

			if (ReturnLocation != null) {
				ReturnLocation.Dispose ();
				ReturnLocation = null;
			}

			if (VehicleImage != null) {
				VehicleImage.Dispose ();
				VehicleImage = null;
			}
		}
	}
}
