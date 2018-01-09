using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class Country:MyBase, IDatabase
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public bool Insert()
        {
            Command = MyCommand("insert into country(name) values(@name)");
            Command.Parameters.AddWithValue("@name", Name);
            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand("update country set name = @name where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from country where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select id, name from country where id = @id");
            Command.Parameters.AddWithValue("@id", Id); 
            MyReader = ExecuteReader(Command);
            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select(string ExtraSQL = "")
        {
            Command = MyCommand("select id, name from country " + ExtraSQL);
            if(!(Name == null || Name == ""))
            {
                Command.CommandText += " where name like @search";
                Command.Parameters.AddWithValue("@search", "%" + Name + "%");
            }
            return ExecuteDataSet(Command);
        }

        public DataSet Select()
        {
            Command = MyCommand("select id, name from country ");
            if (!(Name == null || Name == ""))
            {
                Command.CommandText += " where name like @search";
                Command.Parameters.AddWithValue("@search", "%" + Name + "%");
            }
            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand("create table country(id int identity primary key, name varchar(200) not null unique)");
            return Execute(Command);
        }

    }
}
