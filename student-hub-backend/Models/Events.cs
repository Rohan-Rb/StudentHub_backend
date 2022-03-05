using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Models
{
    public class Events
    {
        [Key]
        public int EventID { get; set; }
        public string EventName { get; set; }
        public string Banner { get; set; }
        public string Organizer { get; set; }
        public string EventType { get; set; }
        public DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Cost { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        public Boolean Tickets { get; set; }
        public string TicketLink { get; set; }
        public string Refund { get; set; }
        public string Description { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }

        [Display(Name = "UserID")]
        public virtual int UserID { get; set; }

        [ForeignKey("UserID")]
        public virtual Users Users { get; set; }
        /*public string UserID { get; set; }*/
    }
}
