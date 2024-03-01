namespace WebApi.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        /// <summary>
        /// Hero repository instance
        /// </summary>
        IHeroRepository HeroRepository { get; }
        public void Save();
    }
}
