using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class EducationBoard : MyBase, IDatabase
    {


        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CityId { get; set; }



        public bool Insert()
        {
            Command = MyCommand("insert into EducationBoard (Name,Description,CityId) values(@Name, @Description,@CityId)");

            Command.Parameters.AddWithValue("@Name", Name);
            Command.Parameters.AddWithValue("@Description", Description);
            Command.Parameters.AddWithValue("@CityId", CityId);
            

            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand(@"update EducationBoard  set Name = @Name, 
                                                               Description = @Description,
                                                               EducationBoardId=@EducationBoardId,
                                                               CityId = @CityId
                                                               where Id = @Id");
            Command.Parameters.AddWithValue("@Id", Id);
            Command.Parameters.AddWithValue("@Name", Name);
            Command.Parameters.AddWithValue("@Description", Description);
            Command.Parameters.AddWithValue("@CityId", CityId);
           
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from EducationBoard  where Id = @Id");
            Command.Parameters.AddWithValue("@Id", Id);

            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select Name,Description,CityId from EducationBoard  where Id = @Id");
            Command.Parameters.AddWithValue("@Id", Id);

            MyReader = ExecuteReader(Command);

            while (MyReader.Read())
            {
                Name = MyReader["Name"].ToString();
                Description = MyReader["Description"].ToString();
                CityId = Convert.ToInt32(MyReader["CityId"]);
                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            Command = MyCommand(@"select id, name, description, cityId  from EducationBoard where Id > 0 ");
            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand(@"create table EducationBoard (
                Id int identity(1,1) primary key,
                Name nvarchar(50),
                Description nvarchar(500),
                CityId int,
                foreign key(CityId) references city(id),
                )");
            return Execute(Command);
        }
    }
}
