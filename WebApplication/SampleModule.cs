using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication
{
	public class SampleModule : IHttpModule
	{
		private const string allowedAddressesFile = "AllowedAddresses.txt";
		private List<string> allowedAddresses;

		public void Dispose()
		{
		}

		public void Init(HttpApplication context)
		{
			context.BeginRequest += BeginRequest;
			context.PreRequestHandlerExecute += PreRequestHandlerExecute;
			context.LogRequest += Log;
		}

		private void BeginRequest(object sender, EventArgs e)
		{
			if (allowedAddresses == null)
			{
				string path = (sender as HttpApplication).Server.MapPath(allowedAddressesFile);
				allowedAddresses = File.ReadAllLines(path).ToList();
			}
		}

		private void PreRequestHandlerExecute(object sender, EventArgs e)
		{
			HttpApplication app = sender as HttpApplication;
			HttpRequest req = app.Context.Request;
			if (!allowedAddresses.Contains(req.UserHostAddress))
				throw new HttpException(403, "IP address denied");
		}
		private void Log(object sender, EventArgs e)
		{
		}
	}
}