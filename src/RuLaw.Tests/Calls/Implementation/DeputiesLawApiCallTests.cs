using System;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DeputiesLawApiCall"/>.</para>
  /// </summary>
  public sealed class DeputiesLawApiCallTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DeputiesLawApiCall()"/>
    [Fact]
    public void Constructors()
    {
      var call = new DeputiesLawApiCall();
      Assert.Empty(call.Parameters);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputiesLawApiCall.Name(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Name_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new DeputiesLawApiCall().Name(null));
      Assert.Throws<ArgumentException>(() => new DeputiesLawApiCall().Name(string.Empty));

      var call = new DeputiesLawApiCall();
      Assert.False(call.Parameters.ContainsKey("begin"));
      Assert.True(ReferenceEquals(call.Name("name"), call));
      Assert.Equal("name", call.Parameters["begin"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputiesLawApiCall.Position(string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Position_Method()
    {
      Assert.Throws<ArgumentNullException>(() => new DeputiesLawApiCall().Position(null));
      Assert.Throws<ArgumentException>(() => new DeputiesLawApiCall().Position(string.Empty));

      var call = new DeputiesLawApiCall();
      Assert.False(call.Parameters.ContainsKey("position"));
      Assert.True(ReferenceEquals(call.Position("position"), call));
      Assert.Equal("position", call.Parameters["position"]);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputiesLawApiCall.Current(bool)"/> method.</para>
    /// </summary>
    [Fact]
    public void Current_Method()
    {
      var call = new DeputiesLawApiCall();
      Assert.False(call.Parameters.ContainsKey("current"));
      Assert.True(ReferenceEquals(call.Current(), call));
      Assert.Equal("true", call.Parameters["current"]);
      Assert.Equal("false", call.Current(false).Parameters["current"]);
    }
  }
}