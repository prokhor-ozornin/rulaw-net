using Catharsis.Commons;
using FluentAssertions;
using Xunit;
using FluentAssertions.Execution;

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
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEducationExtensions.Institution<IEducation>(null, "institution")).ThrowExactly<ArgumentNullException>().WithParameterName("educations");

      Validate([], [], null);
      Validate([], [], "institution");

      var first = new Education { Institution = "first" };
      var second = new Education { Institution = "second" };
      Validate([], [null], null);
      Validate([first], [null, first, second, null], first.Institution);
    }

    return;

    static void Validate(IEnumerable<IEducation> result, IEnumerable<IEducation> educations, string institution) => educations.Institution(institution).Should().BeAssignableTo<IEnumerable<IEducation>>().And.Equal(result);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="IEducationExtensions.Year{TEntity}(IEnumerable{TEntity}, short?, short?)"/> method.</para>
  /// </summary>
  [Fact]
  public void Year_Method()
  {
    using (new AssertionScope())
    {
      AssertionExtensions.Should(() => IEducationExtensions.Year<IEducation>(null)).ThrowExactly<ArgumentNullException>();

      Validate([], []);
      
      var first = new Education { Year = 0 };
      var second = new Education { Year = 1 };
      var third = new Education { Year = 2 };

      var educations = new List<IEducation> { null, first, second, third, null };
      Validate([second, third], educations, 1);
      Validate([first, second], educations, null, 1);
      Validate([first, second, third], educations, 0, 2);
    }

    return;

    static void Validate(IEnumerable<IEducation> result, IEnumerable<IEducation> educations, short? from = null, short? to = null) => educations.Year(from, to).Should().BeAssignableTo<IEnumerable<IEducation>>().And.Equal(result);
  }
}