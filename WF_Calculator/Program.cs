using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WF_Calculator
{
	class Program
	{
		static void Main(string[] args)
		{
			Calculator calculator = new Calculator();
			Application.Run(calculator);
		}
	}
}
