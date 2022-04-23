using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.DTO
{
    public class GetEventDto
    {
        public string EventName { get; set; }
        public string Banner { get; set; }
        public string Organizer { get; set; }
        public string EventType { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Cost { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Venue { get; set; }
        /* public string Address { get; set; }*/
        public Boolean Tickets { get; set; }
        public string TicketLink { get; set; }
        public string Refund { get; set; }
        public string Description { get; set; }
        public Boolean IsDeleted { get; set; }
        public DateTime DeletedDate { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}
