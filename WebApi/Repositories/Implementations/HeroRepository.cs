using WebApi.Interfaces.Repositories;

namespace WebApi.Repositories.Implementations
{
    public class HeroRepository : RepositoryBase<Hero>, IHeroRepository
    {
        public HeroRepository(HeroContext context)
            : base(context)
        {
        }
    }
}
