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
    /// <seealso cref="RuLawException(Error, Exception)"/>
    [Fact]
    public void Constructors()
    {
      Assert.Throws<ArgumentNullException>(() => new RuLawException(null));

      var innerException = new Exception();
      var error = new Error(1, "text");
      var exception = new RuLawException(error, innerException);
      Assert.True(ReferenceEquals(exception.InnerException, innerException));
      Assert.Equal("text", exception.Message);
      Assert.True(ReferenceEquals(error, exception.Error));
    }
  }
}