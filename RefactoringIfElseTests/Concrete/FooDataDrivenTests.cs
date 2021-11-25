using RefactoringIfElse.Concrete.DataDriven;

namespace RefactoringIfElseTests.Concrete
{
    public class FooDataDrivenTests : BaseFooTests
    {
        public override void Setup()
        {
            var factory = new HandlerFactory(new[]
            {
                new HandlerCreator(path => path.StartsWith("/tarantino/movies"), path => new MovieHandler(_mockApiAccess.Object, "Kill Bill")),
                new HandlerCreator(path => path.StartsWith("/foofighters/songs"), path => new SongHandler(_mockDbRepo.Object, _mockApiAccess.Object, "The pretender")),
                new HandlerCreator(path => path.StartsWith("/tolkien/books"), path => new BookHandler(_mockDbRepo.Object, _mockApiAccess.Object, "LOTR")),
            });
            sut = new FooDataDriven(factory);
        }
    }
}