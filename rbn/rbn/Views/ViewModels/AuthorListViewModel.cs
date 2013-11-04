using System.Collections.Generic;
using rbn.Models;

namespace rbn.Views.ViewModels
{
  public class AuthorListViewModel
  {
    public IList<AuthorModel> AuthorsList = new List<AuthorModel>
    {
      new AuthorModel
      {
        AuthorId = 100,
        FirstName = "John",
        MiddleName = "Q",
        LastName = "Adams",
        Rating = 1
      },
      new AuthorModel
      {
        AuthorId = 101,
        FirstName = "John",
        MiddleName = "A",
        LastName = "Adams",
        Rating = 2
      },
      new AuthorModel
      {
        AuthorId = 102,
        FirstName = "John",
        MiddleName = "Q",
        LastName = "Doe",
        Rating = 3
      }
    };
    public string Message = string.Empty;
  }
}