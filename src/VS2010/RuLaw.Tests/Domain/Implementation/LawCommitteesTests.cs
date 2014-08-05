using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LawCommittees"/>.</para>
  /// </summary>
  public sealed class LawCommitteesTests : UnitTestsBase<LawCommittees>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new LawCommittees(), new { profile = new object[] {}, soexecutor = new object[] {} });
      this.TestJson(
        new LawCommittees
        {
          ResponsibleOriginal = new Committee { Id = 1 },
          ProfileOriginal = new List<Committee> { new Committee { Id = 2 } },
          SoExecutorOriginal = new List<Committee> { new Committee { Id = 3 } }
        },
        new { profile = new object [] { new { id = 2, isCurrent = false, startDate = DateTime.MinValue } }, responsible = new { id = 1, isCurrent = false, startDate = DateTime.MinValue }, soexecutor = new object [] { new { id = 3, isCurrent = false, startDate = DateTime.MinValue } } }
      );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="LawCommittees()"/>
    [Fact]
    public void Constructors()
    {
      var committtees = new LawCommittees();
      Assert.False(committtees.ProfileOriginal.Any());
      Assert.False(committtees.Profile.Any());
      Assert.Null(committtees.Responsible);
      Assert.False(committtees.SoExecutorOriginal.Any());
      Assert.False(committtees.SoExecutor.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawCommittees.Responsible"/> property.</para>
    /// </summary>
    [Fact]
    public void Responsible_Property()
    {
      var committee = new Committee();
      var committees = new LawCommittees { ResponsibleOriginal = committee };
      Assert.True(ReferenceEquals(committee, committees.ResponsibleOriginal));
      Assert.True(ReferenceEquals(committee, committees.Responsible));
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawCommittees.Profile"/> property.</para>
    /// </summary>
    [Fact]
    public void Profile_Property()
    {
      var committees = new LawCommittees();
      Assert.False(committees.Profile.Any());

      var committee = new Committee();
      committees.ProfileOriginal.Add(committee);
      Assert.True(ReferenceEquals(committee, committees.ProfileOriginal.Single()));
      Assert.True(ReferenceEquals(committee, committees.Profile.Single()));
      committees.ProfileOriginal.Remove(committee);
      Assert.False(committees.ProfileOriginal.Any());
      Assert.False(committees.Profile.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawCommittees.SoExecutor"/> property.</para>
    /// </summary>
    [Fact]
    public void SoExecutor_Property()
    {
      var committees = new LawCommittees();
      Assert.False(committees.SoExecutor.Any());

      var committee = new Committee();
      committees.SoExecutorOriginal.Add(committee);
      Assert.True(ReferenceEquals(committee, committees.SoExecutorOriginal.Single()));
      Assert.True(ReferenceEquals(committee, committees.SoExecutor.Single()));
      committees.SoExecutorOriginal.Remove(committee);
      Assert.False(committees.SoExecutorOriginal.Any());
      Assert.False(committees.SoExecutor.Any());
    }
  }
}