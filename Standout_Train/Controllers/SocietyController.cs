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
    public class SocietyController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public SocietyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainById([FromRoute] int id)
        {
            SocietyDTO society = new();
            try
            {
                society = _mapper.Map<SocietyDTO>(await unitOfWork.Society.GetByIdAsync(id));
                await unitOfWork.Complete();
                return Json(society);
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
                DAL.Models.Society? society = await unitOfWork.Society.GetByIdAsync(id);
                await unitOfWork.Society.Remove(society);
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
                List<SocietyDTO> dtos = new();
                dtos = _mapper.Map<List<SocietyDTO>>(await unitOfWork.Society.GetAllAsync());
                return Json(dtos);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] SocietyDTO societyDTO)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            try
            {
                DAL.Models.Society? society = await unitOfWork.Society.GetByIdAsync(id);
                if (society == null)
                {
                    return NotFound();
                }
                Society? entity = _mapper.Map<Society>(societyDTO);
                await unitOfWork.Society.Update(id, entity);
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
        public async Task<IActionResult> Create([FromBody] SocietyDTO societyDTO)
        {
            try
            {
                if (societyDTO == null)
                {
                    return BadRequest();
                }
                var entity = _mapper.Map<Society>(societyDTO);
                await unitOfWork.Society.AddAsync(entity);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
