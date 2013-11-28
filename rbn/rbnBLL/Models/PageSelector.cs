namespace rbnBLL.Models
{
  public class PageSelector
  {
    public int BookId { get; set; }
    public int NotesThatCanBeViewed { get; set; }
    public int Page { get; set; }
    public int TotalPages { get; set; }
    public bool NextPage { get; set; } // true - next page, false - previous page

    public PageSelector()
    {
      this.BookId = 0;
      this.NotesThatCanBeViewed = 0;
      this.Page = 0;
      this.TotalPages = 0;
      this.NextPage = true;
    }

    public PageSelector(int bookId, int notesThatCanBeViewed, int page, int totalPages, bool nextPage)
    {
      this.BookId = bookId;
      this.NotesThatCanBeViewed = notesThatCanBeViewed;
      this.Page = page;
      this.TotalPages = totalPages;
      this.NextPage = nextPage;
    }
  }
}