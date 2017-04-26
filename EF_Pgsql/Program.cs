using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Pgsql
{
    class Program
    {
        static void Main(string[] args)
        {
            TestDBContext context = new TestDBContext();
            context.Database.Log = Console.WriteLine;
            context.Database.CreateIfNotExists();

            var a = context.Users.ToArray();
            Console.WriteLine(a);
        }
    }

    public class TestDBContext : DbContext
    {
        public TestDBContext() : base("name=TestDBContext") { }

        public DbSet<User> Users { get; set; }
    }


    public class User
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
