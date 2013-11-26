using rbn.Models;

namespace rbn.Providers
{
  public interface IReaderNotesProvider
  {
    ReaderNotesModel GetReaderNote( PageSelectorModel page );
    void SaveReaderNote( ReaderNotesModel readerNote );
  }
}