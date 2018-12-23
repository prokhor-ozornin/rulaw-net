using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LawApiCall"/>.</para>
  /// </summary>
  public sealed class LawApiCallTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="LawApiCall()"/>
    [Fact]
    public void Constructors()
    {
      var call = new MockLawApiCall();
      Assert.Empty(call.Parameters);
    }

    private sealed class MockLawApiCall : LawApiCall
    {
    }
  }
}