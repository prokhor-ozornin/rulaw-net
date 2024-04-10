using System.Runtime.Serialization;
using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TranscriptVote"/>.</para>
/// </summary>
public sealed class TranscriptVoteTest : ClassTest<TranscriptVote>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptVote.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property() { new TranscriptVote(new {Date = DateTimeOffset.MaxValue}).Date.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptVote.Line"/> property.</para>
  /// </summary>
  [Fact]
  public void Line_Property() { new TranscriptVote(new {Line = int.MaxValue}).Line.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="TranscriptVote(DateTimeOffset?, int?)"/>
  /// <seealso cref="TranscriptVote(TranscriptVote.Info)"/>
  /// <seealso cref="TranscriptVote(object)"/>
  [Fact]
  public void Constructors()
  {
    typeof(TranscriptVote).Should().BeDerivedFrom<object>().And.Implement<ITranscriptVote>();

    var vote = new TranscriptVote();
    vote.Date.Should().BeNull();
    vote.Line.Should().BeNull();

    vote = new TranscriptVote(new TranscriptVote.Info());
    vote.Date.Should().BeNull();
    vote.Line.Should().BeNull();

    vote = new TranscriptVote(new {});
    vote.Date.Should().BeNull();
    vote.Line.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptVote.CompareTo(ITranscriptVote)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(TranscriptVote.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="TranscriptVote.Equals(ITranscriptVote)"/></description></item>
  ///     <item><description><see cref="TranscriptVote.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods()
  {
    TestEquality(nameof(TranscriptVote.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
    TestEquality(nameof(TranscriptVote.Line), 1, 2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptVote.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode(nameof(TranscriptVote.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
    TestHashCode(nameof(TranscriptVote.Line), 1, 2);
  }
}

/// <summary>
///   <para>Tests set for class <see cref="TranscriptVote.Info"/>.</para>
/// </summary>
public sealed class TranscriptVoteInfoTests : ClassTest<TranscriptVote.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptVote.Info.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property() { new TranscriptVote(new {Date = DateTimeOffset.MaxValue}).Date.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptVote.Info.Line"/> property.</para>
  /// </summary>
  [Fact]
  public void Line_Property() { new TranscriptVote.Info {Line = int.MaxValue}.Line.Should().Be(int.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="TranscriptVote.Info()"/>
  [Fact]
  public void Constructors()
  {
    typeof(TranscriptVote.Info).Should().BeDerivedFrom<object>().And.Implement<IResultable<ITranscriptVote>>().And.BeDecoratedWith<DataContractAttribute>();

    var info = new TranscriptVote.Info();
    info.Date.Should().BeNull();
    info.Line.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptVote.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new TranscriptVote.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<TranscriptVote>();
      result.Date.Should().BeNull();
      result.Line.Should().BeNull();
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
      Validate(new TranscriptVote.Info
      {
        Date = DateTimeOffset.MinValue.AsString(),
        Line = 1
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}