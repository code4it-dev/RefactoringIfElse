using System.Linq;

namespace RefactoringIfElse.Concrete.Factory
{
    public class Strategy : IStrategy
    {
        private IFactory[] _factories;

        public Strategy(IFactory[] factories)
        {
            _factories = factories;
        }

        public IProvdider Create(string path)
        {
            return _factories.FirstOrDefault(x => x.AppliesTo(path))?.Create();
        }

        public bool TryCreate(string path, out IProvdider provdider)
        {
            provdider = _factories.FirstOrDefault(x => x.AppliesTo(path))?.Create();

            return provdider != null;
        }
    }
}