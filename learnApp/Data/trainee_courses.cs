//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace learnApp.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class trainee_courses
    {
        public int trainee_id { get; set; }
        public int course_id { get; set; }
        public System.DateTime registration_date { get; set; }
    
        public virtual course_t course_t { get; set; }
        public virtual trainee trainee { get; set; }
    }
}
