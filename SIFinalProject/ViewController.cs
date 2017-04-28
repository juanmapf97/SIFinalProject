using System;
using System.IO;
using AppKit;
using Foundation;
using SIFinalProject.Domain;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SIFinalProject
{
	public partial class ViewController : NSViewController
	{
		#region Computed Properties

		public string FilePath { get; set; } = "";

		#endregion

		#region Private Properties

		private Reservation UploadedReservation { get; set; }

		#endregion

		public ViewController(IntPtr handle) : base(handle)
		{
		}



		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			// Do any additional setup after loading the view.
		}

		public override NSObject RepresentedObject
		{
			get
			{
				return base.RepresentedObject;
			}
			set
			{
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}

		#region Public Methods

		public void SetFilePath(string path)
		{
			FilePath = path;
		}

		#endregion

		#region Override Methods

		public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			switch (segue.Identifier)
			{
				case ("OpenInfoDetails"):
					var controller = segue.DestinationController as FirstReservationInfoViewController;
					controller.ControllerReservation = UploadedReservation;
					break;
			}

		}

		#endregion

		#region Actions

		partial void OpenFile(NSObject sender)
		{
			var dlg = NSOpenPanel.OpenPanel;
			dlg.CanChooseFiles = true;
			dlg.CanChooseDirectories = false;
			dlg.AllowedFileTypes = new string[] { "txt" };

			if (dlg.RunModal() == 1)
			{
				// Nab the first file
				var url = dlg.Urls[0];

				if (url != null)
				{
					var path = url.Path;

					var reservationText = File.ReadLines(path)
											  .Select(s => s.Split('-'))
											  .ToArray();

					// Your dictionary
					var reservationProperties = new Dictionary<string, string>();

					// Loop through the array and add the key/value pairs to the dictionary
					for (int i = 0; i < reservationText.Length; i++)
					{
						reservationProperties[reservationText[i][0]] = reservationText[i][1];
					}

					string pickupDate, returnDate, pickupLocation, returnLocation, vehicleType;
					reservationProperties.TryGetValue("Fecha de recogida", out pickupDate);
					reservationProperties.TryGetValue("Lugar de recogida", out pickupLocation);
					reservationProperties.TryGetValue("Fecha de entrega", out returnDate);
					reservationProperties.TryGetValue("Lugar de entrega", out returnLocation);
					reservationProperties.TryGetValue("Tipo de vehículo", out vehicleType);

					int type;
					switch (vehicleType)
					{
						case ("Standard"):
							type = 0;
							break;
						case("Economy"):
							type = 1;
							break;
						case("Compact"):
							type = 2;
							break;
						case("Premium"):
							type = 3;
							break;
						default:
							type = 0;
							break;
					}

					pickupLocation = pickupLocation ?? "";
					returnLocation = returnLocation ?? "";
					pickupDate = pickupDate ?? "";
					returnDate = returnDate ?? "";
					var pDate = (pickupDate != "") ? DateTime.Parse(pickupDate) : DateTime.Today;
					var rDate = (returnDate != "") ? DateTime.Parse(returnDate) : DateTime.Today;
					var reservation = new Reservation(pDate, pickupLocation, rDate, returnLocation, null, null, type);

					UploadedReservation = reservation;

					PerformSegue("OpenInfoDetails", this);
				}
			}
		}

		#endregion
	}
}
