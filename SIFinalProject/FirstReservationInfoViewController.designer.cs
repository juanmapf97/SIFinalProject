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
	[Register ("FirstReservationInfoViewController")]
	partial class FirstReservationInfoViewController
	{
		[Outlet]
		AppKit.NSDatePicker PickupDatePicker { get; set; }

		[Outlet]
		AppKit.NSPopUpButton PickupLocationPicker { get; set; }

		[Outlet]
		AppKit.NSDatePicker ReturnDatePicker { get; set; }

		[Outlet]
		AppKit.NSPopUpButton ReturnLocationPicker { get; set; }

		[Outlet]
		AppKit.NSPopUpButton VehicleTypePicker { get; set; }

		[Action ("Confirm:")]
		partial void Confirm (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (PickupDatePicker != null) {
				PickupDatePicker.Dispose ();
				PickupDatePicker = null;
			}

			if (PickupLocationPicker != null) {
				PickupLocationPicker.Dispose ();
				PickupLocationPicker = null;
			}

			if (ReturnDatePicker != null) {
				ReturnDatePicker.Dispose ();
				ReturnDatePicker = null;
			}

			if (ReturnLocationPicker != null) {
				ReturnLocationPicker.Dispose ();
				ReturnLocationPicker = null;
			}

			if (VehicleTypePicker != null) {
				VehicleTypePicker.Dispose ();
				VehicleTypePicker = null;
			}
		}
	}
}
