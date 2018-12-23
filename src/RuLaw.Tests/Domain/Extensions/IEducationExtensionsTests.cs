using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="IEducationExtensions"/>.</para>
  /// </summary>
  public sealed class IEducationExtensionsTests
  {
    /// <summary>
    ///   <para>Performs testing of <see cref="IEducationExtensions.Institution{ENTITY}(IEnumerable{ENTITY}, string)"/> method.</para>
    /// </summary>
    [Fact]
    public void Institution_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IEducationExtensions.Institution<IEducation>(null, "institution"));
      Assert.Throws<ArgumentNullException>(() => Enumerable.Empty<IEducation>().Institution(null));
      Assert.Throws<ArgumentException>(() => Enumerable.Empty<IEducation>().Institution(string.Empty));

      Assert.Empty(Enumerable.Empty<IEducation>().Institution("institution"));

      var first = new Education { Institution = "FIRST" };
      var second = new Education { Institution = "Second" };
      var educations = new[] { null, first, second };
      Assert.True(ReferenceEquals(first, educations.Institution("first").Single()));
      Assert.True(ReferenceEquals(second, educations.Institution("second").Single()));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="IEducationExtensions.Year{ENTITY}(IEnumerable{ENTITY}, short?, short?)"/> method.</para>
    /// </summary>
    [Fact]
    public void Year_Method()
    {
      Assert.Throws<ArgumentNullException>(() => IEducationExtensions.Year<IEducation>(null));

      Assert.Empty(Enumerable.Empty<IEducation>().Year());

      var first = new Education { Year = 0 };
      var second = new Education { Year = 1 };
      var third = new Education { Year = 2 };

      var educations = new[] { null, first, second, third };
      Assert.True(educations.Year(1).SequenceEqual(new[] { second, third }));
      Assert.True(educations.Year(null, 1).SequenceEqual(new[] { first, second }));
      Assert.True(educations.Year(0, 2).SequenceEqual(new[] { first, second, third }));
    }
  }
}