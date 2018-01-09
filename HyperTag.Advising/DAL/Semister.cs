using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class Semister:MyBase, IDatabase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }

        public bool Insert()
        {
            Command = MyCommand("insert into semister(name,year,duration, description) values(@name,@year,@duration, @description)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@year", Year);
            Command.Parameters.AddWithValue("@duration", Duration);
            Command.Parameters.AddWithValue("@description", Description);
            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand("update semister set name = @name,year = @year, duration=@duration, description = @description where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@year", Year);
            Command.Parameters.AddWithValue("@duration", Duration);
            Command.Parameters.AddWithValue("@description", Description);
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from semister where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select id, name,year,duration, description from semister  where id = @id");
            Command.Parameters.AddWithValue("@id", Id);

            MyReader = ExecuteReader(Command);

            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                Year = Convert.ToInt32(MyReader["year"]);
                Duration = Convert.ToInt32(MyReader["duration"]);
                Description = MyReader["description"].ToString();
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            Command = MyCommand(@"select semister.id, semister.name, semister.year, semister.duration 
                                semister.description
                                from semister where semister.id > 0 ");

            if (Name != null && Name != "")
            {
                Command.CommandText += " and semister.name like @search ";
                Command.Parameters.AddWithValue("@search", "%" + Name + "%");
            }
            if (Description != null && Description != "")
            {
                Command.CommandText += " and semister.description like @search ";
                Command.Parameters.AddWithValue("@search", "%" + Description + "%");
            }
            if (Year > 0)
            {
                Command.CommandText += " and semister.year = @year";
                Command.Parameters.AddWithValue("@year", Year);
            }
            if (Duration > 0)
            {
                Command.CommandText += " and semister.duration = @duration";
                Command.Parameters.AddWithValue("@duration", Duration);
            }

            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand("create table Semester(Id int identity primary key,Name varchar(200) not null,[Year] int not null,Duration int not null,[Description] varchar(500))");
            return Execute(Command);
        }
    }
}
