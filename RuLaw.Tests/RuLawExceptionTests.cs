using System;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="RuLawException"/>.</para>
  /// </summary>
  public sealed class RuLawExceptionTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="RuLawException(string, Exception)"/>
    [Fact]
    public void Constructors()
    {
      Assert.Throws<ArgumentNullException>(() => new RuLawException(null));
      Assert.Throws<ArgumentException>(() => new RuLawException(string.Empty));

      var innerException = new Exception();
      var exception = new RuLawException("message", innerException);
      Assert.True(ReferenceEquals(exception.InnerException, innerException));
      Assert.Equal("message", exception.Message);
    }
  }
}