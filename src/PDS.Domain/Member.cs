using System;

namespace PDS.Domain
{
    public class Rootobject
    {
        public Members Members { get; set; }
    }

    public class Members
    {
        public Member Member { get; set; }
    }

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
      public string Gender { get; set; }
      public Party Party { get; set; }
      public string House { get; set; }
      public string MemberFrom { get; set; }
      public DateTime HouseStartDate { get; set; }
      
  }
  
  public class Party
  {
      public string Id { get; set; }
      public string text { get; set; }
  }

  

}
