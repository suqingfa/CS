using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Configuration;
using System.Transactions;
using System.Data.SqlClient;

class Program
{
	static void Main(string[] args)
	{
		using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
		using (DbConnection conn = GetDbConnection("Main"))
		{
			conn.Open();
			DbCommand cmd = conn.CreateCommand();

			cmd.CommandText = @"SELECT * FROM dbo.[User] WHERE dbo.[User].Name = '苏';";
			// cmd.Parameters.Add 报异常
			DbDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				Console.WriteLine("{0} {1} {2}",
					reader.GetInt32(0),
					reader.GetString(1),
					reader.GetInt32(2));
			}
			reader.Close();

			cmd.CommandText = @"SELECT COUNT(*) FROM dbo.[User];";
			Console.WriteLine("Count: " + cmd.ExecuteScalar());

			scope.Complete();
		}
	}

	static DbConnection GetDbConnection(string name)
	{
		ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
		DbConnection conn =
			DbProviderFactories
			.GetFactory(settings.ProviderName)
			.CreateConnection();
		conn.ConnectionString = settings.ConnectionString;
		return conn;
	}
}