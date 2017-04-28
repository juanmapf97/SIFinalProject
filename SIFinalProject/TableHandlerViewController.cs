using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using SIFinalProject.Domain;

namespace SIFinalProject
{
	public partial class TableHandlerViewController : AppKit.NSViewController
	{
		#region Constructors

		// Called when created from unmanaged code
		public TableHandlerViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public TableHandlerViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public TableHandlerViewController() : base("TableHandlerView", NSBundle.MainBundle)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion

		#region Override Methods

		public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			switch (segue.Identifier)
			{
				case "CancelTableSegue":
					var controller = segue.DestinationController as FirstReservationInfoViewController;
					controller.ControllerReservation = ControllerReservation;
					break;
				case "OpenFullInfoSegue":
					var controller2 = segue.DestinationController as CompleteInfoViewController;
					var dataSource = VehicleTable.DataSource as VehicleTableDataSource;
					ControllerReservation.Vehicle = dataSource.Vehicles[(int)VehicleTable.SelectedRow];
					controller2.ControllerReservation = ControllerReservation;
					break;
				default:
					break;
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			InitializeList();
			var dataSource = new VehicleTableDataSource();
			foreach (var vehicle in Vehicles)
			{
				if (vehicle.Type == ControllerReservation.VehicleType)
					dataSource.Vehicles.Add(vehicle);
			}

			VehicleTable.DataSource = dataSource;
			VehicleTable.Delegate = new VehicleTableDelegate(dataSource);
		}

		#endregion

		#region Public Properties

		public Reservation ControllerReservation { get; set; }
		public List<Vehicle> Vehicles = new List<Vehicle>();

		#endregion

		#region Public Methods

		public void InitializeList()
		{
			Vehicles.Add(new Compact("Kia Rio"));
			Vehicles.Add(new Compact("Ford Fiesta"));
			Vehicles.Add(new Compact("Renault Twingo"));
			Vehicles.Add(new Premium("BMW M3"));
			Vehicles.Add(new Premium("Mercedes E class"));
			Vehicles.Add(new Premium("Porsche Cayenne"));
			Vehicles.Add(new Economy("Nissan Juke"));
			Vehicles.Add(new Economy("Ford Focus"));
			Vehicles.Add(new Economy("Smart"));
			Vehicles.Add(new Standard("Toyota Corolla"));
			Vehicles.Add(new Standard("Volkswagen Jetta"));
			Vehicles.Add(new Standard("Nissan Versa"));
		}

		#endregion

		#region Actions

		partial void CancelButton(NSObject sender)
		{
			PerformSegue("CancelTableSegue", this);
		}

		partial void Confirm(NSObject sender)
		{
			if (!(VehicleTable.SelectedRowCount > 0))
			{
				var alert = new NSAlert()
				{
					AlertStyle = NSAlertStyle.Informational,
					InformativeText = "Por favor seleccione un vehiculo.",
					MessageText = "Seleccionar Vehiculo"
				};
				alert.RunModal();
			} else 
				PerformSegue("OpenFullInfoSegue", this);
		}

		#endregion

		//strongly typed view accessor
		public new TableHandlerView View
		{
			get
			{
				return (TableHandlerView)base.View;
			}
		}
	}
}
