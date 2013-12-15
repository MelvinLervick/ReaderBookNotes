namespace rbn.Providers
{
  public interface IWebRequestApiProvider
  {
    string Status { get; set; }
    string GetResponse();
  }
}