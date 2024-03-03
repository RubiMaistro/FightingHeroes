using WebApi.Repositories.Implementations;

namespace WebApi.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper, IDisposable
    {
        private HeroContext _context;
        private IHeroRepository _heroRepository;
        private IRoundRepository _roundRepository;
        private IBattleRepository _battleRepository;
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
        public IRoundRepository RoundRepository
        {
            get
            {
                if (_roundRepository == null)
                {
                    _roundRepository = new RoundRepository(_context);
                }
                return _roundRepository;
            }
        }
        public IBattleRepository BattleRepository
        {
            get
            {
                if (_battleRepository == null)
                {
                    _battleRepository = new BattleRepository(_context);
                }
                return _battleRepository;
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

        public void Dispose()
        {
            
        }
    }
}
