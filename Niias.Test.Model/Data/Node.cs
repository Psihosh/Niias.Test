namespace Niias.Test.Model.Data;
public class Node
{
    public Node(int id, string name = "") {
        Id = id;
        Name = name;
    }
    public override string ToString() => $"Node: {Name}";
    public int Id { get; private set; }
    public string Name { get; private set; } = "";
    public ICollection<Segment> LeftSegments { get; } = new List<Segment>();
    public ICollection<Segment> RightSegments { get; } = new List<Segment>();
    public IEnumerable<Segment> AllSegments => LeftSegments.Concat(RightSegments);
    public Node Connect(Segment leftSegment, Segment rightSegment) {
        return Connect(new[] { leftSegment }, new[] { rightSegment });
    }
    public Node Connect(IEnumerable<Segment> leftSegments, IEnumerable<Segment> rightSegments) {
        foreach (var leftSegment in leftSegments) {
            if (leftSegment != null && !LeftSegments.Contains(leftSegment)) {
                LeftSegments.Add(leftSegment);
                leftSegment.AddNode(this);
            }
        }
        foreach (var rightSegment in rightSegments) {
            if (rightSegment != null && !RightSegments.Contains(rightSegment)) {
                RightSegments.Add(rightSegment);
                rightSegment.AddNode(this);
            }
        }
        return this;
    }

}
