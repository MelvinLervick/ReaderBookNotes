using System.Collections;
using System.Collections.Generic;
using rbn.Models;

namespace rbn.Providers
{
  public interface IReaderAliasProvider
  {
    List<ReaderAliasModel> GetReaderAliases();
    List<ReaderAliasModel> GetReaderAliases( int bookId );
  }
}