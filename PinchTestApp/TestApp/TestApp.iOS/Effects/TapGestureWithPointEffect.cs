﻿using System;
using TestApp.Controls;
using UIKit;
using System.ComponentModel;
using TestApp.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("AvalonSoftware")]
[assembly: ExportEffect(typeof(TapGestureWithPointEffect), nameof(TapGestureWithPointEffect))]

namespace TestApp.iOS
{
	internal class TapGestureWithPointEffect : PlatformEffect
	{
		private readonly UITapGestureRecognizer tapDetector;
		private Command<Point> tapWithPositionCommand;

		public TapGestureWithPointEffect()
		{
			tapDetector = CreateTapRecognizer(() => tapWithPositionCommand);
			;
		}

		private UITapGestureRecognizer CreateTapRecognizer(Func<Command<Point>> getCommand)
		{
			return new UITapGestureRecognizer(() =>
			{
				var handler = getCommand();
				if (handler != null)
				{
					var control = Control ?? Container;
					var tapPoint = tapDetector.LocationInView(control);
					var point = new Point(tapPoint.X, tapPoint.Y);

					if (handler.CanExecute(point) == true)
						handler.Execute(point);
				}
			})
			{
				Enabled = false,
				ShouldRecognizeSimultaneously = (recognizer, gestureRecognizer) => true,
			};
		}

		protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
		{
			tapWithPositionCommand = Gesture.GetCommand(Element);
		}

		protected override void OnAttached()
		{
			var control = Control ?? Container;

			control.AddGestureRecognizer(tapDetector);
			tapDetector.Enabled = true;

			OnElementPropertyChanged(new PropertyChangedEventArgs(String.Empty));
		}

		protected override void OnDetached()
		{
			var control = Control ?? Container;
			tapDetector.Enabled = false;
			control.RemoveGestureRecognizer(tapDetector);
		}
	}
}