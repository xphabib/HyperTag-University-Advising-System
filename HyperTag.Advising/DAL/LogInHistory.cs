using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class LogInHistory : MyBase,IDatabase
    {
        public int UserId { get; set; }
        public DateTime Datetime { get; set; }
        public string Ip { get; set; }



        public bool Insert()
        {
            Command = MyCommand("Insert into LoginHistry (UserId, Ip) values (@UserId,@Datetime,@Ip)");
            Command.Parameters.AddWithValue("@UserId", UserId);
            Command.Parameters.AddWithValue("@Ip", Ip);
            return Execute(Command);
        }


        public bool Update()
        {
            Command = MyCommand("Update LoginHistry set Datetime=@Datetime,Ip=@Ip WHERE UserId = @UserId");
            Command.Parameters.AddWithValue("@UserId", UserId);
            Command.Parameters.AddWithValue("@Datetime", Datetime);
            Command.Parameters.AddWithValue("@Ip", Ip);
            return Execute(Command);
        }



        public bool Delete()
        {
            Command = MyCommand("Delete from LoginHistry WHERE UserId = @UserId");
            Command.Parameters.AddWithValue("@UserId", UserId);
            return Execute(Command);
        }


        public bool SelectById()
        {
            Command = MyCommand("Select UserId,Datetime,Ip from country WHERE UserId = @UserId");
            Command.Parameters.AddWithValue("@UserId", UserId);

            MyReader = ExecuteReader(Command);

            while (MyReader.Read())
            {
                Datetime = Convert.ToDateTime(MyReader["Datetime"]);
                Ip = MyReader["Ip"].ToString();
                return true;
            }
            MyReader.Close();
            return false;
        }

        public DataSet Select()
        {
            Command = MyCommand(@"Select u.email as email,u.Type as type,lh.Datetime,lh.Ip
                                from LoginHistry as lh
                                Inner Join Users as u 
                                on lh.UserId = u.Id
                                Where lh.Ip is null or lh.Ip like @search");


            Command.Parameters.AddWithValue("@search", "%" + Ip + "%");

            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand(@"create table LoginHistry(
                                UserId int not null,
                                [DateTime] datetime not null default getdate(),
                                IP varchar(50) not null,
                                foreign key(UserId) references Users(Id)
                                )");
            return Execute(Command);
        }
    }
}
