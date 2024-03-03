namespace WebApi.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        /// <summary>
        /// Hero repository instance
        /// </summary>
        IHeroRepository HeroRepository { get; }
        /// <summary>
        /// Round repository instance
        /// </summary>
        IRoundRepository RoundRepository { get; }
        /// <summary>
        /// Battle repository instance
        /// </summary>
        IBattleRepository BattleRepository { get; }
        public void Save();
    }
}
