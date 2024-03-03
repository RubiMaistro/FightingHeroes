namespace WebApi.Repositories.Implementations
{
    public class RoundRepository : RepositoryBase<Round>, IRoundRepository
    {
        public RoundRepository(HeroContext context)
            : base(context)
        {
        }
    }
}
