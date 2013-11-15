using System.Collections;
using System.Collections.Generic;
using rbnBLL.Models;

namespace rbnBLL
{
  public interface IUserProfile
  {
    IEnumerable<UserProfile> GetReaderAliases();
  }
}