using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using TestApp.Controls;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace TestApp.iOS
{
	public class ZoomableScrollViewRenderer : ScrollViewRenderer
	{
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);
			if (e.NewElement == null)
				return;

			if (e.OldElement == null)
			{
				ZoomableScrollView zsv = Element as ZoomableScrollView;
				this.MinimumZoomScale = zsv.MinimumZoomScale;
				this.MaximumZoomScale = zsv.MaximumZoomScale;
				this.ViewForZoomingInScrollView += (UIScrollView sv) => { return this.Subviews[0]; };
			}
		}
	}
}