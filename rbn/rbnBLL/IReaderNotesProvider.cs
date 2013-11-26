using System.Collections.Generic;
using rbnBLL.Models;

namespace rbnBLL
{
  public interface IReaderNotesProvider
  {
    ReaderNotes GetReaderNote( PageSelector page );
    void SaveReaderNotes( ReaderNotes readerNotes );
    void EnableReaderNotes( int readerNotesId, bool enableFlag );
  }
}