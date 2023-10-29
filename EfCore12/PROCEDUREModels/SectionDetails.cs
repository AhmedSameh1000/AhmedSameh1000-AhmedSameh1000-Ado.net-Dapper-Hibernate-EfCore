using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore12.PROCEDUREModels
{


    [NotMapped]
    [Keyless]
    public class SectionDetails
    {
        public int Id {  get; set; }
        public string CourseName { get; set; }
        public int TotalHours { get; set; }
        public string SectionName { get; set; }
        public string Instructor { get; set; }
        public string Period { get; set; }
        public string Timeslot { get; set; }
        public bool SUN { get; set; }
        public bool MON { get; set; }
        public bool Tue { get; set; }
        public bool WED { get; set; }
        public bool THU { get; set; }
        public bool FRI { get; set; }
        public bool SAT { get; set; }

        public override string ToString()
        {
            return $"{Id}  {CourseName}  {Instructor}  {Timeslot}  " +
                $"{string.Join("|",GetDays())} {TotalHours} hrs/week";
        }

        private  List<string> GetDays()
        {
            var Days=new List<string>();

            if(SUN)
                Days.Add(nameof(SUN));
            if (MON)
                Days.Add(nameof(MON));
            if (Tue)
                Days.Add(nameof(Tue));
            if (WED)
                Days.Add(nameof(WED));

            if (THU)
                Days.Add(nameof(THU));
            if (FRI)
                Days.Add(nameof(FRI));

            if (SAT)
                Days.Add(nameof(SAT));


            return Days;
        }
    }





    [NotMapped]
    [Keyless]
    //View
    public class AllSections
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int TotalHours { get; set; }
        public string SectionName { get; set; }
        public string Instructor { get; set; }
        public string Period { get; set; }
        public string Timeslot { get; set; }
        public bool SUN { get; set; }
        public bool MON { get; set; }
        public bool Tue { get; set; }
        public bool WED { get; set; }
        public bool THU { get; set; }
        public bool FRI { get; set; }
        public bool SAT { get; set; }

        public override string ToString()
        {
            return $"{Id}  {CourseName}  {Instructor}  {Timeslot}  " +
                $"{string.Join("|", GetDays())} {TotalHours} hrs/week";
        }

        private List<string> GetDays()
        {
            var Days = new List<string>();

            if (SUN)
                Days.Add(nameof(SUN));
            if (MON)
                Days.Add(nameof(MON));
            if (Tue)
                Days.Add(nameof(Tue));
            if (WED)
                Days.Add(nameof(WED));

            if (THU)
                Days.Add(nameof(THU));
            if (FRI)
                Days.Add(nameof(FRI));

            if (SAT)
                Days.Add(nameof(SAT));


            return Days;
        }
    }
}