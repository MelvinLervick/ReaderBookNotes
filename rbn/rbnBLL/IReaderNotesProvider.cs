using System.Collections.Generic;
using rbnBLL.Models;

namespace rbnBLL
{
  public interface IReaderNotesProvider
  {
    IEnumerable<ReaderNotes> GetReaderNotesList();
    ReaderNotes GetReaderNotesDetails( int readerNotesId );
    void UpdateReaderNotesDetails( ReaderNotes readerNotes );
    void EnableReaderNotes( int readerNotesId, bool enableFlag );
  }
}