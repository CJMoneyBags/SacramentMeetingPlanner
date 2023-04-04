using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SacramentMeetingPlannerContext context)
        {
            context.Database.EnsureCreated();

            if (context.SacramentMeeting.Any())
            {
                return;
            }

            var meetings = new SacramentMeeting[]
            {
                new SacramentMeeting
                {
                    Date = DateTime.Parse("3/26/23"),
                    ConductingLeaderName = "Brian Almeda",
                    OpeningHymn = 95,
                    SacramentHymn = 135,
                    ClosingHymn = 225,
                    OpeningPrayerPerson = "Calvin Braun",
                    ClosingPrayerPerson = "Alex Vasiuk",
                    NumberOfSpeakers = 3,
                    SpeakerSubjects = new List<string>()
                    {
                        "Atonement",
                        "Resurrection",
                        "Prayer"
                    }
                },
                // It's gonna be fasting Sunday, so no assigned Speakers
                new SacramentMeeting
                {
                    Date = DateTime.Parse("3/19/23"),
                    ConductingLeaderName = "Scott Whiteside",
                    OpeningHymn = 1,
                    SacramentHymn = 165,
                    ClosingHymn = 5,
                    OpeningPrayerPerson = "Austin Earl",
                    ClosingPrayerPerson = "Chris Bagwell",
                    NumberOfSpeakers = 0,
                    SpeakerSubjects = new List<string>()
                    {
                        "FastSunday"
                    }
                }
            };

            foreach (SacramentMeeting meeting in meetings)
            {
                context.SacramentMeeting.Add(meeting);
            }
            context.SaveChanges();
        }
    }
}
