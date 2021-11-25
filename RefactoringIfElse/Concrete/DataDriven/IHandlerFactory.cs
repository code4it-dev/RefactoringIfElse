namespace RefactoringIfElse.Concrete.DataDriven
{
    public interface IHandlerFactory
    {
        IHandler CreateHandler(string path);
    }


}