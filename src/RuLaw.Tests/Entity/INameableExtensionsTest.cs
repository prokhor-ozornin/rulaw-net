using FluentAssertions;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="INameableExtensions"/>.</para>
/// </summary>
public sealed class INameableExtensionsTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="INameableExtensions.Name{T}(IEnumerable{T}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Name_Method()
  {
    AssertionExtensions.Should(() => ((IEnumerable<NameableEntity>) null).Name("currency")).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<NameableEntity>().Name(null).Should().NotBeNull().And.BeEmpty();

    new[] {null, new NameableEntity {Name = "first"}, null, new NameableEntity {Name = "second"}}.Name("first").Should().NotBeNullOrEmpty().And.ContainSingle();
  }

  private sealed class NameableEntity : INameable
  {
    public string Name { get; init; }
  }
}