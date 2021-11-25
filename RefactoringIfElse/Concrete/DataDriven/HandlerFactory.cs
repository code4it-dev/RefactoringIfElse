using System.Linq;
using System.Collections.Generic;

namespace RefactoringIfElse.Concrete.DataDriven
{
    public class HandlerFactory : IHandlerFactory
    {

        private readonly IEnumerable<HandlerCreator> _factories;

        public HandlerFactory(IEnumerable<HandlerCreator> factories)
        {
            _factories = factories;
        }

        public IHandler CreateHandler(string path)
        {
            var creator = _factories.FirstOrDefault(kv => kv.Filter(path));
            if (creator is null)
                return null;
            return creator.Creator(path);
        }
    }
}