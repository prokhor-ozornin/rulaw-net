using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LawType"/>.</para>
  /// </summary>
  public sealed class LawTypeTests : UnitTestsBase<LawType>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      TestJson(new LawType(), new { id = 0 });
      TestJson(
        new LawType
        {
          Id = 1,
          Name = "name"
        },
        new { id = 1, name = "name" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      TestXml(new LawType(), "type", new { id = 0 });
      TestXml(
        new LawType
        {
          Id = 1,
          Name = "name"
        },
        "type",
        new { id = 1, name = "name" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="LawType()"/>
    [Fact]
    public void Constructors()
    {
      var type = new LawType();
      Assert.Equal(0, type.Id);
      Assert.Null(type.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawType.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new LawType { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawType.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new LawType { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawType.CompareTo(ILawType)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="LawType.Equals(ILawType)"/></description></item>
    ///     <item><description><see cref="LawType.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawType.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawType.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new LawType { Name = "name" }.ToString());
    }
  }
}