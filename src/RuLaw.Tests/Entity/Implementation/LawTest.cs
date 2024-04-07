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
  ///   <para>Performs testing of <see cref="Law.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new Law(new {Id = long.MaxValue}).Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Law(new {Name = Guid.Empty.ToString()}).Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property() { new Law(new {Date = DateTimeOffset.MaxValue}).Date.Should().Be(DateTimeOffset.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Number"/> property.</para>
  /// </summary>
  [Fact]
  public void Number_Property() { new Law(new {Number = Guid.Empty.ToString()}).Number.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Subject"/> property.</para>
  /// </summary>
  [Fact]
  public void Subject_Property()
  {
    var subject = new LawSubject();
    new Law(new {Subject = subject}).Subject.Should().BeSameAs(subject);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Type"/> property.</para>
  /// </summary>
  [Fact]
  public void Type_Property()
  {
    var type = new LawType();
    new Law(new {Type = type}).Type.Should().BeSameAs(type);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Url"/> property.</para>
  /// </summary>
  [Fact]
  public void Url_Property() { new Law(new {Url = "http://yandex.ru"}).Url.Should().Be("http://yandex.ru"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.TranscriptUrl"/> property.</para>
  /// </summary>
  [Fact]
  public void TranscriptUrl_Property() { new Law(new {TranscriptUrl = "http://yandex.ru"}).TranscriptUrl.Should().Be("http://yandex.ru"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Comments"/> property.</para>
  /// </summary>
  [Fact]
  public void Comments_Property() { new Law(new {Comments = Guid.Empty.ToString()}).Comments.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.LastEvent"/> property.</para>
  /// </summary>
  [Fact]
  public void LastEvent_Property()
  {
    var lawEvent = new LawEvent();
    new Law(new {LastEvent = lawEvent}).LastEvent.Should().BeSameAs(lawEvent);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Committees"/> property.</para>
  /// </summary>
  [Fact]
  public void Committees_Property()
  {
    var committees = new LawCommittees();
    new Law(new {Committees = committees}).Committees.Should().BeSameAs(committees);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Law(long?, string?, DateTimeOffset?, string?, ILawSubject?, ILawType?, string?, string?, string?, ILawEvent?, ILawCommittees?)"/>
  /// <seealso cref="Law(Law.Info)"/>
  /// <seealso cref="Law(object)"/>
  [Fact]
  public void Constructors()
  {
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

    law = new Law(new Law.Info());
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

    law = new Law(new {});
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
    new Law(new {Name = Guid.Empty.ToString()}).ToString().Should().Be(Guid.Empty.ToString());
  }
}

/// <summary>
///   <para>Tests set for class <see cref="Law.Info"/>.</para>
/// </summary>
public sealed class LawInfoTests : ClassTest<Law.Info>
{
  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Info.Id"/> property.</para>
  /// </summary>
  [Fact]
  public void Id_Property() { new Law.Info {Id = long.MaxValue}.Id.Should().Be(long.MaxValue); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Info.Name"/> property.</para>
  /// </summary>
  [Fact]
  public void Name_Property() { new Law.Info {Name = Guid.Empty.ToString()}.Name.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Info.Date"/> property.</para>
  /// </summary>
  [Fact]
  public void Date_Property() { new Law.Info {Date = Guid.Empty.ToString()}.Date.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Info.Number"/> property.</para>
  /// </summary>
  [Fact]
  public void Number_Property() { new Law.Info {Number = Guid.Empty.ToString()}.Number.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Info.Subject"/> property.</para>
  /// </summary>
  [Fact]
  public void Subject_Property()
  {
    var subject = new LawSubject(new {});
    new Law.Info {Subject = subject}.Subject.Should().BeSameAs(subject);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Info.Type"/> property.</para>
  /// </summary>
  [Fact]
  public void Type_Property()
  {
    var type = new LawType();
    new Law.Info {Type = type}.Type.Should().BeSameAs(type);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Info.Url"/> property.</para>
  /// </summary>
  [Fact]
  public void Url_Property() { new Law.Info {Url = "http://yandex.ru"}.Url.Should().Be("http://yandex.ru"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Info.TranscriptUrl"/> property.</para>
  /// </summary>
  [Fact]
  public void TranscriptUrl_Property() { new Law.Info {TranscriptUrl = "http://yandex.ru"}.TranscriptUrl.Should().Be("http://yandex.ru"); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Info.Comments"/> property.</para>
  /// </summary>
  [Fact]
  public void Comments_Property() { new Law.Info {Comments = Guid.Empty.ToString()}.Comments.Should().Be(Guid.Empty.ToString()); }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Info.LastEvent"/> property.</para>
  /// </summary>
  [Fact]
  public void LastEvent_Property()
  {
    var lawEvent = new LawEvent();
    new Law.Info {LastEvent = lawEvent}.LastEvent.Should().BeSameAs(lawEvent);
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Info.Committees"/> property.</para>
  /// </summary>
  [Fact]
  public void Committees_Property()
  {
    var committees = new LawCommittees();
    var law = new Law.Info {Committees = committees}.Committees.Should().BeSameAs(committees);
  }

  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="Law.Info()"/>
  [Fact]
  public void Constructors()
  {
    var info = new Law.Info();
    info.Id.Should().BeNull();
    info.Name.Should().BeNull();
    info.Date.Should().BeNull();
    info.Number.Should().BeNull();
    info.Subject.Should().BeNull();
    info.Type.Should().BeNull();
    info.Url.Should().BeNull();
    info.TranscriptUrl.Should().BeNull();
    info.Comments.Should().BeNull();
    info.LastEvent.Should().BeNull();
    info.Committees.Should().BeNull();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="Law.Info.ToResult()"/> method.</para>
  /// </summary>
  [Fact]
  public void ToResult_Method()
  {
    using (new AssertionScope())
    {
      var result = new Law.Info().ToResult();
      result.Should().NotBeNull().And.BeOfType<Law>();
      result.Id.Should().BeNull();
      result.Name.Should().BeNull();
      result.Date.Should().BeNull();
      result.Number.Should().BeNull();
      result.Subject.Should().BeNull();
      result.Type.Should().BeNull();
      result.Url.Should().BeNull();
      result.TranscriptUrl.Should().BeNull();
      result.Comments.Should().BeNull();
      result.LastEvent.Should().BeNull();
      result.Committees.Should().BeNull();
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
      Validate(new Law());
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}