using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rbnDLL.Providers
{
  public class AuthorProvider : IAuthor
  {
    #region IAuthor Members

    public IEnumerable<Author> AuthorList()
    {
      throw new NotImplementedException();
    }

    public Author AuthorDetails( int authorId )
    {
      throw new NotImplementedException();
    }

    public void AuthorCreate( Author newAuthor )
    {
      throw new NotImplementedException();
    }

    public void AuthorUpdate( Author author )
    {
      throw new NotImplementedException();
    }

    public void AuthorEnable( int authorId, bool enableFlag )
    {
      throw new NotImplementedException();
    }

    #endregion
  }
}
