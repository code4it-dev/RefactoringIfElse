using RefactoringIfElse.Concrete.DataDriven;

namespace RefactoringIfElseTests.Concrete
{
    public class FooDataDrivenTests : BaseFooTests
    {
        public override void Setup()
        {
            var factory = new FooDataDrivenFileFactory(_mockDbRepo.Object, _mockApiAccess.Object);
            sut = factory.Create("resources/data.json");
        }
    }
}