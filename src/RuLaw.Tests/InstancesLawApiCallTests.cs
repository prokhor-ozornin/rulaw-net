using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="InstancesLawApiCall"/>.</para>
  /// </summary>
  public sealed class InstancesLawApiCallTests
  {
    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="InstancesLawApiCall()"/>
    [Fact]
    public void Constructors()
    {
      var call = new InstancesLawApiCall();
      Assert.Empty(call.Parameters);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="InstancesLawApiCall.Current(bool)"/> method.</para>
    /// </summary>
    [Fact]
    public void Current_Method()
    {
      var call = new InstancesLawApiCall();
      Assert.False(call.Parameters.ContainsKey("current"));
      Assert.True(ReferenceEquals(call.Current(), call));
      Assert.Equal("true", call.Parameters["current"]);
      Assert.Equal("false", call.Current(false).Parameters["current"]);
    }
  }
}