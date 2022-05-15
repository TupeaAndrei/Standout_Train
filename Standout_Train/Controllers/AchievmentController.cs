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
    public class AchievmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public AchievmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrainById([FromRoute] int id)
        {
            AchievmentsDTO achievment = new();
            try
            {
                achievment = _mapper.Map<AchievmentsDTO>(await unitOfWork.Achievments.GetByIdAsync(id));
                await unitOfWork.Complete();
            }
            catch (DbUpdateException)
            {
                return NotFound();
            }
            return Json(achievment);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                DAL.Models.Achievments? achievment = await unitOfWork.Achievments.GetByIdAsync(id);
                await unitOfWork.Achievments.Remove(achievment);
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
                List<AchievmentsDTO> dtos = new();
                dtos = _mapper.Map<List<AchievmentsDTO>>(await unitOfWork.Achievments.GetAllAsync());
                return Json(dtos);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] AchievmentsDTO achievmentDTO)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            try
            {
                var achievment = await unitOfWork.Achievments.GetByIdAsync(id);
                if (achievment == null)
                {
                    return NotFound();
                }
                Achievments? entity = _mapper.Map<Achievments>(achievmentDTO);
                await unitOfWork.Achievments.Update(id, entity);
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
        public async Task<IActionResult> Create([FromBody] AchievmentsDTO achievmentDTO)
        {
            try
            {
                if (achievmentDTO == null)
                {
                    return BadRequest();
                }
                var entity = _mapper.Map<Achievments>(achievmentDTO);
                await unitOfWork.Achievments.AddAsync(entity);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
