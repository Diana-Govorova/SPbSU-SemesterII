﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task2
{
	/// <summary>
	/// Analog circle clock.
	/// </summary>
	public partial class Clock : Form
	{
		private Timer timer = new Timer();

		private const int width = 300;
		private const int height = 300;
		private const int lengthOfSecondHand = 140;
		private const int lengthOfMinuteHand = 110;
		private const int lengthOfHourHand = 80;

		private Coordinate centerCoordinate;

		private Bitmap bitmap;
		private Graphics graphics;

		/// <summary>
		/// Coordinates for hands.
		/// </summary>
		private class Coordinate
		{
			public int xCoordinate;
			public int yCoordinate;

			/// <summary>
			/// Coordinate constructor with x and y.
			/// </summary>
			public Coordinate(int xCoordinate, int yCoordinate)
			{
				this.xCoordinate = xCoordinate;
				this.yCoordinate = yCoordinate;
			}

			/// <summary>
			/// Coordinate constructor without x and y.
			/// </summary>
			public Coordinate()
			{
			}
		}

		public Clock()
		{
			InitializeComponent();
			bitmap = new Bitmap(width + 1, height + 1);
			centerCoordinate = new Coordinate();
			centerCoordinate.xCoordinate = width / 2;
			centerCoordinate.yCoordinate = height / 2;
			ClockFace();
			timer.Interval = 1000;
			timer.Tick += new EventHandler(this.Tick);
			timer.Start();
		}

		/// <summary>
		/// Draw a clock's face.
		/// </summary>
		private void ClockFace()
		{
			graphics = Graphics.FromImage(bitmap);

			graphics.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, width, height);

			graphics.DrawString("12", new Font("Arial", 12), Brushes.Black, new PointF(140, 2));
			graphics.DrawString("3", new Font("Arial", 12), Brushes.Black, new PointF(286, 140));
			graphics.DrawString("6", new Font("Arial", 12), Brushes.Black, new PointF(142, 282));
			graphics.DrawString("9", new Font("Arial", 12), Brushes.Black, new PointF(0, 140));

			Tick(timer, EventArgs.Empty);
		}

		/// <summary>
		/// Clock's tick.
		/// </summary>
		private void Tick(object sender, EventArgs e)
		{
			var tickBitmap = (Bitmap)bitmap.Clone();
			graphics = Graphics.FromImage(tickBitmap);

			int second = DateTime.Now.Second;
			int minute = DateTime.Now.Minute;
			int hour = DateTime.Now.Hour;

			var handCoordinate = new Coordinate();

			handCoordinate = MinuteOrSecondHandCoordinate(second, lengthOfSecondHand);
			graphics.DrawLine(new Pen(Color.Red, 1f), new Point(centerCoordinate.xCoordinate, centerCoordinate.yCoordinate), new Point(handCoordinate.xCoordinate, handCoordinate.yCoordinate));

			handCoordinate = MinuteOrSecondHandCoordinate(minute, lengthOfMinuteHand);
			graphics.DrawLine(new Pen(Color.Black, 2f), new Point(centerCoordinate.xCoordinate, centerCoordinate.yCoordinate), new Point(handCoordinate.xCoordinate, handCoordinate.yCoordinate));

			handCoordinate = HourHandCoordinate(hour % 12, minute, lengthOfHourHand);
			graphics.DrawLine(new Pen(Color.Black, 3f), new Point(centerCoordinate.xCoordinate, centerCoordinate.yCoordinate), new Point(handCoordinate.xCoordinate, handCoordinate.yCoordinate));

			pictureBox1.Image = tickBitmap;
		}

		/// <summary>
		/// Coordinate for minute and second hand.
		/// </summary>
		/// <param name="value">Minute or second value.</param>
		/// <param name="handLength">Hand length.</param>
		/// <returns>Coordinate of clock's hands.</returns>
		private Coordinate MinuteOrSecondHandCoordinate(int value, int handLength)
		{
			var coordinate = new Coordinate();
			value *= 6;

			if (value >= 0 && value <= 180)
			{
				coordinate.xCoordinate = centerCoordinate.xCoordinate + (int)(handLength * Math.Sin(Math.PI * value / 180));
				coordinate.yCoordinate = centerCoordinate.yCoordinate - (int)(handLength * Math.Cos(Math.PI * value / 180));
			}
			else
			{
				coordinate.xCoordinate = centerCoordinate.xCoordinate - (int)(handLength * -Math.Sin(Math.PI * value / 180));
				coordinate.yCoordinate = centerCoordinate.yCoordinate - (int)(handLength * Math.Cos(Math.PI * value / 180));
			}

			return coordinate;
		}

		/// <summary>
		/// Coordinate for hour hand.
		/// </summary>
		/// <param name="hourValue">Hour value.</param>
		/// <param name="minuteValue">Minute value.</param>
		/// <param name="handLength">Hand length.</param>
		/// <returns>Coordinate of clock's hands.</returns>
		private Coordinate HourHandCoordinate(int hourValue, int minuteValue, int handLength)
		{
			var coordinate = new Coordinate();
			int value = (int)((hourValue * 30) + (minuteValue * 0.5));

			if (value >= 0 && value <= 180)
			{
				coordinate.xCoordinate = centerCoordinate.xCoordinate + (int)(handLength * Math.Sin(Math.PI * value / 180));
				coordinate.yCoordinate = centerCoordinate.yCoordinate - (int)(handLength * Math.Cos(Math.PI * value / 180));
			}
			else
			{
				coordinate.xCoordinate = centerCoordinate.xCoordinate - (int)(handLength * -Math.Sin(Math.PI * value / 180));
				coordinate.yCoordinate = centerCoordinate.yCoordinate - (int)(handLength * Math.Cos(Math.PI * value / 180));
			}

			return coordinate;
		}
	}
}