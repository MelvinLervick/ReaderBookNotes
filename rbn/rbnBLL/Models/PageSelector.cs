namespace rbnBLL.Models
{
  public class PageSelector
  {
    public int BookId { get; set; }
    public int NotesTotal { get; set; }
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public bool NextPage { get; set; } // true - next page, false - previous page

    public PageSelector()
    {
      this.BookId = 0;
      this.NotesTotal = 0;
      this.Page = 0;
      this.TotalPages = 0;
      this.NextPage = true;
    }

    public PageSelector(int bookId, int notesTotal, int page, int totalPages, bool nextPage)
    {
      this.BookId = bookId;
      this.NotesTotal = notesTotal;
      this.Page = page;
      this.TotalPages = totalPages;
      this.NextPage = nextPage;
    }
  }
}