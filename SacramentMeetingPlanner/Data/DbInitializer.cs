using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Newtonsoft.Json;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SacramentMeetingPlannerContext context)
        {
            context.Database.EnsureCreated();

            if (context.LDSMember.Any())
            {
                return;
            }

            var members = new LDSMember[]
            {
                new LDSMember
                {
                    RecordNumber = 1234,
                    FullName = "Alex Vasiuk",
                    BirthDay = DateTime.Parse("01/04/2000"),
                    MusicalSkills = false,
                }, 
                new LDSMember
                {
                    RecordNumber = 1235,
                    FullName = "Chris Bagwell",
                    BirthDay = DateTime.Parse("05/21/1988"),
                    MusicalSkills = false,
                }, 
                new LDSMember
                {
                    RecordNumber = 1236,
                    FullName = "Jason Macdonald",
                    BirthDay = DateTime.Parse("07/25/1991"),
                    MusicalSkills = true,
                },
                new LDSMember
                {
                    RecordNumber = 1237,
                    FullName = "Austin Earl", 
                    BirthDay = DateTime.Parse(""),
                    MusicalSkills = true,
                },
                new LDSMember
                {
                    RecordNumber = 1236,
                    FullName = "Scott Whiteside",
                    BirthDay = DateTime.Parse("05/27/1978"),
                    MusicalSkills = true,
                },
                new LDSMember
                {
                    RecordNumber = 1236,
                    FullName = "Brian Almeda",
                    BirthDay = DateTime.Parse("04/21/1984"),
                    MusicalSkills = true,
                },
                new LDSMember
                {
                    RecordNumber = 1236,
                    FullName = "Calvin Braun",
                    BirthDay = DateTime.Parse("03/18/1980"),
                    MusicalSkills = false,
                }
            };

            foreach ( LDSMember m in members ) 
            {
                context.LDSMember.Add(m );
            }
            context.SaveChanges();

            var meetings = new SacramentMeeting[]
            {
                new SacramentMeeting
                {
                    Date = DateTime.Parse("3/26/23"),
                    ConductingLeaderName = "Brian Almeda",
                    Speakers = new List<LDSMember>(),
                    OpeningHymn = 95,
                    SacramentHymn = 135,
                    ClosingHymn = 225,
                    OpeningPrayerPerson = "Calvin Braun",
                    ClosingPrayerPerson = "Alex Vasiuk"
                },
                new SacramentMeeting
                {
                    Date = DateTime.Parse("3/19/23"),
                    ConductingLeaderName = "Scott Whiteside",
                    OpeningHymn = 1,
                    SacramentHymn = 165,
                    ClosingHymn = 5,
                    OpeningPrayerPerson = "Austin Earl",
                    ClosingPrayerPerson = "Chris Bagwell"
                }
            };

            foreach ( SacramentMeeting meeting in meetings ) 
            {
                context.SacramentMeeting.Add(meeting);
            }
            context.SaveChanges();
        }
    }
}
