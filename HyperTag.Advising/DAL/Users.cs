using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class Users:MyBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateIP { get; set; }

        public bool Insert()
        {
            Command = MyCommand("insert into users(name,email,password,type, createIp) values(@name,@email,@password,@type, @createIp)");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@email", Email);
            Command.Parameters.AddWithValue("@password",Password);
            Command.Parameters.AddWithValue("@type",Type);
            Command.Parameters.AddWithValue("@createIp",CreateIP);



            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand("update users set name = @name,email= @email,password =  @password,type=@type,createDate=@createDate,createIp=@createIp where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            Command.Parameters.AddWithValue("@name", Name);
            Command.Parameters.AddWithValue("@email", Email);
            Command.Parameters.AddWithValue("@password", Password);
            Command.Parameters.AddWithValue("@type", Type);
            Command.Parameters.AddWithValue("@createDate", CreateDate);
            Command.Parameters.AddWithValue("@createIp", CreateIP);
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from users where id = @id");
            Command.Parameters.AddWithValue("@id", Id);

            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select  id,name,email,password,type,createDate,createIp from users where id = @id");
            Command.Parameters.AddWithValue("@id", Id);
            MyReader = ExecuteReader(Command);
            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                return true;
            }
            return false;
        }

        public bool SelectByOthers()
        {
            Command = MyCommand("select  id,name,email,password,type,createDate,createIp from users where id > 0 ");
            if (Email != null && Email != "")
            {
                Command.CommandText += " and email = @email";
                Command.Parameters.AddWithValue("@email", Email);
            }
            if (Password != null && Password != "")
            {
                Command.CommandText += " and password = @password";
                Command.Parameters.AddWithValue("@password", Password);
            }
            MyReader = ExecuteReader(Command);
            while (MyReader.Read())
            {
                Id = Convert.ToInt32(MyReader["id"]);
                Name = MyReader["name"].ToString();
                Email = MyReader["email"].ToString();
                Type = MyReader["type"].ToString();
                CreateDate = Convert.ToDateTime(MyReader["createDate"]);
                CreateIP = MyReader["createIP"].ToString();
                return true;
            }
            return false;
        }

        public DataSet Select(string ExtraSQL = "")
        {
            Command = MyCommand("select id, name,email,password,type,createDate,createIp from users " + ExtraSQL);
            if (!(Name == null || Name == ""))
            {
                Command.CommandText += " where name like @search";
                Command.Parameters.AddWithValue("@search", "%" + Name + "%");
            }
            return ExecuteDataSet(Command);
        }

        public DataSet Select()
        {
            Command = MyCommand("select id, name,email,password,type,createDate,createIp from users ");
            if (!(Name == null || Name == ""))
            {
                Command.CommandText += " where name like @search";
                Command.Parameters.AddWithValue("@search", "%" + Name + "%");
            }
            return ExecuteDataSet(Command);
        }

    }
}
