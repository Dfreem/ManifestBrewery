
namespace ManifestTests;

[TestFixture]
public class PubTest
{
    ManifestBreweryContext db;
    Pub? pub;
    List<Pub>? Pubs;

    [SetUp]
    public void Setup()
    {
        db = new();

    }

    [Test]
    public void GetAllTest()
    {
        Pubs = db.Pubs.OrderBy(employee => employee.PubId).ToList();
        Assert.That(Pubs, Is.Not.Empty);
        Assert.That(Pubs?.Count, Is.InRange(1, 50));
        PrintAll(Pubs);
    }
    [Test]
    public void GetByPrimaryKeyTest()
    {
        pub = db.Pubs.Find(8);
        Assert.That(pub, Is.Not.Null);
        Console.WriteLine(pub);
    }
    [Test]
    public void GetUsingWhereTest()
    {
        Pubs = db.Pubs.OrderBy(p => p.PubId).ToList();
        PrintAll(Pubs);
    }
    [Test]
    public void GetWithJoinTest()
    {
        var joined = db.Pubs.Join(
            db.PubEmployees,
            pub => pub.PubId,
            e => e.PubId,
            (a, e) => new { pub!.City, pub.PubId, e.Name, e.EmployeeId }).OrderBy(k => k.PubId);
        Assert.That(joined, Is.Not.Null);
    }
    [Test]
    public void Create()
    {
        pub = new();
        pub.City = "test";
        pub.State = "CA";
        pub.Phone = "1234567";
        db.Pubs.Add(pub);
        int rowsChanged = db.SaveChanges();
        Console.WriteLine("ID: " + pub.PubId);
        Console.WriteLine("rows changed: " + rowsChanged);
        Assert.That(rowsChanged, Is.Not.Zero);
    }

    [Test] //this works but breaks stuff.
    public void DeleteTest()
    {
        //pub = db.Pubs.Find(1);
        //db.Pubs.Remove(pub!);
        //db.SaveChanges();
        //Assert.That(db.Pubs.Find(1), Is.Null);

    }

    [Test]
    public void UpdateTest()
    {
        pub = db.Pubs.Find(7);
        Assert.That(pub, Is.Not.Null);
        Console.WriteLine(pub.ManagerName);

        // set string testName to original name
        string? testName = pub.City;
        pub.City = "Not Here";
        db.Pubs.Update(pub);
        int rows = db.SaveChanges();
        pub = db.Pubs.Find(7);
        Assert.That(rows, Is.Not.Zero);
        Assert.That(pub!.City, Is.Not.EqualTo("test"));

        //// should this pass? it passes only if this is a reference and not a value.
        Assert.That(pub!.City, Is.EqualTo(testName));


    }

    static void PrintAll(List<Pub> publist)
    {
        for (int i = 0; i < publist.Count; i++)
        {
            Console.WriteLine(publist[i].City + " " + publist[i].ManagerName);
        }
    }
}
