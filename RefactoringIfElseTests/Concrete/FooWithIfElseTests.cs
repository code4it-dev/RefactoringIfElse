using RefactoringIfElse.Concrete;

namespace RefactoringIfElseTests.Concrete
{
    public class FooWithIfElseTests : BaseFooTests
    {
        public override void Setup()
        {
            sut = new FooWithIfElse(_mockDbRepo.Object, _mockApiAccess.Object);
        }
    }
}