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
	[Register ("TableHandlerViewController")]
	partial class TableHandlerViewController
	{
		[Outlet]
		AppKit.NSTableColumn modelColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn priceColumn { get; set; }

		[Outlet]
		AppKit.NSTableColumn typeColumn { get; set; }

		[Outlet]
		AppKit.NSTableView VehicleTable { get; set; }

		[Action ("CancelButton:")]
		partial void CancelButton (Foundation.NSObject sender);

		[Action ("Confirm:")]
		partial void Confirm (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (modelColumn != null) {
				modelColumn.Dispose ();
				modelColumn = null;
			}

			if (priceColumn != null) {
				priceColumn.Dispose ();
				priceColumn = null;
			}

			if (typeColumn != null) {
				typeColumn.Dispose ();
				typeColumn = null;
			}

			if (VehicleTable != null) {
				VehicleTable.Dispose ();
				VehicleTable = null;
			}
		}
	}
}
