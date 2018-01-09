using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class Education : MyBase, IDatabase
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool Insert()
        {
            Command = MyCommand("insert into education(name, description) values(@name, @description)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand("update education set name = @name, description = @description where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from description  where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select id, name, description from education  where id = @id");
            Command.Parameters.AddWithValue("@id", Id);

            MyReader = ExecuteReader(Command);

            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                Description = MyReader["description"].ToString();
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            Command = MyCommand(@"select e.id, e.name, 
                                e.description
                                from education as e where e.id > 0 ");

            if (Name != null && Name != "")
            {
                Command.CommandText += " and education.name like @search ";
                Command.Parameters.AddWithValue("@search", "%" + Name + "%");
            }
            if(Description != null && Description !="")
            {
                Command.CommandText += " and education.description like @search ";
                Command.Parameters.AddWithValue("@search", "%" + Description + "%");
            }

            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand("create table Education(Id int identity primary key,Name varchar(200) not null,[Description] varchar(500))");
            return Execute(Command);
        }


    }
  
}
