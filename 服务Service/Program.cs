using System.ServiceProcess;

namespace 服务Service
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		static void Main()
		{
			ServiceBase.Run(new Service());
		}
	}
}
