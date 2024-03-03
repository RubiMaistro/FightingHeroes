namespace WebApi.Interfaces.Models
{
    public interface IRound
    {
        public int RoundNumber { get; set; }
        public int AttackerHeroId { get; set; }
        public int DefenderHeroId { get; set; }
    }
}
