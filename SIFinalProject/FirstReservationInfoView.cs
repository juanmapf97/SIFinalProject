using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace SIFinalProject
{
	public partial class FirstReservationInfoView : AppKit.NSView
	{
		#region Constructors

		// Called when created from unmanaged code
		public FirstReservationInfoView(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public FirstReservationInfoView(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion
	}
}
