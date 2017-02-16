using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

class Program
{
	static void Main(string[] args)
	{
		var i = DateTime.Now;
		Console.WriteLine(i);

		CultureInfo cultureInfo = new CultureInfo("en-us");
		Console.WriteLine(cultureInfo);
		Thread.CurrentThread.CurrentCulture = cultureInfo;

		Console.WriteLine(i);
	}
}
