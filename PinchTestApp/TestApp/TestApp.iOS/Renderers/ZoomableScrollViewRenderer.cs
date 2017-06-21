using TestApp.Controls;
using TestApp.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ZoomableScrollView), typeof(ZoomableScrollViewRenderer))]

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
				var zsv = Element as ZoomableScrollView;
				this.MinimumZoomScale = zsv.MinimumZoomScale;
				this.MaximumZoomScale = zsv.MaximumZoomScale;
				this.ViewForZoomingInScrollView += (UIScrollView sv) => this.Subviews[0];
			}
		}
	}
}