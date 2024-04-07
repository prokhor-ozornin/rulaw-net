using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using Catharsis.Extensions;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ((IEnumerable<ILaw>) null).Number("number")).ThrowExactly<ArgumentNullException>().WithParameterName("laws");
      AssertionExtensions.Should(() => Enumerable.Empty<ILaw>().Number(null)).ThrowExactly<ArgumentNullException>().WithParameterName("number");
      AssertionExtensions.Should(() => Enumerable.Empty<ILaw>().Number(string.Empty)).ThrowExactly<ArgumentException>().WithParameterName("number");

      var laws = new Law(new {Number = "first"}).ToSequence(new Law(new {Number = "second"}), null);
      new Law(new {Number = "first"}).ToSequence(new Law(new {Number = "second"}), null).Number("first").Should().NotBeNull();
      laws.Number("third").Should().BeNull();
    }

    return;

    static void Validate()
    {

    }
  }
}