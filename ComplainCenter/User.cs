//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComplainCenter
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Complains = new HashSet<Complain>();
            this.Complains1 = new HashSet<Complain>();
            this.Complains2 = new HashSet<Complain>();
            this.Complains3 = new HashSet<Complain>();
            this.Complains4 = new HashSet<Complain>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Nullable<int> UserTypeId { get; set; }
    
        public virtual ICollection<Complain> Complains { get; set; }
        public virtual ICollection<Complain> Complains1 { get; set; }
        public virtual ICollection<Complain> Complains2 { get; set; }
        public virtual ICollection<Complain> Complains3 { get; set; }
        public virtual ICollection<Complain> Complains4 { get; set; }
        public virtual UserType UserType { get; set; }
    }
}
