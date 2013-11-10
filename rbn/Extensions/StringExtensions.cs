using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Security.Cryptography;
using System.Net;
using System.Threading;

namespace Extensions
{
  public static class StringExtensions
  {
    public static bool IsSimilarTo(this string string1, string string2)
    {
      return (string1.GetSimilarity(string2) > 0.75F);
    }

    public static float GetSimilarity( this string string1, string string2 )
    {
      float retval = 0.0F;

      if (string1.Equals(string2))
      {
        retval = 1.0F;
      }
      else
      {
        var maxLen = string1.Length;

        if (maxLen < string2.Length)
        {
          maxLen = string2.Length;
        }

        if (maxLen == 0)
        {
          retval = 1.0F;
        }
        else
        {
          float dis = ComputeDistance( string1, string2 );
          retval = 1.0F - dis / maxLen;
        }
      }

      return retval;
    }

    private static int ComputeDistance( string s, string t )
    {
      int n = s.Length;
      int m = t.Length;
      var distance = new int[n + 1, m + 1]; // matrix
      int cost = 0;

      if (n == 0)
      {
        return m;
      }
      if (m == 0)
      {
        return n;
      }
      
      //init1
      for (var i = 0; i <= n; distance[i, 0] = i++)
      {
      }
      for (var j = 0; j <= m; distance[0, j] = j++)
      {
      }

      //find min distance
      for (var i = 1; i <= n; i++)
      {
        for (var j = 1; j <= m; j++)
        {
          cost = (t.Substring( j - 1, 1 ) == s.Substring( i - 1, 1 ) ? 0 : 1);

          distance[i, j] = Min3(distance[i - 1, j] + 1,
            distance[i, j - 1] + 1,
            distance[i - 1, j - 1] + cost);
        }
      }

      return distance[n, m];
    }

    static int Min3( int a, int b, int c )
    {
      return Math.Min( Math.Min( a, b ), c );
    }
    //private public static unsafe int StringDistance( string s1, string s2 )
    //{
    //  int liLengthS1 = s1.Length;
    //  int liLengthS2 = s2.Length;
    //  int liColWidth = liLengthS2 + 1;
    //  int[,] distance = new int[liLengthS1 + 1, liColWidth];

    //  int liCost = 0;
    //  if (liLengthS1 == 0)
    //    return liLengthS2;
    //  if (liLengthS2 == 0)
    //    return liLengthS1;

    //  fixed (char* lpchS1 = s1, lpchS2 = s2)
    //  fixed (int* lpiDistance = distance)
    //  {
    //    for (int liRow = 0; liRow <= liLengthS1; lpiDistance[liRow * liColWidth] = liRow++)
    //      ;
    //    for (int liCol = 0; liCol <= liLengthS2; lpiDistance[liCol] = liCol++)
    //      ;

    //    int* lpiRow = lpiDistance;
    //    int* lpiRowBefore = lpiDistance;

    //    for (int liRow = 1; liRow <= liLengthS1; liRow++)
    //    {
    //      lpiRow += liColWidth;

    //      for (int liCol = 1; liCol <= liLengthS2; liCol++)
    //      {
    //        liCost = (lpchS2[liCol - 1] == lpchS1[liRow - 1] ? 0 : 1);

    //        lpiRow[liCol] =
    //            Min3(
    //                lpiRowBefore[liCol] + 1,
    //                lpiRow[liCol - 1] + 1,
    //                lpiRowBefore[liCol - 1] + liCost
    //            );
    //      }

    //      lpiRowBefore += liColWidth;
    //    }
    //  }

    //  return distance[liLengthS1, liLengthS2];
    //}

    /// <summary>
    /// true, if is valid email address
    /// from http://www.davidhayden.com/blog/dave/
    /// archive/2006/11/30/ExtensionMethodsCSharp.aspx
    /// </summary>
    /// <param name="s">email address to test</param>
    /// <returns>true, if is valid email address</returns>
    public static bool IsValidEmailAddress( this string s )
    {
      return new Regex( @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,6}$" ).IsMatch( s );
    }

    /// <summary>
    /// Checks if url is valid. 
    /// from http://www.osix.net/modules/article/?id=586 and changed to match http://localhost
    /// 
    /// complete (not only http) url regex can be found 
    /// at http://internet.ls-la.net/folklore/url-regexpr.html
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    public static bool IsValidUrl( this string url )
    {
      const string STR_REGEX = "^(https?://)"
                              + "?(([0-9a-z_!~*'().&=+$%-]+: )?[0-9a-z_!~*'().&=+$%-]+@)?" //user@
                              + @"(([0-9]{1,3}\.){3}[0-9]{1,3}" // IP- 199.194.52.184
                              + "|" // allows either IP or domain
                              + @"([0-9a-z_!~*'()-]+\.)*" // tertiary domain(s)- www.
                              + @"([0-9a-z][0-9a-z-]{0,61})?[0-9a-z]" // second level domain
                              + @"(\.[a-z]{2,6})?)" // first level domain- .com or .museum is optional
                              + "(:[0-9]{1,5})?" // port number- :80
                              + "((/?)|" // a slash isn't required if there is no file name
                              + "(/[0-9a-z_!~*'().;?:@&=+$,%#-]+)+/?)$";
      return new Regex( STR_REGEX ).IsMatch( url );
    }

    /// <summary>
    /// Check if url (http) is available.
    /// </summary>
    /// <param name="httpUrl">url to check</param>
    /// <example>
    /// string url = "www.codeproject.com;
    /// if( !url.UrlAvailable())
    ///     ...codeproject is not available
    /// </example>
    /// <returns>true if available</returns>
    public static bool UrlAvailable( this string httpUrl )
    {
      if (!httpUrl.StartsWith( "http://" ) || !httpUrl.StartsWith( "https://" ))
        httpUrl = "http://" + httpUrl;
      try
      {
        var myRequest = (HttpWebRequest)WebRequest.Create( httpUrl );
        myRequest.Method = "GET";
        myRequest.ContentType = "application/x-www-form-urlencoded";

        var myHttpWebResponse = (HttpWebResponse)myRequest.GetResponse();

        return true;
      }
      catch
      {
        return false;
      }
    }

    /// <summary>
    /// Reverse the string
    /// from http://en.wikipedia.org/wiki/Extension_method
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    public static string Reverse( this string input )
    {
      var chars = input.ToCharArray();
      Array.Reverse( chars );

      return new String( chars );
    }


    /// <summary>
    /// Reduce string to shorter preview which is optionally ended by some string (...).
    /// </summary>
    /// <param name="s">string to reduce</param>
    /// <param name="count">Length of returned string including endings.</param>
    /// <param name="endings">optional edings of reduced text</param>
    /// <example>
    /// string description = "This is very long description of something";
    /// string preview = description.Reduce(20,"...");
    /// produce -> "This is very long..."
    /// </example>
    /// <returns></returns>
    public static string Reduce( this string s, int count, string endings )
    {
      if (count < endings.Length)
        throw new Exception( "Failed to reduce to less then endings length." );
      
      var sLength = s.Length;
      var len = sLength;

      if (!string.IsNullOrEmpty(endings))
      {
        len += endings.Length;
      }

      if (count > sLength)
      {
        return s; //it's too short to reduce
      }

      s = s.Substring( 0, sLength - len + count );
      
      if (!string.IsNullOrEmpty( endings ))
      {
        s += endings;
      }

      return s;
    }

    /// <summary>
    /// remove white space, not line end
    /// Useful when parsing user input such phone,
    /// price int.Parse("1 000 000".RemoveSpaces(),.....
    /// </summary>
    /// <param name="s"></param>
    /// <returns>string without spaces</returns>
    public static string RemoveSpaces( this string s )
    {
      return s.Replace( " ", "" );
    }

    /// <summary>
    /// true, if the string can be parse as Double respective Int32
    /// Spaces are not considred.
    /// </summary>
    /// <param name="s">input string</param>
    /// <param name="floatpoint">true, if Double is considered,
    /// otherwhise Int32 is considered.</param>
    /// <returns>true, if the string contains only digits or float-point</returns>
    public static bool IsNumber( this string s, bool floatpoint )
    {
      int i;
      double d;
      var withoutWhiteSpace = s.RemoveSpaces();

      if (floatpoint)
      {
        return double.TryParse(withoutWhiteSpace, NumberStyles.Any,
          Thread.CurrentThread.CurrentUICulture, out d);
      }

      return int.TryParse(withoutWhiteSpace, out i);
    }

    /// <summary>
    /// true, if the string contains only digits or float-point.
    /// Spaces are not considred.
    /// </summary>
    /// <param name="s">input string</param>
    /// <param name="floatpoint">true, if float-point is considered</param>
    /// <returns>true, if the string contains only digits or float-point</returns>
    public static bool IsNumberOnly( this string s, bool floatpoint )
    {
      s = s.Trim();
      if (s.Length == 0)
        return false;
      foreach (char c in s)
      {
        if (!char.IsDigit( c ))
        {
          if (floatpoint && (c == '.' || c == ','))
          {
            continue;
          }
          return false;
        }
      }

      return true;
    }

    /// <summary>
    /// Remove accent from strings 
    /// </summary>
    /// <example>
    ///  input:  "Příliš žluťoučký kůň úpěl ďábelské ódy."
    ///  result: "Prilis zlutoucky kun upel dabelske ody."
    /// </example>
    /// <param name="s"></param>
    /// <remarks>founded at http://stackoverflow.com/questions/249087/
    /// how-do-i-remove-diacritics-accents-from-a-string-in-net</remarks>
    /// <returns>string without accents</returns>
    public static string RemoveDiacritics( this string s )
    {
      var stFormD = s.Normalize( NormalizationForm.FormD );
      var sb = new StringBuilder();

      foreach (var t in stFormD)
      {
        var uc = CharUnicodeInfo.GetUnicodeCategory( t );
        if (uc != UnicodeCategory.NonSpacingMark)
        {
          sb.Append( t );
        }
      }

      return (sb.ToString().Normalize( NormalizationForm.FormC ));
    }

    /// <summary>
    /// Replace \r\n or \n by <br />
    /// from http://weblogs.asp.net/gunnarpeipman/archive/2007/11/18/c-extension-methods.aspx
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string ConvertNewlineToHtmlBreak( this string s )
    {
      return s.Replace( "\r\n", "<br />" ).Replace( "\n", "<br />" );
    }


    static MD5CryptoServiceProvider sMD5 = null;

    /// <summary>
    /// from http://weblogs.asp.net/gunnarpeipman/archive/2007/11/18/c-extension-methods.aspx
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static string MD5( this string s )
    {
      if (sMD5 == null) //creating only when needed
        sMD5 = new MD5CryptoServiceProvider();
      Byte[] newdata = Encoding.Default.GetBytes( s );
      Byte[] encrypted = sMD5.ComputeHash( newdata );
      return BitConverter.ToString( encrypted ).Replace( "-", "" ).ToLower();
    }
  }
}
