using EfCore8.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore9
{
    public class SeedingData
    {
        public static List<Office> LoadOffices() => new List<Office>()
        {
            new Office{Id=1,OfficeName="Off_01",OfficeLocation="Building A"},
            new Office{Id=2,OfficeName="Off_02",OfficeLocation="Building B"},
            new Office{Id=3,OfficeName="Off_03",OfficeLocation="Building C"},
            new Office{Id=4,OfficeName="Off_04",OfficeLocation="Building D"},

        };
        public static List<Section> LoadSection() => new List<Section>()
        {
            new Section {Id=1,CourseId=1,InstructorId=1,SectionName="Searching"},
            new Section {Id=2,CourseId=2,InstructorId=2,SectionName="programing"},
            new Section {Id=3,CourseId=3,InstructorId=3,SectionName="OOP"},
            new Section {Id=4,CourseId=4,InstructorId=4,SectionName="Algorithm"},
        };

        public static List<Course> LoadCourses() => new List<Course>()
        {
            new Course {Id=1,CourseName="math",Price=1000},
            new Course {Id=2,CourseName="C#",Price=2000},
            new Course {Id=3,CourseName="OOP",Price=3000},
            new Course {Id=4,CourseName="Data Structure",Price=4000},
        };
        public static List<Schedule> LoadSchaduels() => new List<Schedule>()
        {
            new Schedule {Id=1,Title="Weekend",FRI=true,MON=true,SAT=true,SUN=false,THU=false,TUE=false,WED=true},
            new Schedule {Id=2,Title="Se",FRI=true,MON=true,SAT=true,SUN=false,THU=false,TUE=false,WED=true},
            new Schedule {Id=3,Title="data",FRI=true,MON=true,SAT=true,SUN=false,THU=false,TUE=false,WED=true},
            new Schedule {Id=4,Title="ahmed",FRI=true,MON=true,SAT=true,SUN=false,THU=false,TUE=false,WED=true},
        };
        public static List<Instructor> LoadInstractor() => new List<Instructor>()
        {
            new Instructor {Id=1,Name="ahmed",OfficeId=1},
            new Instructor {Id=2,Name="ahmed",OfficeId=2},
            new Instructor {Id=3,Name="ahmed",OfficeId=3},
            new Instructor {Id=4,Name="ahmed",OfficeId=4},
        };
  
        public static List<Student> LoadStudent() => new List<Student>()
        {
            new Student {Id=1,Name="Ahmed"},
            new Student {Id=2,Name="Ali"},
            new Student {Id=3,Name="Sameh"},
            new Student {Id=4,Name="Sara"},
        };

    }
}
