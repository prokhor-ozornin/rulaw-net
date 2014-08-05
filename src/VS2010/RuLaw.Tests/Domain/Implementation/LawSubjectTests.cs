using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RuLaw
{
  /// <summary>
  ///   <para>Tests set for class <see cref="LawSubject"/>.</para>
  /// </summary>
  public sealed class LawSubjectTests : UnitTestsBase<LawSubject>
  {
    /// <summary>
    ///   <para>Performs testing of JSON serialization/deserialization process.</para>
    /// </summary>
    [Fact]
    public void Json()
    {
      this.TestJson(new LawSubject(), new { departments = new object[] {}, deputies = new object[] {} });
      this.TestJson(
        new LawSubject
        {
          DepartmentsOriginal = new List<Authority> { new Authority { Id = 1 } },
          DeputiesOriginal = new List<Deputy> { new Deputy { Id = 2 } }
        },
        new { departments = new object[] { new { id = 1, isCurrent = false, startDate = DateTime.MinValue } }, deputies = new object[] { new { id = 2, isCurrent = false } } }
     );
    }

    /// <summary>
    ///   <para>Performs testing of class constructor(s).</para>
    /// </summary>
    /// <seealso cref="LawSubject()"/>
    [Fact]
    public void Constructors()
    {
      var subject = new LawSubject();
      Assert.False(subject.Departments.Any());
      Assert.False(subject.Deputies.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawSubject.Departments"/> property.</para>
    /// </summary>
    [Fact]
    public void Departments_Property()
    {
      var subject = new LawSubject();
      Assert.False(subject.Departments.Any());

      var department = new Authority();
      subject.DepartmentsOriginal.Add(department);
      Assert.True(ReferenceEquals(department, subject.DepartmentsOriginal.Single()));
      Assert.True(ReferenceEquals(department, subject.Departments.Single()));
      subject.DepartmentsOriginal.Remove(department);
      Assert.False(subject.DepartmentsOriginal.Any());
      Assert.False(subject.Departments.Any());
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawSubject.Deputies"/> property.</para>
    /// </summary>
    [Fact]
    public void Deputies_Property()
    {
      var subject = new LawSubject();
      Assert.False(subject.Deputies.Any());

      var deputy = new Deputy();
      subject.DeputiesOriginal.Add(deputy);
      Assert.True(ReferenceEquals(deputy, subject.DeputiesOriginal.Single()));
      Assert.True(ReferenceEquals(deputy, subject.Deputies.Single()));
      subject.DeputiesOriginal.Remove(deputy);
      Assert.False(subject.DeputiesOriginal.Any());
      Assert.False(subject.Deputies.Any());
    }
  }
}