using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class City:MyBase, IDatabase
    {

       
        public int Id { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }

        public bool Insert()
        {
            Command = MyCommand("insert into city(name, countryId) values(@name, @countryId)");
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@countryId", CountryId);
            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand("update city set name = @name, countryId = @countryId where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@countryId", CountryId);
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from city  where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select id, name, countryId from city  where id = @id");
            Command.Parameters.AddWithValue("@id", Id);

            MyReader = ExecuteReader(Command);
           
            while(MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                CountryId = Convert.ToInt32(MyReader["countryId"]);
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            Command = MyCommand(@"select city.id, city.name, 
                                country.name as country
                                from city
                                inner join country on city.countryId = country.id where city.id > 0 ");

            if(Name != null && Name != "")
            {
                Command.CommandText += " and city.name like @search ";
                Command.Parameters.AddWithValue("@search", "%"+ Name +"%");
            }

            if (CountryId > 0)
            {
                Command.CommandText += " and city.countryId = @countryId";
                Command.Parameters.AddWithValue("@countryId", CountryId);
            }

            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand("create table city(id int identity primary key, name varchar(200) not null unique, countryId int, foreign key(countryId) references country(id))");
            return Execute(Command);
        }
    }
}
