using CarRepairShop.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRepairShop.Controllers
{
    [Authorize(Roles ="Owner")]
    [Route("api/statistic")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticService statisticService;

        public StatisticController(IStatisticService _statisticService)
        {
            statisticService = _statisticService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatistic()
        {
            var result = await statisticService.TotalAsync();
            return Ok(result);
        }
    }
}
