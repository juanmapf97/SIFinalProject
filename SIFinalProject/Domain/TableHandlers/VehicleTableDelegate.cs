using System;
using AppKit;
using CoreImage;
namespace SIFinalProject
{
	public class VehicleTableDelegate : NSTableViewDelegate
	{
		#region Constants

		private const string CellIdentifier = "VehiCell";

		#endregion

		#region Private Variables

		private VehicleTableDataSource DataSource;

		#endregion

		#region Constructors

		public VehicleTableDelegate(VehicleTableDataSource datasource)
		{
			DataSource = datasource;
		}

		#endregion

		#region Override methods

		public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
		{

			NSTextField view = (NSTextField)tableView.MakeView(CellIdentifier, this);
			if (view == null)
			{
				view = new NSTextField();
				view.Identifier = CellIdentifier;
				view.BackgroundColor = NSColor.Clear;
				view.Bordered = false;
				view.Selectable = true;
				view.Editable = false;
			}

			switch (tableColumn.Title)
			{
				case "Modelo":
					view.StringValue = DataSource.Vehicles[(int)row].Model;
					break;
				case "Tipo":
					view.StringValue = DataSource.Vehicles[(int)row].Type.ToString();
					break;
				case "Precio":
					view.StringValue = DataSource.Vehicles[(int)row].RentalPrice.ToString();
					break;
				default:
					break;
			}
			return view;
		}

		#endregion



	}
}
