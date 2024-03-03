namespace WebApi.Interfaces.Models
{
    public interface IHero
    {
        public int Id { get; set; }
        public HeroHealthType HeroType { get; set; }
        public double Health { get; set; }
        /// <summary>
        /// Performs the attack and get the dead hero
        /// </summary>
        /// <param name="defenderHero">defender hero</param>
        /// <returns>dead hero</returns>
        public IHero Attack(IHero defenderHero);
    }
}
