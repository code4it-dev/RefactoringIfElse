namespace RefactoringIfElse.Concrete
{
    public class FooWithChainOfResponsibility : BaseFoo
    {
        public FooWithChainOfResponsibility(IDbRepository dbRepository, IApiAccess apiAccess) 
            : base(dbRepository, apiAccess)
        {
        }

        public override string DoSomething(string path)
        {
            var fooFightersLink = new FooFightersLink(_apiAccess, _dbRepository, null);
            var tolkienLink = new TolkienLink(_apiAccess, _dbRepository, fooFightersLink);
            var tarantinoLink = new TarantinoLink(_apiAccess, tolkienLink);

            return tarantinoLink.Handle(path);
        } 
    }

    public class TarantinoLink : BaseLink
    {
        private readonly IApiAccess _apiAccess;

        public TarantinoLink(IApiAccess apiAccess, BaseLink successor) 
            : base(successor)
        {
            _apiAccess = apiAccess;
        }

        protected override bool IsMatch(string path)
        {
            return path.StartsWith("/tarantino/movies");
        }

        protected override string SuccessHandler(string path)
        {
            _apiAccess.UpdateItem("Kill Bill");
            return "Kill Bill";
        }
    }

    public class TolkienLink : BaseLink
    {
        private readonly IApiAccess _apiAccess;
        private readonly IDbRepository _dbRepository;

        public TolkienLink(IApiAccess apiAccess, IDbRepository dbRepository, BaseLink successor) 
            : base(successor)
        {
            _apiAccess = apiAccess;
            _dbRepository = dbRepository;
        }

        protected override bool IsMatch(string path)
        {
            return path.StartsWith("/tolkien/books");
        }

        protected override string SuccessHandler(string path)
        {
            var item = _dbRepository.Get("LOTR");
            _apiAccess.UpdateItem(item);
            return item;
        }
    }

    public class FooFightersLink : BaseLink
    {
        private readonly IApiAccess _apiAccess;
        private readonly IDbRepository _dbRepository;

        public FooFightersLink(IApiAccess apiAccess, IDbRepository dbRepository, BaseLink successor) 
            : base(successor)
        {
            _apiAccess = apiAccess;
            _dbRepository = dbRepository;
        }

        protected override bool IsMatch(string path)
        {
            return path.StartsWith("/foofighters/songs");
        }

        protected override string SuccessHandler(string path)
        {
            var item = _dbRepository.Get("The pretender");
            _apiAccess.UpdateItem(item);
            _dbRepository.Add(item);
            return item;
        }
    }

    public abstract class BaseLink
    {
        public BaseLink(BaseLink successor)
        {
            Successor = successor;
        }

        public string Handle(string path)
        {
            if (IsMatch(path))
            {
                return SuccessHandler(path);
            }
            else
            {
                return Successor?.Handle(path) ?? string.Empty;
            }
        }

        protected abstract bool IsMatch(string path);
        protected abstract string SuccessHandler(string path);

        private BaseLink Successor { get; } 
    }
}
