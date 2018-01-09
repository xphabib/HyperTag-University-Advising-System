using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class StudentCourses : MyBase, IDatabase
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int SemesterId { get; set; }
        public DateTime Date { get; set; }
        public String Remarks { get; set; }

        public bool Insert()
        {
            Command = MyCommand("insert into StudentCourses(StudentId,CourseId,SemesterId,Date,Remarks) values(@StudentId,@CourseId,@SemesterId,@Date,@Remarks)");
            Command.Parameters.AddWithValue("@StudentId", StudentId);
            Command.Parameters.AddWithValue("@CourseId", CourseId);
            Command.Parameters.AddWithValue("@SemesterId", SemesterId);
            Command.Parameters.AddWithValue("@Date", Date);
            Command.Parameters.AddWithValue("@Remarks", Remarks);
            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand("update StudentCourses set StudentId = @StudentId,CourseId=@CourseId,SemesterId=@SemesterId,Date=@date,Remarks=@Remarks where StudentId = @StudentId");
            Command.Parameters.AddWithValue("@StudentId", StudentId);
            Command.Parameters.AddWithValue("@CourseId", CourseId);
            Command.Parameters.AddWithValue("@SemesterId", SemesterId);
            Command.Parameters.AddWithValue("@Date", Date);
            Command.Parameters.AddWithValue("@Remarks", Remarks);
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from StudentCourses where StudentId = @StudentId");
            Command.Parameters.AddWithValue("@StudentId", StudentId);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select StudentId,CourseId,SemesterId,Date,Remarks from StudentCourses where StudentId = @StudentId");
            Command.Parameters.AddWithValue("@StudentId", StudentId);
            MyReader = ExecuteReader(Command);
            while (MyReader.Read())
            {
                StudentId = Convert.ToInt32(MyReader["StudentId"]);
                CourseId = Convert.ToInt32(MyReader["CourseId"]);
                SemesterId = Convert.ToInt32(MyReader["SemesterId"]);
                Date = Convert.ToDateTime(MyReader["Date"]);
                Remarks = MyReader["Remarks"].ToString();

                return true;
            }
            return false;
        }
        public DataSet Select()
        {
            Command = MyCommand(@"select Student.Name as Student, Course.Name as Course, Semester.Name as Semester, Date,Remarks 
                                    from StudentCourses stCourse
                                    JOIN Student on stCourse.StudentId = Student.Id
                                    JOIN Course on stCourse.CourseId = Course.Id
                                    JOIN Semester on stCourse.SemesterId = Semester.Id
                                     where StudentId > 0 
                                ");
            //if (StudentId == 0)
            //{
            //    Command.CommandText += " and StudentId like @search ";
            //    Command.Parameters.AddWithValue("@search", "%" + StudentId + "%");
            //}

            //if (StudentId > 0)
            //{
            //    Command.CommandText += " and StudentId = @StudentId";

            //}
            return ExecuteDataSet(Command);
        }


        public bool Table()
        {
            Command = MyCommand("create table StudentCourses(StudentId int,CourseId int,SemesterId int,Date datetime,Remarks varchar(200),foreign key(StudentId) references student(id),foreign key(CourseId) references course(id),foreign key(SemesterId) references semester(id),primary key(StudentId, CourseId, SemesterId)");
            return Execute(Command);
        }
    }
}
