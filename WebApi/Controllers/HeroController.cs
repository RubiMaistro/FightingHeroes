using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/hero")]
    public class HeroController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        public HeroController(IRepositoryWrapper epositoryWrapper)
        {
            _repository = epositoryWrapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Hero>))]
        public IActionResult Get()
        {
            var foods = _repository.HeroRepository.FindAll();
            if (foods != null)
                return Ok(foods);

            return NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Hero))]
        public IActionResult Get(int id)
        {
            var food = _repository.HeroRepository
                .FindByCondition(x => x.Id.Equals(id))
                .FirstOrDefault();

            if (food != null)
                return Ok(food);

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Hero))]
        public IActionResult Post(Hero heroCreate)
        {
            if (heroCreate == null)
                return BadRequest(heroCreate);

            var existingHero = _repository.HeroRepository
                .FindByCondition(x => x.Id == heroCreate.Id)
                .FirstOrDefault();

            if (existingHero != null)
                return UnprocessableEntity(heroCreate);

            _repository.HeroRepository.Create(heroCreate);
            _repository.Save();

            return Ok(heroCreate);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Put(Hero hero, int id)
        {
            var existingOrder = _repository.HeroRepository
                .FindByCondition(x => x.Id.Equals(id))
                .FirstOrDefault();

            if (existingOrder != null)
            {
                _repository.HeroRepository.Update(hero);
                _repository.Save();
                return Ok($"{hero.Id} hero updating successful!");
            }
            else
            {
                _repository.HeroRepository.Create(hero);
                _repository.Save();
                return Ok($"{hero.Id} hero adding successful!");
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(string))]
        public IActionResult Delete(int id)
        {
            var existingHero = _repository.HeroRepository
                .FindByCondition(x => x.Id.Equals(id))
                .FirstOrDefault();

            if (existingHero != null)
            {
                _repository.HeroRepository.Delete(existingHero);
                _repository.Save();

                return Ok($"{existingHero.Id} hero deleting successful!");
            }

            return NotFound("Hero not found!");
        }

    }
}
