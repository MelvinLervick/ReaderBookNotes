﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using rbn.Models;
using rbnDLL.Models;

namespace rbn.Providers.RbnDll.Adapters
{
  public class UserAccountAdapter
  {
    internal static UserAccount TransformToUiModel( UserAccountUserFields userFields )
    {
      return new UserAccount
      {
        UserId = userFields.UserId,
        FirstName = userFields.FirstName,
        LastName = userFields.LastName,
        EmailAddress = userFields.EmailAddress,
        Country = userFields.Country,
        Question1 = userFields.Question1,
        Answer1 = userFields.Answer1,
        Question2 = userFields.Question2,
        Answer2 = userFields.Answer2,
        AccountUserId = userFields.AccountUserId,
        AccountLocked = userFields.AccountLocked
      };
    }
  }
}