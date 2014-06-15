using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="AuthoritiesLawApiCall"/>.</para>
  /// </summary>
  public sealed class AuthoritiesLawApiCallTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DeputiesLawApiCall()"/>
    [Fact]
    public void Constructors()
    {
      var call = new AuthoritiesLawApiCall();
      Assert.False(call.Parameters.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="AuthoritiesLawApiCall.Current(bool)"/> method.</para>
    /// </summary>
    [Fact]
    public void Current_Method()
    {
      var call = new AuthoritiesLawApiCall();
      Assert.False(call.Parameters.ContainsKey("current"));
      Assert.True(ReferenceEquals(call.Current(), call));
      Assert.Equal("true", call.Parameters["current"]);
      Assert.Equal("false", call.Current(false).Parameters["current"]);
    }
  }
}