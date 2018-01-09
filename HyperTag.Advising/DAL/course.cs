using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class course : MyBase, IDatabase
    {
        

        public int Id { get; set; }
        public string Name { get; set; }
        public int Credit { get; set; }
        public int ProgramId { get; set; }
        public string Description { get; set; }

        

        public bool Insert()
        {
            Command = MyCommand("insert into course(name, credit,programId, Description) values( @name, @credit, @programId, @Description)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@credit", Credit);
            Command.Parameters.AddWithValue("@programId", ProgramId);
            Command.Parameters.AddWithValue("@Description", Description);
            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand("update course set  name = @name, credit = @credit, programId = @programId, Description = @Description where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@credit", Credit);
            Command.Parameters.AddWithValue("@programId", ProgramId);
            Command.Parameters.AddWithValue("@Description", Description);

            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from course  where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select id, name, credit, program, Descriotion from course  where id = @id");
            Command.Parameters.AddWithValue("@id", Id);

            MyReader = ExecuteReader(Command);

            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                Credit = Convert.ToInt32(MyReader["credit"]);
                ProgramId = (int)MyReader["program"];
                Description = MyReader["Description"].ToString();
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            Command = MyCommand(@"select course.id, course.name, course.credit, course.program, course.Description  from course where course.id > 0 ");

            if (Name != null && Name != "")
            {
                Command.CommandText += " and course.name like @search ";
                Command.Parameters.AddWithValue("@search", "%" + Name + "%");
            }
            

            if (ProgramId > 0)
            {
                Command.CommandText += "and course.program like @search";
                Command.Parameters.AddWithValue("@search", "%" + ProgramId + "%");
            }
            if (Description != null && Description != "")
            {
                Command.CommandText += " and course.description like @search ";
                Command.Parameters.AddWithValue("@search", "%" + Description + "%");
            }
            if (Credit > 0)
            {
                Command.CommandText += "and course.credite = @credite";
                Command.Parameters.AddWithValue("@credite", Credit);
            }
            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand("create table teacher(Id int identity(1, 1) primary key, Code varchar(30),Name varchar(200) not null,Creadit int, ProgramId varchar(200),[Description] varchar(500))");

            return Execute(Command);
        }
    }
}