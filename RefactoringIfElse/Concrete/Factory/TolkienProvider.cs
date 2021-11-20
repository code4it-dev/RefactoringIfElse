using System;

namespace RefactoringIfElse.Concrete.Factory
{
    public class TolkienProviderFactory : IFactory
    {
        private readonly IApiAccess _apiAccess;
        private readonly IDbRepository _dbRepository;


        public  TolkienProviderFactory(IApiAccess apiAccess, IDbRepository dbRepository)
        {
            _apiAccess = apiAccess;
            _dbRepository = dbRepository;
        }

        public bool AppliesTo(string path) => path.StartsWith("/tolkien/books");

        public IProvdider Create()
        {
            return new  TolkienProvider(_apiAccess, _dbRepository);
        }
    }
    
    public class  TolkienProvider : IProvdider
    {
        private readonly IApiAccess _apiAccess;
        private readonly IDbRepository _dbRepository;

        public  TolkienProvider(IApiAccess apiAccess, IDbRepository dbRepository)
        {
            _apiAccess = apiAccess;
            _dbRepository = dbRepository;
        }

        public string Handle()
        {
            var item = _dbRepository.Get("LOTR");
            _apiAccess.UpdateItem(item);
            return item;
        }
    }
}