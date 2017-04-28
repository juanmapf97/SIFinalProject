using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using SIFinalProject.Domain;
using System.IO;
using System.Text.RegularExpressions;

namespace SIFinalProject
{
	public partial class UserInfoViewController : AppKit.NSViewController
	{
		#region Constructors

		// Called when created from unmanaged code
		public UserInfoViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public UserInfoViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public UserInfoViewController() : base("UserInfoView", NSBundle.MainBundle)
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

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}

		public override void PrepareForSegue(NSStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);

			switch (segue.Identifier)
			{
				case "EndProcessSegue":
					ControllerReservation = null;
					break;
				case "CancelUserInfoSegue":
					var controller = segue.DestinationController as CompleteInfoViewController;
					ControllerReservation.UserInfo = null;
					controller.ControllerReservation = ControllerReservation;
					break;
				default:
					break;
			}
		}

		#endregion

		#region Public Methods

		//public void SaveDocument()
		//{
		//	var dlg = new NSSavePanel();
		//	dlg.Title = "Save Text File";
		//	dlg.AllowedFileTypes = new string[] { "txt", "html", "md", "css" };
		//	if (dlg.RunModal() == 1)
		//	{
		//		var alert = new NSAlert()
		//		{
		//			AlertStyle = NSAlertStyle.Critical,
		//			InformativeText = "We need to save the document here...",
		//			MessageText = "Save Document",
		//		};
		//		alert.RunModal();
		//	}
		//}

		#endregion

		#region Private Methods

		private string CreateStringMessage(Reservation res)
		{
			var messsage = "Reservación: \n\tFecha de recogida: " + res.PickupDate.ToShortDateString() 
			               + "\n\tLugar de recogida: " + res.PickupLocation
			               + "\n\tFecha de entrega: " + res.ReturnDate.ToShortDateString()
			               + "\n\tLugar de entrega: " + res.ReturnLocation
				           + "\n\n\tVehiculo Seleccionado:\n\t\tModelo: " + res.Vehicle.Model 
			               + "\n\t\tPrecio Total: " + res.Vehicle.CalculatePrice(Convert.ToInt32((res.ReturnDate - res.PickupDate).TotalDays)).ToString("C")
			               + "\n\t\tTipo de vehiculo: " + res.VehicleType
			               + "\n\n\tUsuario:\n\t\tNombre: " + res.UserInfo.FirstName
			               + "\n\t\tApellido: " + res.UserInfo.LastName
			               + "\n\t\tCorreo electronico: " + res.UserInfo.Email
			               + "\n\t\tCiudad: " + res.UserInfo.City
			               + "\n\t\tEstado: " + res.UserInfo.State
			               + "\n\t\tPais: " + res.UserInfo.Country
			               + "\n\t\tNumero de telefono: " + res.UserInfo.Telephone
			               + "\n\t\tNumero de celular: " + res.UserInfo.Cellphone
			               + "\n\t\tHotel: " + res.UserInfo.Hotel;

			return messsage;
		}

		private int SaveDialog()
		{
			var dlg = new NSSavePanel();
			dlg.Title = "Save Text File";
			dlg.AllowedFileTypes = new string[] { "txt" };
			if (dlg.RunModal() == 1)
			{
				var path = dlg.Url.Path;
				File.WriteAllText(path, CreateStringMessage(ControllerReservation));
				return 1;
			}
			else
				return 0;
		}

		private bool ValidateInfo()
		{
			var numbers = new Regex("^[0-9]+$");
			var letters = new Regex("^([A-Za-zÑñáéíóúÁÉÍÓÚ ]+)$");
			if (numbers.IsMatch(CellphoneTF.StringValue) && numbers.IsMatch(TelephoneTF.StringValue) && letters.IsMatch(NameTF.StringValue) && letters.IsMatch(LastNameTF.StringValue))
				return true;
			return false;
		}

		#endregion

		#region Actions

		partial void CancelButton(NSObject sender)
		{
			PerformSegue("CancelUserInfoSegue", this);
		}

		partial void Confirm(NSObject sender)
		{
			if (ValidateInfo())
			{
				ControllerReservation.UserInfo = new User();
				ControllerReservation.UserInfo.FirstName = NameTF.StringValue;
				ControllerReservation.UserInfo.LastName = LastNameTF.StringValue;
				ControllerReservation.UserInfo.Email = EmailTF.StringValue;
				ControllerReservation.UserInfo.Country = CountryTF.StringValue;
				ControllerReservation.UserInfo.City = CityTF.StringValue;
				ControllerReservation.UserInfo.Cellphone = CellphoneTF.StringValue;
				ControllerReservation.UserInfo.Hotel = HotelTF.StringValue;
				ControllerReservation.UserInfo.State = StateTF.StringValue;
				ControllerReservation.UserInfo.Telephone = TelephoneTF.StringValue;
				if (SaveDialog() == 1)
				{
					PerformSegue("EndProcessSegue", this);
				}
			}
			else
			{
				var alert = new NSAlert()
				{
					AlertStyle = NSAlertStyle.Informational,
					InformativeText = "La información proporcionada contiene errores.",
					MessageText = "Error",
				};
				alert.RunModal();
			}
		}

		#endregion

		//strongly typed view accessor
		public new UserInfoView View
		{
			get
			{
				return (UserInfoView)base.View;
			}
		}
	}
}
