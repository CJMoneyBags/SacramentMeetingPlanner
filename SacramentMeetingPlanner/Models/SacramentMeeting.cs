using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SacramentMeetingPlanner.Models
{
    public class SacramentMeeting
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        [Display(Name = "Conducting Leader")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(30)]
        public string ConductingLeaderName { get; set; }
        
        [Display(Name = "Opening Hymn")]
        [Range(1,341)]
        public int OpeningHymn { get; set; }
        
        [Display(Name = "Sacrament Hymn")]
        [Range(1, 341)]
        public int SacramentHymn { get; set; }
        
        [Display(Name = "Intermediate Hymn Or Musical Number")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(30)]
        public string? IntermediateHymnOrMusicalNumber { get; set; }

        [Display(Name = "Closing Hymn")]
        [Range(1, 341)]
        public int ClosingHymn { get; set; }

        [Display(Name = "Opening Prayer")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(30)]
        public string OpeningPrayerPerson { get; set; }
        
        [Display(Name = "Closing Prayer")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(30)]
        public string ClosingPrayerPerson { get; set; }

        [Display(Name = "Number Of Speakers")]
        [Range(0, int.MaxValue, ErrorMessage ="Number of Speakers must be greater or equal to zero")]
        public int NumberOfSpeakers { get; set; }

        [Display(Name = "Talk Subjects")]
        [NotMapped]
        public List<string>? SpeakerSubjects { get; set; }
    }
}
