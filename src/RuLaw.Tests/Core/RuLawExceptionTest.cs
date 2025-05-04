using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
namespace RuLaw.Tests;


/// <summary>
///   <para>Tests set for class <see cref="RuLawException"/>.</para>
/// </summary>
public sealed class RuLawExceptionTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="RuLawException(Error, Exception)"/>
  [Fact]
  public void Constructors()
  {
    typeof(Error).Should().BeDerivedFrom<object>().And.Implement<IError>();

    using (new AssertionScope())
    {
      var exception = new RuLawException();
      exception.InnerException.Should().BeNull();
      exception.Message.Should().BeNull();
    }

    using (new AssertionScope())
    {
      var inner = new Exception();
      var error = new Error(1, "text");
      var exception = new RuLawException(error, inner);
      exception.InnerException.Should().NotBeNull().And.BeSameAs(inner);
      exception.Message.Should().Be("text");
      exception.Error.Should().NotBeNull().And.BeSameAs(error);
    }
  }
}