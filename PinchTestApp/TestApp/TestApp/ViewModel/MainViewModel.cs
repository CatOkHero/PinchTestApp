using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace TestApp.ViewModel
{
	public class MainViewModel : INotifyPropertyChanged
	{
		DateTime dateTime;

		public Command<Point> CanvasTappedCommand
		{
			get
			{
				return new Command<Point>((p) => OnCanvasTapped(p));
			}
		}

		public void OnCanvasTapped(Point p)
		{
			// your event handling logic
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
