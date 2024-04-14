using Catharsis.Commons;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="Law"/>.</para>
/// </summary>
public sealed class LawTest : ClassTest<Law>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Law()"/>
  [Fact]
  public void Constructors()
  {
    typeof(Law).Should().BeDerivedFrom<object>().And.Implement<ILaw>();

    var law = new Law();
    law.Id.Should().BeNull();
    law.Name.Should().BeNull();
    law.Date.Should().BeNull();
    law.Number.Should().BeNull();
    law.Subject.Should().BeNull();
    law.Type.Should().BeNull();
    law.Url.Should().BeNull();
    law.TranscriptUrl.Should().BeNull();
    law.Comments.Should().BeNull();
    law.LastEvent.Should().BeNull();
    law.Committees.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property()
  {
    new Law { Id = long.MaxValue }.Id.Should().Be(long.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property()
  {
    new Law { Name = Guid.Empty.ToString() }.Name.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property()
  {
    new Law { Date = DateTimeOffset.MaxValue }.Date.Should().Be(DateTimeOffset.MaxValue);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Number"/> property.</para>
  /// </summary>
  [Fact]
  public void Number_Property()
  {
    new Law { Number = Guid.Empty.ToString() }.Number.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Subject"/> property.</para>
  /// </summary>
  [Fact]
  public void Subject_Property()
  {
    var subject = new LawSubject();
    new Law { Subject = subject }.Subject.Should().BeSameAs(subject);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Type"/> property.</para>
  /// </summary>
  [Fact]
  public void Type_Property()
  {
    var type = new LawType();
    new Law { Type = type }.Type.Should().BeSameAs(type);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Url"/> property.</para>
  /// </summary>
  [Fact]
  public void Url_Property()
  {
    new Law { Url = "http://yandex.ru" }.Url.Should().Be("http://yandex.ru");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.TranscriptUrl"/> property.</para>
  /// </summary>
  [Fact]
  public void TranscriptUrl_Property()
  {
    new Law { TranscriptUrl = "http://yandex.ru" }.TranscriptUrl.Should().Be("http://yandex.ru");
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Comments"/> property.</para>
  /// </summary>
  [Fact]
  public void Comments_Property()
  {
    new Law { Comments = Guid.Empty.ToString() }.Comments.Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.LastEvent"/> property.</para>
  /// </summary>
  [Fact]
  public void LastEvent_Property()
  {
    var lawEvent = new LawEvent();
    new Law { LastEvent = lawEvent }.LastEvent.Should().BeSameAs(lawEvent);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Committees"/> property.</para>
  /// </summary>
  [Fact]
  public void Committees_Property()
  {
    var committees = new LawCommittees();
    new Law { Committees = committees }.Committees.Should().BeSameAs(committees);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.CompareTo(ILaw)"/> method.</para>
  /// </summary>
  [Fact]
  public void CompareTo_Method() { TestCompareTo(nameof(Law.Date), DateTimeOffset.MinValue, DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of following methods :</para>
  ///   <list type="bullet">
  ///     <item><description><see cref="Law.Equals(ILaw)"/></description></item>
  ///     <item><description><see cref="Law.Equals(object)"/></description></item>
  ///   </list>
  /// </summary>
  [Fact]
  public void Equals_Methods() { TestEquality(nameof(Law.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.GetHashCode()"/> method.</para>
  /// </summary>
  [Fact]
  public void GetHashCode_Method() { TestHashCode(nameof(Law.Id), 1, 2); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.ToString()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToString_Method()
  {
    new Law {Name = Guid.Empty.ToString()}.ToString().Should().Be(Guid.Empty.ToString());
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new Law());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}