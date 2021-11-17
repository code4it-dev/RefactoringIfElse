namespace RefactoringIfElse
{
    public abstract class BaseFoo
    {
        protected readonly IApiAccess _apiAccess;
        protected readonly IDbRepository _dbRepository;

        public BaseFoo(IDbRepository dbRepository, IApiAccess apiAccess)
        {
            _dbRepository = dbRepository;
            _apiAccess = apiAccess;
        }

        public abstract string DoSomething(string path);
    }
}