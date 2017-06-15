using System;
using Xamarin.Forms;

namespace TestApp.Controls
{
	public class GridWithGesture : Grid
	{
		public event EventHandler<PinchGestureUpdatedEventArgs> PinchAction;

		public void OnPinchAction(Element element, PinchGestureUpdatedEventArgs args)
		{
			PinchAction?.Invoke(element, args);
		}
	}
}
