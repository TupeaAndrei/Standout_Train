using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Standout_Train.BL.Interfaces;
using Standout_Train.DAL.Models;
using Standout_Train.TL.DTOs;

namespace Standout_Train.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public TicketController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainById([FromRoute] int id)
        {
            TicketDTO ticket = new();
            try
            {
                ticket = _mapper.Map<TicketDTO>(await unitOfWork.Tickets.GetByIdAsync(id));
                await unitOfWork.Complete();
                return Json(ticket);
            }
            catch (DbUpdateException)
            {
                return NotFound();
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                DAL.Models.Ticket? ticket = await unitOfWork.Tickets.GetByIdAsync(id);
                await unitOfWork.Tickets.Remove(ticket);
                return Ok();
            }
            catch (ArgumentException ag)
            {
                return NotFound(ag.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<TicketDTO> dtos = new();
                dtos = _mapper.Map<List<TicketDTO>>(await unitOfWork.Tickets.GetAllAsync());
                return Json(dtos);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TicketDTO ticketDTO)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            try
            {
                DAL.Models.Ticket? ticket = await unitOfWork.Tickets.GetByIdAsync(id);
                if (ticket == null)
                {
                    return NotFound();
                }
                Ticket? entity = _mapper.Map<Ticket>(ticketDTO);
                await unitOfWork.Tickets.Update(id, entity);
                return Json(entity);
            }
            catch (ArgumentException ag)
            {
                return NotFound(ag.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TicketDTO ticketDTO)
        {
            try
            {
                if (ticketDTO == null)
                {
                    return BadRequest();
                }
                Ticket? entity = _mapper.Map<Ticket>(ticketDTO);
                await unitOfWork.Tickets.AddAsync(entity);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
