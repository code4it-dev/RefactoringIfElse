namespace RefactoringIfElse.Concrete
{
    public class FooWithIfElse : BaseFoo
    {
        private readonly IDbRepository _dbRepository;
        private readonly IApiAccess _apiAccess;

        public FooWithIfElse(IDbRepository dbRepository, IApiAccess apiAccess)
        {
            _dbRepository = dbRepository;
            _apiAccess = apiAccess;
        }

        public override string DoSomething(string path)
        {
            if (path.StartsWith("/tarantino/movies"))
            {
                _apiAccess.UpdateItem("Kill Bill");
                return "Kill Bill";
            }
            else if (path.StartsWith("/tolkien/books"))
            {
                var item = _dbRepository.Get("LOTR");
                _apiAccess.UpdateItem(item);
                return item;
            }
            else if (path.StartsWith("/foofighters/songs"))
            {
                var item = _dbRepository.Get("The pretender");
                _apiAccess.UpdateItem(item);
                _dbRepository.Add(item);
                return item;
            }
            else return string.Empty;
        }
    }
}