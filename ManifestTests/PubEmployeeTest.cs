
using ManifestBreweryClasses.Models;
using Microsoft.EntityFrameworkCore;

namespace ManifestTests;

[TestFixture]
public class PubEmployeeTest
{
    ManifestBreweryContext db;
    PubEmployee? pe;
    List<PubEmployee>? PubEmployees;

    [SetUp]
    public void Setup()
    {
        db = new();

    }

    //[TearDown]
    //public void Rollback()
    //{
    //    foreach (PubEmployee emp in db.PubEmployees.OrderBy(e => e.EmployeeId))
    //    {
    //        emp.Name = "test";
    //        db.PubEmployees.Update(emp);
    //    }

    //    db.SaveChanges();
    //    //db.Database.ExecuteSqlRaw("call usp_testingResetProductData()");
    //}

    [Test]
    public void GetAllTest()
    {
        PubEmployees = db.PubEmployees.OrderBy(employee => employee.EmployeeId).ToList();
        Assert.That(PubEmployees, Is.Not.Empty);
        Assert.That(PubEmployees?.Count, Is.InRange(1, 50));
        PrintAll(PubEmployees);
    }
    [Test]
    public void GetByPrimaryKeyTest()
    {
        pe = db.PubEmployees.Find(1);
        Assert.That(pe, Is.Not.Null);
        Console.WriteLine(pe);
    }
    [Test]
    public void GetUsingWhereTest()
    {
        PubEmployees = db.PubEmployees.Include(employee => employee.Pub).Include( employee => employee.Pub).ToList();
        PrintAll(PubEmployees);
    }
    [Test]
    public void GetWithJoinTest()
    {
        var joined = db.PubEmployees.Join(
            db.PubEmployees,
            pe => pe.EmployeeId,
            e => e.EmployeeId,
            (a, e) => new { pe!.Name, pe.EmployeeId, e.State, e.PubId }).OrderBy(k => k.EmployeeId);
        Assert.That(joined, Is.Not.Null);
        //foreach (var thing in joined)
        //{ Console.WriteLine(thing.ContactName); }
    }
    [Test]
    public void Create()
    {
        pe = new();
        pe.Name = "test";
        pe.State = "CA";
        pe.Phone = "1234567";
        db.PubEmployees.Add(pe);
        db.SaveChanges();
    }

    [Test] //this works but breaks stuff.
    public void DeleteTest()
    {
        //pe = db.PubEmployees.Find(1);
        //db.PubEmployees.Remove(pe!);
        //db.SaveChanges();
        //Assert.That(db.PubEmployees.Find(1), Is.Null);

    }

    [Test]
    public void UpdateTest()
    {
        pe = db.PubEmployees.Find(1);
        Assert.That(pe, Is.Not.Null);
        Console.WriteLine(pe.Name);

        // set string testName to original name
        string? testName = pe.Name;
        pe.Name = "test";
        db.PubEmployees.Update(pe);
        db.SaveChanges();
        pe = db.PubEmployees.Find(1);
        Assert.That(pe!.Name, Is.Not.EqualTo("Joe"));

        // should this pass? it passes only if this is a reference and not a value.
        Assert.That(pe!.Name, Is.EqualTo(testName));


    }

    static void PrintAll(List<PubEmployee> emps)
    {
        for (int i = 0; i < emps.Count; i++)
        {
            Console.WriteLine(emps[i].Name + " " + emps[i].EmployeeId);
        }
    }
}
