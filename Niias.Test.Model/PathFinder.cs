using Niias.Test.Model.Data;

namespace Niias.Test.Model;
public static class PathFinder
{
    public static ICollection<Section?> GetShortRoute(this Station station, string startSectionName, string endSectionName) {
        var sections = station.Sections;
        var startSection = sections.FirstOrDefault(x => x.Name == startSectionName);
        var endSection = sections.FirstOrDefault(x => x.Name == endSectionName);
        return GetShortRoute(station, startSection, endSection);
    }
    public static ICollection<Section?> GetShortRoute(this Station station, Section? startSection, Section? endSection) {
        var segments = new List<Section?>();
        if (startSection == null || endSection == null || !station.Sections.Contains(startSection) || !station.Sections.Contains(endSection)) {
            return segments;
        }
        var allRouteWithSections = GetAllRoutes(station, startSection, endSection);
        var shortRoute = allRouteWithSections.OrderBy(x => x.Count()).FirstOrDefault()?.ToList();
        if (shortRoute != null) {
            return shortRoute;
        }
        return segments;
    }
    public static IEnumerable<IEnumerable<Section?>> GetAllRoutes(this Station station, string startSectionName, string endSectionName) {
        var sections = station.Sections;
        var startSection = sections.FirstOrDefault(x => x.Name == startSectionName);
        var endSection = sections.FirstOrDefault(x => x.Name == endSectionName);
        return GetAllRoutes(station, startSection, endSection);
    }
    public static IEnumerable<IEnumerable<Section?>> GetAllRoutes(this Station station, Section? startSection, Section? endSection) {
        var segments = new List<List<Section?>>();
        if (startSection == null || endSection == null || !station.Sections.Contains(startSection) || !station.Sections.Contains(endSection)) {
            return segments;
        }
        var allRoutes = new List<List<Segment>>();
        foreach (var segment in startSection.Segments) {
            allRoutes.Add(new List<Segment>());
            Find(segment, endSection, ref allRoutes);
        }
        return allRoutes.Select(x => x.Select(x => x.Parent).Where(x => x != null).Distinct());
    }
    private static bool Find(Segment? start, Section? end, ref List<List<Segment>> allRoutes ) {
        if (start == null || end == null || allRoutes == null) {
            return false;
        }
        if (!allRoutes.Any()) {
            allRoutes.Add(new List<Segment>());
        }
        if (start.Parent == end) {
            return true;
        }
        allRoutes.Last().Add(start);
        foreach (var node in start.Nodes) {
            if (allRoutes.Last().Any(x => x != start && x.Nodes.Contains(node))) {
                continue;
            }
            ICollection<Segment> segmentCollection;
            if (node.LeftSegments.Contains(start)) {
                segmentCollection = node.RightSegments;
            }
            else if (node.RightSegments.Contains(start)) { 
                segmentCollection = node.LeftSegments;
            }
            else {
                segmentCollection = new List<Segment>();
            }
            foreach (var segment in segmentCollection) {
                
                if (Find(segment, end, ref allRoutes)) {
                    var newList = new List<Segment>();
                    newList.AddRange(allRoutes.Last());
                    allRoutes.Last().Add(segment);
                    allRoutes.Add(newList);
                }
            }
        }
        allRoutes.Last().Remove(start);
        if (!allRoutes.Last().Any()) {
            var removePath = allRoutes.Last();
            allRoutes.Remove(removePath);
        }
        return false;
    }
}
