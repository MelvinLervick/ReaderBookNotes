using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbnDLL.Models
{
  public class UserAccountUserFields
  {
    public int UserId
    {
      get;
      set;
    }
    public int AccountUserId
    {
      get;
      set;
    }
    public string FirstName
    {
      get;
      set;
    }
    public string LastName
    {
      get;
      set;
    }
    public string EmailAddress
    {
      get;
      set;
    }
    public string Country
    {
      get;
      set;
    }
    public string Question1
    {
      get;
      set;
    }
    public string Answer1
    {
      get;
      set;
    }
    public string Question2
    {
      get;
      set;
    }
    public string Answer2
    {
      get;
      set;
    }

    public bool AccountLocked
    {
      get;
      set;
    }

    public DateTime LastModifiedDate
    {
      get;
      set;
    }
  }
}
