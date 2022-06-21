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
    public class StationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper _mapper;

        public StationController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStationById([FromRoute] int id)
        {
            StationDTO station = new();
            try
            {
                station = _mapper.Map<StationDTO>(await unitOfWork.Stations.GetByIdAsync(id));
                await unitOfWork.Complete();
                return Json(station);
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
                DAL.Models.Station? station = await unitOfWork.Stations.GetByIdAsync(id);
                await unitOfWork.Stations.Remove(station);
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
                List<StationDTO> dtos = new();
                dtos = _mapper.Map<List<StationDTO>>(await unitOfWork.Stations.GetAllAsync());
                return Json(dtos);
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StationDTO stationDTO)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            try
            {
                DAL.Models.Station? station = await unitOfWork.Stations.GetByIdAsync(id);
                if (station == null)
                {
                    return NotFound();
                }
                Station? entity = _mapper.Map<Station>(stationDTO);
                await unitOfWork.Stations.Update(id, entity);
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
        public async Task<IActionResult> Create([FromBody] StationDTO stationDTO)
        {
            try
            {
                if (stationDTO == null)
                {
                    return BadRequest();
                }
                Station? entity = _mapper.Map<Station>(stationDTO);
                await unitOfWork.Stations.AddAsync(entity);
                return Ok();
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
