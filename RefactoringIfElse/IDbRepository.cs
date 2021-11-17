namespace RefactoringIfElse
{
    public interface IDbRepository
    {
        void Add(string item);

        string Get(string item);
    }
}