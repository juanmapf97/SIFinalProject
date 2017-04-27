using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace SIFinalProject
{
	public partial class VehicleTableViewControllerController : AppKit.NSViewController
	{
		#region Constructors

		// Called when created from unmanaged code
		public VehicleTableViewControllerController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public VehicleTableViewControllerController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public VehicleTableViewControllerController() : base("VehicleTableViewController", NSBundle.MainBundle)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion

		//strongly typed view accessor
		public new VehicleTableViewController View
		{
			get
			{
				return (VehicleTableViewController)base.View;
			}
		}
	}
}
