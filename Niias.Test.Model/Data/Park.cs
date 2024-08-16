namespace Niias.Test.Model.Data;
public class Park
{
    public Park(int id, string name) {
        Id = id;
        Name = name;
    }
    public override string ToString() => $"Park: {Name}";   
    public int Id { get; private set; }
    public string Name { get; private set; } = "";
    public Station? Station { get; private set; }
    public ICollection<PathSection> Paths { get; } = new List<PathSection>();
    public Park AddSection(PathSection section) {
        if (section == null || !section.Segments.Any()) {
            return this;
        }
        Paths.Add(section);
        return this;
    }
    public Park SetStation(Station station) {
        if (station == null) {
            return this;
        }
        Station = station;
        return this;
    }

}
