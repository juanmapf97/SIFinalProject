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

		#region Private Methods

		private bool OpenFile(NSUrl url)
		{
			var good = false;

			// Trap all errors
			try
			{
				var path = url.Path;

				// Is the file already open?
				foreach (NSWindow window in NSApplication.SharedApplication.Windows)
				{
					var content = window.ContentViewController as ViewController;
					if (content != null && path == content.FilePath)
					{
						// Bring window to front
						window.MakeKeyAndOrderFront(this);
						return true;
					}
				}

				// Get new window
				var storyboard = NSStoryboard.FromName("Main", null);
				var controller = storyboard.InstantiateControllerWithIdentifier("MainWindow") as NSWindowController;

				// Display
				controller.ShowWindow(this);

				// Load the text into the window
				//var viewController = controller.Window.ContentViewController as ViewController;
				View.Window.RepresentedUrl = url;
				SetFilePath(path);

				// Add document to the Open Recent menu
				NSDocumentController.SharedDocumentController.NoteNewRecentDocumentURL(url);

				// Make as successful
				good = true;
			}
			catch
			{
				// Mark as bad file on error
				good = false;
			}

			// Return results
			return good;
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
					reservationProperties.TryGetValue("PickupDate", out pickupDate);
					reservationProperties.TryGetValue("Lugar de pickup", out pickupLocation);
					reservationProperties.TryGetValue("Devolución", out returnDate);
					reservationProperties.TryGetValue("Lugar de devolución", out returnLocation);
					reservationProperties.TryGetValue("Tipo de Vehículo", out vehicleType);

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

					var reservation = new Reservation(DateTime.Parse(pickupDate), pickupLocation, DateTime.Parse(returnDate), returnLocation, null, null, type);

					UploadedReservation = reservation;

					PerformSegue("OpenInfoDetails", this);
				}
			}
		}

		#endregion
	}
}
