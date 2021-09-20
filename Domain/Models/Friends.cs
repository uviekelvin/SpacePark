using System;

namespace Domain.Models
{
    public class Friends
    {
        public long ObserverId { get; set; }
        public long TargetId { get; set; }
        public Users Observer { get; set; }
        public Users Target { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime? DateUpdated { get; set; }

    }
}