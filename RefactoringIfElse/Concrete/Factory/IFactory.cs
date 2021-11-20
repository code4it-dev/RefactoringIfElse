namespace RefactoringIfElse.Concrete.Factory
{
    public interface IFactory
    {
        bool AppliesTo(string path);

        IProvdider Create();

    }
}