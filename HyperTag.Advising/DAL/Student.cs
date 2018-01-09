using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hypertag.Advising.DAL
{
    class Student : MyBase,IDatabase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string LocalGuardian { get; set; }
        public string IdNumber { get; set; }
        public string BloodGroup { get; set; }
        public  string AddressPresent { get; set; }
        public string AddressPermanent { get; set; }
        public byte[] Image { get; set; }
        public int CityId { get; set; }
        public int ProgramId { get; set; }


        public bool Insert()
        {
            Command = MyCommand(@"Insert into Student (Name, Email, FatherName,
                                  MotherName,LocalGuardian,IdNumber,BloodGroup,
                            AddressPresent,AddressPermanent,Image,cityId,ProgramId) 
                            values (@Name,@Email,@FatherName,
                            @MotherName,@LocalGuardian,@IdNumber,@BloodGroup,
                            @AddressPresent,@AddressPermanent,@Image, 
                            @cityId,@ProgramId)");

            Command.Parameters.AddWithValue("@Name", Name);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@FatherName", FatherName);
            Command.Parameters.AddWithValue("@MotherName", MotherName);
            Command.Parameters.AddWithValue("@LocalGuardian", LocalGuardian);
            Command.Parameters.AddWithValue("@IdNumber", IdNumber);
            Command.Parameters.AddWithValue("@BloodGroup", BloodGroup);
            Command.Parameters.AddWithValue("@AddressPresent", AddressPresent);
            Command.Parameters.AddWithValue("@AddressPermanent", AddressPermanent);
            Command.Parameters.AddWithValue("@Image", Image);
            Command.Parameters.AddWithValue("@ProgramId", ProgramId);
            Command.Parameters.AddWithValue("@cityId", CityId);
            return Execute(Command);
        }


        public bool Update()
        {
            Command = MyCommand(@"Update Student set
                                Name = @Name,
                                Email =@Email,
                                FatherName=@FatherName,
                                MotherName = @MotherName,
                                LocalGuardian=@LocalGuardian,
                                IdNumber=@IdNumber,
                                BloodGroup=@BloodGroup,
                                AddressPresent=@BloodGroup,
                                AddressPermanent=@AddressPermanent,
                                CityId=@CityId,
                                ProgramId=@ProgramId
                        WHERE Id = @Id");

            Command.Parameters.AddWithValue("@Name", Name);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@FatherName", FatherName);
            Command.Parameters.AddWithValue("@MotherName", MotherName);
            Command.Parameters.AddWithValue("@LocalGuardian", LocalGuardian);
            Command.Parameters.AddWithValue("@IdNumber", IdNumber);
            Command.Parameters.AddWithValue("@BloodGroup", BloodGroup);
            Command.Parameters.AddWithValue("@AddressPresent", AddressPresent);
            Command.Parameters.AddWithValue("@AddressPermanent", AddressPermanent);
            Command.Parameters.AddWithValue("@Image", Image);
            Command.Parameters.AddWithValue("@ProgramId", ProgramId);
            Command.Parameters.AddWithValue("@cityId", CityId);
            return Execute(Command);
        }



        public bool Delete()
        {
            Command = MyCommand("Delete from Student WHERE Id = @Id");
            Command.Parameters.AddWithValue("@Id", Id);
            return Execute(Command);
        }


        public bool SelectById()
        {
            Command = MyCommand(@"Select Id,Name,Email,FatherName,MotherName,
                                    LocalGuardian,IdNumber,BloodGroup,AddressPresent,
                                    AddressPermanent,CityId,ProgramId 
                                    from Student WHERE Id = @Id");

            Command.Parameters.AddWithValue("@Id", Id);

            MyReader = ExecuteReader(Command);

            while (MyReader.Read())
            {
                Name = MyReader["name"].ToString();
                Email = MyReader["email"].ToString();
                FatherName = MyReader["FatherName"].ToString();
                MotherName = MyReader["MotherName"].ToString();
                LocalGuardian = MyReader["dateOfBirth"].ToString();
                IdNumber = MyReader["IdNumber"].ToString();
                BloodGroup = MyReader["BloodGroup"].ToString();
                AddressPresent = MyReader["AddressPresent"].ToString();
                AddressPermanent = MyReader["AddressPermanent"].ToString();
                Image = (byte[])MyReader["Image"];
                CityId = Convert.ToInt32(MyReader["cityId"]);
                ProgramId = Convert.ToInt32(MyReader["ProgramId"]);

                return true;
            }
            MyReader.Close();
            return false;
        }

        public DataSet Select(int countryId = 0,int departmentId = 0)
        {
            Command = MyCommand(@"Select s.Id,s.Name,s.email,
                                    s.FatherName, s.MotherName,
                                    s.LocalGuardian, s.IdNumber,
                                    s.BloodGroup, s.AddressPresent,
                                    s.AddressPermanent, s.image, ct.name as city,
                                    cn.name as country, p.Name as program,
                                    d.Name as department
                                    from Student as s
                                    inner join city as ct on s.cityId = ct.Id
                                    inner join country as cn on ct.countryId = cn.Id
                                    inner join program as p on s.programId = p.Id
                                    inner join department as d on p.departmentId = d.Id
                                    Where s.Id > 0   ");

            if (Name != null && Name != "")
            {
                Command.CommandText += @" and (s.name like @Search or s.email like @Search or
                                    s.FatherName like @Search,s.MotherName like @Search or
                                    s.LocalGuardian like @Search,s.BloodGroup like @Search,
                                    s.AddressPresent like @Search or
                                    s.AddressPermanent like @Search or
                                    s.IdNumber like @Search) ";
                Command.Parameters.AddWithValue("@search", "%" + Name + "%");
            }

            if (CityId > 0)
            {
                Command.CommandText += " and ct.Id = @programId";
                Command.Parameters.AddWithValue("@programId", ProgramId);
            }
            else if (countryId > 0)
            {
                Command.CommandText += " and cn.Id = @countryId";
                Command.Parameters.AddWithValue("@countryId", countryId);
            }

            if (ProgramId > 0)
            {
                Command.CommandText += " and p.Id = @cityId";
                Command.Parameters.AddWithValue("@cityId", CityId);
            }
            else if (departmentId > 0)
            {
                Command.CommandText += " and d.Id = @departmentId";
                Command.Parameters.AddWithValue("@departmentId", departmentId);
            }

            return ExecuteDataSet(Command);
        }
        public bool Table()
        {
            Command = MyCommand(@"create table Student
                                    (
                                    Id int identity(1, 1) primary key,
                                    Name varchar(200) not null,
                                    Email varchar(50) unique not null,
                                    FatherName varchar(200),
                                    MotherName varchar(200),
                                    LocalGuardian varchar(200),
                                    IdNumber varchar(16) unique not null,
                                    BloodGroup varchar(20),
                                    AddressPresent varchar(500) not null,
                                    AddressPermanent varchar(500) not null,
                                    CityId int not null,
                                    Image image not null,
                                    ProgramId int not null, 
                                    foreign key(cityId) references city(id), 
                                    foreign key(programId) references program(id)
                                    )");
            return Execute(Command);
        }

        
    }
}
