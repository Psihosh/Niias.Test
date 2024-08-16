
namespace Niias.Test.Model.Data;
public class Section
{
    public Section(int id, string name) {
        Id = id;
        Name = name;
    }
    public override string ToString() => $"Section: {Name}";
    public int Id { get; private set; }
    public string Name { get; private set; } = "";
    public Station? Station { get; private set; }
    public bool IsOpened { get; set; }
    public ICollection<Segment> Segments { get; } = new List<Segment>();
    public Section SetStation(Station station) {
        if (station == null) {
            return this;
        }
        Station = station;
        return this;
    }
    public IEnumerable<Node> AllNodes => Segments.SelectMany(x => x.Nodes).Distinct();
    public IEnumerable<Node> BorderNodes => AllNodes.Where(x => x.AllSegments.Any(x => x.Parent != this));
}
