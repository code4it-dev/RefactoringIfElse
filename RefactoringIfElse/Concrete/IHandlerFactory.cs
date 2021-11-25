namespace RefactoringIfElse.Concrete
{
    public interface IHandlerFactory
    {
        IHandler CreateHandler(string path);
    }


}