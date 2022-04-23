using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_hub_backend.DTO;
using student_hub_backend.Models;
using student_hub_backend.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;

namespace student_hub_backend.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        IEventService _eventService;
        public EventController(IEventService service)
        {
            _eventService = service;
        }

        /*Get List Of All Events Method*/
        /// <summary>
        /// get all employess
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllEvents()
        {
            try
            {
                var events = _eventService.GetEventsList();
                if (events == null)
                {
                    return NotFound();
                }

                var getEventDto = events.Select(e => new GetEventDto
                {
                    EventName = e.EventName,
                    Banner = e.Banner,
                    Organizer = e.Organizer,
                    EventType = e.EventType,
                    Date = e.Date,
                    StartTime = e.StartTime,
                    EndTime = e.EndTime,
                    Cost = e.Cost,
                    City = e.City,
                    State = e.State,
                    Venue = e.Venue,
                    /*Address = $"{e.Venue}, {e.City}, {e.State}",*/
                    Tickets = e.Tickets,
                    TicketLink = e.TicketLink,
                    Refund = e.Refund,
                    Description = e.Description,
                    IsDeleted = e.IsDeleted,
                    DeletedDate = e.DeletedDate,
                    UserID = e.UserID,
                    UserName = e.Users.UserName
                });
                return Ok(events);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /*Get Events Details By Id Method*/
        /// <summary>
        /// get event details by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetEventsById(int id)
        {
            try
            {
                var events = _eventService.GetEventDetailsById(id);
                if (events == null)
                {
                    return NotFound();
                }
                var getEventDto = new GetEventDto
                {
                    EventName = events.EventName,
                    Banner = events.Banner,
                    Organizer = events.Organizer,
                    EventType = events.EventType,
                    Date = events.Date,
                    StartTime = events.StartTime,
                    EndTime = events.EndTime,
                    Cost = events.Cost,
                    City = events.City,
                    State = events.State,
                    Venue = events.Venue,
                    /*Address = $"{events.Venue}, {events.City}, {events.State}",*/
                    Tickets = events.Tickets,
                    TicketLink = events.TicketLink,
                    Refund = events.Refund,
                    Description = events.Description,
                    IsDeleted = events.IsDeleted,
                    DeletedDate = events.DeletedDate,
                    UserID = events.UserID,
                    UserName = events.Users.UserName

                };
                return Ok(getEventDto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /*Save Events Method*/
        /// <summary>
        /// save Event
        /// </summary>
        /// <param name="eventModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveEvents([FromForm] EventDto eventDto)
        {
            try
            {
                string path = Path.Combine("F:\\student-hub-fyp\\public\\Images\\EventImages", eventDto.FileName);

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    eventDto.FormFile.CopyTo(stream);
                }

                    var eventModel = new Events
                    {
                        EventName = eventDto.EventName,
                        Banner = "\\Images\\EventImages\\"+eventDto.FileName,
                        Organizer = eventDto.Organizer,
                        EventType = eventDto.EventType,
                        Date = eventDto.Date,
                        StartTime = eventDto.StartTime,
                        EndTime = eventDto.EndTime,
                        Cost = eventDto.Cost,
                        City = eventDto.City,
                        State = eventDto.State,
                        Venue = eventDto.Venue,
                        Tickets = eventDto.Tickets,
                        TicketLink = eventDto.TicketLink,
                        Refund = eventDto.Refund,
                        Description = eventDto.Description,
                        IsDeleted = eventDto.IsDeleted,
                        DeletedDate = eventDto.DeletedDate,
                        UserID = eventDto.UserID

                    };

                var model = _eventService.SaveEvent(eventModel);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /*Delete event Method*/
        /// <summary>
        /// delete event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteEvent(int id)
        {
            try
            {
                var model = _eventService.DeleteEvent(id);
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
