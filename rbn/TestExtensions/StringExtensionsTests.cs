using System;
using System.Globalization;
using System.Threading;
using Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestExtensions
{
  [TestClass]
  public class StringExtensionsTests
  {
    private const double THRESHHOLD99 = 0.99;
    private const double THRESHHOLD = 0.8;
    StopWatch Watch = new StopWatch();

    [TestMethod()]
    public void IsSimilarToTestThatShouldMatch()
    {
      var s1 = "Clemens, Samul";
      var s2 = "Clemmons, Samuel";

      var test1 = s1.GetSimilarity( s2 );
      var test2 = s2.GetSimilarity( s1 );

      Assert.AreEqual( test1, test2, string.Format( "Strings are just reversed, so should be the same." ) );
    }

    /// <summary>
    ///A test for String Similarity
    ///</summary>
    [TestMethod()]
    public void StringSimilarityTest()
    {
      var test1 = ("Clemmons, Samuel").GetSimilarity( "Clemmons, Samuel" );
      var test2 = ("Clemons, Samuel").GetSimilarity( "Clemmons, Samuel" );
      var test3 = ("Clemmens, Samuel").GetSimilarity( "Clemmons, Samuel" );
      var test4 = ("Clemens, Samual").GetSimilarity( "Clemmons, Samuel" );
      var test5 = ("Clemens, Samul").GetSimilarity( "Clemmons, Samuel" );

      Assert.IsTrue( test1 > THRESHHOLD99, string.Format( "1. Strings are the same, so SimilarityRating[{0}] should have been > 0.99.", test1 ) );
      Assert.IsTrue( test2 > THRESHHOLD, string.Format( "2. SimilarityRating[{0}] should have been > {1}.", test2, THRESHHOLD ) );
      Assert.IsTrue( test3 > THRESHHOLD, string.Format( "3. SimilarityRating[{0}] should have been > {1}.", test3, THRESHHOLD ) );
      Assert.IsTrue( test4 > THRESHHOLD, string.Format( "4. SimilarityRating[{0}] should have been > {1}.", test4, THRESHHOLD ) );
      Assert.IsTrue( test5 > THRESHHOLD, string.Format( "5. SimilarityRating[{0}] should have been > {1}.", test5, THRESHHOLD ) );
    }

    [TestMethod()]
    public void StringSimilarityTestWithStringsReversed()
    {
      var s1 = "Clemens, Samul";
      var s2 = "Clemmons, Samuel";
      const int LOOP_COUNT = 10000;

      var test1 = s1.GetSimilarity( s2 );
      Watch.Start();
      for (var i = 0; i < LOOP_COUNT; i++)
      {
        var test3 = s1.GetSimilarity(s2);
      }
      Watch.Stop();
      var test2 = s2.GetSimilarity( s1 );

      var time = Watch.GetElapsedTime()/LOOP_COUNT;
      Assert.AreEqual( test1, test2,
        string.Format( "Strings are just reversed, so Similarity Ratings should be the same.[{0}]", time ) );
      /* uncomment the following for Timing Tests
       * ========================================
      Assert.AreNotEqual( test1, test2,
        string.Format("Strings are just reversed, so Similarity Ratings should be the same.[{0}]", time) );
       */
    }

    /// <summary>
    ///A test for UrlAvailable
    ///</summary>
    [TestMethod()]
    public void UrlAvailableTest()
    {
      Assert.IsTrue( "www.codeproject.com".UrlAvailable() );
    }

    /// <summary>
    ///A test for Reverse
    ///</summary>
    [TestMethod()]
    public void ReverseTest()
    {
      const string INPUT = "yellow dog";
      const string EXPECTED = "god wolley";
      var actual = INPUT.Reverse();

      Assert.AreEqual( EXPECTED, actual );
    }

    /// <summary>
    ///A test for RemoveSpaces
    ///</summary>
    [TestMethod()]
    public void RemoveSpacesTest()
    {
      var input = "yellow dog" + Environment.NewLine + "black cat";
      var expected = "yellowdog" + Environment.NewLine + "blackcat";
      var actual = input.RemoveSpaces();

      Assert.AreEqual( expected, actual );
    }

    /// <summary>
    ///A test for RemoveDiacritics
    ///</summary>
    [TestMethod()]
    public void RemoveDiacriticsTest()
    {
      const string INPUT = "Příliš žluťoučký kůň úpěl ďábelské ódy."; //contains all czech accents
      const string EXPECTED = "Prilis zlutoucky kun upel dabelske ody.";
      var actual = INPUT.RemoveDiacritics();

      Assert.AreEqual( EXPECTED, actual );
    }

    /// <summary>
    ///A test for Reduce
    ///</summary>
    [TestMethod()]
    public void ReduceTest()
    {
      const string INPUT = "The quick brown fox jumps over the lazy dog";
      const int COUNT = 10;
      const string ENDINGS = "...";
      const string EXPECTED = "The qui...";
      var actual = INPUT.Reduce( COUNT, ENDINGS );

      Assert.AreEqual( EXPECTED, actual );
    }

    /// <summary>
    ///A test for ConvertNewlineToHtmlBreak
    ///</summary>
    [TestMethod()]
    public void ConvertNewlineToHtmlBreakTest()
    {
      var input = "yellow dog" + Environment.NewLine + "black cat";
      const string EXPECTED = "yellow dog<br />black cat";
      var actual = input.ConvertNewlineToHtmlBreak();

      Assert.AreEqual( EXPECTED, actual );
    }

    /// <summary>
    ///A test for MD5
    ///</summary>
    [TestMethod()]
    public void MD5Test()
    {
      const string INPUT = "The quick brown fox jumps over the lazy dog";
      const string EXPECTED = "9e107d9d372bb6826bd81d3542a419d6";
      var actual = INPUT.MD5();

      Assert.AreEqual( EXPECTED, actual );
    }

    /// <summary>
    ///A test for IsValidUrl
    ///</summary>
    [TestMethod()]
    public void IsValidUrlTest()
    {
      Assert.IsTrue( "http://www.codeproject.com".IsValidUrl() );
      Assert.IsTrue( "https://www.codeproject.com/#some_anchor".IsValidUrl() );
      Assert.IsTrue( "https://localhost".IsValidUrl() );
      Assert.IsTrue( "http://www.beresfordltd.nf.net/signs-banners.jpg".IsValidUrl() );
      Assert.IsTrue( "http://aa-bbbb.cc.bla.com:80800/test/test/test.aspx?dd=dd&id=dki".IsValidUrl() );
      Assert.IsFalse( "http:wwwcodeprojectcom".IsValidUrl() );
      Assert.IsFalse( "http://www.code project.com".IsValidUrl() );
    }

    /// <summary>
    ///A test for IsValidEmailAddress
    ///</summary>
    [TestMethod()]
    public void IsValidEmailAddressTest()
    {
      Assert.IsTrue( "yellowdog@someemail.uk".IsValidEmailAddress() );
      Assert.IsTrue( "yellow.444@email4u.co.uk".IsValidEmailAddress() );
      Assert.IsFalse( "adfasdf".IsValidEmailAddress() );
      Assert.IsFalse( "asd@asdf".IsValidEmailAddress() );
    }

    /// <summary>
    ///A test for IsNumberOnly
    ///</summary>
    [TestMethod()]
    public void IsNumberOnlyTest()
    {
      Assert.IsTrue( "12345".IsNumberOnly( false ) );
      Assert.IsTrue( "   12345".IsNumberOnly( false ) );
      Assert.IsTrue( "12.345".IsNumberOnly( true ) );
      Assert.IsTrue( "   12,345 ".IsNumberOnly( true ) );
      Assert.IsFalse( "12 345".IsNumberOnly( false ) );
      Assert.IsFalse( "tractor".IsNumberOnly( true ) );
    }

    /// <summary>
    ///A test for IsNumber
    ///</summary>
    [TestMethod()]
    public void IsNumberTest()
    {
      Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;

      Assert.IsTrue( "12345".IsNumber( false ) );
      Assert.IsTrue( "   12345".IsNumber( false ) );
      Assert.IsTrue( "12.345".IsNumber( true ) );
      Assert.IsTrue( "   12,345 ".IsNumber( true ) );
      Assert.IsTrue( "12 345".IsNumber( false ) );
      Assert.IsFalse( "tractor".IsNumber( true ) );
    }

    #region StopWatch
    public class StopWatch
    {
      private DateTime startTime;
      private DateTime stopTime;
      private bool running = false;

      public void Start()
      {
        this.startTime = DateTime.Now;
        this.running = true;
      }


      public void Stop()
      {
        this.stopTime = DateTime.Now;
        this.running = false;
      }

      // elaspsed time in milliseconds
      public double GetElapsedTime()
      {
        TimeSpan interval;

        if (running)
          interval = DateTime.Now - startTime;
        else
          interval = stopTime - startTime;

        return interval.TotalMilliseconds;
      }

      // elaspsed time in seconds
      public double GetElapsedTimeSecs()
      {
        TimeSpan interval;

        if (running)
          interval = DateTime.Now - startTime;
        else
          interval = stopTime - startTime;

        return interval.TotalSeconds;
      }

      //// sample usage
      //public static void Main( String[] args )
      //{
      //  StopWatch s = new StopWatch();
      //  s.Start();
      //  // code you want to time goes here
      //  s.Stop();
      //  Console.WriteLine( "elapsed time in milliseconds: " + s.GetElapsedTime() );
      //}

    }
    #endregion
  }
}
