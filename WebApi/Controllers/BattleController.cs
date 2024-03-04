using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/battle")]
    public class BattleController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IBattleHandlingService _battleHandling;
        public BattleController(IRepositoryWrapper repositoryWrapper, IBattleHandlingService battleHandling)
        {
            _repository = repositoryWrapper;
            _battleHandling = battleHandling;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Battle))]
        public IActionResult Get(int id)
        {
            var battle = _repository.BattleRepository
                .FindByCondition(x => x.Id.Equals(id))
                .FirstOrDefault();

            if (battle != null)
                return Ok(battle);

            return NotFound();
        }
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(int))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult Post([FromQuery] int count)
        {
            var battleCreate = new Battle()
            {
                NumberOfHeores = count
            };
            if (battleCreate.NumberOfHeores < 2)
                return BadRequest("The number of heroes must be greater than or equal to 2");

            var existingBattle = _repository.BattleRepository
                .FindByCondition(x => x.Id == battleCreate.Id)
                .FirstOrDefault();

            if (existingBattle != null)
                return UnprocessableEntity(battleCreate);

            _repository.BattleRepository.Create(battleCreate);
            _repository.Save();

            _battleHandling.GenerateRandomHeroesByBattle(battleCreate);
            _battleHandling.ExecuteBattle(battleCreate);

            _repository.Save();

            return Ok(battleCreate.Id);
        }
        
    }
}
