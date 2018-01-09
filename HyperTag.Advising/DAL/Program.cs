using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class Program:MyBase,IDatabase
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public int MinimumCredit { get; set; }
        public int DepartmentId { get; set; }

        public bool Insert()
        {
            Command = MyCommand("insert into program(name, description,duration,minimumCredit,departmentId) values(@name,@description,@duration,@minimumCredit,@departmentId)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@duration", Duration);
            Command.Parameters.AddWithValue("@minimumCredit", MinimumCredit);
            Command.Parameters.AddWithValue("@departmentId", DepartmentId);
            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand("update program set name = @name, departmentId = @departmentId where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@description", Description);
            Command.Parameters.AddWithValue("@duration", Duration);
            Command.Parameters.AddWithValue("@minimumCredit", MinimumCredit);
            Command.Parameters.AddWithValue("@countryId", DepartmentId);
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from program  where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select id, name, description,duration,minimumCredit,departmentId from program  where id = @id");
            Command.Parameters.AddWithValue("@id", Id);

            MyReader = ExecuteReader(Command);

            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                Description = MyReader["description"].ToString();
                Duration = Convert.ToInt32(MyReader["duration"]);
                MinimumCredit = Convert.ToInt32(MyReader["minimumCredit"]);
                DepartmentId = Convert.ToInt32(MyReader["departmentId"]);
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            Command = MyCommand(@"select p.id, p.name, p.duration, p.minimumCredit, 
                                d.name as department, p.description
                                from program p
                                left join department d on p.departmentId = d.id where p.id > 0 ");

            if (Name != null && Name != "")
            {
                Command.CommandText += " and program.name like @search ";
                Command.Parameters.AddWithValue("@search", "%" + Name + "%");
            }

            if (DepartmentId > 0)
            {
                Command.CommandText += " and program.departmentId = @departmentId";
                Command.Parameters.AddWithValue("@departmentId", DepartmentId);
            }

            return ExecuteDataSet(Command);
        }

            public bool Table()
           {
            Command = MyCommand("create table program (id int identity primary key, name varchar(200) not null unique,description varchar(500),duration int,minimumCredit int,departmentId int, foreign key(departmentId) references department(id))");
            return Execute(Command);
           }


        
    }
}

