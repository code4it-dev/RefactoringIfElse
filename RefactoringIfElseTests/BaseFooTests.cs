using Moq;
using NUnit.Framework;
using RefactoringIfElse;

namespace RefactoringIfElseTests
{
    public abstract class BaseFooTests
    {
        protected readonly Mock<IApiAccess> _mockApiAccess;
        protected readonly Mock<IDbRepository> _mockDbRepo;

        protected BaseFoo sut;

        public BaseFooTests()
        {
            _mockApiAccess = new Mock<IApiAccess>();
            _mockDbRepo = new Mock<IDbRepository>();
        }

        [Test]
        public void HandlesFooFightersSongs()
        {
            _mockDbRepo.Setup(_ => _.Get("The pretender")).Returns("drums");

            var result = sut.DoSomething("/foofighters/songs/times-like-these");

            Assert.AreEqual("drums", result);
            _mockDbRepo.Verify(_ => _.Add("drums"));
            _mockApiAccess.Verify(_ => _.UpdateItem("drums"));
        }

        [Test]
        public void HandlesTarantinoMovies()
        {
            var result = sut.DoSomething("/tarantino/movies/123");

            Assert.AreEqual("Kill Bill", result);
            _mockApiAccess.Verify(_ => _.UpdateItem("Kill Bill"));
        }

        [Test]
        public void HandlesTolkienBooks()
        {
            _mockDbRepo.Setup(_ => _.Get("LOTR")).Returns("Gandalf");

            var result = sut.DoSomething("/tolkien/books/lord-of-the-rings");

            Assert.AreEqual("Gandalf", result);
            _mockApiAccess.Verify(_ => _.UpdateItem("Gandalf"));
        }

        [Test]
        public void ReturnsEmptyString_When_PathIsNotRecognized()
        {
            var result = sut.DoSomething("ciao");

            Assert.AreEqual(string.Empty, result);
        }

        [SetUp]
        public abstract void Setup();
    }
}