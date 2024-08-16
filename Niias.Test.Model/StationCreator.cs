using Niias.Test.Model.Data;

namespace Niias.Test.Model;
public static class StationCreator
{
    //TestStation
    //               A
    //           ____1___                B
    //lp1_1___7_/____2___\26_22_20_______4___________2_rp1
    //lp2__\__/_9____3_______/__\________5__________/__rp2
    //     3  5            24  18 \16    C      /6  4
    //                             \_____6_____/
    //                            14\____7____/8
    //                             12\___8___/10
    //
    public static Station CreateTeststation() {
        var id = 1;
        var sectionId = 1;
        var segmentId = 1;
        var parkId = 1;
        var station = new Station(1, "TestStation");

        var lp1 = new PathSection(sectionId++, "leftP1");
        var slp1 = new Segment(segmentId++, "sLp1", lp1);

        var sws17 = new SwitchSection(sectionId++, "s1-7");
        var s17lp1 = new Segment(segmentId++, "s1-7-lp1", sws17);
        var s1717 = new Segment(segmentId++, "s1-7-17", sws17);
        var s17s3 = new Segment(segmentId++, "s1-7-3", sws17);
        var s17s5 = new Segment(segmentId++, "s1-7-5", sws17);
        var s17s9 = new Segment(segmentId++, "s1-7-9", sws17);

        var nlp1s1 = new Node(id++, "lp1-1")
            .Connect(slp1, s17lp1);
        var ns1 = new Node(id++, "1")
            .Connect(new[] { s17lp1 }, new[] { s1717, s17s3 });
        var ns7 = new Node(id++, "7")
            .Connect(new[] { s1717, s17s5 }, new[] { s17s9 });

        var lp2 = new PathSection(sectionId++, "leftP2");
        var slp2 = new Segment(segmentId++, "sLp2", lp2);

        var sws35 = new SwitchSection(sectionId++, "s3-5");
        var s35lp2 = new Segment(segmentId++, "s3-5-lp2", sws35);
        var s35s1 = new Segment(segmentId++, "s3-5-1", sws35);
        var s3535 = new Segment(segmentId++, "s3-5-35", sws35);
        var s35p3 = new Segment(segmentId++, "s3-5-p3", sws35);
        var s35s7 = new Segment(segmentId++, "s3-5-7", sws35);

        var nlp2s3 = new Node(id++, "lp2-3")
            .Connect(slp2, s35lp2);
        var ns3 = new Node(id++, "3")
            .Connect(new[] { s35s1, s35lp2 }, new[] { s3535 });
        var ns5 = new Node(id++, "5")
            .Connect(new[] { s3535 }, new[] { s35s7, s35p3 });
        var ns1s3 = new Node(id++, "1-3")
            .Connect(s17s3, s35s1);
        var ns5s7 = new Node(id++, "5-7")
            .Connect(s35s7, s17s5);

        var p1 = new PathSection(sectionId++, "p1");
        var sp11 = new Segment(segmentId++, "sP1-1", p1);
        var sp12 = new Segment(segmentId++, "sP1-2", p1);
        var sp13 = new Segment(segmentId++, "sP1-3", p1);

        var p2 = new PathSection(sectionId++, "p2");
        var sp2 = new Segment(segmentId++, "sP2", p2);

        var p3 = new PathSection(sectionId++, "p3");
        var sp3 = new Segment(segmentId++, "sP3", p3);

        var sws9 = new SwitchSection(sectionId++, "s9");
        var s9s7 = new Segment(segmentId++, "s9-7", sws9);
        var s9p1 = new Segment(segmentId++, "s9-p1", sws9);
        var s9p2 = new Segment(segmentId++, "s9-p2", sws9);

        var ns9s7 = new Node(id++, "7-9")
            .Connect(s17s9, s9s7);
        var ns9p11 = new Node(id++, "9-p1-1")
            .Connect(s9p1, sp11);
        var ns9 = new Node(id++, "9")
            .Connect(new[] { s9s7 }, new[] { s9p1, s9p2 });
        var ns9p12 = new Node(id++, "9-p2")
            .Connect(s9p2, sp2);
        var np1112 = new Node(id++, "p1-1-p1-2")
            .Connect(sp11, sp12);
        var np1213 = new Node(id++, "p1-2-p1-3")
            .Connect(sp12, sp13);
        var ns5p3 = new Node(id++, "5-p3")
            .Connect(s35p3, sp3);

        var sws26 = new SwitchSection(sectionId++, "s26");
        var s26p1 = new Segment(segmentId++, "s26-P1", sws26);
        var s26p2 = new Segment(segmentId++, "s26-P2", sws26);
        var s26s22 = new Segment(segmentId++, "s26-22", sws26);

        var np13s26 = new Node(id++, "p1-3-26")
            .Connect(sp13, s26p1);
        var np2s26 = new Node(id++, "p2-26")
            .Connect(sp2, s26p2);
        var ns26 = new Node(id++, "26")
            .Connect(new[] { s26p1, s26p2 }, new[] { s26s22 });

        var sws2022 = new SwitchSection(sectionId++, "s20-22");
        var s2022s26 = new Segment(segmentId++, "s20-22-26", sws2022);
        var s2022s24 = new Segment(segmentId++, "s20-22-24", sws2022);
        var s20222022 = new Segment(segmentId++, "s20-22-2022", sws2022);
        var s2022p4 = new Segment(segmentId++, "s20-22-20", sws2022);
        var s2022s18 = new Segment(segmentId++, "s20-22-18", sws2022);

        var ns26s22 = new Node(id++, "26-22")
            .Connect(s26s22, s2022s26);
        var ns22 = new Node(id++, "22")
            .Connect(new[] { s2022s26, s2022s24 }, new[] { s20222022 });
        var ns20 = new Node(id++, "20")
            .Connect(new[] { s20222022 }, new[] { s2022p4, s2022s18 });

        var sws1824 = new SwitchSection(sectionId++, "s18-24");
        var s1824p3 = new Segment(segmentId++, "s18-24-p3", sws1824);
        var s18241824 = new Segment(segmentId++, "s18-24-1824", sws1824);
        var s1824s22 = new Segment(segmentId++, "s18-24-22", sws1824);
        var s1824s20 = new Segment(segmentId++, "s18-24-20", sws1824);
        var s1824s16 = new Segment(segmentId++, "s18-24-16", sws1824);

        var np3s24 = new Node(id++, "p3-24")
            .Connect(sp3, s1824p3);
        var ns24 = new Node(id++, "24")
            .Connect(new[] { s1824p3 }, new[] { s1824s22, s18241824 });
        var ns18 = new Node(id++, "18")
            .Connect(new[] { s1824s20, s18241824 }, new[] { s1824s16 });
        var ns22s24 = new Node(id++, "24-22")
           .Connect(s1824s22, s2022s24);
        var ns20s18 = new Node(id++, "20-18")
            .Connect(s2022s18, s1824s20);

        var p4 = new PathSection(sectionId++, "p4");
        var sp4 = new Segment(segmentId++, "sP4", p4);

        var ns20p4 = new Node(id++, "20-p4")
            .Connect(s2022p4, sp4);

        var p5 = new PathSection(sectionId++, "p5");
        var sp5 = new Segment(segmentId++, "sP5", p5);

        var p6 = new PathSection(sectionId++, "p6");
        var sp6 = new Segment(segmentId++, "sP6", p6);

        var p7 = new PathSection(sectionId++, "p7");
        var sp7 = new Segment(segmentId++, "sP7", p7);

        var p8 = new PathSection(sectionId++, "p8");
        var sp8 = new Segment(segmentId++, "sP8", p8);

        var sws1216 = new SwitchSection(sectionId++, "s12-16");
        var s1216s18 = new Segment(segmentId++, "s12-16-18", sws1216);
        var s1216s16p5 = new Segment(segmentId++, "s12-16-16p5", sws1216);
        var s1216s1416 = new Segment(segmentId++, "s12-16-1416", sws1216);
        var s1216s14p6 = new Segment(segmentId++, "s12-16-14p6", sws1216);
        var s1216s1214 = new Segment(segmentId++, "s12-16-1214", sws1216);
        var s1216s12p7 = new Segment(segmentId++, "s12-16-12p7", sws1216);
        var s1216s12p81 = new Segment(segmentId++, "s12-16-12p8-1", sws1216);
        var s1216s12p82 = new Segment(segmentId++, "s12-16-12p8-2", sws1216);

        var ns18s16 = new Node(id++, "18-16")
            .Connect(s1824s16, s1216s18);
        var ns16 = new Node(id++, "16")
            .Connect(new[] { s1216s18 }, new[] { s1216s16p5, s1216s1416 });
        var ns16p5 = new Node(id++, "16-p5")
            .Connect(s1216s16p5, sp5);
        var ns14 = new Node(id++, "14")
            .Connect(new[] { s1216s1416 }, new[] { s1216s14p6, s1216s1214 });
        var ns14p6 = new Node(id++, "14-p6")
            .Connect(s1216s14p6, sp6);
        var ns12 = new Node(id++, "12")
            .Connect(new[] { s1216s1214 }, new[] { s1216s12p7, s1216s12p81 });
        var ns12p7 = new Node(id++, "12-p7")
            .Connect(s1216s12p7, sp7);
        var ns12s12p8 = new Node(id++, "12-12p8")
            .Connect(s1216s12p81, s1216s12p82);
        var ns12p8p8 = new Node(id++, "12p8-p8")
            .Connect(s1216s12p82, sp8);

        var sws610 = new SwitchSection(sectionId++, "s6-10");
        var s610s4 = new Segment(segmentId++, "s6-10-4", sws610);
        var s610s6p5 = new Segment(segmentId++, "s6-10-6p5", sws610);
        var s610s68 = new Segment(segmentId++, "s6-10-68", sws610);
        var s610s8p6 = new Segment(segmentId++, "s6-10-8p6", sws610);
        var s610s810 = new Segment(segmentId++, "s6-10-810", sws610);
        var s610s10p7 = new Segment(segmentId++, "s6-10-102p7", sws610);
        var s610s10p81 = new Segment(segmentId++, "s6-10-10p8-1", sws610);
        var s610s10p82 = new Segment(segmentId++, "s6-10-10p8-2", sws610);

        var np8s10p8 = new Node(id++, "p8-2-10p8")
            .Connect(sp8, s610s10p82);
        var ns10p8s10 = new Node(id++, "10p8-10")
            .Connect(s610s10p82, s610s10p81);
        var ns10p7 = new Node(id++, "p7-10")
            .Connect(sp7, s610s10p7);
        var ns10 = new Node(id++, "10")
            .Connect(new[] { s610s10p7, s610s10p81 }, new[] { s610s810 });
        var ns8p6 = new Node(id++, "p6-8")
            .Connect(sp6, s610s8p6);
        var ns8 = new Node(id++, "8")
            .Connect(new[] { s610s8p6, s610s810 }, new[] { s610s68 });
        var ns6p5 = new Node(id++, "p5-6")
            .Connect(sp5, s610s6p5);
        var ns6 = new Node(id++, "6")
            .Connect(new[] { s610s6p5, s610s68 }, new[] { s610s4 });

        var sws4 = new SwitchSection(sectionId++, "s4");
        var s4s6 = new Segment(segmentId++, "s4-6", sws4);
        var s4s2 = new Segment(segmentId++, "s4-2", sws4);
        var s4rp2 = new Segment(segmentId++, "s4-rp2", sws4);

        var ns6s4 = new Node(id++, "6-4")
            .Connect(s610s4, s4s6);
        var ns4 = new Node(id++, "4")
            .Connect(new[] { s4s6 }, new[] { s4s2, s4rp2 });        

        var sws2 = new SwitchSection(sectionId++, "s2");
        var s2s4 = new Segment(segmentId++, "s2-4", sws2);
        var s2p4 = new Segment(segmentId++, "s2-p4", sws2);
        var s2rp1 = new Segment(segmentId++, "s2-rp1", sws2);

        var np4s2 = new Node(id++, "p4-2")
            .Connect(sp4, s2p4);
        var ns4s2 = new Node(id++, "4-2")
            .Connect(s4s2, s2s4);
        var ns2 = new Node(id++, "2")
            .Connect(new[] { s2p4, s2s4 }, new[] { s2rp1 });


        var rp1 = new PathSection(sectionId++, "rightP1");
        var srp1 = new Segment(segmentId++, "sRp1", rp1);
        var rp2 = new PathSection(sectionId++, "rightP2");
        var srp2 = new Segment(segmentId++, "sRp2", rp2);

        var ns2rp1 = new Node(id++, "2-rp1")
            .Connect(s2rp1, srp1);
        var ns4rp2 = new Node(id++, "4-rp2")
            .Connect(s4rp2, srp2);

        station
            .AddPark(new Park(parkId++, "A")
                .AddSection(p1)
                .AddSection(p2)
                .AddSection(p3))
            .AddPark(new Park(parkId++, "B")
                .AddSection(p4)
                .AddSection(p5))
            .AddPark(new Park(parkId++, "C")
                .AddSection(p6)
                .AddSection(p7)
                .AddSection(p8))
            .AddSection(lp1)
            .AddSection(lp2)
            .AddSection(sws17)
            .AddSection(sws9)
            .AddSection(sws35)
            .AddSection(sws26)
            .AddSection(sws1824)
            .AddSection(sws2022)
            .AddSection(sws1216)
            .AddSection(sws610)
            .AddSection(sws4)
            .AddSection(sws2)
            .AddSection(rp1)
            .AddSection(rp2);
        return station;
    }
}
