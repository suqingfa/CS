using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Linq_to_SQL
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] nums = { -1, 0, 1, 2, 2, 3, 4, 1 };
			var posNums = from n in nums
						  where n > 0
						  orderby n descending
						  select n * n
						  into nn
						  where nn < 10
						  select nn;

			// 匿名类
			var tempVar = new { a = 1, b = 2};
			Console.WriteLine(tempVar);

			using (DataClassesDataContext context = new DataClassesDataContext())
			{
				context.Log = Console.Out;
				var groups = from g in context.Group select g;
				foreach (var group in groups)
				{
					Console.WriteLine(group.Authority);
				}
			}
		}
	}
}