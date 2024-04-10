using System.Runtime.Serialization;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Education"/>.</para>
/// </summary>
public sealed class EducationTest : ClassTest<Education>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Education.Institution"/> property.</para>
  /// </summary>
  [Fact]
  public void Institution_Property() { new Education(new {Institution = Guid.Empty.ToString()}).Institution.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Education.Year"/> property.</para>
  /// </summary>
  [Fact]
  public void Year_Property() { new Education(new {Year = short.MaxValue}).Year.Should().Be(short.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Education(string?, short?)"/>
  /// <seealso cref="Education(Education.Info)"/>
  /// <seealso cref="Education(object)"/>
  [Fact]
  public void Constructors()
  {
    typeof(Education).Should().BeDerivedFrom<object>().And.Implement<IEducation>();

    var education = new Education();
    education.Institution.Should().BeNull();
    education.Year.Should().BeNull();

    education = new Education(new Education.Info());
    education.Institution.Should().BeNull();
    education.Year.Should().BeNull();

    education = new Education(new {});
    education.Institution.Should().BeNull();
    education.Year.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Education.CompareTo(IEducation)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(Education.Year), (short) 1, (short) 2); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Education.Equals(IEducation)"/></description></item>
  ///     <item><description><see cref="Education.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(Education.Institution), "first", "second");
    TestEquality(nameof(Education.Year), (short) 1, (short) 2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Education.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(Education.Institution), "first", "second");
    TestHashCode(nameof(Education.Year), (short) 1, (short) 2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Education.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Education(new {Institution = Guid.Empty.ToString(), Year = 1}).ToString().Should().Be($"{Guid.Empty} (1)");
  }
}

/// <summary>
///   <para>Tests set for class <see cref="Education.Info"/>.</para>
/// </summary>
public sealed class EducationInfoTests : ClassTest<Education.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Education.Info.Institution"/> property.</para>
  /// </summary>
  [Fact]
  public void Institution_Property() { new Education.Info {Institution = Guid.Empty.ToString()}.Institution.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Education.Info.Year"/> property.</para>
  /// </summary>
  [Fact]
  public void Year_Property() { new Education.Info {Year = short.MaxValue}.Year.Should().Be(short.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Education.Info()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Education.Info).Should().BeDerivedFrom<object>().And.Implement<IResultable<IEducation>>().And.BeDecoratedWith<DataContractAttribute>();

    var info = new Education.Info();
    info.Institution.Should().BeNull();
    info.Year.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Education.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new Education.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<Education>();
      result.Institution.Should().BeNull();
      result.Year.Should().BeNull();
    }

    return;

    static void Validate()
    {

    }
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Education.Info
      {
        Institution = "institution",
        Year = 1
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}