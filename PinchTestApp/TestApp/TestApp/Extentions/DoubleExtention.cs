using System;

namespace TestApp.Extentions
{
	public static class DoubleExtention
	{
		public static double Clamp(this double self, double min, double max)
		{
			return Math.Min(max, Math.Max(self, min));
		}
	}
}
