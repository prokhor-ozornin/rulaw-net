using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Convocation"/>.</para>
  /// </summary>
  public sealed class ConvocationTests : UnitTestsBase<Convocation>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      TestJson(new Convocation(), new { id = 0, sessions = new object[] {}, startDate = default(DateTime) });
      TestJson(
        new Convocation
        {
          Id = 1,
          FromDate = DateTime.MinValue,
          Name = "name",
          SessionsOriginal = new List<Session> { new Session { Id = 2 } },
          ToDate = DateTime.MaxValue
        },
        new { id = 1, endDate = DateTime.MaxValue, name = "name", sessions = new object[] { new { id = 2, startDate = default(DateTime) } }, startDate = DateTime.MinValue }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      TestXml(new Convocation(), "period", new { id = 0, startDate = default(DateTime).ISO8601() });
      TestXml(
        new Convocation
        {
          Id = 1,
          FromDate = DateTime.MinValue,
          Name = "name",
          SessionsOriginal = new List<Session> { new Session { Id = 2 } },
          ToDate = DateTime.MaxValue
        },
        "period",
        new { id = 1, startDate = DateTime.MinValue.ISO8601(), name = "name", endDate = DateTime.MaxValue.ISO8601() }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Convocation()"/>
    [Fact]
    public void Constructors()
    {
      var period = new Convocation();
      Assert.Equal(0, period.Id);
      Assert.Equal(default(DateTime), period.FromDate);
      Assert.Null(period.Name);
      Assert.Empty(period.SessionsOriginal);
      Assert.Empty(period.Sessions);
      Assert.Null(period.ToDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Convocation.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new Convocation { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Convocation.FromDate"/> property.</para>
    /// </summary>
    [Fact]
    public void FromDate_Property()
    {
      Assert.Equal(DateTime.MinValue, new Convocation { FromDate = DateTime.MinValue }.FromDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Convocation.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new Convocation { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Convocation.Sessions"/> property.</para>
    /// </summary>
    [Fact]
    public void Sessions_Property()
    {
      var convocation = new Convocation();
      var session = new Session();

      convocation.SessionsOriginal.Add(session);
      Assert.True(ReferenceEquals(convocation.SessionsOriginal.Single(), session));
      Assert.True(ReferenceEquals(convocation.Sessions.Single(), session));

      convocation.SessionsOriginal.Remove(session);
      Assert.Empty(convocation.SessionsOriginal);
      Assert.Empty(convocation.Sessions);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Convocation.ToDate"/> property.</para>
    /// </summary>
    [Fact]
    public void ToDate_Property()
    {
      Assert.Equal(DateTime.MaxValue, new Convocation { ToDate = DateTime.MaxValue }.ToDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Convocation.CompareTo(IConvocation)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      TestCompareTo("Name", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Convocation.Equals(IConvocation)"/></description></item>
    ///     <item><description><see cref="Convocation.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Convocation.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Convocation.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new Convocation { Name = "name" }.ToString());
    }
  }
}