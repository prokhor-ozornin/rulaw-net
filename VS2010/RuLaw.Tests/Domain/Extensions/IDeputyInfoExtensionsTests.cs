using System;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IDeputyInfoExtensions"/>.</para>
  /// </summary>
  public sealed class IDeputyInfoExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IDeputyInfoExtensions.FullName(IDeputyInfo)"/> method.</para>
    /// </summary>
    [Fact]
    public void FullName_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IDeputyInfoExtensions.FullName(null));
      
      Assert.Equal("LastName FirstName MiddleName", new DeputyInfo { FirstName = "FirstName", LastName = "LastName", MiddleName = "MiddleName" }.FullName());
      Assert.Equal("LastName FirstName", new DeputyInfo { FirstName = "FirstName", LastName = "LastName" }.FullName());
    }
  }
}