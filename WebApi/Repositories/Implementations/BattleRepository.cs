namespace WebApi.Repositories.Implementations
{
    public class BattleRepository : RepositoryBase<Battle>, IBattleRepository
    {
        public BattleRepository(HeroContext context)
            : base(context)
        {
        }
    }
}
