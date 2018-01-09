using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class StudentEducation : MyBase, IDatabase
    {


        public int StudentId { get; set; }
        public int EducationId  { get; set; }
        public int EducationBoardId { get; set; }

        public int Year { get; set; }
        public string Result { get; set; }
        public string Roll { get; set; }
        public string Registration { get; set; }
        public string Remarks { get; set; }
        public string DocumentType { get; set; }
        public byte[] Document { get; set; }
        public string fileName { get; set; }


        public bool Insert()
        {
            Command = MyCommand("insert into StudentEducation (StudentId, EducationId,EducationBoardId,Year,Result,Roll,Registration,Remarks,DocumentType,Document, fileName) values(@StudentId, @EducationId,@EducationBoardId,@Year,@Result,@Roll,@Registration,@Remarks,@DocumentType,@Document, @fileName)");
            Command.Parameters.AddWithValue("@StudentId", StudentId);
            Command.Parameters.AddWithValue("@EducationId", EducationId);
            Command.Parameters.AddWithValue("@EducationBoardId", EducationBoardId);
            Command.Parameters.AddWithValue("@Registration", Registration);
            Command.Parameters.AddWithValue("@Year", Year);
            Command.Parameters.AddWithValue("@Result", Result);
            Command.Parameters.AddWithValue("@Roll", Roll);
            Command.Parameters.AddWithValue("@Remarks", Remarks);
            Command.Parameters.AddWithValue("@DocumentType", DocumentType);
            Command.Parameters.AddWithValue("@Document", Document);
            Command.Parameters.AddWithValue("@fileName", fileName);

            return Execute(Command);
        }

        public bool Update()
        {
            Command = MyCommand(@"update StudentEducation  set StudentId = @StudentId, 
                                                               EducationId = @EducationId,
                                                               EducationBoardId=@EducationBoardId,
                                                               Year = @Year,
                                                               Result = @Result,
                                                               Roll = @Roll,
                                                               Remarks = @Remarks,
                                                               DocumentType = @DocumentType,
                                                               Document = @Document
                                              where StudentId = @StudentId and EducationId = @EducationId");

            Command.Parameters.AddWithValue("@StudentId", StudentId);
            Command.Parameters.AddWithValue("@EducationId", EducationId);
            Command.Parameters.AddWithValue("@EducationBoardId", EducationBoardId);
            Command.Parameters.AddWithValue("@Year", Year);
            Command.Parameters.AddWithValue("@Result", Result);
            Command.Parameters.AddWithValue("@Roll", Roll);
            Command.Parameters.AddWithValue("@Remarks", Remarks);
            Command.Parameters.AddWithValue("@DocumentType", DocumentType);
            Command.Parameters.AddWithValue("@Document", Document);
            return Execute(Command);
        }

        public bool Delete()
        {
            Command = MyCommand("delete from StudentEducation  where StudentId = @StudentId");
            Command.Parameters.AddWithValue("@StudentId", StudentId);
            return Execute(Command);
        }

        public bool SelectById()
        {
            Command = MyCommand("select StudentId, EducationId, EducationBoardId, Year, Result, Roll, Remarks, DocumentType, Document, fileName from StudentEducation  where StudentId = @StudentId and EducationId = @EducationId");
            Command.Parameters.AddWithValue("@StudentId", StudentId);
            Command.Parameters.AddWithValue("@EducationId", EducationId);
            MyReader = ExecuteReader(Command);
           
            while(MyReader.Read())
            {
                EducationBoardId = Convert.ToInt32(MyReader["EducationBoardId"]);
                Year = Convert.ToInt32(MyReader["Year"]);
                Result = MyReader["Result"].ToString();
                Roll = MyReader["Roll"].ToString();
                Remarks = MyReader["Remarks"].ToString();
                DocumentType = MyReader["DocumentType"].ToString();
                Document = (byte[])MyReader["Document"];
                fileName = MyReader["fileName"].ToString();

                return true;
            }
            return false;
        }

        public DataSet Select()
        {
            Command = MyCommand(@"select se.studentId, se.educationId, s.name as student, e.name as education, eb.name as educationBoard, se.year, se.result, se.roll, se.remarks, se.documentType, se.fileName 
                                    from StudentEducation se 
                                    left join student s on se.studentId = s.id
                                    left join education as e on se.educationId = e.id
                                    left join educationBoard as eb on se.educationBoardId = eb.id
                                    where se.StudentId > 0 ");
            if(Search != null && Search != "")
            {
                Command.CommandText += " and (se.result like @search or se.remarks like @search or se.documentType like @search) ";
                Command.Parameters.AddWithValue("@search", "%" + Search + "%");
            }

            if ( StudentId > 0)
            {
                Command.CommandText += " and se.studentId = @sid ";
                Command.Parameters.AddWithValue("@sid", StudentId);
            }
            if (EducationId > 0)
            {
                Command.CommandText += " and se.educationId = @eid ";
                Command.Parameters.AddWithValue("@eid", EducationId);
            }

            if (EducationBoardId > 0)
            {
                Command.CommandText += " and se.educationBoardId = @ebid ";
                Command.Parameters.AddWithValue("@ebid", EducationBoardId);
            }


            return ExecuteDataSet(Command);
        }

        public bool Table()
        {
            Command = MyCommand(@"create table StudentEducation (
            StudentId int,
            EducationId int,
            EducationBoardId int,
            Year int,
            Result nvarchar(5),
            Roll nvarchar(50),
            Registration nvarchar(10),
            Remarks nvarchar(500),
            DocumentType nvarchar(50),
            Document image,
            foreign key(EducationBoardId) references educationboard(id),
            foreign key(StudentId) references student(id),
            foreign key(EducationId) references education(id),
            primary key(StudentId,EducationId,EducationBoardId),
)");
            return Execute(Command);
        }
    }
}
