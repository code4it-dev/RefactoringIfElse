using System;

namespace RefactoringIfElse.Concrete.Factory
{
    public class FoofightersProviderFactory : IFactory
    {
        private readonly IApiAccess _apiAccess;
        private readonly IDbRepository _dbRepository;


        public  FoofightersProviderFactory(IApiAccess apiAccess, IDbRepository dbRepository)
        {
            _apiAccess = apiAccess;
            _dbRepository = dbRepository;
        }

        public bool AppliesTo(string path) => path.StartsWith("/foofighters/songs");

        public IProvdider Create()
        {
            return new  FoofightersProvider(_apiAccess, _dbRepository);
        }
    }
    
    public class  FoofightersProvider : IProvdider
    {
        private readonly IApiAccess _apiAccess;
        private readonly IDbRepository _dbRepository;

        public  FoofightersProvider(IApiAccess apiAccess, IDbRepository dbRepository)
        {
            _apiAccess = apiAccess;
            _dbRepository = dbRepository;
        }

        public string Handle()
        {
            var item = _dbRepository.Get("The pretender");
            _apiAccess.UpdateItem(item);
            _dbRepository.Add(item);
            return item;
        }
    }
}