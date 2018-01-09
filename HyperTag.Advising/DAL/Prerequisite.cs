using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class Prerequisite : MyBase, IDatabase
    {

        public int CourseId { get; set; }

        public int RequiredCourseId { get; set; }

        public string Result { get; set; }
        public string Remarks { get; set; }

        public bool Insert()
        {
            Command = MyCommand("insert into Prerequisite(CourseId, RequiredCourseId, Result, Remarks ) values(@CourseId, @RequiredCourseId, @Result, @Remarks,)");
            Command.Parameters.AddWithValue("@CourseId", CourseId);
            Command.Parameters.AddWithValue("@RequiredCourseId", RequiredCourseId);
            Command.Parameters.AddWithValue("@Result", Result);
            Command.Parameters.AddWithValue("@Remarks", Remarks);
            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand("update Prerequisite set Result = @Result, Result = @Result where CourseId = @CourseId and RequiredCourseId = @RequiredCourseId");
            Command.Parameters.AddWithValue("@CourseId", CourseId);
            Command.Parameters.AddWithValue("@RequiredCourseId", RequiredCourseId);
            Command.Parameters.AddWithValue("@Result", Result);
            Command.Parameters.AddWithValue("@Remarks", Remarks);
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from Prerequisite where CourseId = @CourseId and RequiredCourseId = @RequiredCourseId");
            Command.Parameters.AddWithValue("@CourseId", CourseId);
            Command.Parameters.AddWithValue("@RequiredCourseId", RequiredCourseId);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select CourseId, RequiredCourseId, Result, Remarks from Prerequisite where CourseId = @CourseId and RequiredCourseId = @RequiredCourseId");
            Command.Parameters.AddWithValue("@CourseId", CourseId);
            Command.Parameters.AddWithValue("@RequiredCourseId", RequiredCourseId);
            MyReader = ExecuteReader(Command);
            while (MyReader.Read())
            {
                Result = MyReader["Result"].ToString();
                Remarks = MyReader["Remarks"].ToString();
                return true;
            }
            return false;
        }
        public DataSet Select(string ExtraSQL = "")
        {
            Command = MyCommand("select CourseId, RequiredCourseId, Result from Prerequisite " + ExtraSQL);

            if (!(Result == null || Result.ToString() == ""))
            {
                Command.CommandText += " where Result like @search";
                Command.Parameters.AddWithValue("@search", "%" + Result + "%");
            }
            return ExecuteDataSet(Command);
        }

        public DataSet Select()
        {
            Command = MyCommand("select CourseId, RequiredCourseId, Result from Prerequisite ");

            if (!(Result == null || Result.ToString() == ""))
            {
                Command.CommandText += " where Result like @search";
                Command.Parameters.AddWithValue("@search", "%" + Result + "%");
            }
            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand("create table Prerequisite(CourseId int identity primary key, RequiredCourseId int identity primary key, Result varchar(100) not null, Remarks varchar(200) not null unique,foreign key (courseid) references course(id),foreign key(RequiredCourseId) references course(id))");
            return Execute(Command);
        }

    }
}
