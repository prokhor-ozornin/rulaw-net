using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="VoteExtensions"/>.</para>
  /// </summary>
  public sealed class VoteExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="VoteExtensions.Subject(IEnumerable{Vote}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Subject_Method()
    {
      Assert.Throws<ArgumentNullException>(() => VoteExtensions.Subject(null, "subject"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<Vote>().Subject(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<Vote>().Subject(string.Empty));

      Assert.False(Enumerable.Empty<Vote>().Subject("subject").Any());

      var first = new Vote { Subject = "FIRST" };
      var second = new Vote { Subject = "Second" };
      var votes = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, votes.Subject("first").Single()));
      Assert.True(ReferenceEquals(second, votes.Subject("second").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VoteExtensions.Successful(IEnumerable{Vote})"/> method.</para>
    /// </summary>
    [Fact]
    public void Successful_Method()
    {
      Assert.Throws<ArgumentNullException>(() => VoteExtensions.Successful(null));

      Assert.False(Enumerable.Empty<Vote>().Successful().Any());

      var first = new Vote { Successful = true };
      var second = new Vote { Successful = false };
      var votes = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, votes.Successful().Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="VoteExtensions.Unsuccessful(IEnumerable{Vote})"/> method.</para>
    /// </summary>
    [Fact]
    public void Unsuccessful_Method()
    {
      Assert.Throws<ArgumentNullException>(() => VoteExtensions.Unsuccessful(null));

      Assert.False(Enumerable.Empty<Vote>().Unsuccessful().Any());

      var first = new Vote { Successful = true };
      var second = new Vote { Successful = false };
      var votes = new[] { null, first, second };
      Assert.True(ReferenceEquals(second, votes.Unsuccessful().Single()));
    }
  }
}