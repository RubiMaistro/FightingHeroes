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
        public HeroType HeroType { get; set; }
        public double Health { get; set; }

        public Hero(int id, HeroType heroType)
        {
            Id = id;
            HeroType = heroType;
            switch (heroType)
            {
                case HeroType.Bowman:
                    Health = 100;
                    break;
                case HeroType.Swordsman:
                    Health = 120;
                    break;
                case HeroType.Rider:
                    Health = 150;
                    break;
            }
        }

    }
}
