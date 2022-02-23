using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using student_hub_backend.Models;
using student_hub_backend.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                if (events == null) return NotFound();
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
                if (events == null) return NotFound();
                return Ok(events);
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
        public IActionResult SaveEvents(Events eventModel)
        {
            try
            {
                var model = _eventService.SaveEvent(eventModel);
                return Ok(model);
            }
            catch (Exception)
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
