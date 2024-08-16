using Niias.Test.Model;
using Niias.Test.Model.Data;

namespace TestProject;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }
    [Test]
    public void DataTest() {
        var id = 1;
        var station = new Station(id++, "st1");
        var section = new PathSection(id++, "s1");
        var section2 = new PathSection(id++, "s2");
        var section3 = new PathSection(id++, "s3");
        var segment = new Segment(id++, "sg1", section);
        var segment2 = new Segment(id++, "sg2", section3);
        var segment3 = new Segment(id++, "sg3", section3);
        var switchSection = new SwitchSection(id++, "1");
        var segment4 = new Segment(id++, "sg4", switchSection);
        var segment5 = new Segment(id++, "sg5", switchSection);

        Assert.That(section.Segments.Count, Is.EqualTo(1));
        Assert.That(switchSection.Segments.Count, Is.EqualTo(2));

        station.AddPark(new Park(id++, "A")
            .AddSection(section)
            .AddSection(section2));
        var park = station.Parks.FirstOrDefault();

        Assert.That(station.Parks.Count, Is.EqualTo(1));   
        Assert.NotNull(park);
        Assert.That(park.Paths.Count, Is.EqualTo(1));
        Assert.That(park.Station, Is.EqualTo(station));
        Assert.That(section.Station, Is.EqualTo(station));

        station.AddSection(switchSection)
            .AddSection(section3);

        Assert.That(station.Sections.Count, Is.EqualTo(3));
        Assert.That(station.SwitchSections.Count, Is.EqualTo(1));
        Assert.That(station.PathSections.Count, Is.EqualTo(2));
       
        var node = new Node(id++, "1").Connect(new[] { segment4 }, new[] { segment, segment2 });
        var node2 = new Node(id++, "2").Connect(segment5, segment4);

        Assert.That(segment.Nodes.Count, Is.EqualTo(1));
        Assert.That(segment.Parent, Is.EqualTo(section));
        Assert.That(node.LeftSegments.Count, Is.EqualTo(1));
        Assert.That(node.RightSegments.Count, Is.EqualTo(2));
        Assert.That(node.AllSegments.Count, Is.EqualTo(3));

        var section4 = new Section(id++, "s4");
        var segment6 = new Segment(id++, "sg6", section4);
        var node3 = new Node(id++, "3").Connect(segment2, segment3);
        var node4 = new Node(id++, "4").Connect(segment3, segment6);

        Assert.That(section3.AllNodes.Count, Is.EqualTo(3));
        Assert.That(section3.BorderNodes.Count, Is.EqualTo(2));
    }

    [Test]
    public void TestRoutes() {
        var station = StationCreator.CreateTeststation();     
        var allRoutes = station.GetAllRoutes("leftP1", "s18-24");

        Assert.That(allRoutes.Count, Is.EqualTo(5));

        var start = station.Sections.FirstOrDefault(x => x.Name == "p4");
        var end = station.Sections.FirstOrDefault(x => x.Name == "leftP2");
        var allRoutes2 = station.GetAllRoutes(start, end);

        Assert.That(allRoutes2.Count, Is.EqualTo(3));

        var shortRoute = station.GetShortRoute("p4", "leftP2");

        Assert.That(shortRoute.Count, Is.EqualTo(6));

        var allRoutes3 = station.GetAllRoutes("leftP1", "rightP2");

        Assert.That(allRoutes3.Count, Is.EqualTo(24));

        var start2 = station.Sections.FirstOrDefault(x => x.Name == "p4");
        var end2 = station.Sections.FirstOrDefault(x => x.Name == "p5");
        var shortRoute2 = station.GetShortRoute(start2, end2);

        Assert.That(shortRoute2.Count, Is.EqualTo(0));

        var testShort = station.GetShortRoute("s1-7","p3");

        Assert.That(testShort.Count, Is.EqualTo(3));

    }

}