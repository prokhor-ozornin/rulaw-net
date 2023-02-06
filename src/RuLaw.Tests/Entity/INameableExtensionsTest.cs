using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="INameableExtensions"/>.</para>
/// </summary>
public sealed class INameableExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="INameableExtensions.Name{T}(IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<NameableEntity>) null).Name("currency")).ThrowExactly<ArgumentNullException>().WithParameterName("entities");

    Enumerable.Empty<NameableEntity>().Name(null).Should().NotBeNull().And.BeEmpty();

    new NameableEntity { Name = "first" }.ToSequence(new NameableEntity { Name = "second" }, null).Name("first").Should().NotBeNullOrEmpty().And.ContainSingle();
  }

  private sealed class NameableEntity : INameable
  {
    public string Name { get; init; }
  }
}