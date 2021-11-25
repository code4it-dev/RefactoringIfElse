using System;

namespace RefactoringIfElse.Concrete.DataDriven
{
    public record HandlerCreator(Predicate<string> Filter, Func<string, IHandler> Creator);
}