using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbnDLL.Providers
{
  public class ReaderNotesProvider : IReaderNotes
  {
    #region IReaderNotes Members

    public IEnumerable<ReaderNotes> ReaderNotesList()
    {
      throw new NotImplementedException();
    }

    public ReaderNotes ReaderNotesDetails( int readerNotesId )
    {
      throw new NotImplementedException();
    }

    public void ReaderNotesCreate( ReaderNotes newReaderNotes )
    {
      throw new NotImplementedException();
    }

    public void ReaderNotesUpdate( ReaderNotes readerNotes )
    {
      throw new NotImplementedException();
    }

    public void ReaderNotesEnable( int readerNotesId, bool enableFlag )
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
