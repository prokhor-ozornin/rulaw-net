using System;
using System.Collections.Generic;
using System.Linq;
using Catharsis.Commons;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="DeputyInfo"/>.</para>
  /// </summary>
  public sealed class DeputyInfoTests : UnitTestsBase<DeputyInfo>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new DeputyInfo(), new { id = 0, activity = new object[] {}, birthdate = default(DateTime), credentialsStart = default(DateTime), degrees = new object[] {}, educations = new object[] {}, factionId = 0, isActual = false, lawcount = 0, ranks = new object[] {}, regions = new object[] {}, speachCount = 0} );
      this.TestJson(
        new DeputyInfo
        {
          Id = 1,
          Active = true,
          ActivitiesOriginal = new List<DeputyActivity> { new DeputyActivity { Name = "activity.name", CommitteeId = 1 } },
          BirthDate = DateTime.MaxValue,
          DegreesOriginal = new List<string> { "degree" },
          EducationsOriginal = new List<Education> { new Education { Year = 2000 } },
          FactionId = 2,
          FactionName = "factionName",
          FactionRegion = "factionRegion",
          FactionRole = "factionRole",
          FirstName = "firstName",
          LastName = "lastName",
          LawsCount = 3,
          MiddleName = "middleName",
          RanksOriginal = new List<string> { "rank" },
          RegionsOriginal = new List<string> { "region" },
          SpeachesCount = 4,
          TranscriptLink = "transcriptLink",
          VoteLink = "voteLink",
          WorkStartDate = DateTime.MaxValue,
          WorkEndDate = DateTime.MaxValue
        },
        new { id = 1, activity = new object[] { new { name = "activity.name", subdivisionId  = 1 } }, birthdate = DateTime.MaxValue, credentialsEnd = DateTime.MaxValue, credentialsStart = DateTime.MaxValue, degrees = new object[] { "degree" }, educations = new object[] { new { year = 2000 } }, factionId = 2, factionName = "factionName", factionRegion = "factionRegion", factionRole = "factionRole", family = "lastName", isActual = true, lawcount = 3, name = "firstName", patronymic = "middleName", ranks = new object[] { "rank" }, regions = new object[] { "region" }, speachCount = 4, transcriptLink = "transcriptLink", voteLink = "voteLink" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of XML serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Xml()
    {
      this.TestXml(new DeputyInfo(), "deputy", new { id = 0, birthdate = default(DateTime).ISO8601(), credentialsStart = default(DateTime).ISO8601(), factionId = 0, isActual = false, lawcount = 0, speachCount = 0 });
      this.TestXml(
        new DeputyInfo
        {
          Id = 1,
          Active = true,
          ActivitiesOriginal = new List<DeputyActivity> { new DeputyActivity { Name = "activity.name", CommitteeId = 1 } },
          BirthDate = DateTime.MaxValue,
          DegreesOriginal = new List<string> { "degree" },
          EducationsOriginal = new List<Education> { new Education { Year = 2000 } },
          FactionId = 2,
          FactionName = "factionName",
          FactionRegion = "factionRegion",
          FactionRole = "factionRole",
          FirstName = "firstName",
          LastName = "lastName",
          LawsCount = 3,
          MiddleName = "middleName",
          RanksOriginal = new List<string> { "rank" },
          RegionsOriginal = new List<string> { "region" },
          SpeachesCount = 4,
          TranscriptLink = "transcriptLink",
          VoteLink = "voteLink",
          WorkStartDate = DateTime.MaxValue,
          WorkEndDate = DateTime.MaxValue
        },
        "deputy",
        new { id = 1, birthdate = DateTime.MaxValue.ISO8601(), credentialsEnd = DateTime.MaxValue.ISO8601(), credentialsStart = DateTime.MaxValue.ISO8601(), degree = "degree", factionId = 2, factionName = "factionName", factionRegion = "factionRegion", factionRole = "factionRole", family = "lastName", isActual = true, lawcount = 3, name = "firstName", patronymic = "middleName", rank = "rank", region = "region", speachCount = 4, transcriptLink = "transcriptLink", voteLink = "voteLink" }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="DeputyInfo()"/>
    [Fact]
    public void Constructors()
    {
      var deputy = new DeputyInfo();
      Assert.False(deputy.Active);
      Assert.False(deputy.ActivitiesOriginal.Any());
      Assert.False(deputy.Activities.Any());
      Assert.Equal(default(DateTime), deputy.BirthDate);
      Assert.False(deputy.DegreesOriginal.Any());
      Assert.False(deputy.Degrees.Any());
      Assert.False(deputy.EducationsOriginal.Any());
      Assert.False(deputy.Educations.Any());
      Assert.Equal(0, deputy.FactionId);
      Assert.Null(deputy.FactionName);
      Assert.Null(deputy.FactionRegion);
      Assert.Null(deputy.FactionRole);
      Assert.Null(deputy.FirstName);
      Assert.Equal(0, deputy.Id);
      Assert.Null(deputy.LastName);
      Assert.Equal(0, deputy.LawsCount);
      Assert.Null(deputy.MiddleName);
      Assert.False(deputy.RanksOriginal.Any());
      Assert.False(deputy.Ranks.Any());
      Assert.False(deputy.RegionsOriginal.Any());
      Assert.False(deputy.Regions.Any());
      Assert.Equal(0, deputy.SpeachesCount);
      Assert.Null(deputy.TranscriptLink);
      Assert.Null(deputy.VoteLink);
      Assert.Null(deputy.WorkEndDate);
      Assert.Equal(default(DateTime), deputy.WorkStartDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.Id"/> property.</para>
    /// </summary>
    [Fact]
    public void Id_Property()
    {
      Assert.Equal(1, new DeputyInfo { Id = 1 }.Id);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.Active"/> property.</para>
    /// </summary>
    [Fact]
    public void Active_Property()
    {
      Assert.True(new DeputyInfo { Active = true }.Active);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.Activities"/> property.</para>
    /// </summary>
    [Fact]
    public void Activities_Property()
    {
      var deputy = new DeputyInfo();
      Assert.False(deputy.Activities.Any());
      var activity = new DeputyActivity();
      deputy.ActivitiesOriginal.Add(activity);
      Assert.True(ReferenceEquals(activity, deputy.ActivitiesOriginal.Single()));
      Assert.True(ReferenceEquals(activity, deputy.Activities.Single()));
      deputy.ActivitiesOriginal.Remove(activity);
      Assert.False(deputy.ActivitiesOriginal.Any());
      Assert.False(deputy.Activities.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.BirthDate"/> property.</para>
    /// </summary>
    [Fact]
    public void BirthDate_Property()
    {
      Assert.Equal(DateTime.MinValue, new DeputyInfo { BirthDate = DateTime.MinValue }.BirthDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.Degrees"/> property.</para>
    /// </summary>
    [Fact]
    public void Degrees_Property()
    {
      var deputy = new DeputyInfo();
      Assert.False(deputy.Degrees.Any());
      deputy.DegreesOriginal.Add("degree");
      Assert.Equal("degree", deputy.DegreesOriginal.Single());
      Assert.Equal("degree", deputy.Degrees.Single());
      deputy.DegreesOriginal.Remove("degree");
      Assert.False(deputy.DegreesOriginal.Any());
      Assert.False(deputy.Degrees.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.Educations"/> property.</para>
    /// </summary>
    [Fact]
    public void Educations_Property()
    {
      var deputy = new DeputyInfo();
      Assert.False(deputy.Educations.Any());
      var education = new Education();
      deputy.EducationsOriginal.Add(education);
      Assert.True(ReferenceEquals(education, deputy.EducationsOriginal.Single()));
      Assert.True(ReferenceEquals(education, deputy.Educations.Single()));
      deputy.EducationsOriginal.Remove(education);
      Assert.False(deputy.EducationsOriginal.Any());
      Assert.False(deputy.Educations.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.FactionId"/> property.</para>
    /// </summary>
    [Fact]
    public void FactionId_Property()
    {
      Assert.Equal(1, new DeputyInfo { FactionId = 1 }.FactionId);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.FactionName"/> property.</para>
    /// </summary>
    [Fact]
    public void FactionName_Property()
    {
      Assert.Equal("factionName", new DeputyInfo { FactionName = "factionName" }.FactionName);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.FactionRegion"/> property.</para>
    /// </summary>
    [Fact]
    public void FactionRegion_Property()
    {
      Assert.Equal("factionRegion", new DeputyInfo { FactionRegion = "factionRegion" }.FactionRegion);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.FactionRole"/> property.</para>
    /// </summary>
    [Fact]
    public void FactionRole_Property()
    {
      Assert.Equal("factionRole", new DeputyInfo { FactionRole = "factionRole" }.FactionRole);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.FirstName"/> property.</para>
    /// </summary>
    [Fact]
    public void FirstName_Property()
    {
      Assert.Equal("firstName", new DeputyInfo { FirstName = "firstName" }.FirstName);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.LastName"/> property.</para>
    /// </summary>
    [Fact]
    public void LastName_Property()
    {
      Assert.Equal("lastName", new DeputyInfo { LastName = "lastName" }.LastName);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.LawsCount"/> property.</para>
    /// </summary>
    [Fact]
    public void LawsCount_Property()
    {
      Assert.Equal(1, new DeputyInfo { LawsCount = 1 }.LawsCount);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.MiddleName"/> property.</para>
    /// </summary>
    [Fact]
    public void MiddleName_Property()
    {
      Assert.Equal("middleName", new DeputyInfo { MiddleName = "middleName" }.MiddleName);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.Ranks"/> property.</para>
    /// </summary>
    [Fact]
    public void Ranks_Property()
    {
      var deputy = new DeputyInfo();
      Assert.False(deputy.Ranks.Any());
      deputy.RanksOriginal.Add("rank");
      Assert.Equal("rank", deputy.RanksOriginal.Single());
      Assert.Equal("rank", deputy.Ranks.Single());
      deputy.RanksOriginal.Remove("rank");
      Assert.False(deputy.RanksOriginal.Any());
      Assert.False(deputy.Ranks.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.Regions"/> property.</para>
    /// </summary>
    [Fact]
    public void Regions_Property()
    {
      var deputy = new DeputyInfo();
      Assert.False(deputy.Regions.Any());
      deputy.RegionsOriginal.Add("region");
      Assert.Equal("region", deputy.RegionsOriginal.Single());
      Assert.Equal("region", deputy.Regions.Single());
      deputy.RegionsOriginal.Remove("region");
      Assert.False(deputy.RegionsOriginal.Any());
      Assert.False(deputy.Regions.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.SpeachesCount"/> property.</para>
    /// </summary>
    [Fact]
    public void SpeachesCount_Property()
    {
      Assert.Equal(1, new DeputyInfo { SpeachesCount = 1 }.SpeachesCount);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.TranscriptLink"/> property.</para>
    /// </summary>
    [Fact]
    public void TranscriptLink_Property()
    {
      Assert.Equal("transcriptLink", new DeputyInfo { TranscriptLink = "transcriptLink" }.TranscriptLink);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.VoteLink"/> property.</para>
    /// </summary>
    [Fact]
    public void VoteLink_Property()
    {
      Assert.Equal("voteLink", new DeputyInfo { VoteLink = "voteLink" }.VoteLink);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.WorkStartDate"/> property.</para>
    /// </summary>
    [Fact]
    public void WorkStartDate_Property()
    {
      Assert.Equal(DateTime.MinValue, new DeputyInfo { WorkStartDate = DateTime.MinValue }.WorkStartDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.WorkEndDate"/> property.</para>
    /// </summary>
    [Fact]
    public void WorkEndDate_Property()
    {
      Assert.Equal(DateTime.MinValue, new DeputyInfo { WorkEndDate = DateTime.MinValue }.WorkEndDate);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.CompareTo(IDeputyInfo)"/> method.</para>
    /// </summary>
    [Fact]
    public void CompareTo_Method()
    {
      this.TestCompareTo("FirstName", "first", "second");
    }

    /// <summary>
    ///   <para>Performs testing of following methods :</para>
    ///   <list type="bullet">
    ///     <item><description><see cref="DeputyInfo.Equals(IDeputyInfo)"/></description></item>
    ///     <item><description><see cref="DeputyInfo.Equals(object)"/></description></item>
    ///   </list>
    /// </summary>
    [Fact]
    public void Equals_Methods()
    {
      this.TestEquality("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.GetHashCode()"/> method.</para>
    /// </summary>
    [Fact]
    public void GetHashCode_Method()
    {
      this.TestHashCode("Id", 1, 2);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="DeputyInfo.ToString()"/> method.</para>
    /// </summary>
    [Fact]
    public void ToString_Method()
    {
      Assert.Equal("LastName FirstName MiddleName", new DeputyInfo { FirstName = "FirstName", LastName = "LastName", MiddleName = "MiddleName" }.ToString());
    }
  }
}