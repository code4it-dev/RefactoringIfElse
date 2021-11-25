namespace RefactoringIfElse.Concrete.DataDriven
{
    public class SongHandler : IHandler
    {
        private readonly IDbRepository _dbRepository;
        private readonly IApiAccess _apiAccess;

        private readonly string _itemName;

        public SongHandler(IDbRepository dbRepository, IApiAccess apiAccess, string itemName)
        {
            if (string.IsNullOrWhiteSpace(itemName))
            {
                throw new System.ArgumentException($"'{nameof(itemName)}' cannot be null or whitespace.", nameof(itemName));
            }

            _dbRepository = dbRepository ?? throw new System.ArgumentNullException(nameof(dbRepository));
            _apiAccess = apiAccess ?? throw new System.ArgumentNullException(nameof(apiAccess));
            _itemName = itemName;
        }

        public string Handle()
        {
            var item = _dbRepository.Get(_itemName);
            _apiAccess.UpdateItem(item);
            _dbRepository.Add(item);
            return item;
        }
    }
}