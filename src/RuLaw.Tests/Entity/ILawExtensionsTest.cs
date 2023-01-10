using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="ILawExtensions"/>.</para>
/// </summary>
public sealed class ILawExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="ILawExtensions.Number{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Number_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<ILaw>) null).Number("number")).ThrowExactly<ArgumentNullException>().WithParameterName("laws");
    AssertionExtensions.Should(() => Enumerable.Empty<ILaw>().Number(null)).ThrowExactly<ArgumentNullException>().WithParameterName("number");
    AssertionExtensions.Should(() => Enumerable.Empty<ILaw>().Number(string.Empty)).ThrowExactly<ArgumentException>().WithParameterName("number");

    var laws = new[] {null, new Law(new {Number = "first"}), null, new Law(new {Number = "second"})};
    new[] {null, new Law(new {Number = "first"}), null, new Law(new {Number = "second"})}.Number("first").Should().NotBeNull();
    laws.Number("third").Should().BeNull();
  }
}