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
	[Register ("UserInfoViewController")]
	partial class UserInfoViewController
	{
		[Outlet]
		AppKit.NSTextField CellphoneTF { get; set; }

		[Outlet]
		AppKit.NSTextField CityTF { get; set; }

		[Outlet]
		AppKit.NSTextField CountryTF { get; set; }

		[Outlet]
		AppKit.NSTextField EmailTF { get; set; }

		[Outlet]
		AppKit.NSTextField HotelTF { get; set; }

		[Outlet]
		AppKit.NSTextField LastNameTF { get; set; }

		[Outlet]
		AppKit.NSTextField NameTF { get; set; }

		[Outlet]
		AppKit.NSTextField StateTF { get; set; }

		[Outlet]
		AppKit.NSTextField TelephoneTF { get; set; }

		[Action ("CancelButton:")]
		partial void CancelButton (Foundation.NSObject sender);

		[Action ("Confirm:")]
		partial void Confirm (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (NameTF != null) {
				NameTF.Dispose ();
				NameTF = null;
			}

			if (EmailTF != null) {
				EmailTF.Dispose ();
				EmailTF = null;
			}

			if (CityTF != null) {
				CityTF.Dispose ();
				CityTF = null;
			}

			if (StateTF != null) {
				StateTF.Dispose ();
				StateTF = null;
			}

			if (CountryTF != null) {
				CountryTF.Dispose ();
				CountryTF = null;
			}

			if (LastNameTF != null) {
				LastNameTF.Dispose ();
				LastNameTF = null;
			}

			if (TelephoneTF != null) {
				TelephoneTF.Dispose ();
				TelephoneTF = null;
			}

			if (CellphoneTF != null) {
				CellphoneTF.Dispose ();
				CellphoneTF = null;
			}

			if (HotelTF != null) {
				HotelTF.Dispose ();
				HotelTF = null;
			}
		}
	}
}
