using System.Collections.Generic;
using rbn.Models;

namespace rbn.Views.ViewModels
{
  public class AuthorViewModel
  {
    public AuthorModel Author = new AuthorModel
    {
      AuthorId = 0,
      Enabled = true,
      FirstName = string.Empty,
      MiddleName = string.Empty,
      LastName = string.Empty,
      Rating = 0
    };
    public string Message = string.Empty;
  }
}