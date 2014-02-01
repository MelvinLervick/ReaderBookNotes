using System.Collections.Generic;
using rbnBLL.Models;

namespace rbnBLL
{
  public interface IUserRoles
  {
      IEnumerable<UserRoles> GetRoles();
  }
}