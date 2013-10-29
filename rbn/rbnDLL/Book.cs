//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace rbnDLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public Book()
        {
            this.ReaderNotes = new HashSet<ReaderNotes>();
        }
    
        public int BookId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public Nullable<int> AuthorId { get; set; }
        public Nullable<int> AudienceId { get; set; }
        public int Rating { get; set; }
        public System.DateTime LastModifiedDate { get; set; }
        public bool Enabled { get; set; }
    
        public virtual Audience Audience { get; set; }
        public virtual Author Author { get; set; }
        public virtual ICollection<ReaderNotes> ReaderNotes { get; set; }
    }
}
