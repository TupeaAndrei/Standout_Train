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
    public class CustomerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                IEnumerable<DAL.Models.Customer>? customers = await _unitOfWork.Customers.GetAllAsync();
                List<CustomerDTO> results = _mapper.Map<List<CustomerDTO>>(customers);
                return Json(results);
            }catch(DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            try
            {
                Customer? result = await _unitOfWork.Customers.GetByIdAsync(id);
                return Json(result);
            }catch(DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ArgumentException ag)
            {
                return NotFound(ag.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody]CustomerDTO dto)
        {
            try
            {
                Customer entity = _mapper.Map<Customer>(dto);
                await _unitOfWork.Customers.AddAsync(entity);
                return Ok();
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer([FromRoute]int id)
        {
            try
            {
                Customer? result = await _unitOfWork.Customers.GetByIdAsync(id);
                if (result == null)
                {
                    throw new ArgumentException(null, nameof(id));
                }
                await _unitOfWork.Customers.Remove(result);
                return Ok();
            }catch(ArgumentException ag)
            {
                return NotFound(ag.Message);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute]int id,[FromBody]CustomerDTO dto)
        {
            try
            {
                Customer? entity = _mapper.Map<Customer>(dto);
                await _unitOfWork.Customers.Update(id, entity);
                return Ok();
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ArgumentException ag)
            {
                return BadRequest(ag.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAchievments([FromRoute]int id)
        {
            try
            {
                Customer? result = await _unitOfWork.Customers.GetByIdAsync(id);
                if (result == null)
                {
                    throw new ArgumentException(null,nameof(id));
                }
                List<Achievments>? achievments = await _unitOfWork.Customers.GetUserAchievments(result);
                List<AchievmentsDTO> results = _mapper.Map<List<AchievmentsDTO>>(achievments);
                return Json(results);
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ArgumentException ag)
            {
                return BadRequest(ag.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTickets([FromRoute] int id)
        {
            try
            {
                Customer? result = await _unitOfWork.Customers.GetByIdAsync(id);
                if (result == null)
                {
                    throw new ArgumentException(null, nameof(id));
                }
                List<Ticket>? tickets = await _unitOfWork.Customers.GetBookedTickets(result);
                List<TicketDTO> results = _mapper.Map<List<TicketDTO>>(tickets);
                return Json(results);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ag)
            {
                return BadRequest(ag.Message);
            }
        }

    }
}
