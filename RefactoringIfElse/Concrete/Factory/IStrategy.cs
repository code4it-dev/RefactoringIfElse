namespace RefactoringIfElse.Concrete.Factory
{
    public interface IStrategy
    {
        IProvdider Create(string path);

        bool TryCreate(string path, out IProvdider provdider);
    }
}