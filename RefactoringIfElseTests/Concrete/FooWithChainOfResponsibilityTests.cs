using RefactoringIfElse.Concrete;

namespace RefactoringIfElseTests.Concrete
{
    public class FooWithChainOfResponsibilityTests : BaseFooTests
    {
        public FooWithChainOfResponsibilityTests()
        {
        }

        public override void Setup()
        {
            sut = new FooWithChainOfResponsibility(_mockDbRepo.Object, _mockApiAccess.Object);
        }
    }
}