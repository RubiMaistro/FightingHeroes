using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class Hero : IHero
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        [Required]
        public HeroHealthType HeroType { get; set; }
        public double Health { get; set; }
        public int BattleId { get; set; }

        public virtual IHero Attack(IHero defenderHero)
        {
            if (defenderHero.HeroType == HeroType)
                defenderHero.Health = 0;
            switch (HeroType)
            {
                case HeroHealthType.Bowman:
                    switch (defenderHero.HeroType)
                    {
                        case HeroHealthType.Swordsman:
                            defenderHero.Health = 0;
                            break;
                        case HeroHealthType.Rider:
                            var random = new Random();
                            if (random.Next(1, 100) <= 40)
                                defenderHero.Health = 0;
                            break;
                    }
                    break;
                case HeroHealthType.Swordsman:
                    if (defenderHero.HeroType == HeroHealthType.Bowman)
                        defenderHero.Health = 0;
                    break;
                case HeroHealthType.Rider:
                    switch (defenderHero.HeroType)
                    {
                        case HeroHealthType.Bowman:
                            defenderHero.Health = 0;
                            break;
                        case HeroHealthType.Swordsman:
                            Health = 0;
                            return this; // attacker hero is dead
                    }
                    break;
            }
                            
            if (Health != 0)
                Health = Health > (int)HeroType / 4 ? Health / 2 : 0;
            else
                defenderHero.Health = defenderHero.Health > (int)defenderHero.HeroType / 4 ? defenderHero.Health / 2 : 0;
            return defenderHero;
        }
        
    }
}
