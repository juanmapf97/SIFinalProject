using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace SIFinalProject
{
	public partial class TableHandlerView : AppKit.NSView
	{
		#region Constructors

		// Called when created from unmanaged code
		public TableHandlerView(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public TableHandlerView(NSCoder coder) : base(coder)
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
