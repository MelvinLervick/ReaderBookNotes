﻿using System.Collections.Generic;
using rbnBLL.Models;

namespace rbnBLL
{
  public interface IBookProvider
  {
    IEnumerable<Book> GetBookList();
    Book GetBookDetails( int bookId );
    void SaveBook( Book book );
    void EnableBook( int bookId, bool enableFlag );
  }
}