using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Redis
{
	class Program
	{
		static void Main(string[] args)
		{
			string host = "localhost";
			string elementKey = "testKeyRedis";

			using (RedisClient redisClient = new RedisClient(host))
			{
				redisClient.Set(elementKey, "fuck you value");
				string message = "Item value is: " + redisClient.Get<string>(elementKey);
				Console.WriteLine(message);
			}
		}
	}
}
