namespace LibraryDAO.Api
{
  public interface IWebRequestApiProvider
  {
    string Status { get; set; }
    string GetResponse();
  }
}