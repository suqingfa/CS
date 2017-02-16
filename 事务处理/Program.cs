using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Transactions;

[Transaction(TransactionOption.Required)]
class Program : ServicedComponent
{
	static void Main(string[] args)
	{
	}

	[AutoComplete]
	void AddStudent(Student student)
	{
		using (var con = new SqlConnection())
		{
			con.Open();
			SqlCommand command = con.CreateCommand();

			command.CommandText = "INSERT INTO Students VALUES(@ID, @Name)";
			command.Parameters.AddWithValue("@ID", student.ID);
			command.Parameters.AddWithValue("@name", student.Name);

			command.ExecuteNonQuery();
		}
	}
}


class Student
{
	public int ID { get; set; }
	public string Name { get; set; }
	public string Company { get; set; }

	public override string ToString()
	{
		return string.Format("ID: {0}, Name: {1}", ID, Name);
	}
}