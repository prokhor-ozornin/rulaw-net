using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Education"/>.</para>
  /// </summary>
  public sealed class EducationTests : UnitTestsBase<Education>
  {
    /// <summary>
    ///   <para>Performs testing of class attributes.</para>
    /// </summary>
    [Fact]
    public void Attributes()
    {
      this.TestDescription("Institution", "Year");
    }

    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new Education(), new { year = 0 });
      this.TestJson(
        new Education
        {
          Institution = "institution",
          Year = 1
        },
        new { institution = "institution", year = 1 }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new Education(), "education", new { year = 0 });
      this.TestXml(
        new Education
        {
          Institution = "institution",
          Year = 1
        },
        "education",
        new { institution = "institution", year = 1 }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Education()"/>
    [Fact]
    public void Constructors()
    {
      var education = new Education();
      Assert.Null(education.Institution);
      Assert.Equal(0, education.Year);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Education.Institution"/> property.</para>
    /// </summary>
    [Fact]
    public void Institution_Property()
    {
      Assert.Equal("institution", new Education { Institution = "institution" }.Institution);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Education.Year"/> property.</para>
    /// </summary>
    [Fact]
    public void Year_Property()
    {
      Assert.Equal(1, new Education { Year = 1 }.Year);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Education.CompareTo(Education)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("Year", (short) 1, (short) 2);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Education.Equals(Education)"/></description></item>
    ///     <item><description><see cref="Education.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Institution", "first", "second");
      this.TestEquality("Year", (short) 1, (short) 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Education.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Institution", "first", "second");
      this.TestHashCode("Year", (short) 1, (short) 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Education.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("institution (1)", new Education { Institution = "institution", Year = 1 }.ToString());
    }
  }
}