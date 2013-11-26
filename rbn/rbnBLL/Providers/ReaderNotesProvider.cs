using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbnBLL.Providers
{
  public class ReaderNotesProvider : IReaderNotesProvider
  {
    #region IReaderNotesProvider Members

    public Models.ReaderNotes GetReaderNote( Models.PageSelector page )
    {
      throw new NotImplementedException();
    }

    public void SaveReaderNotes( Models.ReaderNotes readerNotes )
    {
      throw new NotImplementedException();
    }

    public void EnableReaderNotes( int readerNotesId, bool enableFlag )
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
