using System.Collections.Generic;
using rbnBLL.Models;

namespace rbnBLL
{
  public interface IReaderNotes
  {
    IEnumerable<ReaderNotes> ReaderNotesList();
    ReaderNotes ReaderNotesDetails( int readerNotesId );
    void ReaderNotesCreate( ReaderNotes newReaderNotes );
    void ReaderNotesUpdate( ReaderNotes readerNotes );
    void ReaderNotesEnable( int readerNotesId, bool enableFlag );
  }
}