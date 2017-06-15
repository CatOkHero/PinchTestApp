using System;
using Xamarin.Forms;

namespace TestApp.ViewModel
{
    public class TouchEffect : RoutingEffect
    {
        public event TouchActionEventHandler TouchAction;

	    public event EventHandler<PinchGestureUpdatedEventArgs> PinchAction;

        public TouchEffect() : base("new.new1")
        {
        }

        public bool Capture { set; get; }

        public void OnTouchAction(Element element, TouchActionEventArgs args)
        {
            TouchAction?.Invoke(element, args);
        }

	    public void OnPinchAction(Element element, PinchGestureUpdatedEventArgs args)
	    {
		    PinchAction?.Invoke(element, args);
		}
    }
}
