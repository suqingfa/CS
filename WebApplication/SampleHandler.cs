using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
	public class SampleHandler : IHttpHandler
	{
		public bool IsReusable => true;

		public void ProcessRequest(HttpContext context)
		{
			string responseSting = @"
<!DOCTYPE html>
<html>
	<head>
		<meta charset=""UTF-8""/>
		<title>主页</title>
	</head>
	<body>
		<h1> Hello from the custom handler </h1>
		<div>{0}</div>
		<div>{1}</div>
	</body>
</html>";
			HttpRequest request = context.Request;
			HttpResponse response = context.Response;
			response.ContentType = "text/html";
			response.Write(string.Format(responseSting, request.UserHostAddress, request.UserAgent));
		}
	}
}