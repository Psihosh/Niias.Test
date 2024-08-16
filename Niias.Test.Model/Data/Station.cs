namespace Niias.Test.Model.Data;
public class Station
{
    public Station(int id, string name) {
        Id = id;
        Name = name;
    }
    public int Id { get; private set; }
    public string Name { get; private set; }
    public ICollection<Park> Parks { get; } = new List<Park>();
    public ICollection<Section> Sections { get; } = new List<Section>();
    public IEnumerable<SwitchSection?> SwitchSections => Sections.Where(x => x is SwitchSection).Select(x => x as SwitchSection);
    public IEnumerable<PathSection?> PathSections => Sections.Where(x => x is PathSection).Select(x => x as PathSection);
    public Station AddPark(Park park) {
        if (park == null) {
            return this;
        }
        park.SetStation(this);
        Parks.Add(park);
        foreach (var section in park.Paths) {
            AddSection(section);
        }
        return this;
    }
    public Station AddSection(Section section) {
        if (section == null || !section.Segments.Any()) {
            return this;
        }
        section.SetStation(this);
        Sections.Add(section);
        return this;
    }
}
