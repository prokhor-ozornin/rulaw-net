using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="TranscriptVote"/>.</para>
/// </summary>
public sealed class TranscriptVoteTest : Test
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="TranscriptVote()"/>
  [Fact]
  public void Constructors()
  {
    typeof(TranscriptVote).Should().BeDerivedFrom<object>().And.Implement<ITranscriptVote>();

    using (new AssertionScope())
    {
      var vote = new TranscriptVote();

      vote.Date.Should().BeNull();
      vote.Line.Should().BeNull();
    }
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptVote.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property()
  {
    new TranscriptVote { Date = DateTimeOffset.MaxValue }.Date.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptVote.Line"/> property.</para>
  /// </summary>
  [Fact]
  public void Line_Property()
  {
    new TranscriptVote { Line = int.MaxValue }.Line.Should().Be(int.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptVote.CompareTo(ITranscriptVote)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method()
  {
    TestCompareTo<TranscriptVote, DateTimeOffset>(nameof(TranscriptVote.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); 
  }

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
    TestEquality<TranscriptVote, DateTimeOffset>(nameof(TranscriptVote.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
    TestEquality<TranscriptVote, int>(nameof(TranscriptVote.Line), 1, 2);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="TranscriptVote.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method()
  {
    TestHashCode<TranscriptVote, DateTimeOffset>(nameof(TranscriptVote.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
    TestHashCode<TranscriptVote, int>(nameof(TranscriptVote.Line), 1, 2);
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new TranscriptVote
      {
        Date = DateTimeOffset.MinValue,
        Line = 1
      });
    }

    return;

    static void Validate(ITranscriptVote instance) => instance.To<object>().Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}