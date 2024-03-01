using WebApi.Repositories.Implementations;

namespace WebApi.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private HeroContext _context;
        private IHeroRepository _heroRepository;
        public IHeroRepository HeroRepository
        {
            get
            {
                if (_heroRepository == null)
                {
                    _heroRepository = new HeroRepository(_context);
                }
                return _heroRepository;
            }
        }

        public RepositoryWrapper(HeroContext heroContext)
        {
            _context = heroContext;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
