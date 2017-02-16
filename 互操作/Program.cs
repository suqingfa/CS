using System;
using System.Runtime.InteropServices;
using 互操作性COMLib;

namespace 互操作
{
	class Program
	{
		static void Main(string[] args)
		{
			IWelcome demo = new Welcome();
			Console.WriteLine(demo.Greeting("苏"));

			// 释放组件
			Marshal.ReleaseComObject(demo);

			Type t = Type.GetTypeFromProgID("COMServer.COMDemo");
			dynamic o = Activator.CreateInstance(t);
			Console.WriteLine(o.Greeting("庆发"));

			Console.WriteLine(fnDLL());
		}
		
		[DllImport("互操作性DLL.dll")]
		static extern int fnDLL();
	}
}
