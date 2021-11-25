namespace RefactoringIfElse.Concrete
{
    public class MovieHandler : IHandler
    {
        private readonly IApiAccess _apiAccess;
        private readonly string _result;

        public MovieHandler(IApiAccess apiAccess,string result)
        {
            if (string.IsNullOrWhiteSpace(result))
            {
                throw new System.ArgumentException($"'{nameof(result)}' cannot be null or whitespace.", nameof(result));
            }

            _apiAccess = apiAccess ?? throw new System.ArgumentNullException(nameof(apiAccess));
            _result = result;
        }

        public string Handle()
        {
            _apiAccess.UpdateItem(_result);
            return _result;
        }
    }
}