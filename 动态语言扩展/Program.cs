using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Dynamic;

class Person
{
	static void Main(string[] args)
	{
		ScriptEngine pyEngine = Python.CreateEngine();
		
		ScriptScope scope = pyEngine.CreateScope();
		scope.SetVariable("i", 1234);
		pyEngine.CreateScriptSourceFromFile("Test.py").Execute(scope);
		int ret = scope.GetVariable<int>("ret");

		Console.WriteLine(ret);

		dynamic expObj = new ExpandoObject();
		expObj.Name = "苏";
		Console.WriteLine(expObj.Name);
	}
}