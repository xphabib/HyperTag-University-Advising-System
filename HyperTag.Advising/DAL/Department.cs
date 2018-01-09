using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class Department:MyBase,IDatabase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

  
        public bool Insert()
        {
            Command = MyCommand("insert into department(name, description) values(@name,@description)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand("update department set name = @name, description= @description where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from department  where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select id, name, description,from department  where id = @id");
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

        public DataSet Select(string ExtraSQL = "")
        {
            Command = MyCommand("select id, name, description from department " + ExtraSQL);
            if (!(Name == null || Name == ""))
            {
                Command.CommandText += " where name like @search";
                Command.Parameters.AddWithValue("@search", "%" + Name + "%");
            }
            return ExecuteDataSet(Command);
        }

     

        public bool Table()
        {
            Command = MyCommand("create table department (id int identity primary key, name varchar(200) not null unique,description varchar(500)");
            return Execute(Command);
        }


    }
}
