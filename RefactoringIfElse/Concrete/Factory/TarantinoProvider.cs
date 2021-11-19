using System;

namespace RefactoringIfElse.Concrete.Factory
{
    public class TarantinoProviderFactory : IFactory
    {
        private readonly IApiAccess _apiAccess;

        public TarantinoProviderFactory(IApiAccess apiAccess)
        {
            _apiAccess = apiAccess;
        }

        public bool AppliesTo(string path) => path.StartsWith("/tarantino/movies");

        public IProvdider Create()
        {
            return new TarantinoProvider(_apiAccess);
        }
    }
    
    public class TarantinoProvider : IProvdider
    {
        private readonly IApiAccess _apiAccess;

        public TarantinoProvider(IApiAccess apiAccess)
        {
            _apiAccess = apiAccess;
        }

        public string Handle()
        {
            _apiAccess.UpdateItem("Kill Bill");
            return "Kill Bill";
        }
    }
}