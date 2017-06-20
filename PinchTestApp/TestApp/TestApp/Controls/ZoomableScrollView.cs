using Xamarin.Forms;

namespace TestApp.Controls
{
	public class ZoomableScrollView : ScrollView
	{
		public static readonly BindableProperty MinimumZoomScaleProperty = BindableProperty.Create("MinimumZoomScale", typeof(float), typeof(ZoomableScrollView), default(float));

		public float MinimumZoomScale
		{
			get { return (float)GetValue(MinimumZoomScaleProperty); }
			set { SetValue(MinimumZoomScaleProperty, value); }
		}
		public static readonly BindableProperty MaximumZoomScaleProperty = BindableProperty.Create("MaximumZoomScale", typeof(float), typeof(ZoomableScrollView), default(float));

		public float MaximumZoomScale
		{
			get { return (float)GetValue(MaximumZoomScaleProperty); }
			set { SetValue(MaximumZoomScaleProperty, value); }
		}
	}
}
