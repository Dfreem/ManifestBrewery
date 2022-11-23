using Microsoft.EntityFrameworkCore;

namespace ManifestTests;
[TestFixture]
public class AccountTest
{
    ManifestBreweryContext db;
    Account? a;
    List<Account>? accounts;

    [SetUp]
    public void Setup()
    {
        db = new();

    }

    [Test]
    public void GetAllTest()
    {
        accounts = db.Accounts.OrderBy(a => a.AccountId).ToList();
        Assert.That(accounts, Is.Not.Empty);
        Assert.That(accounts?.Count, Is.AtLeast(1));
        PrintAll(accounts);

        a = db.Accounts.Find(5);
        Assert.That(a, Is.InstanceOf(typeof(Account)));
        Console.WriteLine(a);
    }
    [Test]
    public void GetByPrimaryKeyTest()
    {
        a = db.Accounts.Where(ac => ac.AccountId.Equals(2)).SingleOrDefault();
        Assert.That(a, Is.InstanceOf(typeof(Account)));
        Console.WriteLine(a);
    }
    [Test]
    public void GetUsingWhereTest()
    {
        // this is tested in get by primary id
    }
    [Test]
    public void GetWithJoinTest()
    {
        var joined = db.Accounts.Join(
            db.PubEmployees,
            a => a.SalesEmployeeId,
            e => e.EmployeeId,
            (a, e) => new { a.ContactName, a.AccountId, e.Name, e.PubId }).OrderBy(k => k.AccountId);
        Assert.That(joined, Is.Not.Null);
        //foreach (var thing in joined)
        //{ Console.WriteLine(thing.ContactName); }
    }
    [Test]
    public void Create()
    {
        a = new();
        a.Name = "test";
        a.ContactName = "some guy";
        db.Accounts.Add(a);
        db.SaveChanges();
    }

    [Test] //this works but breaks stuff.
    public void DeleteTest()
    {
        //a = db.Accounts.Find(1);
        //db.Accounts.Remove(a!);
        //db.SaveChanges();
        //Assert.That(db.Accounts.Find(1), Is.Null);

    }

    [Test]
    public void UpdateCustomerTest()
    {
        a = db.Accounts.Find(1);
        Assert.That(a, Is.Not.Null);
        a.ContactName = "Changed";
        db.Accounts.Update(a);
        db.SaveChanges();
        a = db.Accounts.Find(1);
        Assert.That(a!.ContactName, Is.EqualTo("Changed"));
        Console.WriteLine(a.ContactName);
    }

    static void PrintAll(List<Account> accnts)
    {
        for (int i = 0; i < accnts.Count; i++)
        {
            Console.WriteLine(accnts[i]);
        }
    }
}

