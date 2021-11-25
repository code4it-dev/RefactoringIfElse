namespace RefactoringIfElse.Concrete
{
    public class FooDataDriven : BaseFoo
    {
        private readonly IHandlerFactory _factory;

        public FooDataDriven(IHandlerFactory factory)
        {
            _factory = factory;
        }

        public override string DoSomething(string path)
        {
            var handler = _factory.CreateHandler(path);
            return (handler != null) ?
                handler.Handle():
                string.Empty;
        }
    }
}