using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebApi.Services
{
    public class BattleHandlingService : IBattleHandlingService
    {
        private readonly IRepositoryWrapper _repository;
        public BattleHandlingService(IRepositoryWrapper repositoryWrapper)
        {
            _repository = repositoryWrapper;
        }

        public void GenerateRandomHeroesByBattle(Battle battle)
        {
            double generatedHeroes = 0;
            while (battle.NumberOfHeores > generatedHeroes)
            {
                var heroTypes = Enum.GetValues(typeof(HeroHealthType));
                var random = new Random();
                var heroType = (HeroHealthType)heroTypes.GetValue(random.Next(heroTypes.Length));
                _repository.HeroRepository.Create(new Hero()
                {
                    HeroType = heroType,
                    Health = (double)heroType,
                    BattleId = battle.Id
                });
                generatedHeroes += 1;
                _repository.Save();
            }
        }

        public void ExecuteBattle(Battle battle)
        {
            while(GetHeroesByBattleId(out var heroes))
            {
                if (heroes.Count() <= 1)
                {
                    battle.WinnerHeroId = heroes.First().Id;
                    _repository.Save();
                    return;
                }
                CreateRound(heroes.First(), heroes.Last());
                var other = _repository.HeroRepository
                    .FindByCondition(x => x.BattleId == battle.Id && x.Health != 0 && !heroes.Contains(x)).ToList();
                foreach (var otherHero in other)
                {
                    var differenceHealth = (int)otherHero.HeroType - otherHero.Health;
                    int addHealth = 10;
                    if (differenceHealth > addHealth)
                        otherHero.Health += addHealth;
                    else
                        otherHero.Health += differenceHealth;
                }
                _repository.Save();
            }
        }

        

        private bool GetHeroesByBattleId(out IEnumerable<Hero> heroes)
        {
            heroes = _repository.HeroRepository.FindByCondition(x => x.BattleId == x.Id && x.Health != 0).Take(2);
            return heroes.Any();
        }

        private void CreateRound(IHero attacker, IHero defender) 
        {
            var deadHero = attacker.Attack(defender);
            if (deadHero.Id == attacker.Id)
            _repository.RoundRepository.Create(new Round()
            {
                AttackerHeroId = attacker.Id,
                DefenderHeroId = defender.Id
            });
        }

    }
}
