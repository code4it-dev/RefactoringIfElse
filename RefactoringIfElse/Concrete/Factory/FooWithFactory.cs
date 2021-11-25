using System.Linq;

namespace RefactoringIfElse.Concrete.Factory
{
    public class FooWithFactory: BaseFoo
    {
        private IStrategy _strategy;
        
        public FooWithFactory(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public override string DoSomething(string path)
        {
            return _strategy.TryCreate(path, out var provdider) 
                ? provdider.Handle()
                : string.Empty;
        }
    }
}