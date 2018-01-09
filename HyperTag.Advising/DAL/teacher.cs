using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class teacher : MyBase, IDatabase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string contact { get; set; }
        public string email { get; set; }

        public bool Insert()
        {
            Command = MyCommand("insert into teacher(name, contact, email, courseId) values( @name, @contact, @email, @courseId)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@contact", contact);
            Command.Parameters.AddWithValue("@email", email);
            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand("update teacher set name = @name, contact = @contact, email = @email, courseId = @courseId where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@contact", contact);
            Command.Parameters.AddWithValue("@email", email);
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from teacher  where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select id, name, contact,email, courseId from teacher  where id = @id");
            Command.Parameters.AddWithValue("@id", Id);

            MyReader = ExecuteReader(Command);

            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                contact = MyReader["contact"].ToString();
                email = MyReader["email"].ToString();
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            Command = MyCommand(@"select teacher.id, teacher.name, teacher.contact, teacher.email
                                from teacher where teacher.id > 0 ");

            if (Name != null && Name != "")
            {
                Command.CommandText += " and teacher.name like @search ";
                Command.Parameters.AddWithValue("@search", "%" + Name + "%");
            }

           

            if(contact != null && contact != "")
            {
                Command.CommandText += "and teacher.contact like @search";
                Command.Parameters.AddWithValue("@search", "%" + contact + "%");
            }

            if(email != null && email != "")
            {
                Command.CommandText += " and teacher.email like @search";
                Command.Parameters.AddWithValue("@search", "%" + email + "%");
            }


            return ExecuteDataSet(Command);
        }


        public bool Table()
        {
            Command = MyCommand(" create table teacher(Id int identity(1,1) primary key, Name varchar(200) not null,courseId int,Contact varchar(25) unique not null,Email varchar(25) unique not null,forign key(courseId) references course(id),)");
            return Execute(Command);
        }
    }
}
