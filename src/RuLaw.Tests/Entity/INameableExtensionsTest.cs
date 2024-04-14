using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => ((IEnumerable<NameableEntity>) null).Name("currency")).ThrowExactly<ArgumentNullException>().WithParameterName("entities");
      AssertionExtensions.Should(() => Enumerable.Empty<INameable>().Name(null)).ThrowExactly<ArgumentNullException>().WithParameterName("name");
      AssertionExtensions.Should(() => Enumerable.Empty<INameable>().Name(string.Empty)).ThrowExactly<ArgumentException>().WithMessage("name");
      
      Validate(new NameableEntity[] { new() { Name = "first" }, new() { Name = "second" } }, "first", 1);
    }

    return;

    static void Validate(IEnumerable<INameable> sequence, string name, int count) => sequence.Name(name).Should().NotBeNull().And.NotBeSameAs(sequence).And.HaveCount(count);
  }

  private sealed class NameableEntity : INameable
  {
    public string Name { get; init; }
  }
}