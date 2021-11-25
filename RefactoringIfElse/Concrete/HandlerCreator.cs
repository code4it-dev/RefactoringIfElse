using System;

namespace RefactoringIfElse.Concrete
{
    public record HandlerCreator(Predicate<string> Filter, Func<string, IHandler> Creator);
}