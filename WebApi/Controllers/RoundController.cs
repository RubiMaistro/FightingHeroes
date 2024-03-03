using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/round")]
    public class RoundController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        public RoundController(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Round>))]
        public IActionResult Get()
        {
            var rounds = _repository.RoundRepository.FindAll();
            if (rounds != null)
                return Ok(rounds);

            return NotFound();
        }
    }
}
