namespace WebApi.Interfaces.Models
{
    public interface IHero
    {
        public int Id { get; set; }
        public HeroType HeroType { get; set; }
        public double Health { get; set; }
    }
}
