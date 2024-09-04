using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DapperLesson
{
    internal class Database : IDisposable
    {
        public SqlConnection Connection { get; set; }
        public Database(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }
        public Student? Login(int id)
        {
            var query = "Select * From Students Where id = @id";
            var student = Connection.QuerySingleOrDefault<Student>(query, param: new { id });
            return student;
        }

        public List<Book> GetAllBooks()
        {
            var query = "Select * From Books Where Quantity > 0";
            var books = Connection.Query<Book>(query).ToList();
            return books;
        }

        public Book? GetBookByName(string name)
        {
            var query = "Select * From Books Where Name = @name AND Quantity > 0";
            var book = Connection.QuerySingleOrDefault<Book>(query, new { name });
            return book;
        }


        public void Dispose()
        {
            Connection.Dispose();
        }

    }
}
