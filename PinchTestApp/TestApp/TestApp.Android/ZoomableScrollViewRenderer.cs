using System;
using System.Linq;
using Android.Util;
using Android.Views;
using SkiaSharp.Views.Forms;
using TestApp.Controls;
using TestApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly:ExportRenderer(typeof(ZoomableScrollView), typeof(ZoomableScrollViewRenderer))]

namespace TestApp.Droid
{
	public class ZoomableScrollViewRenderer : ScrollViewRenderer
	{
		float originalDistanceX, currentdistanceX, originalDistanceY, currentdistanceY;
		bool IsPinching = false;
		double currentScale;
		private SKCanvasView canvas;
		ScrollView svMain, svSub;
		private StackLayout absoluteLayout;
		private DisplayMetrics displayMetrics;

		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);
			displayMetrics = Context.Resources.DisplayMetrics;
			svMain = ((ScrollView)e.NewElement);
			absoluteLayout = svMain.Content as StackLayout;
			canvas = absoluteLayout.Children.FirstOrDefault() as SKCanvasView;
			//svSub = new ScrollView();
			//svSub.Orientation = ScrollOrientation.Horizontal;
			//svSub.Content = absoluteLayout;
			//svMain.Content = svSub;
		}

		public override bool OnTouchEvent(MotionEvent e)
		{
			if (e.PointerCount > 1)
			{
				IsPinching = true;
				currentScale = canvas.Scale;
				originalDistanceX = Math.Abs(e.GetX(0) - e.GetX(1));
				originalDistanceY = Math.Abs(e.GetY(0) - e.GetY(1));

			}
			else
			{
				IsPinching = false;
			}
			return base.OnTouchEvent(e);
		}

		public override bool DispatchTouchEvent(Android.Views.MotionEvent e)
		{
			switch (e.Action)
			{
				case MotionEventActions.Down:
					this.Parent.RequestDisallowInterceptTouchEvent(true);
					break;
				case MotionEventActions.Move:
					if (IsPinching && e.PointerCount > 1)
					{
						currentdistanceX = Math.Abs(e.GetX(0) - e.GetX(1));
						currentdistanceY = Math.Abs(e.GetY(0) - e.GetY(1));


						if (originalDistanceX < currentdistanceX || originalDistanceY < currentdistanceY)
						{
							svMain.Scale += 0.2;
						}
						else if ((originalDistanceX > currentdistanceX || originalDistanceY > currentdistanceY) && svMain.Scale > 1)
						{
							svMain.Scale -= 0.2;
						}
					}
					break;
				case MotionEventActions.Up:
					this.Parent.RequestDisallowInterceptTouchEvent(false);
					break;
			}
			return base.DispatchTouchEvent(e);
		}

		private Point PxToDp(Point point)
		{
			point.X = point.X / displayMetrics.Density;
			point.Y = point.Y / displayMetrics.Density;
			return point;
		}


	}



	//public class ZoomableScrollViewRenderer : ScrollViewRenderer
	//{
	//	private ScaleGestureDetector _scaleDetector;
	//	private bool _isScaleProcess = false;
	//	private float _prevScale = 1f;

	//	protected override void OnElementChanged(VisualElementChangedEventArgs e)
	//	{
	//		base.OnElementChanged(e);
	//		if (e.NewElement != null)
	//		{
	//			_scaleDetector = new ScaleGestureDetector(Context, new ClearScaleListener(
	//				scale =>
	//				{
	//					var scrollView = Element as ZoomableScrollView;

	//					var xRatio = scale.FocusX / Width;
	//					var yRatio = scale.FocusY / Height;

	//					scrollView.AnchorX = xRatio;
	//					scrollView.AnchorY = yRatio;
	//				},
	//				scale =>
	//				{
	//					_isScaleProcess = true;
	//					var scrollView = Element as ZoomableScrollView;
	//					var horScrollView = GetChildAt(0) as global::Android.Widget.HorizontalScrollView;
	//					var content = horScrollView.GetChildAt(0);
	//					_prevScale = Math.Max((float)scrollView.MinimumZoomScale, Math.Min(_prevScale * scale.ScaleFactor, (float)scrollView.MaximumZoomScale));

	//					content.ScaleX = content.ScaleY = _prevScale;
	//					System.Diagnostics.Debug.WriteLine($"Delta: {scale}  Final: {content.ScaleX}");
	//					System.Diagnostics.Debug.WriteLine($"AnchorX: {scrollView.AnchorX}  AnchorY: {scrollView.AnchorY}");
	//				}));
	//		}
	//	}

	//	public override bool DispatchTouchEvent(MotionEvent e)
	//	{
	//		if (e.PointerCount == 2)
	//		{
	//			return _scaleDetector.OnTouchEvent(e);
	//		}
	//		else if (_isScaleProcess)
	//		{
	//			//HACK:
	//			//Prevent letting any touch events from moving the scroll view until all fingers are up from zooming...This prevents the jumping and skipping around after user zooms.
	//			if (e.Action == MotionEventActions.Up)
	//				_isScaleProcess = false;
	//			return false;
	//		}
	//		else
	//			return base.OnTouchEvent(e);
	//	}
	//}

	//public class ClearScaleListener : ScaleGestureDetector.SimpleOnScaleGestureListener
	//{
	//	private Action<ScaleGestureDetector> _onScale;
	//	private Action<ScaleGestureDetector> _onScaleBegin;
	//	private bool _skip = false;

	//	public ClearScaleListener(Action<ScaleGestureDetector> onScaleBegin, Action<ScaleGestureDetector> onScale)
	//	{
	//		_onScale = onScale;
	//		_onScaleBegin = onScaleBegin;
	//	}

	//	public override bool OnScale(ScaleGestureDetector detector)
	//	{
	//		if (_skip)
	//		{
	//			_skip = false;
	//			return true;
	//		}
	//		_onScale?.Invoke(detector);
	//		return true;
	//	}

	//	public override bool OnScaleBegin(ScaleGestureDetector detector)
	//	{
	//		System.Diagnostics.Debug.WriteLine($"Begin {detector.ScaleFactor}");
	//		_skip = true;
	//		_onScaleBegin.Invoke(detector);
	//		return true;
	//	}
	//}
}