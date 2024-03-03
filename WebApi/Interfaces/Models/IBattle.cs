namespace WebApi.Interfaces.Models
{
    public interface IBattle
    {
        public int Id { get; set; }
        public double NumberOfHeores { get; set; }
        public int WinnerHeroId { get; set; }
    }
}
