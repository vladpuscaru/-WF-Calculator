using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WF_Calculator
{
	class Calculator : Form
	{
		private Button CE;
		private Button C;
		private Button back;
		private Button divide;
		private Button multiply;
		private Button minus;
		private Button plus;
		private Button equal;
		private Button point;
		private Button[] numbers;
		private Panel screen;
		private Label screenTop;
		private Label screenBottom;

		private int marginBetween = 5;
		private int marginAround = 15;
		private Size buttonSize = new Size(45, 30);

		private bool operation;

		public Calculator()
		{
			InitializeComponent();
		}
		private void InitializeComponent()
		{
			int xOffSet = 0;
			int yOffSet = 0;

			this.Text = "Calculator";
			this.Size = new Size(240, 310);
			this.MaximumSize = new Size(240, 310);
			this.MinimumSize = new Size(240, 310);

			screen = new Panel();
			screen.Size = new Size(195, 70);
			screen.BackColor = Color.White;
			screen.BorderStyle = BorderStyle.FixedSingle;
			screen.Location = new Point(marginAround, marginAround);

			screenTop = new Label();
			screenTop.Size = new Size(screen.Size.Width - 10, screen.Size.Height / 2);
			screenTop.Location = new Point(0, 0);
			screenTop.TextAlign = ContentAlignment.MiddleRight;
			screen.Controls.Add(screenTop);

			screenBottom = new Label();
			screenBottom.Size = new Size(screen.Size.Width - 10, screen.Size.Height / 2);
			screenBottom.Location = new Point(0, screen.Size.Height / 2);
			screenBottom.TextAlign = ContentAlignment.MiddleRight;
			screenBottom.Text = "0";
			screenBottom.Font = new Font("Arial", 16, FontStyle.Bold);
			screen.Controls.Add(screenBottom);
			

			yOffSet = marginAround + screen.Size.Height + marginBetween;
			xOffSet = marginAround;

			// FIRST ROW

			CE = new Button();
			CE.Size = new Size(buttonSize.Width, buttonSize.Height);
			CE.Location = new Point(xOffSet, yOffSet);
			CE.Text = "CE";

			xOffSet += buttonSize.Width + marginBetween;

			C = new Button();
			C.Size = new Size(buttonSize.Width, buttonSize.Height);
			C.Location = new Point(xOffSet, yOffSet);
			C.Text = "C";

			xOffSet += buttonSize.Width + marginBetween;

			back = new Button();
			back.Size = new Size(buttonSize.Width, buttonSize.Height);
			back.Location = new Point(xOffSet, yOffSet);
			back.Text = "<=";

			xOffSet += buttonSize.Width + marginBetween;

			divide = new Button();
			divide.Size = new Size(buttonSize.Width, buttonSize.Height);
			divide.Location = new Point(xOffSet, yOffSet);
			divide.Text = "÷";

			xOffSet = marginAround;
			yOffSet += buttonSize.Height + marginBetween;

			// NUMBERS 1 - 9

			numbers = new Button[10];
			for (int i = 0; i < 9; i++)
			{
				numbers[i] = new Button();
				numbers[i].Size = new Size(buttonSize.Width, buttonSize.Height);
				numbers[i].Location = new Point(xOffSet, yOffSet);
				numbers[i].Text = ( 9 - i ).ToString();

				if ((i + 1) % 3 == 0)
				{
					xOffSet = marginAround;
					yOffSet += buttonSize.Height + marginBetween;
				}
				else
				{
					xOffSet += buttonSize.Width + marginBetween;
				}

			}

			xOffSet = marginAround + 3 * marginBetween + 3 * buttonSize.Width;
			yOffSet = marginAround + screen.Size.Height + 2 * marginBetween + buttonSize.Height;

			multiply = new Button();
			multiply.Size = new Size(buttonSize.Width, buttonSize.Height);
			multiply.Location = new Point(xOffSet, yOffSet);
			multiply.Text = "x";

			yOffSet += buttonSize.Height + marginBetween;

			minus = new Button();
			minus.Size = new Size(buttonSize.Width, buttonSize.Height);
			minus.Location = new Point(xOffSet, yOffSet);
			minus.Text = "-";

			yOffSet += buttonSize.Height + marginBetween;

			plus = new Button();
			plus.Size = new Size(buttonSize.Width, buttonSize.Height);
			plus.Location = new Point(xOffSet, yOffSet);
			plus.Text = "+";

			yOffSet += buttonSize.Height + marginBetween;

			equal = new Button();
			equal.Size = new Size(buttonSize.Width, buttonSize.Height);
			equal.Location = new Point(xOffSet, yOffSet);
			equal.Text = "=";

			xOffSet = marginAround;

			// zero
			numbers[9] = new Button();
			numbers[9].Size = new Size(buttonSize.Width * 2 + marginBetween, buttonSize.Height);
			numbers[9].Location = new Point(xOffSet, yOffSet);
			numbers[9].Text = "0";

			// point
			xOffSet += buttonSize.Width * 2 + 2 * marginBetween;

			point = new Button();
			point.Size = new Size(buttonSize.Width, buttonSize.Height);
			point.Location = new Point(xOffSet, yOffSet);
			point.Text = ".";



			this.Controls.Add(screen);
			this.Controls.Add(CE);
			this.Controls.Add(C);
			this.Controls.Add(back);
			this.Controls.Add(divide);
			for (int i = 0; i < 10; i++)
			{
				this.Controls.Add(numbers[i]);
			}
			this.Controls.Add(multiply);
			this.Controls.Add(minus);
			this.Controls.Add(plus);
			this.Controls.Add(equal);
			this.Controls.Add(point);


			// ADDING EVENTS
			for (int i = 0; i < 10; i++)
			{
				numbers[i].Click += UpdateScreen;
			}
			CE.Click += UpdateScreen;
			C.Click += UpdateScreen;
			multiply.Click += UpdateScreen;
			divide.Click += UpdateScreen;
			plus.Click += UpdateScreen;
			minus.Click += UpdateScreen;


		}
		private void UpdateScreen(Object sender, EventArgs a)
		{
			switch((sender as Button).Text)
			{
				case "CE": screenTop.Text = ""; screenBottom.Text = "0"; break;
				case "C": screenBottom.Text = "0"; break;
				case "x": screenTop.Text += " " + (sender as Button).Text + " "; operation = true; break;
				case "+": screenTop.Text += " " + (sender as Button).Text + " "; operation = true; break;
				case "-": screenTop.Text += " " + (sender as Button).Text + " "; operation = true; break;
				default:
					if (screenBottom.Text == "0" || operation)
					{
						screenBottom.Text = (sender as Button).Text;
						if (operation)
							operation = false;
					}
					else
						screenBottom.Text += (sender as Button).Text;
					screenTop.Text += (sender as Button).Text;
					break;
			}
		}
	}
}
