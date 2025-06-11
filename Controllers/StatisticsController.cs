// Controllers/StatisticsController.cs
using Bimbrownik_API.Models.Dto;
using Bimbrownik_API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bimbrownik_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _stats;

        public StatisticsController(IStatisticsService stats)
        {
            _stats = stats;
        }

        // GET: api/statistics
        // publiczne – każdy może zobaczyć podstawowe statystyki
        [HttpGet]
        public async Task<ActionResult<StatisticsDto>> Get()
        {
            var dto = await _stats.GetStatisticsAsync();
            return Ok(dto);
        }

        // GET: api/statistics/admin
        // bardziej szczegółowe statystyki dostępne tylko dla administratorów
        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<StatisticsDto>> GetForAdmin()
        {
            var dto = await _stats.GetStatisticsAsync();
            return Ok(dto);
        }
    }
}
