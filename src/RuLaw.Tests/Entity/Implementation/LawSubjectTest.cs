using Catharsis.Commons;
using Catharsis.Extensions;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Json;
using Xunit;

namespace RuLaw.Tests;

/// <summary>
///   <para>Tests set for class <see cref="LawSubject"/>.</para>
/// </summary>
public sealed class LawSubjectTest : ClassTest<LawSubject>
{
  /// <summary>
  ///   <para>Performs testing of class constructor(s).</para>
  /// </summary>
  /// <seealso cref="LawSubject()"/>
  [Fact]
  public void Constructors()
  {
    typeof(LawSubject).Should().BeDerivedFrom<object>().And.Implement<ILawSubject>();

    var subject = new LawSubject();
    subject.Departments.Should().BeEmpty();
    subject.Deputies.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawSubject.Departments"/> property.</para>
  /// </summary>
  [Fact]
  public void Departments_Property()
  {
    var subject = new LawSubject();
    subject.Departments.Should().BeEmpty();

    var department = new Authority();

    var departments = subject.Departments.To<List<Authority>>();
    departments.Add(department);
    subject.Departments.Should().ContainSingle().Which.Should().BeSameAs(department);
    departments.Remove(department);
    subject.Departments.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of <see cref="LawSubject.Deputies"/> property.</para>
  /// </summary>
  [Fact]
  public void Deputies_Property()
  {
    var subject = new LawSubject();
    subject.Deputies.Should().BeEmpty();

    var deputy = new Deputy();

    var deputies = subject.Deputies.To<List<Deputy>>();

    deputies.Add(deputy);
    subject.Deputies.Should().ContainSingle().Which.Should().BeSameAs(deputy);
    deputies.Remove(deputy);
    subject.Deputies.Should().BeEmpty();
  }

  /// <summary>
  ///   <para>Performs testing of serialization/deserialization process.</para>
  /// </summary>
  [Fact]
  public void Serialization()
  {
    using (new AssertionScope())
    {
      Validate(new LawSubject
      {
        Departments = [new Authority { Id = 1 }],
        Deputies = [new Deputy { Id = 2 }]
      });
    }

    return;

    static void Validate(object instance) => instance.Should().BeDataContractSerializable().And.BeXmlSerializable().And.BeJsonSerializable();
  }
}