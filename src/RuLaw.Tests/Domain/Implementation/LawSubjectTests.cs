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
      TestJson(new LawSubject(), new { departments = new object[] {}, deputies = new object[] {} });
      TestJson(
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
      Assert.Empty(subject.Departments);
      Assert.Empty(subject.Deputies);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawSubject.Departments"/> property.</para>
    /// </summary>
    [Fact]
    public void Departments_Property()
    {
      var subject = new LawSubject();
      Assert.Empty(subject.Departments);

      var department = new Authority();
      subject.DepartmentsOriginal.Add(department);
      Assert.True(ReferenceEquals(department, subject.DepartmentsOriginal.Single()));
      Assert.True(ReferenceEquals(department, subject.Departments.Single()));
      subject.DepartmentsOriginal.Remove(department);
      Assert.Empty(subject.DepartmentsOriginal);
      Assert.Empty(subject.Departments);
    }

    /// <summary>
    ///   <para>Performs testing of <see cref="LawSubject.Deputies"/> property.</para>
    /// </summary>
    [Fact]
    public void Deputies_Property()
    {
      var subject = new LawSubject();
      Assert.Empty(subject.Deputies);

      var deputy = new Deputy();
      subject.DeputiesOriginal.Add(deputy);
      Assert.True(ReferenceEquals(deputy, subject.DeputiesOriginal.Single()));
      Assert.True(ReferenceEquals(deputy, subject.Deputies.Single()));
      subject.DeputiesOriginal.Remove(deputy);
      Assert.Empty(subject.DeputiesOriginal);
      Assert.Empty(subject.Deputies);
    }
  }
}