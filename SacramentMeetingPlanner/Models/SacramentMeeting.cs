using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SacramentMeetingPlanner.Models
{
    public class SacramentMeeting
    {
        public DateTime Date { get; set; }
        public string ConductingLeaderName { get; set; }
        public List<LDSMember> Speakers { get; set; }
        public int OpeningHymn { get; set; }
        public int SacramentHymn { get; set; }
        public int? IntermediateHymn { get; set; }
        public string? MusicalNumber { get; set; }
        public int ClosingHymn { get; set; }
        public string OpeningPrayerPerson { get; set; }
        public string ClosingPrayerPerson { get; set; }
    }
}
