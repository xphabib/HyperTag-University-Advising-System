using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class TeacherCourse : MyBase, IDatabase
    {

        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public int DepartmentsId { get; set; }
        public string Remarks { get; set; }
        


        public bool Insert()
        {
            Command = MyCommand("insert into TeacherCourse(TeacherId,CourseId,DepartmentsId,Remarks) values(@TeacherId,@CourseId,@DepartmentsId,@Remarks)");

            Command.Parameters.AddWithValue("@TeacherId", TeacherId);
            Command.Parameters.AddWithValue("@CourseId", CourseId);
            Command.Parameters.AddWithValue("@DepartmentsId", DepartmentsId);
            Command.Parameters.AddWithValue("@Remarks", Remarks);


            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand(@"update TeacherCourse set 
                                TeacherId = @TeacherId,
                                CourseId = @CourseId,
                                DepartmentsId = @DepartmentsId,
                                Remarks = @Remarks
                                
                                where TeacherId = @TeacherId and CourseId = @CourseId");

            Command.Parameters.AddWithValue("@TeacherId", TeacherId);
            Command.Parameters.AddWithValue("@CourseId", CourseId);
            Command.Parameters.AddWithValue("@DepartmentsId", DepartmentsId);
            Command.Parameters.AddWithValue("@Remarks", Remarks);

            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from TeacherCourse where where TeacherId = @TeacherId OR CourseId = @CourseId");

            Command.Parameters.AddWithValue("@TeacherId", TeacherId);
            Command.Parameters.AddWithValue("@CourseId", CourseId);

            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select TeacherId,CourseId,DepartmentsId,Remarks from TeacherCourse where TeacherId = @TeacherId OR CourseId = @CourseId");

            Command.Parameters.AddWithValue("@TeacherId", TeacherId);
            Command.Parameters.AddWithValue("@CourseId", CourseId);

            MyReader = ExecuteReader(Command);
            while (MyReader.Read())
            {
                TeacherId = Convert.ToInt32(MyReader["TeacherId"]);
                CourseId = Convert.ToInt32(MyReader["CourseId"]);
                DepartmentsId = Convert.ToInt32(MyReader["DepartmentsId"]);
                Remarks = MyReader["Remarks"].ToString();
                

                return true;
            }
            return false;
        }
        public DataSet Select(string ExtraSQL = "")
        {
            Command = MyCommand("select id, name from TeacherCourse " + ExtraSQL);
            if (TeacherId == 0 )
            {
                Command.CommandText += " where name like @search";
                Command.Parameters.AddWithValue("@search", "%" + TeacherId + "%");
            }
            return ExecuteDataSet(Command);
        }

        public DataSet Select()
        {
            Command = MyCommand("select TeacherId,CourseId,DepartmentsId,Remarks from TeacherCourse ");
            if (TeacherId == 0)
            {
                Command.CommandText += " where name like @search";
                Command.Parameters.AddWithValue("@search", "%" + TeacherId + "%");
            }
            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand(@"create table TeacherCourse(
            TeacherId int,
            CourseId int,
            DepartmentsId int,
            Remarks varchar(500) not null,
            foreign key(CourseId) references Course(Id),
            foreign key(TeacherId) references Teacher(Id),
            foreign key(DepartmentsId) references Department(Id),
            primary key (TeacherId,CourseId)
            )");
            return Execute(Command);
        }

    }
}
