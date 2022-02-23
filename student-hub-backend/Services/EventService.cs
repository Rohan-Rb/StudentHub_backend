using student_hub_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_hub_backend.Services
{
    public class EventService : IEventService
    {

        private EventContext _context;
        public EventService(EventContext context)
        {
            _context = context;
        }

        public List<Events> GetEventsList()
        {
            List<Events> eventList;
            try
            {
                eventList = _context.Set<Events>().ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return eventList;
        }

        public Events GetEventDetailsById(int eventId)
        {
            Events events;
            try
            {
                events = _context.Find<Events>(eventId);
            }
            catch (Exception)
            {
                throw;
            }
            return events;
        }

        public ResponseModel SaveEvent(Events eventModel)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Events _temp = GetEventDetailsById(eventModel.EventID);
                if (_temp != null)
                {
                    _temp.EventName = eventModel.EventName;
                    _temp.Banner = eventModel.Banner;
                    _temp.Organizer = eventModel.Organizer;
                    _temp.EventType = eventModel.EventType;
                    _temp.Date = eventModel.Date;
                    _temp.StartTime = eventModel.StartTime;
                    _temp.EndTime = eventModel.EndTime;
                    _temp.Cost = eventModel.Cost;
                    _temp.State = eventModel.State;
                    _temp.City = eventModel.City;
                    _temp.Venue = eventModel.Venue;
                    _temp.Tickets = eventModel.Tickets;
                    _temp.TicketLink = eventModel.TicketLink;
                    _temp.Refund = eventModel.Refund;
                    _temp.Description = eventModel.Description;
                    _temp.IsDeleted = eventModel.IsDeleted;
                    _temp.DeletedDate = eventModel.DeletedDate;
                    _context.Update<Events>(_temp);
                    model.Messsage = "event Update Successfully";
                }
                else
                {
                    _context.Add<Events>(eventModel);
                    model.Messsage = "Events Inserted Successfully";
                }
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel DeleteEvent(int eventId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                Events _temp = GetEventDetailsById(eventId);
                if (_temp != null)
                {
                    _context.Remove<Events>(_temp);
                    _context.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "event Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "event Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

    }
}
