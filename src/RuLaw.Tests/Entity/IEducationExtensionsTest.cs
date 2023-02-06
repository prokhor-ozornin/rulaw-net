using FluentAssertions;
using Xunit;
using Catharsis.Extensions;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="IEducationExtensions"/>.</para>
/// </summary>
public sealed class IEducationExtensionsTest : UnitTest
{
  /// <summary>
  ///   <para>Performs testing of <see cref="IEducationExtensions.Institution{TEntity}(IEnumerable{TEntity}, string)"/> method.</para>
  /// </summary>
  [Fact]
  public void Institution_Method()
  {
    AssertionExtensions.Should(() => IEducationExtensions.Institution<IEducation>(null, "institution")).ThrowExactly<ArgumentNullException>().WithParameterName("educations");
    AssertionExtensions.Should(() => Enumerable.Empty<IEducation>().Institution(null)).ThrowExactly<ArgumentNullException>().WithParameterName("institution");
    AssertionExtensions.Should(() => Enumerable.Empty<IEducation>().Institution(string.Empty)).ThrowExactly<ArgumentException>().WithParameterName("institution");

    Enumerable.Empty<IEducation>().Institution("institution").Should().NotBeNull().And.BeEmpty();

    var first = new Education(new {Institution = "FIRST"});
    var second = new Education(new {Institution = "Second"});
    var educations = first.ToSequence(second, null);
    educations.Institution("first").Should().NotBeNullOrEmpty().And.Equal(first);
    educations.Institution("second").Should().NotBeNullOrEmpty().And.Equal(second);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEducationExtensions.Year{TEntity}(IEnumerable{TEntity}, short?, short?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    AssertionExtensions.Should(() => IEducationExtensions.Year<IEducation>(null)).ThrowExactly<ArgumentNullException>();

    Enumerable.Empty<IEducation>().Year().Should().NotBeNull().And.BeEmpty();

    var first = new Education(new {Year = 0});
    var second = new Education(new {Year = 1});
    var third = new Education(new {Year = 2});

    var educations = first.ToSequence(second, third, null);
    educations.Year(1).Should().NotBeNullOrEmpty().And.Equal(second, third);
    educations.Year(null, 1).Should().NotBeNullOrEmpty().And.Equal(first, second);
    educations.Year(0, 2).Should().NotBeNullOrEmpty().And.Equal(first, second, third);
  }
}