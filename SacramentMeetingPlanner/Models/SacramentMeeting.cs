using System.ComponentModel.DataAnnotations;


namespace SacramentMeetingPlanner.Models
{
    public class SacramentMeeting
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Conducting Leader")]
        public string ConductingLeaderName { get; set; }
        public List<LDSMember>? Speakers = new List<LDSMember>();
        [Display(Name = "Opening Hymn")]
        public int OpeningHymn { get; set; }
        [Display(Name = "Sacrament Hymn")]

        public int SacramentHymn { get; set; }
        [Display(Name = "Intermediate Hymn Or Musical Number")]

        public string? IntermediateHymnOrMusicalNumber { get; set; }
        [Display(Name = "Closing Hymn")]

        public int ClosingHymn { get; set; }
        [Display(Name = "Opening Prayer")]

        public string OpeningPrayerPerson { get; set; }
        [Display(Name = "Closing Prayer")]

        public string ClosingPrayerPerson { get; set; }
    }
}
