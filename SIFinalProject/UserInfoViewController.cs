using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using SIFinalProject.Domain;
using System.IO;

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
			var messsage = "Reservación: \n\tFecha de recogida:" + res.PickupDate.ToShortDateString() 
			               + "\n\tLugar de recogida: " + res.PickupLocation
			               + "\n\tFecha de entrega: " + res.ReturnDate.ToShortDateString()
			               + "\n\tLugar de entrega: " + res.ReturnLocation
				           + "\n\n\tVehiculo Seleccionado:\n\t\tModelo: " + res.Vehicle.Model 
			               + "\n\t\tPrecio Total: " + res.Vehicle.CalculatePrice(Convert.ToInt32((res.ReturnDate - res.PickupDate).TotalDays))
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

		#endregion

		#region 

		#region Actions

		partial void CancelButton(NSObject sender)
		{

		}

		partial void Confirm(NSObject sender)
		{
			var dlg = new NSSavePanel();
			dlg.Title = "Save Text File";
			dlg.AllowedFileTypes = new string[] { "txt" };
			if (dlg.RunModal() == 1)
			{
				var path = dlg.Url.Path;
				File.WriteAllText(path, CreateStringMessage(ControllerReservation));
				//var alert = new NSAlert()
				//{
				//	AlertStyle = NSAlertStyle.Critical,
				//	InformativeText = "We need to save the document here...",
				//	MessageText = "Save Document",
				//};
				//alert.RunModal();
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
