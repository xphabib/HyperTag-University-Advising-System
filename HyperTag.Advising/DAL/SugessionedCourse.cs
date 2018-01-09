using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class SugessionedCourse : MyBase, IDatabase
    {

        public int SemesterId { get; set; }
        public int CourseId { get; set; }
        public string Remarks { get; set; }
        



        public bool Insert()
        {
            Command = MyCommand("insert into SugessionedCourse(SemesterId,CourseId,Remarks) values(@SemesterId,@CourseId,@Remarks)");

            Command.Parameters.AddWithValue("@SemesterId", SemesterId);
            Command.Parameters.AddWithValue("@CourseId", CourseId);
            Command.Parameters.AddWithValue("@Remarks", Remarks);
            


            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand(@"update SugessionedCourse set 
                                SemesterId = @SemesterId,
                                CourseId = @CourseId,
                                Remarks = @Remarks
                                
                                where CourseId = @CourseId and CourseId = @CourseId");

            Command.Parameters.AddWithValue("@SemesterId", SemesterId);
            Command.Parameters.AddWithValue("@CourseId", CourseId);

            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from SugessionedCourse where SemesterId = @SemesterId OR CourseId = @CourseId");

            Command.Parameters.AddWithValue("@SemesterId", SemesterId);
            Command.Parameters.AddWithValue("@CourseId", CourseId);

            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select SemesterId,CourseId,Remarks from SugessionedCourse where SemesterId = @SemesterId OR CourseId = @CourseId");

            Command.Parameters.AddWithValue("@SemesterId", SemesterId);
            Command.Parameters.AddWithValue("@CourseId", CourseId);

            MyReader = ExecuteReader(Command);
            while (MyReader.Read())
            {
                SemesterId = Convert.ToInt32(MyReader["SemesterId"]);
                CourseId = Convert.ToInt32(MyReader["CourseId"]);
                Remarks = MyReader["Remarks"].ToString();


                return true;
            }
            return false;
        }
        public DataSet Select(string ExtraSQL = "")
        {
            Command = MyCommand("select id, name from SugessionedCourse " + ExtraSQL);
            if (CourseId == 0)
            {
                Command.CommandText += " where name like @search";
                Command.Parameters.AddWithValue("@search", "%" + CourseId + CourseId + "%");
            }
            return ExecuteDataSet(Command);
        }

        public DataSet Select()
        {
            Command = MyCommand("select SemesterId,CourseId,Remarks from SugessionedCourse ");
            if (SemesterId == 0 )
            {
                Command.CommandText += " where name like @search";
                Command.Parameters.AddWithValue("@search", "%" + SemesterId + CourseId + "%");
            }
            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand(@"create table SugessionedCourse(
            SemesterId int,
            CourseId int,
            Remarks varchar(500) not null,
            primary key(SemesterId,CourseId),
            foreign key(SemesterId) references Semester(Id),
            foreign key(CourseId) references Course(Id),
            )");
            return Execute(Command);
        }

    }
}
