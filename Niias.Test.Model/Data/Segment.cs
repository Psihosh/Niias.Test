namespace Niias.Test.Model.Data;
public class Segment {
    public Segment(int id, string name, Section? parent = null) {
        Id = id;
        Name = name;
        Parent = parent;
        parent?.Segments.Add(this);
    }
    public override string ToString() => $"Segment: {Name} ({Parent?.Name})";
    public int Id { get; private set; }
    public string Name { get; private set; } = "";
    public Section? Parent { get; private set; }
    public ICollection<Node> Nodes {get; } = new List<Node>();
    public void AddNode(Node node) {
        if (node == null || Nodes.Contains(node)) {
            return;
        }
        Nodes.Add(node);
    }

}
