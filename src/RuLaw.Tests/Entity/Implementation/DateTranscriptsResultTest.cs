using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="DateTranscriptsResult"/>.</para>
/// </summary>
/// <seealso cref="DateTranscriptsResult"/>
public sealed class DateTranscriptsResultTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="DateTranscriptsResult()"/>
  [Fact]
  public void Constructors()
  {
    typeof(DateTranscriptsResult).Should().BeDerivedFrom<object>().And.Implement<IDateTranscriptsResult>();

    using (new AssertionScope())
    {
      var result = new DateTranscriptsResult();

      result.Date.Should().BeNull();
      result.Meetings.Should().BeEmpty();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptsResult.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property() => new DateTranscriptsResult { Date = DateTimeOffset.MaxValue }.Date.Should().Be(DateTimeOffset.MaxValue);

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptsResult.Meetings"/> property.</para>
  /// </summary>
  [Fact]
  public void Meetings_Property()
  {
    var result = new DateTranscriptsResult();
    var meeting = new DateTranscriptMeeting();

    (result.Meetings as ICollection<IDateTranscriptMeeting>)?.Add(meeting);
    result.Meetings.Should().ContainSingle().Which.Should().BeSameAs(meeting);

    (result.Meetings as ICollection<IDateTranscriptMeeting>)?.Remove(meeting);
    result.Meetings.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptsResult.CompareTo(IDateTranscriptsResult)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() => TestCompareTo<DateTranscriptsResult, DateTimeOffset>(nameof(DateTranscriptsResult.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); 

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="DateTranscriptsResult.Equals(IDateTranscriptsResult)"/></description></item>
  ///     <item><description><see cref="DateTranscriptsResult.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() => TestEquality<DateTranscriptsResult, DateTimeOffset>(nameof(DateTranscriptsResult.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); 

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptsResult.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() => TestHashCode<DateTranscriptsResult, DateTimeOffset>(nameof(DateTranscriptsResult.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); 

  /// <summary>
  ///   <para>Performs testing of <see cref="DateTranscriptsResult.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new DateTranscriptsResult {Date = DateTimeOffset.MaxValue}.ToString().Should().Be(DateTimeOffset.MaxValue.AsString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Test(new DateTranscriptsResult());
    }

    return;

    static void Test(IDateTranscriptsResult result) => result.To<object>().Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}