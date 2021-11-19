using RefactoringIfElse.Concrete;
using RefactoringIfElse.Concrete.Factory;

namespace RefactoringIfElseTests.Concrete
{
    public class FooWithFactoryTests : BaseFooTests
    {
        public FooWithFactoryTests()
        {
        }

        public override void Setup()
        {
            sut = new FooWithFactory(_mockDbRepo.Object, _mockApiAccess.Object, new Strategy(new IFactory[]
            {
                new TarantinoProviderFactory(_mockApiAccess.Object),
                new TolkienProviderFactory(_mockApiAccess.Object, _mockDbRepo.Object),
                new FoofightersProviderFactory(_mockApiAccess.Object, _mockDbRepo.Object)
                
            }));
        }
    }
}