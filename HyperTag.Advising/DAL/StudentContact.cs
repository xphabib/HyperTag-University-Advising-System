using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class StudentContact : MyBase, IDatabase
    {

        public int StudentId { get; set; }
        public string Contact { get; set; }

        public bool Insert()
        {
            Command = MyCommand("insert into StudentContact(Contact) values(@Contact)");
            Command.Parameters.AddWithValue("@Contact", Contact);
            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand("update StudentContact set Contact = @name where Contact = @Contact");
            Command.Parameters.AddWithValue("@StudentId", StudentId);
            Command.Parameters.AddWithValue("@Contact", Contact);
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from StudentContact where StudentId = @StudentId");
            Command.Parameters.AddWithValue("@StudentId", StudentId);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select StudentId, Contact from StudentContact where StudentId = @StudentId");
            Command.Parameters.AddWithValue("@StudentId", StudentId);
            MyReader = ExecuteReader(Command);
            while (MyReader.Read())
            {
                Contact = MyReader["Contact"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select(string ExtraSQL = "")
        {
            Command = MyCommand("select StudentId, name from StudentContact " + ExtraSQL);
            if (!(Contact == null || Contact == ""))
            {
                Command.CommandText += " where Contact like @search";
                Command.Parameters.AddWithValue("@search", "%" + Contact + "%");
            }
            return ExecuteDataSet(Command);
        }

        public DataSet Select()
        {
            Command = MyCommand("select StudentId, Contact from StudentContact ");

           /*
         Command = MyCommand(@"select StudentContact.StudentId, 
                             Student.name as name
                             from StudentContact
                             inner join Student on StudentContact.StudentId = Student.id where StudentContact.StudentId > 0 ");
     */

            if (!(Contact == null || Contact == ""))
            {
                Command.CommandText += " where Contact like @search";
                Command.Parameters.AddWithValue("@search", "%" + Contact + "%");
            }
            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand("create table StudentContact(StudentId int, foreign key (StudentId) references Student(id), Contact varchar(200) not null unique)");
            return Execute(Command);
        }

    }
}
