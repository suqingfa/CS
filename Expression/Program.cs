using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Expression
{
	class Program
	{
		private static string GetMapProperty<T>(Expression<Func<T, object>> mapDataColumn)
		{
			var expression = mapDataColumn.Body;

			switch (expression.NodeType)
			{
				case ExpressionType.Constant:
					return (expression as ConstantExpression).Value.ToString();

				case ExpressionType.Convert:
					return (expression as UnaryExpression).Operand.ToString();
			}

			return string.Empty;
		}

		class Test
		{
			public int ID { get; set; }
			public string Name { get; set; }
		}

		static void Main(string[] args)
		{
			Console.WriteLine(GetMapProperty<Test>(m => "3"));
			Console.WriteLine(GetMapProperty<Test>(m => m.ID));
			Console.WriteLine(GetMapProperty<Test>(m => m.ID + "1"));
		}
	}
}
