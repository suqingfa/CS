using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Program
{
	static void Main(string[] args)
	{
		string input = "1851 1999 1950 1905 2003";
		string pattern = @"(?<=19)\d{2}\b";

		foreach (Match match in Regex.Matches(input, pattern))
			Console.WriteLine(match);
	}
}
