using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class LDSMember
    {
        public int Id { get; set; }
        public int RecordNumber { get; private set; }
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        // just added for the fun of it :D
        public bool MusicalSkills { get; set; }
    }
}
