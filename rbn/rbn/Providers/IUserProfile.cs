using System.Collections;
using System.Collections.Generic;
using rbn.Models;

namespace rbn.Providers
{
  public interface IReaderAliases
  {
    List<ReaderAliasModel> GetReaderAliases();
  }
}