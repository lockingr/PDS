using System;
using System.Collections.Generic;
using System.Text;

namespace PDS.Domain
{
   
        public class Member
        {
            public string Member_Id { get; set; }
            public string Dods_Id { get; set; }
            public string Pims_Id { get; set; }
            public string DisplayAs { get; set; }
            public string ListAs { get; set; }
            public string FullTitle { get; set; }
            public object LayingMinisterName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public Dateofdeath DateOfDeath { get; set; }
            public string Gender { get; set; }
            public Party Party { get; set; }
            public string House { get; set; }
            public string MemberFrom { get; set; }
            public DateTime HouseStartDate { get; set; }
            public Houseenddate HouseEndDate { get; set; }
            public Currentstatus CurrentStatus { get; set; }
        }

        public class Dateofdeath
        {
            public string xsinil { get; set; }
            public string xmlnsxsi { get; set; }
        }

        public class Party
        {
            public string Id { get; set; }
            public string text { get; set; }
        }

        public class Houseenddate
        {
            public string xsinil { get; set; }
            public string xmlnsxsi { get; set; }
        }

        public class Currentstatus
        {
            public string Id { get; set; }
            public string IsActive { get; set; }
            public string Name { get; set; }
            public object Reason { get; set; }
            public DateTime StartDate { get; set; }
        }
}
