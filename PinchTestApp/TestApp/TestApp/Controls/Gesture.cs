using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApp.Controls
{
	public static class Gesture
	{
		public static readonly BindableProperty TappedProperty = BindableProperty.CreateAttached("Tapped",
			typeof(Command<Point>), typeof(Gesture), null, propertyChanged: CommandChanged);


		public static readonly BindableProperty PinchedProperty = BindableProperty.CreateAttached("Pinched",
			typeof(Command<PinchGestureUpdatedEventArgs>), typeof(Gesture), null, propertyChanged: CommandChanged);
		

		public static Command<Point> GetCommand(BindableObject view)
		{
			return (Command<Point>) view.GetValue(TappedProperty);
		}

		public static void SetTapped(BindableObject view, Command<Point> value)
		{
			view.SetValue(TappedProperty, value);
		}

		//public static Command<PinchGestureUpdatedEventArgs> GetCommand(BindableObject view)
		//{
		//	return (Command<PinchGestureUpdatedEventArgs>)view.GetValue(PinchedProperty);
		//}

		//public static void SetTapped(BindableObject view, Command<Point> value)
		//{
		//	view.SetValue(PinchedProperty, value);
		//}

		private static void CommandChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var view = bindable as View;
			if (view != null)
			{
				var effect = GetOrCreateEffect(view);
			}
		}

		private static GestureEffect GetOrCreateEffect(View view)
		{
			var effect = (GestureEffect) view.Effects.FirstOrDefault(e => e is GestureEffect);
			if (effect == null)
			{
				effect = new GestureEffect();
				view.Effects.Add(effect);
			}
			return effect;
		}

		
	}

	public class GestureEffect : RoutingEffect
	{
		public event EventHandler<PinchGestureUpdatedEventArgs> PinchAction;

		public GestureEffect() : base("AvalonSoftware.SKCanvasEffect")
		{
		}

		public void OnPinchAction(Element element, PinchGestureUpdatedEventArgs args)
		{
			PinchAction?.Invoke(element, args);
		}
	}
}
