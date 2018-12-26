using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="Law"/>.</para>
  /// </summary>
  public sealed class LawTests : UnitTestsBase<Law>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      TestJson(new Law(), new { id = 0, committees = new { profile = new object[] {}, soexecutor = new object[] {}}, introductionDate = default(DateTime), subject = new { departments = new object[] {}, deputies = new object[] {} }});
      TestJson(new Law
        {
          Id = 1,
          Comments = "comments",
          CommitteesOriginal = new LawCommittees
          {
            ProfileOriginal = new List<Committee> { new Committee { Id = 2 } },
            ResponsibleOriginal = new Committee { Id = 3 },
            SoExecutorOriginal = new List<Committee> { new Committee { Id = 4 } }
          },
          Date = DateTime.MinValue,
          LastEventOriginal = new LawEvent { Date = DateTime.MinValue, DocumentOriginal = new LawEventDocument { Name = "lastEvent.document.name", Type = "lastEvent.document.type" }, PhaseOriginal = new LawEventPhase { Id = 7, Name = "lastEvent.phase.name" }, Solution = "lastEvent.solution", StageOriginal = new LawEventStage { Id = 8, Name = "lastEvent.stage.name" } },
          Name = "name",
          Number = "number",
          SubjectOriginal = new LawSubject { DepartmentsOriginal = new List<Authority> { new Authority { Id = 5 } }, DeputiesOriginal = new List<Deputy> { new Deputy { Id = 6 } } },
          TranscriptUrl = "transcriptUrl",
          Type = new LawType { Id = 7 },
          Url = "url"
        },
        new
        {
          id = 1,
          comments = "comments",
          committees = new
          {
            profile = new object[] { new { id = 2, isCurrent = false, startDate = DateTime.MinValue } },
            responsible = new { id = 3, isCurrent = false, startDate = DateTime.MinValue },
            soexecutor = new object[] { new { id = 4, isCurrent = false, startDate = DateTime.MinValue } }
          },
          introductionDate = DateTime.MinValue,
          lastEvent = new
          {
            date = DateTime.MinValue,
            document = new { name = "lastEvent.document.name", type = "lastEvent.document.type" },
            phase = new { id = 7, name = "lastEvent.phase.name" },
            solution = "lastEvent.solution",
            stage = new { id = 8, name = "lastEvent.stage.name" }
          },
          name = "name",
          number = "number",
          subject = new
          {
            departments = new object[] { new { id = 5, isCurrent = false, startDate = DateTime.MinValue } },
            deputies = new object[] { new { id = 6, isCurrent = false } }
          },
          transcriptUrl = "transcriptUrl",
          type = new { id = 7 }, url = "url"
        });
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      TestXml(new Law(), "law", new { id = 0, introductionDate = default(DateTime).ISO8601() });
      TestXml(new Law
      {
        Id = 1,
        Comments = "comments",
        CommitteesOriginal = new LawCommittees
        {
          ProfileOriginal = new List<Committee> { new Committee { Id = 2 } },
          ResponsibleOriginal = new Committee { Id = 3 },
          SoExecutorOriginal = new List<Committee> { new Committee { Id = 4 } }
        },
        Date = DateTime.MinValue,
        LastEventOriginal = new LawEvent { Date = DateTime.MinValue, DocumentOriginal = new LawEventDocument { Name = "lastEvent.document.name", Type = "lastEvent.document.type" }, PhaseOriginal = new LawEventPhase { Id = 7, Name = "lastEvent.phase.name" }, Solution = "lastEvent.solution", StageOriginal = new LawEventStage { Id = 8, Name = "lastEvent.stage.name" } },
        Name = "name",
        Number = "number",
        SubjectOriginal = new LawSubject { DepartmentsOriginal = new List<Authority> { new Authority { Id = 5 } }, DeputiesOriginal = new List<Deputy> { new Deputy { Id = 6 } } },
        TranscriptUrl = "transcriptUrl",
        Type = new LawType { Id = 7 },
        Url = "url"
      },
      "law",
      new
      {
        id = 1,
        comments = "comments",
        introductionDate = DateTime.MinValue.ISO8601(),
        name = "name",
        number = "number",
        transcriptUrl = "transcriptUrl",
        url = "url"
      });
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="Law()"/>
    [Fact]
    public void Constructors()
    {
      var law = new Law();
      Assert.Equal(0, law.Id);
      Assert.Null(law.Comments);
      Assert.Empty(law.CommitteesOriginal.ProfileOriginal);
      Assert.Empty(law.CommitteesOriginal.Profile);
      Assert.Null(law.CommitteesOriginal.Responsible);
      Assert.Empty(law.CommitteesOriginal.SoExecutorOriginal);
      Assert.Empty(law.CommitteesOriginal.SoExecutor);
      Assert.Equal(default(DateTime), law.Date);
      Assert.Null(law.LastEvent);
      Assert.Null(law.Name);
      Assert.Null(law.Number);
      Assert.Empty(law.SubjectOriginal.DepartmentsOriginal);
      Assert.Empty(law.SubjectOriginal.Departments);
      Assert.Empty(law.SubjectOriginal.DeputiesOriginal);
      Assert.Empty(law.SubjectOriginal.Deputies);
      Assert.Null(law.TranscriptUrl);
      Assert.Null(law.Type);
      Assert.Null(law.Url);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Law.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new Law { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Law.Comments"/> property.</para>
    /// </summary>
    [Fact]
    public void Comments_Property()
    {
      Assert.Equal("comments", new Law { Comments = "comments" }.Comments);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Law.Committees"/> property.</para>
    /// </summary>
    [Fact]
    public void Committees_Property()
    {
      var committees = new LawCommittees();
      var law = new Law { CommitteesOriginal = committees };
      Assert.True(ReferenceEquals(committees, law.CommitteesOriginal));
      Assert.True(ReferenceEquals(committees, law.Committees));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Law.Date"/> property.</para>
    /// </summary>
    [Fact]
    public void Date_Property()
    {
      Assert.Equal(DateTime.MinValue, new Law { Date = DateTime.MinValue }.Date);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Law.LastEvent"/> property.</para>
    /// </summary>
    [Fact]
    public void LastEvent_Property()
    {
      var @event = new LawEvent();
      var law = new Law { LastEventOriginal = @event };
      Assert.True(ReferenceEquals(@event, law.LastEventOriginal));
      Assert.True(ReferenceEquals(@event, law.LastEvent));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Law.Name"/> property.</para>
    /// </summary>
    [Fact]
    public void Name_Property()
    {
      Assert.Equal("name", new Law { Name = "name" }.Name);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Law.Number"/> property.</para>
    /// </summary>
    [Fact]
    public void Number_Property()
    {
      Assert.Equal("number", new Law { Number = "number" }.Number);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Law.Subject"/> property.</para>
    /// </summary>
    [Fact]
    public void Subject_Property()
    {
      var subject = new LawSubject();
      var law = new Law { SubjectOriginal = subject };
      Assert.True(ReferenceEquals(subject, law.SubjectOriginal));
      Assert.True(ReferenceEquals(subject, law.Subject));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Law.TranscriptUrl"/> property.</para>
    /// </summary>
    [Fact]
    public void TranscriptUrl_Property()
    {
      Assert.Equal("http://yandex.ru", new Law { TranscriptUrl = "http://yandex.ru" }.TranscriptUrl);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Law.Type"/> property.</para>
    /// </summary>
    [Fact]
    public void Type_Property()
    {
      var type = new LawType();
      Assert.True(ReferenceEquals(type, new Law { Type = type }.Type));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Law.Url"/> property.</para>
    /// </summary>
    [Fact]
    public void Url_Property()
    {
      Assert.Equal("http://yandex.ru", new Law { Url = "http://yandex.ru" }.Url);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Law.CompareTo(ILaw)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      TestCompareTo("Date", DateTime.MinValue, DateTime.MaxValue);
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="Law.Equals(ILaw)"/></description></item>
    ///     <item><description><see cref="Law.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Law.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="Law.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("name", new Law { Name = "name" }.ToString());
    }
  }
}