//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class EFCourse
    {
        public EFCourse()
        {
            this.Classes = new HashSet<EFClasses>();
        }
    
        public int CourseID { get; set; }
        public int ClassID { get; set; }
        public string Description { get; set; }
        public Nullable<double> AwardedCredit { get; set; }
        public Nullable<int> BuildingNumber { get; set; }
        public int RoomNumber { get; set; }
    
        public virtual ICollection<EFClasses> Classes { get; set; }
    }
}
