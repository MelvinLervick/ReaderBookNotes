using System;
using rbn.Models;
using rbn.Providers.RbnBLL.Adapters;

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
      return ReaderNotesAdapter.TransformToUiModel( Provider.GetReaderNote( ReaderNotesAdapter.TransformToBLLModel(page) ) );
    }

    public void SaveReaderNote( ReaderNotesModel readerNote )
    {
      Provider.SaveReaderNotes( ReaderNotesAdapter.TransformToBLLModel( readerNote ) );
    }

    #endregion

    private rbnBLL.Providers.ReaderNotesProvider provider;
    internal rbnBLL.Providers.ReaderNotesProvider Provider
    {
      get { return provider ?? (provider = new rbnBLL.Providers.ReaderNotesProvider()); }
    }
  }
}