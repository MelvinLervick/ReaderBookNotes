using System;
using rbn.Models;

namespace rbn.Providers.RbnBLL
{
  public class ReaderNotesProvider : IReaderNotesProvider
  {
    public ReaderNotesProvider()
    {
    }
    #region IReaderNotesProvider Members

    public ReaderNotesModel GetReaderNote( PageSelectorModel page )
    {
      throw new NotImplementedException();
    }

    public void SaveReaderNote( ReaderNotesModel readerNote )
    {
      throw new NotImplementedException();
    }

    #endregion

    private rbnBLL.Providers.ReaderNotesProvider provider;
    internal rbnBLL.Providers.ReaderNotesProvider Provider
    {
      get { return provider ?? (provider = new rbnBLL.Providers.ReaderNotesProvider()); }
    }
  }
}