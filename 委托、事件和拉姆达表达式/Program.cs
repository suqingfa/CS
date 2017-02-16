using System;
using System.Linq;

delegate void StrMod(ref string str);

delegate void EventHandler();

class Program
{
	static void Reverse(ref string str)
	{
		str = new string(str.Reverse().ToArray());
	}

	public event EventHandler SomeEvent
	{
		add
		{
			
		}
		remove
		{

		}
	}

	static void Main(string[] args)
	{
		string str = "aaaAAAbb";

		StrMod strOp = Reverse;
		strOp += (ref string t)=> { t = t.ToUpper(); };

		strOp(ref str);

		Console.WriteLine(str);
	}
}
