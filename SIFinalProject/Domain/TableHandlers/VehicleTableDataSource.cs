using System;
using AppKit;
using System.Collections.Generic;
using SIFinalProject.Domain;
namespace SIFinalProject
{
	public class VehicleTableDataSource : NSTableViewDataSource
	{
		#region Public Variables

		public List<Vehicle> Vehicles = new List<Vehicle>();

		#endregion

		#region Constructors

		public VehicleTableDataSource()
		{

		}

		#endregion

		#region Override Methods

		public override nint GetRowCount(NSTableView tableView)
		{
			return Vehicles.Count;
		}

		#endregion
	}
}
