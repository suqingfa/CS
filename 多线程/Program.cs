using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

class Program
{
	static void Main(string[] args)
	{
		int sum = 0;
		object lockOn = new object();
		ThreadStart run = () =>
		{
			for (int i = 0; i < 100; i++)
				lock (lockOn)
				{
					Thread.Sleep(1);
					sum++;
				}
		};

		Thread threadA = new Thread(run);
		Thread threadB = new Thread(run);

		threadA.Start();
		threadB.Start();

		threadA.Join();
		threadB.Join();

		Console.Write(sum);

	}
}
