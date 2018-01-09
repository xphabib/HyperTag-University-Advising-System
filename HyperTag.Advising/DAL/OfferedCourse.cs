using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class OfferedCourse:MyBase, IDatabase
    {
        public int SemesterId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ExpireDate { get; set; }


        public bool Insert()
        {
            Command = MyCommand("insert into OfferedCourse(SemesterId,CourseId,TeacherId,Date,ExpireDate) values(@SemesterId,@CourseId,@TeacherId,@Date,@ExpireDate)");
            Command.Parameters.AddWithValue("@SemesterId", SemesterId);
            Command.Parameters.AddWithValue("@TeacherId", TeacherId);
            Command.Parameters.AddWithValue("@Date", Date);
            Command.Parameters.AddWithValue("@ExpireDate", ExpireDate);
            Command.Parameters.AddWithValue("@CourseId", CourseId);
            
            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand(@"update OfferedCourse set 
                                SemesterId = @SemesterId,
                                TeacherId = @TeacherId,
                                CourseId = @CourseId,
                                Date = @Date,
                                ExpireDate = @ExpireDate
                                where id = @id");

            Command.Parameters.AddWithValue("@SemesterId", SemesterId);
            Command.Parameters.AddWithValue("@TeacherId", TeacherId);
            Command.Parameters.AddWithValue("@Date", Date);
            Command.Parameters.AddWithValue("@ExpireDate", ExpireDate);
            Command.Parameters.AddWithValue("@CourseId", CourseId);

            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from OfferedCourse where id = @Id");
            //Command.Parameters.AddWithValue("@Id", Id);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select Id,SemesterId,CourseId,TeacherId,Date,ExpireDate from OfferedCourse where id = @Id");
            //Command.Parameters.AddWithValue("@Id", Id); 
            MyReader = ExecuteReader(Command);
            while (MyReader.Read())
            {
                SemesterId = Convert.ToInt32(MyReader["SemesterId"]);
                CourseId = Convert.ToInt32(MyReader["CourseId"]);
                TeacherId = Convert.ToInt32(MyReader["TeacherId"]);
                Date = Convert.ToDateTime(MyReader["Date"]);
                ExpireDate = Convert.ToDateTime(MyReader["ExpireDate"]);
               
                return true;
            }
            return false;
        }
        public DataSet Select(string ExtraSQL = "")
        {
            Command = MyCommand("select id, name from OfferedCourse " + ExtraSQL);
           
            return ExecuteDataSet(Command);
        }

        public DataSet Select()
        {
            Command = MyCommand("select Id,SemesterId,CourseId,TeacherId,Date,ExpireDate from OfferedCourse ");
            
            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand(@"create table OfferedCourse(
            Id int identity(1,1) primary key,
            SemesterId int,
            CourseId int,
            TeacherId int,
            Date date,
            ExpireDate date,
            foreign key(SemesterId) references semester(id),
            foreign key(CourseId) references Course(id),
            foreign key(TeacherId) references Teacher(id),
            )");
            return Execute(Command);
        }

    }
}
