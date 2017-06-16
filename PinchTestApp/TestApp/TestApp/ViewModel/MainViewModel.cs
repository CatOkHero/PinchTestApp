using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

		public MainViewModel()
		{
			this.DateTime = DateTime.Now;

			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
			{
				this.DateTime = DateTime.Now;
				return true;
			});
		}

		public DateTime DateTime
		{
			set
			{
				if (dateTime != value)
				{
					dateTime = value;

					if (PropertyChanged != null)
					{
						PropertyChanged(this,
							new PropertyChangedEventArgs("DateTime"));
					}
				}
			}
			get
			{
				return dateTime;
			}
		}
	}
}
