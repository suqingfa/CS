using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
	static Task<string> GreetingAsync(string name)
	{
		return Task.Run(() =>
		{
			Thread.Sleep(1000);
			return name;
		});
	}

	static async void Caller()
	{
		string t = await GreetingAsync("Hello ");
		var t1 = GreetingAsync("苏");
		var t2 = GreetingAsync("庆发");
		string[] result = await Task.WhenAll(t1, t2);

		Console.WriteLine(t + result[0] + result[1]);
	}

	static void Main(string[] args)
	{
		Caller();
		Console.WriteLine("Main Thread");
		Thread.Sleep(3000);
	}
}
