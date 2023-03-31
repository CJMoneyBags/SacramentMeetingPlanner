using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SacramentMeetingPlanner.Models
{
    public class SacramentMeeting
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ConductingLeaderName { get; set; }
        public List<LDSMember> Speakers = new List<LDSMember>();
        public int OpeningHymn { get; set; }
        public int SacramentHymn { get; set; }
        public string? IntermediateHymnOrMusicalNumber { get; set; }
        public int ClosingHymn { get; set; }
        public string OpeningPrayerPerson { get; set; }
        public string ClosingPrayerPerson { get; set; }

        public SacramentMeeting(int id, DateTime date,
            string conductingLeaderName, int openingHymn,
            int sacramentHymn, string? intermediateHymnOrMusicNumber,
            int closingHymn, string openingPrayerPerson,
            string closingPrayerPerson)
        {
            Id = id;
            Date = date;
            ConductingLeaderName = conductingLeaderName;
            OpeningHymn = openingHymn;
            SacramentHymn = sacramentHymn;
            IntermediateHymnOrMusicalNumber = intermediateHymnOrMusicNumber;
            ClosingHymn = closingHymn;
            OpeningPrayerPerson = openingPrayerPerson;
            ClosingPrayerPerson = closingPrayerPerson;
        }

        public SacramentMeeting() { }
    }
}
