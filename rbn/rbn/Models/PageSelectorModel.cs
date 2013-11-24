using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rbn.Models
{
  public class PageSelectorModel
  {
    public int BookId { get; set; }
    public int NotesTotal { get; set; }
    public int Page { get; set; }
    public int TotalPages { get; set; }

    public PageSelectorModel()
    {
      this.BookId = 0;
      this.NotesTotal = 0;
      this.Page = 0;
      this.TotalPages = 0;
    }

    public PageSelectorModel(int bookId, int notesTotal, int page, int totalPages)
    {
      this.BookId = bookId;
      this.NotesTotal = notesTotal;
      this.Page = page;
      this.TotalPages = totalPages;
    }
  }
}