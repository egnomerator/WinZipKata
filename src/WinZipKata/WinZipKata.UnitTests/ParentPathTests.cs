using NUnit.Framework;
using System.Windows.Forms;
using WinZipKata.TestUtilities;

namespace WinZipKata.UnitTests
{
    [TestFixture]
    public class ParentPathTests
    {
        [SetUp]
        public void Setup()
        {
            Support.Fixture.Setup();
        }

        [TearDown]
        public void Cleanup()
        {
            Support.Fixture.Cleanup();
        }

        [Test]
        public void ShouldUpdate()
        {
            // setup
            var startingPath = Support.Fixture.ParentPath;
            var newPath = $"{Support.Fixture.ParentPath}new";

            // run
            var SUT = new ParentPath(startingPath);
            SUT.Update(newPath);

            // assert
            Assert.That(SUT.Path, Is.EqualTo(newPath));

        }

        [Test]
        public void ShouldResetParentPathToEmptyString()
        {
            // setup
            var startingPath = Support.Fixture.ParentPath;

            // run
            var SUT = new ParentPath(startingPath);
            SUT.Reset();

            // assert
            Assert.That(SUT.Path, Is.Empty);

        }

        [Test]
        public void ShouldDetermineThatParentPathChanged()
        {
            // setup
            var startingPath = Support.Fixture.ParentPath;
            var newPath = $"{Support.Fixture.ParentPath}new";

            // run
            var SUT = new ParentPath(startingPath);
            var isChanged = SUT.IsChanged(newPath);

            // assert
            Assert.That(isChanged, Is.True);

        }

        [Test]
        public void ShouldDetermineThatParentPathDidNotChanged()
        {
            // setup
            var startingPath = Support.Fixture.ParentPath;

            // run
            var SUT = new ParentPath(startingPath);
            var isChanged = SUT.IsChanged(startingPath);

            // assert
            Assert.That(isChanged, Is.False);

        }
    }
}
